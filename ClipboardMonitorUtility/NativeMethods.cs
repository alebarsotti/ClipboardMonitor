﻿namespace ClipboardMonitor.Utilities
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provee métodos nativos para interactuar con el SO y su portapapeles.
    /// </summary>
    internal static class NativeMethods
    {
        public const int WM_CLIPBOARDUPDATE = 0x031D;
        public static IntPtr HWND_MESSAGE = new IntPtr(-3);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    }
}
