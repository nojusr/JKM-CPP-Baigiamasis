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

namespace Baigiamasis {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

        }
           
        //isjungia si langa ir paleidzia pagrindini langa
        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Window1 n = new Window1();
            n.Show();
            this.Close();
        }
    }


}
