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
using System.Windows.Shapes;

namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WpfImportTools : Window
    {
        public WpfImportTools()
        {
            InitializeComponent();
        }

        private void GetExample(object sender, RoutedEventArgs e)
        {
            WpfExample example = new WpfExample();
            example.ShowDialog();
        }
        
        private void BtnClear_Click(object sender,EventArgs e)
        {
            TxtbxFrmText.Clear();
        }
    }
}
