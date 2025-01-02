This project demonstrates some very strange behavior in EF (Entity Framework) TPT (Table Per Type).

To recreate the problem:
 - Publish the "TptDb" database project to a SQL Server of your choice.
 - Run the "PrepDb.sql" script to populate the database with some test data.
 - Modify the "TptApp\appsettings.json" file, adjusting the connection string as required.
 - Run the "TptApp" project.

I would expect the application to run all the way through smoothly, but that is not the case.
Instead, after the second "Sale" record is inserted, casting errors start appearing.
Here is the console output I get when I run it:
```
Running with 0 records
Sales count with nothing: 0
Sales count with buyer: 0
Sales count with seller: 0
Sales count with both: 0
Running with 1 records
Sales count with nothing: 1
Sales count with buyer: 1
Sales count with seller: 1
Sales count with both: 1
Running with 2 records
Sales count with nothing: 2
Unable to cast object of type 'TptApp.Models.Seller' to type 'TptApp.Models.Buyer'.
Unable to cast object of type 'TptApp.Models.Buyer' to type 'TptApp.Models.Seller'.
Unable to cast object of type 'TptApp.Models.Seller' to type 'TptApp.Models.Buyer'.
```

This might make sense if the very first record failed, but it doesn't.

# Problem solved!
## Follow-up
Thanks to David Browne - Microsoft, the solution was to turn tracking off for the query.
https://stackoverflow.com/questions/79322601/strange-casting-problem-in-ef-tpt-table-per-type/79324091
