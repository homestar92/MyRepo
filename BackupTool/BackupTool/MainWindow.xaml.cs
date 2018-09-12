using System;
using System.Collections.Generic;
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

namespace BackupTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<FolderModel> SelectedFolders { get; set;  }

        public MainWindow()
        {
            SelectedFolders = new List<FolderModel>();
            InitializeComponent();
            SelectedFolders.Add(new FolderModel("Hello!"));
        }
    }
}
