namespace ClipboardMonitor.Utilities
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Ventana "message-only" utilizada para recibir el mensaje "WM_CLIPBOARDUPDATE".
    /// </summary>
    internal class NotificationForm : Form
    {
        /// <summary>
        /// Se produce cuando el contenido del portapapeles es modificado.
        /// </summary>
        public event EventHandler<ClipboardUpdateEventArgs> ClipboardUpdate;

        /// <summary>
        /// Lanza el evento <see cref="ClipboardUpdate"/>.
        /// </summary>
        /// <param name="e">EventArgs del evento.</param>
        private void OnClipboardUpdate(ClipboardUpdateEventArgs e)
        {
            ClipboardUpdate?.Invoke(null, e);
        }

        public NotificationForm()
        {
            NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
            NativeMethods.AddClipboardFormatListener(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            // Verificar que el mensaje "ClipboardUpdate" fue recibido.
            if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
            {
                // Obtener el contenido del portapapeles.
                IDataObject iData = Clipboard.GetDataObject();

                var args = new ClipboardUpdateEventArgs();

                // Verificar que el contenido sea texto y que el nombre del proceso sea distinto al de la propia aplicación.
                if (iData.GetDataPresent(DataFormats.Text) && args.ProcessName != System.Diagnostics.Process.GetCurrentProcess().ProcessName)
                {
                    // Convertir el contenido a string.
                    var clipboardData = (string)iData.GetData(DataFormats.Text);

                    // Establecer contenido de los EventArgs.
                    args.CopiedText = clipboardData;
                    
                    // Lanzar evento.
                    OnClipboardUpdate(args);
                }
            }

            base.WndProc(ref m);
        }
    }
}
