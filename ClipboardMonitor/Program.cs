namespace ClipboardMonitor
{
    using ClipboardMonitor.Utilities;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClipboardNotification.AddEventHandler(DoSomething);
            Application.Run(/*new Form1()*/);
        }

        public static void DoSomething(object sender, ClipboardUpdateEventArgs args)
        {
            Debug.WriteLine(string.Format("Proceso: {1}\nNombre de la ventana: {2}\nTexto copiado: {0}", args.CopiedText, args.ProcessName, args.WindowTitle));
        }
    }
}
