using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.UsbX;
using System.Threading;

namespace Kilometros_Testing {
    class Program {
        static void WriteHelp() {
            Console.WriteLine("---- Testing de KMS Inner Core ----");
            Console.WriteLine("   Escribir comando con el formato");
            Console.WriteLine("   [comando] [attr1,attr2,...]");
            Console.WriteLine();
            Console.WriteLine("   El [comando] y los [attr] pueden ser en HEX (0x??) o en enteros");
            Console.WriteLine();
            Console.WriteLine("   Comandos especiales:");
            Console.WriteLine("    help - Esta ayuda");
            Console.WriteLine("    exit - Salir");
            Console.WriteLine();
        }

        static USBDevice OpenDevice() {
            try {
                Console.WriteLine("          ---- Abriendo dispositivo ...");
                USBDevice device
                    = (
                        from d in USBDevice.DeviceList.Values
                        where d.PID == "ea60"
                        select d
                    ).FirstOrDefault();

                if ( device != null )
                    return device;
                else
                    return OpenDevice();
            } catch ( USBXpressNETException ) {
                return OpenDevice();
            }
        }

        static void Main(string[] args) {
            WriteHelp();

            USBDevice device
                = OpenDevice();
            device.Timeouts
                = new ReadWriteTimeouts(1000, 1000);
                
            string input;

            while ( true ) {
                Console.Write(" (kms.usb)> ");
                
                input
                    = Console.ReadLine();

                if ( input == "exit" ) {
                    break;
                } else if ( input == "help" ) {
                    WriteHelp();
                    continue;
                } else if ( input == "reset" ) {
                    device
                        = OpenDevice();
                    continue;
                }

                try {
                    string[] command
                        = input.Split(new char[]{' '}, 2);
                    byte commandByte
                        = command[0].StartsWith("0x")
                        ? Convert.ToByte(command[0], 16)
                        : byte.Parse(command[0]);

                    byte[] responseBuffer
                        = new byte[256];
                    byte[] writeBytes;
                    byte[] response
                        = new byte[0];

                    StringBuilder bytesInt
                        = new StringBuilder();

                    if ( command.Length == 1 ) {
                        writeBytes
                            = new byte[] { commandByte, 0, 0 };

                        bytesInt
                            = new StringBuilder();

                        foreach ( string s in response.Select(b => b.ToString().PadRight(3)) )
                            bytesInt.Append(s + " ");

                        Console.WriteLine("          ---> {0}", BitConverter.ToString(writeBytes).Replace("-", "  "));
                        Console.WriteLine("               {0}", bytesInt.ToString());
                        device.Write(writeBytes);

                        int responseByteCount
                            = device.Read(responseBuffer);
                        response
                            = new byte[responseBuffer[1]];

                        for ( short i = 0; i < responseBuffer[1] + 2; i++ ) {
                            response[i]
                                = responseBuffer[i];
                        }

                        bytesInt
                        = new StringBuilder();

                        foreach ( string s in response.Select(b => b.ToString().PadRight(3)) )
                            bytesInt.Append(s + " ");

                        Console.WriteLine("          <--- {0}", BitConverter.ToString(response).Replace("-", "  "));
                        Console.WriteLine("               {0}", bytesInt.ToString());
                    } else {
                        string[] parameters
                            = command[1].Split(new char[]{','}).Select(s => s.Trim()).ToArray();
                        writeBytes
                            = new byte[parameters.Length + 3];

                        writeBytes[0]
                            = commandByte;
                        writeBytes[1]
                            = (byte)parameters.Length;

                        for ( int i = 2, s = 0; s < parameters.Length; i++, s++ ) {
                            writeBytes[i]
                                = parameters[s].StartsWith("0x")
                                ? Convert.ToByte(parameters[s], 16)
                                : (byte)short.Parse(parameters[s]);
                        }

                        writeBytes[parameters.Length + 2] = writeBytes[2];
                        for ( int i = 3; i < writeBytes.Length - 1; i++ ) {
                            writeBytes[parameters.Length + 2]
                                = (byte)(writeBytes[parameters.Length + 2] ^ writeBytes[i]);
                        }
                        //writeBytes[parameters.Length + 2] = writeBytes[0];
                        //for ( int i = 0; i < writeBytes.Length - 1; i++ ) {
                        //    writeBytes[parameters.Length + 2]
                        //        = (byte)(writeBytes[parameters.Length + 2] ^ writeBytes[i]);
                        //}
                    }

                    foreach ( string s in writeBytes.Select(b => b.ToString().PadRight(3)) )
                        bytesInt.Append(s + " ");

                    Console.WriteLine("          ---> {0}", BitConverter.ToString(writeBytes).Replace("-","  ") );
                    Console.WriteLine("               {0}", bytesInt.ToString());

                    device.Write(writeBytes);
                    device.Read(responseBuffer);

                    response
                        = new byte[responseBuffer[1]];

                    for ( short i = 0, s = 2; s < responseBuffer[1] + 2; i++,s++ ) {
                        response[i]
                            = responseBuffer[s];
                    }

                    bytesInt
                        = new StringBuilder();

                    foreach ( string s in response.Select(b => b.ToString().PadRight(3)) )
                        bytesInt.Append(s + " ");

                    Console.WriteLine("          <--- {0}", BitConverter.ToString(response).Replace("-", "  "));
                    Console.WriteLine("               {0}", bytesInt.ToString());
                } catch ( Exception ex ) {
                    Console.WriteLine("          ---- {0}: {1}", ex.ToString(), ex.Message);
                } finally {
                    Console.WriteLine();
                }
            }
        }
    }
}
