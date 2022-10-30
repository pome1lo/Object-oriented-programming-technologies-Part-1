using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using static Hard_Tasks.Program;

namespace Hard_Tasks
{
    internal class CustomSerializer
    {
        public static void Serializer(object obj)
        {
            try
            {
                SerializeJson(obj);
                SerializeSOAP(obj);
                SerializeBinary(obj);
                SerializeXML(obj);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Serialization is successful.");
                Console.ResetColor();
            }
            catch
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Something went wrong..");
                Console.ResetColor();
            }
        }
        public static void Deserializer(object obj)
        {
            try
            {
                var xml = DeserializeXML();
                var json = DeserializeJson();
                var soap = DeserializeSOAP();
                var bin = DeserializeBinary();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deserialization is successful.");
                Console.ResetColor();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Something went wrong..");
                Console.ResetColor();
            }
        }

        private static void SerializeJson(object obj)
        {
            using (FileStream fs = new FileStream(@"..\..\..\Hard.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, obj);
            }
        }
        private static void SerializeSOAP(object obj)
        {
            using (FileStream fs = new FileStream(@"..\..\..\HardSOAP.dat", FileMode.OpenOrCreate))
            {
                SoapFormatter binary = new SoapFormatter();
                binary.Serialize(fs, obj);
            }
        }
        private static void SerializeBinary(object obj)
        {
            using (FileStream fs = new FileStream(@"..\..\..\Hard.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(new XorStream(fs, 24), obj);
            }
        }
        private static void SerializeXML(object obj)
        {
            XmlSerializer xml = null;
            if (obj is Human)
            {
                xml = new XmlSerializer(typeof(Human));
            } else if(obj is MyStruct)
            {
                xml = new XmlSerializer(typeof(MyStruct));
            }
            else
            {
                xml = new XmlSerializer(typeof(object));
            }
            using (FileStream fs = new FileStream(@"..\..\..\Hard.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, obj);
            }
        }

        private static Object DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(object));

            using (FileStream fs = new FileStream(@"..\..\..\Hard.xml", FileMode.OpenOrCreate))
            {
                return xml.Deserialize(fs);
            }
        }
        private static Object DeserializeSOAP()
        {
            using (FileStream fs = new FileStream(@"..\..\..\HardSOAP.dat", FileMode.OpenOrCreate))
            {
                SoapFormatter binary = new SoapFormatter();
                return binary.Deserialize(fs);
            }
        }
        private static Object DeserializeBinary()
        {
            using (FileStream fs = new FileStream(@"..\..\..\Hard.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter binary = new BinaryFormatter();
                return binary.Deserialize(fs);
            }
        }
        private static Object DeserializeJson()
        {
            using (FileStream fs = new FileStream(@"..\..\..\Hard.json", FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<object>(fs);
            }
        }
    }

    class XorStream : Stream
    {
        Stream parent;
        byte xor;

        public XorStream(Stream stream, byte xor)
        {
            parent = stream;
            this.xor = xor;
        }

        public override bool CanRead
        {
            get { return parent.CanRead; }
        }
        public override bool CanSeek
        {
            get { return parent.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return parent.CanWrite; }
        }
        public override void Flush()
        {
            parent.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return parent.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            parent.SetLength(value);
        }
        public override long Length
        {
            get { return parent.Length; }
        }
        public override long Position
        {
            get
            {
                return parent.Position;
            }
            set
            {
                parent.Position = value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int readed = parent.Read(buffer, offset, count);
            for (int i = offset; i < readed; ++i)
                buffer[i] ^= xor;
            return readed;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            for (int i = offset; i < count; ++i)
                buffer[i] ^= xor;
            parent.Write(buffer, offset, count);
        }
    }
}
