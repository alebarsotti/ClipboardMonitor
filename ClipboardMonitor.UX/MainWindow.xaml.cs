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
    using ClipboardMonitor.Contracts;
    using ClipboardMonitor.Services;

    /// <summary>
    /// Lógica de interacción para la ventana principal.
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDatabaseService DatabaseService { get; set; }
        private ObservableCollection<ClipboardHistoryModel> ClipboardHistorySource { get; set; } = new ObservableCollection<ClipboardHistoryModel>();

        public MainWindow()
        {
            DatabaseService = new DatabaseService();

            InitializeDB();

            InitializeComponent();

            lbClipboardHistory.ItemsSource = ClipboardHistorySource;

            ClipboardNotification.AddEventHandler(UpdateClipboardHistorySource);
        }

        private void InitializeDB()
        {
            using (var db = new ClipboardMonitorContext())
            {
                db.Database.EnsureCreated();

                // Inicializar ClipboardHistorySource.
                ClipboardHistorySource = new ObservableCollection<ClipboardHistoryModel>(DatabaseService.GetClipboardHistory(new GetClipboardHistoryRequest()).ClipboardHistoryCollection);
            }
        }

        public void UpdateClipboardHistorySource(object sender, ClipboardUpdateEventArgs args)
        {
            var newEntry = DatabaseService.CreateClipboardHistory(new CreateClipboardHistoryRequest()
            {
                CopiedText = args.CopiedText,
                ProcessName = args.ProcessName,
                Time = args.Time,
                WindowTitle = args.WindowTitle
            }).ClipboardHistory;

            // Actualizar ClipboardHistorySource.
            ClipboardHistorySource.Add(newEntry);
        }

        private void CopyEntryButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ClipboardHistoryModel)lbClipboardHistory.SelectedItem;

            if (selectedItem != null)
            {
                Clipboard.SetText(selectedItem.CopiedText);

                MessageBox.Show("¡Se ha copiado la entrada al portapapeles!");
            }
        }

        private void DeleteEntryButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (ClipboardHistoryModel)lbClipboardHistory.SelectedItem;

            if (selectedItem != null)
            {
                // TODO: Utilizar servicio para eliminar la entrada seleccionada.

                // TODO: Actualizar UI para reflejar la eliminación.
            }
        }
    }
}
