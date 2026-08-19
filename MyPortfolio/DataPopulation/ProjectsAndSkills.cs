using MyPortfolio.Models;

namespace MyPortfolio.DataPopulation;

public class ProjectsAndSkills
{
    private static List<Project> _projects = new()
    {
        new Project
        {
            Title = "Orbit",
            Description = """
            Orbit is a multi-tenant physical access-control platform. Organizations model their real
            estate as a tree of nodes (property → building → floor → office → space), attach fixtures
            (smart locks) to those nodes, and control who can unlock what through access grants,
            bookings, QR codes and time-limited guest tickets.

            Admin authority is delegated down the tree, so a building manager can run their building
            without ever seeing the rest of the estate.
            """,
            ImageUrl = "images/Orbit/OrbitMyDoors.jpg",
            DetailedDescription = """
            #### The node tree

            An organization's real estate is modelled as a single tree. A *property* contains
            *buildings*, a building contains *floors*, a floor contains *offices* and *spaces*.
            Every node can carry fixtures (the smart locks themselves) and every node can carry
            access rules. Because the structure is recursive rather than a fixed schema,
            a tenant with an unusual layout (a campus, a single floor sublet to four companies) is
            modelled with the same primitives as everyone else.

            #### Delegated authority

            Admin rights are granted *at a node* and inherit downwards. A building manager granted
            authority over `Building A` can create offices, invite members and issue guest tickets
            inside that building, and cannot see the rest of the estate.
            This keeps a single deployment usable by a property owner and their tenants at the same
            time, without separate installations per company.

            #### Getting through a door

            A member's right to open a fixture can come from several directions, and the API
            resolves all of them at unlock time:

            - **Implicit Access grants**: standing permission on a node, inherited by everything beneath it
            - **Explicit Access grants**: permission on a node, granted to a specific member or group of members
            - **Bookings**: a reservation on a space that implies access for its duration
            - **QR codes**: scanned at the door, resolved back to the member and their grants
            - **Guest tickets**: time-limited links issued to someone with no account at all

            #### The stack

            - **API**: ASP.NET Core over PostgreSQL, with identity delegated to Keycloak so
              organizations can bring their own SSO
            - **Front end**: a Next.js 16 admin console for operators, and a member PWA that works
              as an installable app on a phone
            - **Integration layer**: a message-driven service that speaks to real LTE and WiFi lock
              hardware over CoAP or MQTT, bridged through RabbitMQ. Locks go offline, wake on their
              own schedule and acknowledge late, so commands are queued and reconciled rather than
              assumed to have landed.
            """,
            GalleryImages = new List<string>
            {
                "images/Orbit/OrbitOverview.jpg",
                "images/Orbit/OrbitOrgView.jpg",
                "images/Orbit/OrbitNodes.jpg",
                "images/Orbit/OrbitDoors.jpg",
                "images/Orbit/OrbitMyDoors.jpg",
                "images/Orbit/OrbitBooking.jpg"
            }
        },
        new Project
        {
            Title = "Game Recommender",
            Description = """
            This project is a website that allows the user to rate different games and get recommendations based on their ratings. 
            The project uses a **filtering algorithm** to recommend games that are similar to the ones the user has rated highly.
            The website also has a feature where the user swipes left or right on games to indicate whether they like or dislike them.
            
            The frontend project is built using **Next.js** and **TypeScript** and uses **Cypress** for end-to-end testing.
            The Backend project is built using **C#** and **Entity Framework**. The backend interacts with multiple external APIs to get game data which is then stored in a **SQL database**.
            The project also uses **xUnit** for unit testing the backend.

            The backend project is deployed on the free tier of **Render**, so the first time the user visits the website, it may take a few seconds for the backend to wake up and respond to requests.
            """,
            ImageUrl = "images/GameRecommender.jpg",
            ProjectUrl = "https://game-recommender-blue.vercel.app/"
        },
        new Project
        {
            Title = "Frölunda Arcade",
            Description = """
            This project is a web shop for a game store made in **Blazor**. It has functionality for
            storing and updating products, reviews, forum posts and comments and events using
            *Firebase*.

            The backend uses MVC controllers for handling API calls from the frontend and the
            purchases are handled using *Stripe*. Orders are stored in Azure Blob Storage using
            Azure Functions.
            """,
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
            Proficiency = ProficiencyLevel.Proficient,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!,
                Projects.Find(p => p.Title == "Web Shop Template")!,
                Projects.Find(p => p.Title == "Hellsvik")!,
                Projects.Find(p => p.Title == "Samurai Game")!,
                Projects.Find(p => p.Title == "Dungeon Crawler")!,
                Projects.Find(p => p.Title == "Simulation Game")!,
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!
            }
        },
        new Skill
        {
            Name = "SQL",
            Proficiency = ProficiencyLevel.Proficient,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Web Shop Template")!,
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!
            }
        },
        new Skill
        {
            Name = "xUnit",
            Proficiency = ProficiencyLevel.Proficient,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!
            }
        },
        new Skill
        {
            Name = "Unity",
            Proficiency = ProficiencyLevel.Proficient,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Hellsvik")!,
                Projects.Find(p => p.Title == "Samurai Game")!,
                Projects.Find(p => p.Title == "Simulation Game")!
            }
        },
        new Skill
        {
            Name = "Next.js",
            Proficiency = ProficiencyLevel.Experienced,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!
            }
        },
        new Skill
        {
            Name = "TypeScript",
            Proficiency = ProficiencyLevel.Experienced,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!
            }
        },
        new Skill
        {
            Name = "HTML",
            Proficiency = ProficiencyLevel.Experienced,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!,
                Projects.Find(p => p.Title == "Web Shop Template")!,
                Projects.Find(p => p.Title == "Pokemon Card Store")!
            }
        },
        new Skill
        {
            Name = "CSS",
            Proficiency = ProficiencyLevel.Experienced,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!,
                Projects.Find(p => p.Title == "Web Shop Template")!,
                Projects.Find(p => p.Title == "Orbit")!,
                Projects.Find(p => p.Title == "Game Recommender")!,
                Projects.Find(p => p.Title == "Pokemon Card Store")!
            }
        },
        new Skill
        {
            Name = "Blazor",
            Proficiency = ProficiencyLevel.Experienced,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!,
                Projects.Find(p => p.Title == "Web Shop Template")!
            }
        },
        new Skill
        {
            Name = "JavaScript",
            Proficiency = ProficiencyLevel.Intermediate,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!,
                Projects.Find(p => p.Title == "Web Shop Template")!,
                Projects.Find(p => p.Title == "Pokemon Card Store")!
            }
        },
        new Skill
        {
            Name = "Firebase",
            Proficiency = ProficiencyLevel.Intermediate,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Frölunda Arcade")!
            }
        },
        new Skill
        {
            Name = "MongoDB",
            Proficiency = ProficiencyLevel.Intermediate,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Dungeon Crawler")!
            }
        },
        new Skill
        {
            Name = "Golang",
            Proficiency = ProficiencyLevel.Intermediate,
            RelatedProjects = new List<Project>
            {
                Projects.Find(p => p.Title == "Orbit")!
            }
        }
    };

    public static List<Project> Projects => _projects;
    public static List<Skill> Skills => _skills;

    public static Project? FindByTitle(string? title) =>
        _projects.FirstOrDefault(p => string.Equals(p.Title, title, StringComparison.OrdinalIgnoreCase));

    public static List<Skill> SkillsFor(Project? project) =>
        project == null
            ? new List<Skill>()
            : _skills.Where(s => s.RelatedProjects.Contains(project)).ToList();
}
