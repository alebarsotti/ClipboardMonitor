namespace ClipboardMonitor.UX
{
    using ClipboardMonitor.Utilities;
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

            lbClipboardHistory.ItemsSource = ClipboardHistorySource;

            //ClipboardNotification.AddEventHandler(DoSomething);
            ClipboardNotification.AddEventHandler(UpdateClipboardHistorySource);
        }

        public void UpdateClipboardHistorySource(object sender, ClipboardUpdateEventArgs args)
        {
            ClipboardHistorySource.Add(new ClipboardEntryModel()
            {
                CopiedText = args.CopiedText,
                ProcessName = args.ProcessName,
                Time = args.Time,
                WindowTitle = args.WindowTitle
            });

            //lbClipboardHistory.ItemsSource = ClipboardHistorySource;
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
