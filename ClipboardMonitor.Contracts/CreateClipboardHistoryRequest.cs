namespace ClipboardMonitor.Contracts
{
    using System;

    public class CreateClipboardHistoryRequest
    {
        public string CopiedText { get; set; }
        public string ProcessName { get; set; }
        public DateTime Time { get; set; }
        public string WindowTitle { get; set; }
    }
}