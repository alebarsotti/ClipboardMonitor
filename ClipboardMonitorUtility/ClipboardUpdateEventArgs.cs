namespace ClipboardMonitor.Utilities
{
    using System;

    /// <summary>
    /// Posee los argumentos del evento "ClipboardUpdate".
    /// </summary>
    public class ClipboardUpdateEventArgs : EventArgs
    {
        private const string UnknownString = "Desconocido";

        public string CopiedText { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }

        public ClipboardUpdateEventArgs()
        {
            (ProcessName, WindowTitle) = GetForegroundProcessName();
        }

        /// <summary>
        /// Devuelve el nombre del proceso y el título de la ventana que posee el foco en el momento.
        /// </summary>
        /// <returns></returns>
        private (string, string) GetForegroundProcessName()
        {
            IntPtr hwnd = NativeMethods.GetForegroundWindow();

            if (hwnd == null)
                return (UnknownString, UnknownString);

            NativeMethods.GetWindowThreadProcessId(hwnd, out uint pid);

            var process = System.Diagnostics.Process.GetProcessById((int)pid);

            return (process?.ProcessName, process?.MainWindowTitle);
        }
    }
}
