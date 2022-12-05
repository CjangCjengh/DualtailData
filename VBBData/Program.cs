using System;
using System.IO;
using System.Runtime.InteropServices;

namespace VBBData
{
    internal static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            AllocConsole();
            foreach (string path in argv)
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
