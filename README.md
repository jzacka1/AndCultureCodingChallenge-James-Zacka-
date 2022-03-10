AndCultureCodingChallenge

Steps to Run application:

1. Run Sql script, 'OpenBreweryDbScript.sql', to generate database with datatable with data.  You can find the connection string inside the appsettings.json file in the API project, and change the 'Data Source' name to any name you like instead of 'JAMESPC'.

2. Have the solution run both the API and React projects:
    a. Right-click on solution > Properties > Startup Project > Multiple startup projects
    b. Set the actions for both the API and React projects to Start.

How to run Specflow

1. Open the solution, and run it.
2. Then Open the same solution in another IDE.
3. Int second solution, go into the Specflow project.
4. Click on the green arrow to run the tests, or Debug.  It should show green check marks.
