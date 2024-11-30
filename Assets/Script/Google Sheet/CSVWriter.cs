using System.Collections.Generic;
using System.IO;

public static class CSVWriter
{
    public static void WriteCSV(string filePath, List<string> data)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string line in data)
            {
                writer.WriteLine(line);
            }
        }
    }
}