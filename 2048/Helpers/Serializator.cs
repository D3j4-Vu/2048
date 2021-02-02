using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace _2048
{
    public static class Serializator
    {
        public static void serialize<T>(T objToSerialize, string folderPath, string fileName)
        {
            System.IO.Directory.CreateDirectory(folderPath);
            using (Stream stream = File.Open(folderPath + fileName, FileMode.Create, FileAccess.Write))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Default);
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, objToSerialize);
                writer.Close();
            }
        }

        public static T deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T serializedData;
            using (Stream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                serializedData = (T)serializer.Deserialize(stream);
            }
            return serializedData;
        }

    }
}
