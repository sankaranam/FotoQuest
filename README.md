# FotoQuest Go API

This is a sample application designed to submit and retrieve image and metadata for fotoquest-go application
This project is implemented in docker and using microservice for sepcific jobs viz, command API, Query API, Database.

### swagger hosting ##
https://sankaranam.github.io/FotoQuest/

### Following is the general description of the solution

- ***FotoQuestGoCommandApi*** project has the command APIs, which takes the user submission data which contains the coordinates, list of images and list of question answers. 
- ***FotoQuestGoQueryApi*** project has the query APIs to query the images submitted in any image version (thumbnail,small,large,custom)
- ***FotoQuestGoRepository*** project has the repository class to access the database. This project uses entity framework to access the database.
- ***FotoQuestGo.DataSubmissionService*** project many coordicate the work and handles any logic peice. 

### Yml File description ###
- Has 3 services hosted. FotoQuestGoCommandApi, FotoQuestGoQueryApi are web APIs and db is mssql image hosted as container
- mssql image used is "mcr.microsoft.com/mssql/server:2017-latest"
- To save the images in file system values are created. The command API saves images folder created in ymal file directory path.
- to host all the services in a network a network bridge is created. So that accessing sql becomes easy.
