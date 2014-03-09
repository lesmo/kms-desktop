using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Testing {
    class Program {
        static void Main(string[] args) {
            BluetoothClient btc = new BluetoothClient();
            BluetoothDeviceInfo[] devices = btc.DiscoverDevices();

            foreach ( BluetoothDeviceInfo device in devices ) {
                Console.WriteLine("{0}", device.DeviceName);
            }

            Console.ReadKey();
        }
    }
}
