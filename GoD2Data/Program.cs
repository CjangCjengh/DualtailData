using System;
using System.IO;

namespace GoD2Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (string path in args)
            {
                try
                {
                    if (path.EndsWith(".bytes"))
                    {
                        string jsonData = DataConverter.BytesToJson(path);
                        string jsonPath = Path.ChangeExtension(path, "json");
                        using (StreamWriter sw = new StreamWriter(jsonPath))
                            sw.WriteLine(jsonData);
                        Console.WriteLine($"{path} => {jsonPath}");
                    }
                    else
                    {
                        DataConverter.JsonToBytes(path);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
