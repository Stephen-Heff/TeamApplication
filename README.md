# Premier League TeamApplication 
This is a content management system for Premier Legaue Teams.
- Please note: Not all fuctionality works, however those listed below do.

## CRUD Functionality:
You should be able to add a new team, player and stat, update a coach when it changes and delete a player when they retire. 

## Database
This database has 3 tables (Player, Team and Stat). Each table has a primary key and the Stat table has two foreign keys. One for the player table (to retrieve a player's name) and two for the Team table (to retrieve the team a goal scored against).

## How to use the database
 1. Get a List of Players curl https://localhost:44388/api/PlayerData/ListPlayers
 2. Get a List of Teams curl https://localhost:44388/api/TeamData/ListTeams
 3. Get a List of Stats curl https://localhost:44388/api/StatData/ListStats
 4. View the list players https://localhost:44388/Player/List
 5. View the list of Teams https://localhost:44388/Team/List
 6. Viewthe list of Stats https://localhost:44388/Stat/List
 7. Add a new Team (new team info is in teams.json) curl -d @teams.json -H "Content-type:application/json" https://localhost:44388/api/TeamData/AddTeam
 8. Delete an Team curl -d "" https://localhost:44388/api/TeamData/DeleteTeam/{id}





