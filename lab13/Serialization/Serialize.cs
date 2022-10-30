using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Serialization
{
    public partial class Form1 : Form
    {
        private void SerializeXML(Users users)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));

            using (FileStream fs = new FileStream(@"..\..\..\Users.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, users);
            }

        }
        private void SerializeJSON(Users user)
        {
            using (FileStream fs = new FileStream(@"..\..\..\Users.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, user);
            }
        }
        private void SerializeSOAP(Users user)
        {
            using (FileStream fs = new FileStream(@"..\..\..\UsersSOAP.dat", FileMode.OpenOrCreate))
            {
                SoapFormatter binary = new SoapFormatter();
                binary.Serialize(fs, user);
            }
        }
        private void SerializeBinary(Users user)
        {
            using (FileStream fs = new FileStream(@"..\..\..\Users.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, user);
            }
        }
        private Users DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));

            using (FileStream fs = new FileStream(@"..\..\..\Users.xml", FileMode.OpenOrCreate))
            {
                return (Users)xml.Deserialize(fs);
            }
        }
        private Users DeserializationJSON()
        {
            using (FileStream fs = new FileStream(@"..\..\..\Users.json", FileMode.OpenOrCreate))
            {
                return (Users)JsonSerializer.Deserialize<Users>(fs);
            }
        }
        private Users DeserializationBinary()
        {
            using (FileStream fs = new FileStream(@"..\..\..\Users.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter binary = new BinaryFormatter();
                return (Users)binary.Deserialize(fs);
            }
        }
        private Users DeserializationSOAP()
        {
            using (FileStream fs = new FileStream(@"..\..\..\UsersSOAP.dat", FileMode.OpenOrCreate))
            {
                SoapFormatter binary = new SoapFormatter();
                return (Users)binary.Deserialize(fs);
            }
        }

        private void XMLSelector()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"..\..\..\Users.xml");
            
            XmlElement xRoot = xDoc.DocumentElement;
            
            XmlNodeList personNodes = xRoot?.SelectNodes("UserList//User//Name");
            XmlNodeList personNodes2 = xRoot?.SelectNodes("UserList//User//Age");
            
            for (int i = 0; i < personNodes.Count; i++)
            {
                File.AppendAllText(@"..\..\..\Task3.txt", personNodes[i].InnerText + "\n");
                File.AppendAllText(@"..\..\..\Task3.txt", personNodes2[i].InnerText + "\n");
            }
        }
        private void LinqToXML()
        {
            XDocument students = new XDocument(
               new XElement("Students",
                   new XElement("Student",
                       new XElement("Name", "Алеша"),
                       new XElement("Course", "2",
                           new XAttribute("group", "6"),
                           new XAttribute("subgroup", "2")),
                       new XElement("AverageMark", "8,9")),
                   new XElement("Student",
                       new XElement("Name", "Степан"),
                       new XElement("Course", "2",
                           new XAttribute("group", "6"),
                           new XAttribute("subgroup", "2")),
                       new XElement("AverageMark", "10")),
                   new XElement("Student",
                       new XElement("Name", "Анатолий"),
                       new XElement("Course", "4",
                           new XAttribute("group", "10"),
                           new XAttribute("subgroup", "1")),
                       new XElement("AverageMark", "4"))
                   )
             );
            students.Save(@"..\..\..\Stud.xml");

            var newlist3 = students.Elements().Count();
            var newlist1 = students.Elements().OrderBy(x => x.Name).ToList();
            var newlist2 = students.Elements().Select(x => $"element: {x}").ToList();
        }
    }
}
