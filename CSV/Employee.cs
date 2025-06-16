using CsvHelper.Configuration.Attributes;


public class Employee
{
    [Name("Id")]
    public int ID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Name("Department")]
    public string Department { get; set; }

    [Name("Salary")]
    public double Salary { get; set; }

    [Name("HireDate")]
    public string HireDate { get; set; }
}