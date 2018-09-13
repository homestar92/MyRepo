using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BackupTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<FolderModel> SelectedFolders { get; set; }

        private ICommand m_deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (m_deleteCommand == null)
                {
                    m_deleteCommand = new RelayCommand(param => Delete((FolderModel)param));
                }
                return m_deleteCommand;
            }
        }

        private void Delete(FolderModel result)
        {
            SelectedFolders.Remove(result);
        }

        public MainWindow()
        {
            SelectedFolders = new ObservableCollection<FolderModel>();
            InitializeComponent();
            dataGrid.ItemsSource = SelectedFolders;
        }

        public static string NormalizePath(string path)
        {
            return System.IO.Path.GetFullPath(new Uri(path).LocalPath)
                .TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar)
                .ToUpperInvariant();
        }

        private void BtnAddFolder_OnClick(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    if (Directory.Exists(path) && !SelectedFolders.Any(x => NormalizePath(x.Folder) == NormalizePath(path)))
                    {
                        SelectedFolders.Add(new FolderModel(path));
                    }
                }
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
