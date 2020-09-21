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

namespace _22.SQLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
        }

        private void Txt_Entry_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(TxT_ID.Text, TxT_Name.Text, TxT_Lastname.Text, TxT_Email.Text);
            string Data = "";
            foreach (string sh in DataAccess.GetData())
            {
                Data = Data +" "+ sh + "\n";
            }
            MessageBox.Show(Data);
            
        }
    }
}
