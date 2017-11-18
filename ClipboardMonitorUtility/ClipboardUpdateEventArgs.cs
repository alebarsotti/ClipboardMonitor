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

        // Returns the name of the process owning the foreground window.
        private (string, string) GetForegroundProcessName()
        {
            IntPtr hwnd = NativeMethods.GetForegroundWindow();

            if (hwnd == null)
                return (UnknownString, UnknownString);

            NativeMethods.GetWindowThreadProcessId(hwnd, out uint pid);

            //foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            //{
            //    if (p.Id == pid)
            //        return p.ProcessName;
            //}
            var process = System.Diagnostics.Process.GetProcessById((int)pid);
            return (process?.ProcessName, process?.MainWindowTitle);
        }
    }
}
