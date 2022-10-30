using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketTcpClient
{
    class Program
    {
        static int port = 7000; // порт сервера
        
        static string address = "127.0.0.1"; // адрес сервера
        
        static void Main(string[] args)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
               
                socket.Connect(ipPoint);                // подключаемся к удаленному хосту
                Console.Write("Enter a message:");
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                // получаем ответ
                data = new byte[256];                           // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0;                                  // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                Console.WriteLine("server response: " + builder.ToString());

               
                socket.Shutdown(SocketShutdown.Both); // закрываем сокет
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}