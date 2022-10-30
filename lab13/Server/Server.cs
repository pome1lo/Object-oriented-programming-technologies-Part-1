using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server
{
    internal class Program
    {
        static int port = 7000; // порт для приема входящих запросов
        
        static void Main(string[] args)
        {
            
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);    // получаем адреса для запуска сокета

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);// создаем сокет
            try
            {
                
                listenSocket.Bind(ipPoint); // связываем сокет с локальной точкой, по которой будем принимать данные

                
                listenSocket.Listen(10);    // начинаем прослушивание

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The server is active. Waiting for messages...");//The server is running. Waiting for messages...
                Console.ResetColor();
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    
                    StringBuilder builder = new StringBuilder(); // получаем сообщение
                    int bytes = 0;                               // количество полученных байтов
                    byte[] data = new byte[256];                 // буфер для получаемых данных

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                    Console.ResetColor();
                    
                    string message = "your message has been delivered";
                    data = Encoding.Unicode.GetBytes(message);  // отправляем ответ
                    handler.Send(data);
                    
                    handler.Shutdown(SocketShutdown.Both);      // закрываем сокет
                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
