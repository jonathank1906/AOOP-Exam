using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public interface IAccount
{
    int Id { get; set; }
    string Username { get; set; }
    string DefinitelyNotPasswordHash { get; set; }
    string Name { get; set; }
    string Surname { get; set; }
    string ToString();
}

public class StudentAccount : IAccount
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string DefinitelyNotPasswordHash { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<int> EnrolledSubjects { get; set; }

    public override string ToString()
    {
        return Id + " " + Username + " " + DefinitelyNotPasswordHash + " " + Name + " " + Surname + " " + string.Join(" ", EnrolledSubjects);
    }
}

public class AccountLoader
{
    private const string StudentAccountsPath = "student_users.json";

    public List<IAccount> LoadAccounts()
    {
        List<IAccount> accounts = new List<IAccount>();
        accounts.AddRange(LoadStudentAccounts());
        return accounts;
    }

    public List<StudentAccount> LoadStudentAccounts()
    {
        List<StudentAccount> studentAccounts = [];
        if (File.Exists(StudentAccountsPath))
        {
            string json = File.ReadAllText(StudentAccountsPath);
            studentAccounts = JsonSerializer.Deserialize<List<StudentAccount>>(json);
        }
        return studentAccounts;
    }
}