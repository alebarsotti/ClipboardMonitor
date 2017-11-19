namespace ClipboardMonitor.UX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClipboardEntryModel
    {
        public string CopiedText { get; set; }
        public DateTime Time { get; set; }
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }
    }
}
