# Priemer League TeamApplication 
Team Application (CRUD)
This is a content management system for Priemier Legaue Teams.
 - Please note: Not all fuctionality works, however those listed below do.

## CRUD Functionality:
You should be able to add a new team, player and stat, update a coach when it changes and delete a player when they retire. 

## Database
This database has 3 tables(Player, Team and Stat). Each table has a primary key and the Stat table has two foreign keys. One to the player table (to retireve the player name) and two to the Team table (to retieve the team a goal is scored against).

## How to use the database
 1. Get a List of Players curl https://localhost:44388/api/PlayerData/ListPlayers
 2. Get a List of Teams curl https://localhost:44388/api/TeamData/ListTeams
 3. Get a List of Stats curl https://localhost:44388/api/StatData/ListStats
 4. Add a new Team (new team info is in teams.json) curl -H "Content-Type:application/json" -d @teams.json https://localhost:44388/api/TeamData/AddTeam
 5. Delete an Team curl -d "" https://localhost:44388/api/TeamData/DeleteTeam/{id}





