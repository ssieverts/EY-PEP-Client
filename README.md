# EY-PEP-Client
**Project Instructions**
1. Load the solution into VS 2017 or 2019
2. The Application is a ASP.Net Core 2.2 Web application that useds the Angular 7 template.
3. During the load the Nuget packages should resolve and the NPM packages should resolve on the first project build.
4. No additional packages were added to support the application.
5. Changes to the Angular piece were handled with the angular cli.

**Assumptions**:
1. I had to modify the schema a bit to support FKs to access Doctor collections like languages, ratings, and specialties(F5).

**Comments**:
1. For the sake of time I didn't implement a star rating system. Initially I inplemented a 1-100% rating system but didn't have time to go back and change it.
2. I made use of the dotnet cli migrations to build the database and keep track of changes.
