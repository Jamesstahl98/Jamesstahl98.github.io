using MyPortfolio.Models;

namespace MyPortfolio.DataPopulation;

public class ProjectsAndSkills
{
    private static List<Project> _projects = new()
    {
        new Project
        {
            Title = "Project 1",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
        new Project
        {
            Title = "Project 2",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
        new Project
        {
            Title = "Project 3",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
        new Project
        {
            Title = "Project 4",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
        new Project
        {
            Title = "Project 5",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
        new Project
        {
            Title = "Project 6",
            Description = "This is a description of Project 1. It is a very interesting project that does many things.",
            ImageUrl = "images/PlaceholderLandscape.jpg",
            ProjectUrl = "http://www.google.com"
        },
    };

    private static List<Skill> _skills = new()
    {
        new Skill
        {
            Name = "C#",
            Proficiency = 80,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Project 1"),
                Projects.Find(p => p.Title == "Project 2"),
                Projects.Find(p => p.Title == "Project 3"),
                Projects.Find(p => p.Title == "Project 4"),
                Projects.Find(p => p.Title == "Project 5"),
                Projects.Find(p => p.Title == "Project 6")
            }
        },
        new Skill
        {
            Name = "JavaScript",
            Proficiency = 60,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Project 1"),
                Projects.Find(p => p.Title == "Project 2")
            }
        },
        new Skill
        {
            Name = "HTML",
            Proficiency = 70,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Project 1"),
                Projects.Find(p => p.Title == "Project 2"),
                Projects.Find(p => p.Title == "Project 3")
            }
        },
        new Skill
        {
            Name = "CSS",
            Proficiency = 70,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Project 1"),
                Projects.Find(p => p.Title == "Project 2"),
                Projects.Find(p => p.Title == "Project 3")
            }
        },
        new Skill
        {
            Name = "Unity",
            Proficiency = 75,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Project 4"),
                Projects.Find(p => p.Title == "Project 5"),
                Projects.Find(p => p.Title == "Project 6")
            }
        },
    };

    public static List<Project> Projects => _projects;
    public static List<Skill> Skills => _skills;
}
