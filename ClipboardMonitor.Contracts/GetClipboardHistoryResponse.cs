namespace ClipboardMonitor.Contracts
{
    using System.Collections.Generic;

    public class GetClipboardHistoryResponse
    {
        public List<ClipboardHistoryModel> ClipboardHistoryCollection { get; set; }
    }
}