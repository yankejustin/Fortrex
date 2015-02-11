using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjFortrex.GameEngine.Network;
using System.Net;
using System.Net.Sockets;

namespace prjFortrex.Server
{
    class Program
    {
        private static List<EntityConnection> EntityConnections;
        private const int Port = 4321;

        private static readonly object locker = new object();

        static void Main(string[] args)
        {
            EntityConnections = new List<EntityConnection>();

            while (true)
            {
                Console.WriteLine("Press any key to start the server...");
                Console.ReadKey(true);

                Console.Clear();
                Console.WriteLine("Initializing the server...");

                if (StartServer())
                {
                    Console.WriteLine("Server was initialized.");
                    Console.WriteLine("IP: " + "127.0.0.1");
                    Console.WriteLine("Port: " + Port.ToString());
                }
                else
                {
                    Console.WriteLine("Unable to start the server.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
        }

        private static bool StartServer()
        {
            IPHostEntry localhost = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            IPEndPoint serverEndPoint;

            try
            {
                serverEndPoint = new IPEndPoint(localhost.AddressList[0], Port);
                ServerSocket = new Socket(serverEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                ServerSocket.Bind(serverEndPoint);
                // Set a limit on the awaiting connection queue to 20.
                ServerSocket.Listen(20);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ex.Log("Invalid port number (" + Port.ToString() + "). Should be between 1024 and 65535.");
            }
            catch (SocketException ex)
            {
                ex.Log("Unable to create socket. Be sure that the port is not being duplicated.");
            }
            catch (Exception ex)
            {
                ex.Log("An unexpected error has occurred when trying to start the server.");
            }

            try
            {
                ServerSocket.BeginAccept(new AsyncCallback(AcceptCallback), ServerSocket);
            }
            catch (Exception ex)
            {
                ex.Log("Error occured starting listeners, check inner exception");
            }

            return true;
        }

        private static void AcceptCallback(IAsyncResult result)
        {
            PlayerConnection connection = new PlayerConnection();
            bool EntityError = false;
            try
            {
                // Finish accepting the connection.
                using (Socket s = (Socket)result.AsyncState)
                {
                    connection.ConnectionSocket = s.EndAccept(result);
                    connection.Buffer = new byte[connection.Buffer.Length];
                    lock (locker)
                    {
                        EntityConnections.Add(connection);
                    }
                    // Queue the receiving of data from the connection.
                    connection.ConnectionSocket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None,
                                                             new AsyncCallback(ReceiveCallback), connection);

                }
            }
            catch (Exception)
            {
                EntityError = true;
            }
            finally
            {
                if (EntityError)
                {
                    DisconnectUser(connection);
                }

                // Accept the next incoming connection.
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), _serverSocket);
            }
        }

        private static void ReceiveCallback(IAsyncResult result)
        {
            EntityConnection connection = (EntityConnection)result.AsyncState;
            bool EntityError = false;

            try
            {
                // Get the buffer and count the number of bytes received.
                int bytesRead = connection.ConnectionSocket.EndReceive(result);
                //make sure we've read something, if we haven't it supposadly means that the client disconnected
                if (bytesRead > 0)
                {
                    //put whatever you want to do when you receive data here

                    //Queue the next receive
                    connection.ConnectionSocket.BeginReceive(connection.Buffer, 0, connection.Buffer.Length, SocketFlags.None,
                                                             new AsyncCallback(ReceiveCallback), connection);
                }
                else
                {
                    // Callback ran, but gave no data, so kill the connection.
                    DisconnectUser(connection);
                }
            }
            catch 
            {
                EntityError = true;
            }
            finally
            {
                if (EntityError)
                {
                    DisconnectUser(connection);
                }
            }
        }

        private static void DisconnectUser(EntityConnection connection)
        {
            lock (locker)
            {
                if (connection != null)
                {
                    if (connection.ConnectionSocket != null)
                    {
                        connection.ConnectionSocket.Close();
                    }

                    if (EntityConnections.Contains(connection))
                    {
                        EntityConnections.Remove(connection);

                        connection.Dispose();
                    }
                }
            }
        }

        private static Socket _serverSocket;
        private static Socket ServerSocket
        {
            get { return _serverSocket; }
            set
            {
                if (_serverSocket != null && _serverSocket != value)
                {
                    _serverSocket.Close();
                    _serverSocket.Dispose();
                }

                _serverSocket = value;
            }
        }
    }
}