using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;

namespace GoD2Data
{
    internal static class DataConverter
    {
        public static string BytesToJson(string path)
        {
            object obj;
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                obj = binaryFormatter.Deserialize(fileStream);
            }
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static void JsonToBytes(string path)
        {
            List<avgViewControlData> obj = new JavaScriptSerializer().Deserialize<List<avgViewControlData>>(File.ReadAllText(path));
            using (FileStream fileStream = new FileStream(Path.ChangeExtension(path, "bytes"), FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter binFormatter = new BinaryFormatter();
                binFormatter.Serialize(fileStream, obj);
            }
        }
    }
}
