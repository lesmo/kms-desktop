using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kilometros.UsbX;
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

        static KmsDevice OpenDevice() {
            try {
                Console.WriteLine("          ---- Abriendo dispositivo ...");
                return new KmsDevice();
            } catch (CradleNotFoundException) {
                return OpenDevice();
            }
        }

        static void Main(string[] args) {
            WriteHelp();

            KmsDevice device
                = OpenDevice();

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

                    byte[] response
                        = new byte[0];
                    byte[] writeBytes;

                    if ( command.Length == 1 ) {
                        writeBytes
                            = new byte[] { commandByte, 0, 0 };
                        response
                            = device.Request(writeBytes);
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

                        for ( int i = 2, s = 3; i - 2  < parameters.Length; i++, s++ ) {
                            writeBytes[parameters.Length + 2]
                                = (byte)(writeBytes[i] ^ writeBytes[s]);
                        }
                    }

                    StringBuilder bytesInt
                        = new StringBuilder();

                    foreach ( string s in writeBytes.Select(b => b.ToString().PadRight(3)) )
                        bytesInt.Append(s + " ");

                    Console.WriteLine("          ---> {0}", BitConverter.ToString(writeBytes).Replace("-","  ") );
                    Console.WriteLine("               {0}", bytesInt.ToString());

                    byte[] readBytes
                        = device.Request(writeBytes);
                    bytesInt
                        = new StringBuilder();

                    foreach ( string s in readBytes.Select(b => b.ToString().PadRight(3)) )
                        bytesInt.Append(s + " ");

                    Console.WriteLine("          <--- {0}", BitConverter.ToString(readBytes).Replace("-", "  "));
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
