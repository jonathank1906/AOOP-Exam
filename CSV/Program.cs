//css_nuget CsvHelper
//css_include Employee.cs
//css_include DataLoader.cs

var dataLoader = new DataLoader();

// Synchronous load
//var employees = dataLoader.LoadCsv<Employee>("employees.csv");
List<Employee> employees = dataLoader.LoadCsv<Employee>("employees.csv");

// // OR async load (better for large files)
// var employeesAsync = await dataLoader.LoadCsvAsync<Employee>("employees.csv");

foreach (var emp in employees)
{
    Console.WriteLine($"ID: {emp.ID}, Name: {emp.FirstName} {emp.LastName}");
}