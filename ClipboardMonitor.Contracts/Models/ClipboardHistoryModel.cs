namespace ClipboardMonitor.Contracts
{
    using ClipboardMonitor.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ClipboardHistoryModel
    {
        public int? Id { get; set; }
        public string CopiedText { get; set; }
        public DateTime Time { get; set; }
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }

        public string CopiedTextSummary
        {
            get
            {
                var result = CopiedText.Trim().Replace(Environment.NewLine, string.Empty);

                return result.Substring(0, Math.Min(result.Length, 50));
            }
        }
    }
}
