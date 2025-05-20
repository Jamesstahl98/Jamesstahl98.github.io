using MyPortfolio.Models;

namespace MyPortfolio.DataPopulation;

public class ProjectsAndSkills
{
    private static List<Project> _projects = new()
    {
        new Project
        {
            Title = "Frölunda Arcade",
            Description = "This is a project is a web shop for a game store made in Blazor. It has functionality for storing and updating products, reviews, forums posts and comments and events using Firebase. " +
            "The backend uses MVC controllers for handling API calls from the frontend and the purchases are handled using Stripe. Orders are stored in Azure Blob Storage using Azure Functions.",
            ImageUrl = "images/FrolundaArcade.jpg",
            ProjectUrl = "https://arcade-frolunda.azurewebsites.net/"
        },
        new Project
        {
            Title = "Web Shop Template",
            Description = "This project is a reusable web shop template using Blazor for the frontend and SQL as a database for the products and the roles. The project uses custom built token-based authorization.",
            ImageUrl = "images/WebShop.jpg",
            ProjectUrl = "https://github.com/Jamesstahl98/WebLab2"
        },
        new Project
        {
            Title = "Hellsvik",
            Description = "A puzzle game made in Unity where you use a magical lantern to peer into the past.",
            ImageUrl = "images/Hellsvik.jpg",
            ProjectUrl = "https://that-martin-guy.itch.io/hellsvik"
        },
        new Project
        {
            Title = "Samurai Game",
            Description = "A game made in Unity created to study the effects of game feel/juice (non-essential visual, audio and haptic feedback) on player experience for my bachelors thesis.",
            ImageUrl = "images/SamuraiGame.jpg",
            ProjectUrl = "https://jamooz.itch.io/samurai-game"
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
                Projects.Find(p => p.Title == "Frölunda Arcade"),
                Projects.Find(p => p.Title == "Web Shop Template"),
                Projects.Find(p => p.Title == "Hellsvik"),
                Projects.Find(p => p.Title == "Samurai Game")
            }
        },
        new Skill
        {
            Name = "JavaScript",
            Proficiency = 60,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade"),
                Projects.Find(p => p.Title == "Web Shop Template")
            }
        },
        new Skill
        {
            Name = "HTML",
            Proficiency = 70,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade"),
                Projects.Find(p => p.Title == "Web Shop Template"),
            }
        },
        new Skill
        {
            Name = "CSS",
            Proficiency = 70,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade"),
                Projects.Find(p => p.Title == "Web Shop Template"),
            }
        },
        new Skill
        {
            Name = "Unity",
            Proficiency = 75,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Hellsvik"),
                Projects.Find(p => p.Title == "Samurai Game")
            }
        },
    };

    public static List<Project> Projects => _projects;
    public static List<Skill> Skills => _skills;
}
