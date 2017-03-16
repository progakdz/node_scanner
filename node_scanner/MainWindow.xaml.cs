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
using MySql.Data.MySqlClient;
using System.Data;

namespace node_scanner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Window1 w1 = new Window1();
            w1.Show();

            update();
        }

        DBClass db = new DBClass();

        public void update()
        {
            var myData = db.getState().Select();
            for (int i = 1; i < myData.Length; i++)
            {
                for (int j = 0; j < myData[i].ItemArray.Length; j++)
                {
                    richtextbox1.AppendText(myData[i].ItemArray[j] + " ");
                }
                richtextbox1.AppendText("\n");
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            update();
        }
    }
}
