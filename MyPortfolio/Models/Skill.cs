namespace MyPortfolio.Models;

public class Skill
{
    public required string Name { get; set; }
    public required ProficiencyLevel Proficiency { get; set; }
    public required List<Project> RelatedProjects { get; set; } = new List<Project>();
}
