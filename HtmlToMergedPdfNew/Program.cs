using System.Runtime.InteropServices;

namespace HtmlToMergedPdfNew
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadLibWkHtmlTox();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static void LoadLibWkHtmlTox()
        {
            string libWkHtmlToxPath = Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll");
            if (!File.Exists(libWkHtmlToxPath))
            {
                throw new Exception("libwkhtmltox.dll not found at the specified location.");
            }

            IntPtr libraryHandle = WinAPI.LoadLibrary(libWkHtmlToxPath);
            if (libraryHandle == IntPtr.Zero)
            {
                throw new Exception("Failed to load libwkhtmltox.dll.");
            }
        }

        public static class WinAPI
        {
            [DllImport("kernel32", SetLastError = true)]
            public static extern IntPtr LoadLibrary(string lpFileName);
        }
    }
   
}