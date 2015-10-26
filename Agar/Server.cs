using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Agar
{
    class Server
    {
       public void Listen()
       {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("192.168.101.153");
                    TcpListener myList = new TcpListener(ipAd, 9001);

                    /* Start Listeneting at the specified port */
                    myList.Start();

                    Socket socket = myList.AcceptSocket();

                    byte[] b = new byte[100];
                    int k = socket.Receive(b);
                    Console.WriteLine("Recieved...");
                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(b[i]));

                    ASCIIEncoding asen = new ASCIIEncoding();
                    socket.Send(asen.GetBytes("The string was recieved by the server."));
                    
                    /* clean up */
                    socket.Close();
                    myList.Stop();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
            }

        }

    
    }

