namespace MyPortfolio.Models;

public class Project
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public string? ProjectUrl { get; set; }

    /// <summary>Long-form markdown shown only on the project's detail page.</summary>
    public string? DetailedDescription { get; set; }

    public List<string> GalleryImages { get; set; } = new();

    /// <summary>A project opts into a detail page by supplying extended content.</summary>
    public bool HasDetailPage =>
        !string.IsNullOrWhiteSpace(DetailedDescription) || GalleryImages.Count > 0;

    /// <summary>The title as it appears in a URL, e.g. "projects/Fr%C3%B6lunda%20Arcade".</summary>
    public string Slug => Uri.EscapeDataString(Title);

    /// <summary>"https://arcade-frolunda.azurewebsites.net/" becomes "arcade-frolunda.azurewebsites.net".</summary>
    public string? ProjectUrlHost =>
        Uri.TryCreate(ProjectUrl, UriKind.Absolute, out var uri) ? uri.Host : ProjectUrl;
}
