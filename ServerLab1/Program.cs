using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Server
{
    public class ServerProgram
    {
        const int SIO_UDP_CONNRESET = -1744830452;
        const int port = 1984;


        public static int SizeCheck(Int16 x, Int16 y,Int16 Width, Int16 Height)
        {
            if( x > Width || y > Height || x < -Width || y < -Height)
            {
                return 1;

            }
            else
            {
                return 0;
            }

            
        }
        public static void SetScreenSize(byte[] RecievedData, out Int16 width, out Int16 height)
        {
            int val1place = 1;
            byte[] transfer = new byte[2];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            width = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            height = BitConverter.ToInt16(transfer, 0);
        }
        public static void ClearDisplay(byte[] RecievedData, out byte[] RGB)
        {
            int val1place = 1;
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);

        }
        public static void ThreeVarsDecode(byte[] RecievedData, out Int16 val1, out Int16 val2, out byte[] RGB)
        {
            byte[] transfer;
            int val1place = 1;
            transfer = new byte[2];
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);

        }

        public static void FiveVarsDecode(byte[] RecievedData, out Int16 val1, out Int16 val2, out Int16 val3, out Int16 val4, out byte[] RGB)
        {
            byte[] transfer;
            int val1place = 1;
            transfer = new byte[2];
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val3 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val4 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);
        }

        public static void CircleDecoder(byte[] RecievedData, out Int16 val1, out Int16 val2, out Int16 val3, out byte[] RGB)
        {
            byte[] transfer;
            int val1place = 1;
            transfer = new byte[2];
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val3 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);

        }

        public static void RoundedRectangleDecoder(byte[] RecievedData, out Int16 val1, out Int16 val2, out Int16 val3, out Int16 val4, out Int16 val5, out byte[] RGB)
        {
            byte[] transfer;
            int val1place = 1;
            transfer = new byte[2];
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val3 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val4 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val5 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);
        }

        public static void TextDecoder(byte[] RecievedData, out Int16 val1, out Int16 val2, out Int16 val3, out Int16 val4, out byte[] RGB, out string text)
        {
            byte[] transfer;
            int val1place = 1;
            transfer = new byte[2];
            RGB = new byte[3];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, RGB, 0, RGB.Length);
            val1place += 3;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val3 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val4 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            transfer = new byte[val4];
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            text = Encoding.ASCII.GetString(transfer);

        }
        public static void ImageDecoder(byte[] RecievedData, out Int16 val1, out Int16 val2, out Int16 width, out Int16 height, out Color[,] pic)
        {
            byte[] transfer;
            int val1place = 1; 
            transfer = new byte[2];
            Color color;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val1 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            val2 = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            width = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
            height = BitConverter.ToInt16(transfer, 0);
            val1place += 2;
            pic = new Color[width,height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    
                    transfer = new byte[3];
                    Array.Copy(RecievedData, val1place, transfer, 0, transfer.Length);
                    color = Color.FromArgb(transfer[0], transfer[1], transfer[2]);
                    pic[i, j] = color;
                    val1place += 3;
                }
            }

        }

        public static void StartServer()
        {
            
            Int16 val1, val2, val3, val4, val5, width = 0, height = 0; byte[] RGB, sendMessage; string text; byte command; Color[,] pic;
            Console.WriteLine("Server Begin");
            UdpClient server = new UdpClient(port);
            server.Client.IOControl((IOControlCode)SIO_UDP_CONNRESET,new byte[] { 0, 0, 0, 0 },null);
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint remoteEP;
            try
            {
                while (true)
                {

                    Console.WriteLine("Waiting for message");
                    byte[] RecievedData = server.Receive(ref localEP);
                    command = RecievedData[0];
                    Console.WriteLine($"Received broadcast from {localEP} :");

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("command:Clear Display");
                            ClearDisplay(RecievedData, out RGB);
                            Console.WriteLine($"color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                            text = $"Display cleared, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            server.Send(sendMessage, sendMessage.Length, remoteEP);
                            break;

                        case 2:
                            Console.WriteLine("command:Draw Pixel");
                            ThreeVarsDecode(RecievedData, out val1, out val2, out RGB);

                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x = {val1}, y = {val2}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Pixel Drawn:Coordinates: x = {val1}, y = {val2}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]} ";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, remoteEP);
                            break;
                        case 3:
                            Console.WriteLine("command:Draw Line");
                            FiveVarsDecode(RecievedData, out val1, out val2, out val3, out val4, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1 || SizeCheck(val3, val4, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, x2 = {val3}, y2 = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Line Drawn: Coordinates: x1 = {val1}, y1 = {val2}, x2 = {val3}, y2 = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }

                            sendMessage = Encoding.ASCII.GetBytes(text);
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            server.Send(sendMessage, sendMessage.Length, remoteEP);
                            break;

                        case 4:
                            Console.WriteLine("command:Draw Rectangle");
                            FiveVarsDecode(RecievedData, out val1, out val2, out val3, out val4, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);
                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Rectangle Drawn: Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }

                            sendMessage = Encoding.ASCII.GetBytes(text);
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            server.Send(sendMessage, sendMessage.Length, remoteEP);
                            break;

                        case 5:
                            Console.WriteLine("command:Fill Rectangle");
                            FiveVarsDecode(RecievedData, out val1, out val2, out val3, out val4, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Rectangle Filled: Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 6:
                            Console.WriteLine("command:Draw Ellipse");
                            FiveVarsDecode(RecievedData, out val1, out val2, out val3, out val4, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, radius x = {val3}, radius y = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Ellipse Drawn: Coordinates: x1 = {val1}, y1 = {val2}, radius x = {val3}, radius y = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);

                            break;

                        case 7:
                            Console.WriteLine("command:Fill Ellipse");
                            FiveVarsDecode(RecievedData, out val1, out val2, out val3, out val4, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, radius x = {val3}, radius y = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Ellipse Filled: Coordinates: x1 = {val1}, y1 = {val2}, radius x = {val3}, radius y = {val4}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 8:
                            Console.WriteLine("command:Draw Circle");
                            CircleDecoder(RecievedData, out val1, out val2, out val3, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, radius = {val3}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Circle Drawn: Coordinates: x1 = {val1}, y1 = {val2}, radius = {val3}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 9:
                            Console.WriteLine("command:Fill Circle");
                            CircleDecoder(RecievedData, out val1, out val2, out val3, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, radius = {val3}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Circle Filled: Coordinates: x1 = {val1}, y1 = {val2}, radius = {val3}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 10:
                            Console.WriteLine("command:Draw Rounded Rectangle");
                            RoundedRectangleDecoder(RecievedData, out val1, out val2, out val3, out val4, out val5, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, radius = {val5}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Rounded Rectangle Drawn: Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, radius = {val5}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 11:
                            Console.WriteLine("command:Fill Rounded Rectangle");
                            RoundedRectangleDecoder(RecievedData, out val1, out val2, out val3, out val4, out val5, out RGB);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);


                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, radius = {val5}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}");
                                text = $"Rounded Rectangle Filled: Coordinates: x1 = {val1}, y1 = {val2}, width = {val3}, height = {val4}, radius = {val5}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;

                        case 12:
                            Console.WriteLine("command:Draw Text");

                            TextDecoder(RecievedData, out val1, out val2, out val3, out val4, out RGB, out text);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);


                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}, font size = {val3}, text = \b {text} ");
                                text = $"Text Drawn: Coordinates: x1 = {val1}, y1 = {val2}, color: Red = {RGB[0]}, Green = {RGB[1]}, Blue = {RGB[2]}, font size = {val3}, text = \b {text} ";

                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;
                        case 13:
                            Console.WriteLine("command:Draw Image");
                            ImageDecoder(RecievedData, out val1, out val2, out val3, out val4, out pic);
                            if (SizeCheck(val1, val2, width, height) == 1)
                            {
                                text = "Error:Figure out of bounds";
                                Console.WriteLine(text);

                            }
                            else
                            {
                                Console.WriteLine($"Coordinates: x1 = {val1}, y1 = {val2}");
                                text = $"Image Drawn: Coordinates: x1 = {val1}, y1 = {val2}, Image Width = {val3}, Image Height = {val4}";
                            }
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;
                        case 14:
                            Console.WriteLine("Command: Set Orientation");
                            text = $"Orientation set:";
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;
                        case 15:
                            Console.WriteLine("Command: Get Width");
                            text = $"Width: {width} px";
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);

                            break;
                        case 16:
                            Console.WriteLine("Command: Get Height");
                            
                            text = $"Height: {height} px";
                            Console.WriteLine(text);
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);

                            break;
                        case 254:
                            Console.WriteLine("Command: Set Screen Size");
                            SetScreenSize(RecievedData, out width, out height);
                            Console.WriteLine($"Width: {width}");
                            Console.WriteLine($"Height: {height}");
                            text = $"Screen Size Set: Width = {width}, Height = {height}";
                            remoteEP = new IPEndPoint(localEP.Address, localEP.Port);
                            sendMessage = Encoding.ASCII.GetBytes(text);
                            server.Send(sendMessage, sendMessage.Length, localEP);
                            break;
                    }

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                server.Close();
            }   
        }
        public static void Main()
        {

            StartServer();
        }
    }
}



