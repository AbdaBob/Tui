- This solution is for TUI Test
- The architecture of this sln solution 
	- A MVC client which has a IFlightService calling a web api
    - A Web APi which returns data or persist it in DB
	
 - There is a test project, but only the MVC IFlightService
 - The persistence middleware is LocalDb
 - To execute, start the webApi project then the MVC's
 - Execute the init.sql file to insert some value in Db