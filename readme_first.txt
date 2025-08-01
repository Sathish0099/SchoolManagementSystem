
# Updating the SQL Server Connection String in AttendanceAPP

This guide helps you update the SQL Server connection string throughout the AttendanceAPP project.

## Default Connection String

The current default connection string is:

```csharp
string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Raji\\source\\repos\\AttendanceAPP\\AttendanceAPP\\Database.mdf;Integrated Security=True";
```
1. **Find All Occurrences**
   - Open the solution in Visual Studio.
   - Use the "Find in Files" feature:
     - Shortcut: `Ctrl + Shift + F`
     - Search term: `Data Source=(LocalDB)\\MSSQLLocalDB`
   - This will show all files where the connection string is used.

2. **Update the Path**
   - Replace the existing `AttachDbFilename` path with the full path to your local copy of the `.mdf` file.
   - Example:
     ```csharp
     string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Your\\Path\\To\\Database.mdf;Integrated Security=True";
     ```

3. **Rebuild the Project**
   - After updating, rebuild the solution to ensure all changes are applied.

4. **Optional: Store in Configuration File**
   - To avoid hardcoding, you can move the connection string to `App.config` or `Settings.settings` and reference it in code:
     ```xml
     <connectionStrings>
       <add name="AttendanceDB" connectionString="..." />
     </connectionStrings>
     ```
     ```csharp
     string connectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;
     ```
