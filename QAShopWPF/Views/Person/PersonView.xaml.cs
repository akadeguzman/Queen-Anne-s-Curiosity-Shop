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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.Views.Person
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private PersonService _personService;
        private PersonListViewModel _personListViewModel;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;


        public PersonView(PersonListViewModel personListViewModel, PersonTypeService personTypeService, AddressService addressService, PersonService personService)
        {
            InitializeComponent();

            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;
            _personListViewModel = new PersonListViewModel(personService);
            DataContext = _personListViewModel;
        }
    }
}
