using System.IO;
using System.Text;
using System.Xml.Serialization;

public class XmlSerialization
{
    public static T LoadFromFile<T>(string fileName)
    {
        if (File.Exists(fileName))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(fileName))
                return (T)serializer.Deserialize(textReader);
        }
        else
            return default(T);
    }

    public static void SaveToFile<T>(string fileName, T t)
    {
        if (!string.IsNullOrEmpty(fileName))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textReader = new StreamWriter(fileName))
                serializer.Serialize(textReader, t);
        }
    }

    public static T LoadFromXml<T>(string xml)
    {
        if (!string.IsNullOrEmpty(xml))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StringReader(xml))
                return (T)serializer.Deserialize(textReader);
        }
        else
            return default(T);
    }

    public static string ConvertToXml<T>(T t)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (t != null)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textReader = new StringWriter(stringBuilder))
                serializer.Serialize(textReader, t);
        }
        return stringBuilder.ToString();
    }

    public static string ConvertToXml(object value)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (value != null)
        {
            XmlSerializer serializer = new XmlSerializer(value.GetType());
            using (TextWriter textReader = new StringWriter(stringBuilder))
                serializer.Serialize(textReader, value);
        }
        return stringBuilder.ToString();
    }
}


