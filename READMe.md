- This solution is for TUI Test
- The persistence middleware is LocalDb

- There is a test project, but only the MVC IFlightService
- To execute, start the webApi project then the MVC's
- Execute the init.sql file to insert some value in Db
 
 - In architecture terms, we got :
 	- DDD : Domain driven design
	- Code first and fluent api for EF core Mapping ( fluent api used in order to be decoupled from EF and keeping domain objects free)
	- A Web api to do the business jobs, which call services and services call repositories
	- Repository Pattern
	- MVC core for the client party
	- The purpose of this, it if someone wants to create a JS client or something else or simply reuse the business, the rest api can be reused
	- Basic .Net IOC used to inject all what every layer needs

- For the test project:
 	- Only the business dll is tested because the logic is there
	- I tested too the mvc client
