namespace ClipboardMonitor.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDatabaseService
    {
        CreateProcessResponse CreateProcess(CreateProcessRequest request);
        CreateClipboardHistoryResponse CreateClipboardHistory(CreateClipboardHistoryRequest request);
        DeleteClipboardHistoryResponse DeleteClipboardHistory(DeleteClipboardHistoryRequest request);
        GetClipboardHistoryResponse GetClipboardHistory(GetClipboardHistoryRequest request);
    }
}
