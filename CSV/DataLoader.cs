using CsvHelper;
using System.Globalization;


public class DataLoader
{
    // Synchronous version (basic)
    public List<T> LoadCsv<T>(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<T>().ToList();
    }

    // // Async version (basic)
    // public async Task<List<T>> LoadCsvAsync<T>(string filePath)
    // {
    //     using var reader = new StreamReader(filePath);
    //     using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
    //     var records = new List<T>();
    //     await foreach (var record in csv.GetRecordsAsync<T>())
    //     {
    //         records.Add(record);
    //     }
    //     return records;
    // }
}