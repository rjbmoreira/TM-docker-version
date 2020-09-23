# TM [dockerized version]
Vestas assignment - Time Management

Based on http://github.com/rjbmoreira/TM with connection IP adjustments.
After running docker-compose (with the supplied yml file) to launch it, find:
* UI accessible on http://localhost:8080
* .NET Core app accessible on http://localhost:5000
* PostgreSQL accessible on http://localhost:15000 [check docker-compose.yml for user/pass]
* PgAdmin accessible on http://localhost:16000 [check docker-compose.yml for user/pass]

# .NET Core info #
Host Version: 3.1.8 / .NET Core SDK Version: 3.1.402

# Angular info #
Node: 12.18.4 / Angular: 10.1.2

# Database info #
PostgreSQL 12 / DB/TimeManagementDB.sql available with database dump. EFCore used for creating the db schema from model during development. PgAdmin also available.
