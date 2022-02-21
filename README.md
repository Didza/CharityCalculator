# CharityCalculator

This is the service and UI repo for the Charity Calculator implementation.

### Build

#### API
1. Firstly set API as startup project in Visual Studio.
#### Infracture
1. In Package Manager run migration for `CharityCalculatorDbContext` in `Calculator.Persistence` project to seed the application db. <br />
    `update-database -context CharityCalculatorDbContext` this will create a the database in sql server.
2. In Package Manager run migration for `CharityCalculatorIdentityDbContext` in `Calculator.Identity` project to seed application identity db. <br />
    `update-database -context CharityCalculatorIdentityDbContext` this will create a the database in sql server.
#### Site Administrator - To Switch databases
1. In order to switch data stores to a Sqlite Database, set the `useInMemoryDb` to `true` in the `CharityCalculator.Api` project's `appsettings.json` <br />
    environment file.
2. In Package Manager run migration for `CharityCalculatorSqliteDbContext` in `Calculator.Persistence` project in order to create the sqlite db  <br />
    and seed database


### Running
Set `Calculator.API` and `Calculator.UI` as startup projects and run via IIS in Visual Studio.

### Authentication
Have seeded accounts for each role but registration can also be done via the ui. <br />

`Donor` username: `donor@localhost.com` password: `P@ssword1`  <br />
`Site Admin` username: `admin@localhost.com` password: `P@ssword1`  <br />
`Event Promoter` username: `promoter@localhost.com` password: `P@ssword1`  <br />