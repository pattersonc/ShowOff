

Database setup
---------------

1. Connection String
- Set the ShowOffConnectionString to your connection string.

2. Initial Setup
- Use aspnet_regsql.exe to generate membership schema in database before running setup and migration scripts.
- Navigate to showoff/setup generate schema from object mappings and run migration scripts.
- Migration scripts are contained in ~/Migrations folder.