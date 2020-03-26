using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QAShopWPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for AddTransactionInputView.xaml
    /// </summary>
    public partial class AddTransactionInputView : Window
    {
        public AddTransactionInputView()
        {
            InitializeComponent();
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
