namespace MyPortfolio.Models;

public class Skill
{
    public required string Name { get; set; }
    public ProficiencyLevel Proficiency { get; set; }
    public List<Project> RelatedProjects { get; set; } = new List<Project>();
}
