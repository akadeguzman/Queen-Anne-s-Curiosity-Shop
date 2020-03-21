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
 using QAShopWPF.ViewModel;
 using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.Views.Address;
using ServiceLayer;

namespace QAShopWPF.Views.Person
{
    /// <summary>
    /// Interaction logic for AddNewPersonView.xaml
    /// </summary>
    public partial class AddNewPersonView : Window
    {
        public AddNewPersonView()
        {
            InitializeComponent();

            DataContext = QAShopService.AddPersonViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QAShopService.AddPersonViewModel.Add();
            QAShopService.PersonListViewModel.PersonList.Insert(0, QAShopService.AddPersonViewModel.PersonViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnNewAddress_Click(object sender, RoutedEventArgs e)
        {
            var addNewAddress = new AddNewAddressView(this);
            addNewAddress.Show();
        }
    }
}
