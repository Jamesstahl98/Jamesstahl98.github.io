using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace MyPortfolio.Utilities;

/// <summary>
/// A minimal markdown-to-HTML converter for the hardcoded content in
/// <see cref="DataPopulation.ProjectsAndSkills"/>. Supports headings, bullet and
/// ordered lists, paragraphs, bold, italic, inline code and links.
/// The source is HTML-encoded before any tags are injected, so raw HTML in the
/// markdown is rendered as text rather than passed through.
/// </summary>
public static class MiniMarkdown
{
    private static readonly Regex HeadingRegex = new(@"^(#{1,6})\s+(.*)$", RegexOptions.Compiled);
    private static readonly Regex BulletRegex = new(@"^[-*]\s+(.*)$", RegexOptions.Compiled);
    private static readonly Regex OrderedRegex = new(@"^\d+\.\s+(.*)$", RegexOptions.Compiled);

    private static readonly Regex CodeRegex = new(@"`([^`]+)`", RegexOptions.Compiled);
    private static readonly Regex LinkRegex = new(@"\[([^\]]+)\]\(([^)\s]+)\)", RegexOptions.Compiled);
    private static readonly Regex BoldRegex = new(@"\*\*(.+?)\*\*", RegexOptions.Compiled);
    private static readonly Regex ItalicRegex = new(@"(?<!\*)\*(?!\*)([^*]+?)\*(?!\*)", RegexOptions.Compiled);
    private static readonly Regex UnderscoreItalicRegex = new(@"(?<!\w)_(?!_)([^_]+?)_(?!\w)", RegexOptions.Compiled);

    public static MarkupString ToHtml(string? markdown)
    {
        if (string.IsNullOrWhiteSpace(markdown))
        {
            return new MarkupString(string.Empty);
        }

        var normalized = markdown.Replace("\r\n", "\n").Replace('\r', '\n');
        var lines = WebUtility.HtmlEncode(normalized).Split('\n');

        var html = new StringBuilder();
        var paragraph = new List<string>();
        var i = 0;

        while (i < lines.Length)
        {
            var line = lines[i].Trim();

            if (line.Length == 0)
            {
                FlushParagraph(html, paragraph);
                i++;
                continue;
            }

            var heading = HeadingRegex.Match(line);
            if (heading.Success)
            {
                FlushParagraph(html, paragraph);
                var level = heading.Groups[1].Value.Length;
                html.Append("<h").Append(level).Append('>')
                    .Append(RenderInline(heading.Groups[2].Value))
                    .Append("</h").Append(level).Append('>');
                i++;
                continue;
            }

            var ordered = OrderedRegex.IsMatch(line);
            if (ordered || BulletRegex.IsMatch(line))
            {
                FlushParagraph(html, paragraph);

                var itemRegex = ordered ? OrderedRegex : BulletRegex;
                var tag = ordered ? "ol" : "ul";

                html.Append('<').Append(tag).Append('>');
                while (i < lines.Length)
                {
                    var item = itemRegex.Match(lines[i].Trim());
                    if (!item.Success)
                    {
                        break;
                    }
                    i++;

                    // Fold wrapped continuation lines back into the item they belong to.
                    var content = new StringBuilder(item.Groups[1].Value);
                    while (i < lines.Length && IsContinuationLine(lines[i].Trim()))
                    {
                        content.Append(' ').Append(lines[i].Trim());
                        i++;
                    }

                    html.Append("<li>").Append(RenderInline(content.ToString())).Append("</li>");
                }
                html.Append("</").Append(tag).Append('>');
                continue;
            }

            // Two trailing spaces is markdown's hard line break; a plain newline is a
            // soft break that only separates words, so source text can wrap freely.
            paragraph.Add(lines[i].EndsWith("  ") ? line + "<br />" : line);
            i++;
        }

        FlushParagraph(html, paragraph);

        return new MarkupString(html.ToString());
    }

    private static bool IsContinuationLine(string line) =>
        line.Length > 0 &&
        !BulletRegex.IsMatch(line) &&
        !OrderedRegex.IsMatch(line) &&
        !HeadingRegex.IsMatch(line);

    private static void FlushParagraph(StringBuilder html, List<string> paragraph)
    {
        if (paragraph.Count == 0)
        {
            return;
        }

        var text = string.Join(' ', paragraph);
        if (text.EndsWith("<br />"))
        {
            text = text[..^"<br />".Length];
        }

        html.Append("<p>").Append(RenderInline(text)).Append("</p>");

        paragraph.Clear();
    }

    /// <summary>
    /// Applies the inline rules, splitting around code spans so their contents are
    /// left untouched by the emphasis and link rules.
    /// </summary>
    private static string RenderInline(string text)
    {
        var result = new StringBuilder();
        var lastIndex = 0;

        foreach (Match code in CodeRegex.Matches(text))
        {
            result.Append(RenderEmphasisAndLinks(text[lastIndex..code.Index]))
                  .Append("<code>").Append(code.Groups[1].Value).Append("</code>");

            lastIndex = code.Index + code.Length;
        }

        return result.Append(RenderEmphasisAndLinks(text[lastIndex..])).ToString();
    }

    private static string RenderEmphasisAndLinks(string text)
    {
        text = LinkRegex.Replace(text, match =>
        {
            var url = match.Groups[2].Value;
            return IsSafeUrl(url)
                ? $"<a href=\"{url}\" target=\"_blank\" rel=\"noopener noreferrer\">{match.Groups[1].Value}</a>"
                : match.Value;
        });

        text = BoldRegex.Replace(text, "<strong>$1</strong>");
        text = ItalicRegex.Replace(text, "<em>$1</em>");
        text = UnderscoreItalicRegex.Replace(text, "<em>$1</em>");

        return text;
    }

    private static bool IsSafeUrl(string url) =>
        url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
        url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ||
        url.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase) ||
        url.StartsWith('/') ||
        url.StartsWith('#');
}
