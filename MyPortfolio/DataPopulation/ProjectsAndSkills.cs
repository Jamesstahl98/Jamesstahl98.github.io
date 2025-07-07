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
            Title = "Simulation Game",
            Description = "This is a project where you can add new creatures and plants, and try to create a sustainable eco-system. The project was made in Unity",
            ImageUrl = "images/SimulationGame.jpg",
            ProjectUrl = "https://play.unity.com/en/games/b4285c32-3695-40fd-8f64-f09e64faf05d/webgl-builds"
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
            Title = "Pokemon Card Store",
            Description = "This project is a web store for buying Pokemon cards. It is built using HTML, CSS and Javascript and uses the Pokemon TCG api to populate the products.",
            ImageUrl = "images/PokemonCardStore.jpg",
            ProjectUrl = "https://jamesstahl98.github.io/WebDevelopmentLab1/html/index.html"
        },
        new Project
        {
            Title = "Dungeon Crawler",
            Description = "This project is a dungeon crawler that runs in the console using C#. MongoDB is used to save and load previous game files.",
            ImageUrl = "images/DungeonCrawler.jpg",
            ProjectUrl = "https://github.com/Jamesstahl98/DatabasesLab3MongoDB/"
        }
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
                Projects.Find(p => p.Title == "Samurai Game"),
                Projects.Find(p => p.Title == "Dungeon Crawler"),
                Projects.Find(p => p.Title == "Simulation Game")
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
            Name = "Blazor",
            Proficiency = 80,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade"),
                Projects.Find(p => p.Title == "Web Shop Template")
            }
        },
        new Skill
        {
            Name = "Unity",
            Proficiency = 75,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Hellsvik"),
                Projects.Find(p => p.Title == "Samurai Game"),
                Projects.Find(p => p.Title == "Simulation Game")
            }
        },
        new Skill
        {
            Name = "SQL",
            Proficiency = 70,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Web Shop Template")
            }
        },
        new Skill
        {
            Name = "Firebase",
            Proficiency = 50,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")
            }
        },
        new Skill
        {
            Name = "MongoDB",
            Proficiency = 75,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Dungeon Crawler"),
            }
        },
    };

    public static List<Project> Projects => _projects;
    public static List<Skill> Skills => _skills;
}
