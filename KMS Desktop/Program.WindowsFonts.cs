using System;
using System.Collections.Generic;
using System.Text;

namespace KMS.Desktop {
    #if !__MonoCS__
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    static partial class Program {
        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        static extern int Gdi_AddFontResource(string lpFilename);

        [DllImport("gdi32", EntryPoint = "RemoveFontResource")]
        static extern bool Gdi_RemoveFontResource(string lpFileName);

        private static String WorkingDirectory =
            Path.GetDirectoryName(Application.ExecutablePath);

        private static List<String> m_loadedFonts = 
            new List<String>();

        private static void InitializeFontLoading() {
            String[] fonts = System.IO.Directory.GetFiles(WorkingDirectory, "*.ttf");

            foreach ( var font in fonts ) {
                Gdi_AddFontResource(font);
                m_loadedFonts.Add(font);
            }

            Application.ApplicationExit += Application_ApplicationExit;
        }

        static void Application_ApplicationExit(object sender, EventArgs e) {
            foreach ( var font in m_loadedFonts )
                Gdi_RemoveFontResource(font);
        }
    }
    #endif
}
