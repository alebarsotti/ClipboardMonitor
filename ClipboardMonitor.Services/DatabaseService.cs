namespace ClipboardMonitor.Services
{
    using ClipboardMonitor.Contracts;
    using ClipboardMonitor.Data;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DatabaseService : IDatabaseService
    {
        public CreateClipboardHistoryResponse CreateClipboardHistory(CreateClipboardHistoryRequest request)
        {
            using (var db = new ClipboardMonitorContext())
            {
                // Intentar encontrar el proceso en la BD.
                var process = db.Process.FirstOrDefault(x => x.Name == request.ProcessName);

                // Crear proceso en caso de no existir.
                if (process == null)
                {
                    process = new Process(request.ProcessName);

                    db.Process.Add(process);

                    db.SaveChanges();
                }

                // Crear nueva entrada en el historial del portapapeles.
                // TODO: Verificar que la entrada no exista aún.
                var newEntry = new ClipboardHistory(request.CopiedText, request.Time, request.WindowTitle, process);

                db.ClipboardHistory.Add(newEntry);

                db.SaveChanges();

                return new CreateClipboardHistoryResponse(new ClipboardHistoryModel()
                {
                    CopiedText = newEntry.CopiedText,
                    Id = newEntry.Id,
                    ProcessName = newEntry.Process.Name,
                    Time = newEntry.Time,
                    WindowTitle = newEntry.WindowTitle
                });
            }
        }

        public CreateProcessResponse CreateProcess(CreateProcessRequest request)
        {
            throw new NotImplementedException();
        }

        public DeleteClipboardHistoryResponse DeleteClipboardHistory(DeleteClipboardHistoryRequest request)
        {
            throw new NotImplementedException();
        }

        public GetClipboardHistoryResponse GetClipboardHistory(GetClipboardHistoryRequest request)
        {
            using (var db = new ClipboardMonitorContext())
            {
                var clipboardHistory = db.ClipboardHistory.Select(x => new ClipboardHistoryModel()
                {
                    CopiedText = x.CopiedText,
                    Id = x.Id,
                    ProcessName = x.Process.Name,
                    Time = x.Time,
                    WindowTitle = x.WindowTitle
                }).ToList();

                return new GetClipboardHistoryResponse()
                {
                    ClipboardHistoryCollection = clipboardHistory
                };
            }
        }
    }
}
