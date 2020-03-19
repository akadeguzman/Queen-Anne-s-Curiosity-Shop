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
using QAShopWPF.ViewModel.Procurement;
using ServiceLayer;

namespace QAShopWPF.Views.Procurement
{
    /// <summary>
    /// Interaction logic for ProcurementView.xaml
    /// </summary>
    public partial class ProcurementView : UserControl
    {
        private ProcurementService _procurementService;
        private ProcurementListViewModel _procurementListViewModel;
        private ShipmentItemVendorService _shipmentItemVendorService;
        private PersonService _personService;
        private PurchasingAgentService _purchasingAgentService;

        public ProcurementView(ProcurementListViewModel procurementListViewModel, ShipmentItemVendorService shipmentItemVendorService, PersonService personService, PurchasingAgentService purchasingAgentService, ProcurementService procurementService)
        {
            InitializeComponent();

            _procurementService = procurementService;
            _shipmentItemVendorService = shipmentItemVendorService;
            _personService = personService;
            _purchasingAgentService = purchasingAgentService;
            _procurementListViewModel = new ProcurementListViewModel(procurementService);

            DataContext = _procurementListViewModel;
        }
    }
}
