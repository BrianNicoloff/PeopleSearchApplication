## People Search Application

### Prerequisites:

- Node 6.11.1
- NPM 5.3.0
- Angular CLI
- VS.NET Community 2015 Update 3
- Typescript for VS 2.2.1.0
- SQL Server or SQL Server Express

### Installation and How To Run 

- git clone https://github.com/BrianNicoloff/PeopleSearchApplication.git
- cd PeopleSearchApplication\websrc
- npm install
- Open PeopleSearchApplication\PeopleSearchApplication.sln
- Rebuild Solution
- Run/Debug the DatabaseSeeder.csproj in VS.NET
- F5 (Run/Debug) the PeopleSearchApplication.csproj

### Seed Data

- Run the DatabaseSeeder project in the solution

### Run Javascript Unit Tests

- cd PeopleSearchApplication/webroot
- npm run test 
  or
  npm run test:watch

### Run NUnit Tests

There is a VS.NET Tests folder with a Database Integration Tests project and a Unit Test project
- Run the NUnit Tests with VS.NET and/or Resharper Test Runner pluggin

### Simulate Slow Connection

- Open Web.Config in the PeopleSearchApplication project and uncomment the <add key="SimulateSlowNetwork" value="true"/> line

