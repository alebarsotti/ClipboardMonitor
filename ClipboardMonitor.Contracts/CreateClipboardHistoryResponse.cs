namespace ClipboardMonitor.Contracts
{
    public class CreateClipboardHistoryResponse
    {
        public ClipboardHistoryModel ClipboardHistory { get; set; }

        public CreateClipboardHistoryResponse()
        {

        }

        public CreateClipboardHistoryResponse(ClipboardHistoryModel clipboardHistory)
        {
            ClipboardHistory = clipboardHistory;
        }
    }
}