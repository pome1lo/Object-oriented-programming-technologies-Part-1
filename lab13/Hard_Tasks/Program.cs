using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Hard_Tasks
{
    public class Program
    {
        [Serializable]
        public struct MyStruct
        {
            public int Field1 { get; set; }
            public float Field2 { get; set; }
            public string Field3 { get; set; }
        }
        [Serializable]
        public class Human
        {
            public string Name { get; set; } = "Alexey";
            public DateTime BirthDate { get; set; } = DateTime.Parse("06.08.2003");
        }


        static void Main(string[] args)
        {
            Int32 integer = new Int32();

            Object obj = new Object();
            
            MyStruct myStruct = new MyStruct();
            
            Human human = new Human();

            myStruct.Field1 = 228;
            myStruct.Field2 = 15F;
            myStruct.Field3 = "Test";

            integer = 69;

            obj = "Hello World";


            //CustomSerializer.Serializer(integer);
            //CustomSerializer.Serializer(obj);
            //CustomSerializer.Serializer(myStruct);
            CustomSerializer.Serializer(human);
            //CustomSerializer.Deserializer(human);

            //Console.WriteLine(human);

        }
    }
}
