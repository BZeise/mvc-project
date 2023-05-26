# mvc-project

## Initial Notes

-  I started with `tdd-project` but that was meant to be a React app
-  This will instead be based on `dotnet new mvc`

-  I'm honestly not sure if I can use vitest or not.  Not sure about how compatability works with testing frameworks.  Let's just try it out.  lol
-  goddammit i hate testing framework bullshit.  i can't get any of these to interact with each other.

- Following this guide:
    - https://www.youtube.com/watch?v=AopeJjkcRvU

### Running, testing, etc notes
-  `dotnet watch` will run the app in hot reload mode
-  how about a quick green box, eh?  lol.


### Daily Notes

- 5/8/23
    - Went through routing section.  Basics there.
    - New thing:  When creating a class, you can type `prop` then hit tab to get the basics of a property out
    - Added Book.cs class.  TODOs remain there, including defaults and validation
    - Installing EntityFramework.Core class via NuGet Package Manager
    - Pausing around here https://youtu.be/AopeJjkcRvU?t=4663

- 5/9/23
    - Installed SSMS and Sql Server '22.  Annoying
    - Set up local testing db, name is `SUSAN\BENSQLSERVER`
    - Set up connectionString in appsettings.json.  TODO:  Check the name of the database I passed there
    - `ctor` is another shortcut to stub out a constructor
    - `public ApplicationDbContext(DbContextOptions<DbContext> options) : base(options)`
        - When declaring a class like so, using : , we are saying to pass the arguments up to the base class we are extending from
    - Using EntityFrameworkCore, we're using the VS Code CLI to simulate interfacing with the NuGet Package Manager Console that VS would use
    - Needed help from here to figure out how to do it in VS Code:
        - https://stackoverflow.com/questions/41536603/visual-studio-code-entity-framework-core-add-migration-not-recognized
    - `dotnet ef migrations add BookInitialMigration`
        - ran this to add a Migration which added my Book class to the database as a table.
    - `dotnet ef database update`
        - Ran this to do the update to actually update the database to run any migrations that haven't run yet
    - STEPS TO ADD A NEW TABLE
        - First, create a model with properties
        - Next, in ApplicationDbContext, you have to create a `DbSet` for that
        - Then in the console, add the migration
        - Also in the console, run the database update command

- 5/11/23
    - Gonna set up CRUD now that I have a database running
    - So much annoying stuff.  Man is making me make a new controller first.
    - What is `OnModelCreating` about?  Hmm.

- 5/12/23
    - Short day yesterday.  Continuing on.
    - we added this `
    - "whenever anything has to be updated with database, we have to add a migration.  always always always remember that"
        - So annoying.  need to understand these migrations better.
        - ran command `dotnet ef migrations add SeedBookTable`
            - How does it know what migrations I've added?  Just, everything in `ApplicationDbContext?`
            - also ran the `dotnet ef database update`
    - Had to change my use of DataAnnotations.  
        - This worked:  
            - `public string Author { get; set; } = "Unknown";`
        - This did not work: 
            - `[DefaultValue("Unknown")]`
            - `public string Author { get; set; }`
        - Error came up when I tried to add a migration for it

- 5/14/23
    - Had a routing error
        - `[Route("[controller]")]` before declaring my controller
        - I'm not sure how that's supposed to be used, but it ended up removing the necessary controller action in my URL calls
        - so it couldn't find /Index or /Error
    - icons were dumb

- 5/16/23
    - icons working through a different CDN than bootstrap provided
    - also interesting logos from different companies
        - such as: `<img height="32" width="32" src="https://unpkg.com/simple-icons@v8/icons/dotnet.svg" />`
    - worked out some initial CRUD
    - Important concept:
        - Implemented `_ValidationScriptsPartial.cshtml`
        - which essentially added in client-side (responsive?) validation
        - see this commit:
            - https://github.com/BZeise/mvc-project/commit/276bc4d9745b87cab4bb962b3ff4864a6453ebc1
        - TODO:  Make a series of notes in the notes doc about validation styles
            - All the different types of validation and when we can implement them and why
            - Client-side, server-side, using data annotations and .NET functions, etc

- 5/19/23
    - Back to CRUD.  Currently have CR.  Gonna work on U and D.
    - added buttons first.  TODO:  Review table layout and think about what components/libraries I want to involve and work with long-term
    - added Edit and Delete functions, still need a view
    - Note about things:
        - `asp-route-bookId="@obj.BookId"`
        -   I added this above line to provide a parameter to the function being called by `asp-action`
        - Notice it needs to match the name of the parameter in the controller method

- 5/26/23
    - on the CRUD, put in some alternate db Find options