using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;

namespace VBRData
{
    internal static class DataConverter
    {
        public static string BytesToJson(string path)
        {
            object obj;
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Decompress))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    obj = formatter.Deserialize(gzipStream);
                }
            }
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static void JsonToBytes(string path)
        {
            avgViewControlRoot obj = new JavaScriptSerializer().Deserialize<avgViewControlRoot>(File.ReadAllText(path));
            using (FileStream fileStream = new FileStream(Path.ChangeExtension(path, "bytes"), FileMode.Create, FileAccess.Write))
            {
                using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(gzipStream, obj);
                }
            }
        }
    }
}
