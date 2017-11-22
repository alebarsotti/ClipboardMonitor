namespace ClipboardMonitor.UX
{
    using ClipboardMonitor.Utilities;
    using ClipboardMonitor.Data;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Lógica de interacción para la ventana principal.
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ClipboardEntryModel> ClipboardHistorySource { get; set; }

        public MainWindow()
        {
            ClipboardHistorySource = new ObservableCollection<ClipboardEntryModel>();

            InitializeComponent();

            InitializeDB();

            lbClipboardHistory.ItemsSource = ClipboardHistorySource;

            ClipboardNotification.AddEventHandler(UpdateClipboardHistorySource);
        }

        private void InitializeDB()
        {
            using (var db = new ClipboardMonitorContext())
            {
                db.Database.EnsureCreated();

                ClipboardHistorySource = new ObservableCollection<ClipboardEntryModel>(
                    db.ClipboardEntries.Select(x => new ClipboardEntryModel()
                    {
                        CopiedText = x.CopiedText,
                        ProcessName = x.ProcessName,
                        Time = x.Time,
                        WindowTitle = x.WindowTitle
                    }
                    ).ToList());
            }
        }

        public void UpdateClipboardHistorySource(object sender, ClipboardUpdateEventArgs args)
        {
            var newEntry = new ClipboardEntryModel()
            {
                CopiedText = args.CopiedText,
                ProcessName = args.ProcessName,
                Time = args.Time,
                WindowTitle = args.WindowTitle
            };

            using (var db = new ClipboardMonitorContext())
            {
                var newRecord = new ClipboardEntry()
                {
                    CopiedText = newEntry.CopiedText,
                    ProcessName = newEntry.ProcessName,
                    Time = newEntry.Time,
                    WindowTitle = newEntry.WindowTitle
                };

                db.ClipboardEntries.Add(newRecord);

                db.SaveChanges();

                // Actualizar
                ClipboardHistorySource.Add(newEntry);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ClipboardEntryModel)lbClipboardHistory.SelectedItem;

            if (selectedItem != null)
            {
                MessageBox.Show(string.Format("Seleccionaste: {0}", selectedItem.ProcessName));
            }
        }
    }
}
