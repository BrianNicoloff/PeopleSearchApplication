## People Search Application

### Prerequisites:

- Node 6.11.1
- NPM 5.3.0
- Angular CLI
- VS.NET Community 2015 Update 3
- Typescript for VS 2.2.1.0
- SQL Server or SQL Server Express

### Seed Data

- Run the DatabaseSeeder project in the solution

### Run Javascript Unit Tests

- cd webroot
- npm run test 
  or
  npm run test:watch

### Run NUnit Tests

- Run the NUnit Tests with VS.NET and/or Resharper pluggin

### Simulate Slow Connection

- Open Web.Config in the PeopleSearchApplication project and uncomment the <add key="SimulateSlowNetwork" value="true"/> line

