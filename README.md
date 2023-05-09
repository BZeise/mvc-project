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
    - `dotnet ef migrations add BookInitialMigration`
        - ran this to add a Migration which added my Book class to the database as a table.
    - `dotnet ef database update`
        - Ran this to do the update to actually update the database to run any migrations that haven't run yet
    - STEPS TO ADD A NEW TABLE
        - First, create a model with properties
        - Next, in ApplicationDbContext, you have to create a `DbSet` for that
        - Then in the console, add the migration
        - Also in the console, run the database update command