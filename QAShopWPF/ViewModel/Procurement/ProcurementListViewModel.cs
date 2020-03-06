using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Procurement
{
    public class ProcurementListViewModel
    {
        private ProcurementService _procurementService;
        private ProcurementViewModel _selectedProcurement;
        private string _searchText;

        public ProcurementListViewModel(ProcurementService procurementService)
        {
            _procurementService = procurementService;

            var procurement = _procurementService.GetProcurements()
                .Select(c => new ProcurementViewModel(
                    c.ProcurementId,
                    c.ShipmentItemLink.ShipmentLink.ShipperInvoiceNumber,
                    c.PersonLink.GetFullName(), c.ShipmentItemVendorId, c.PersonId));

            ProcurementList = new ObservableCollection<ProcurementViewModel>(procurement);

        }


        public ObservableCollection<ProcurementViewModel> ProcurementList { get; }

        public ProcurementViewModel SelectedProcurement { get; set; }

        public void SearchProcurement(string searchString)
        {
            ProcurementList.Clear();

            var procurements = _procurementService.GetProcurements().Where(c => c.ProcurementId.ToString().Contains(searchString) ||
                                                                      c.ShipmentItemVendorId.ToString().Contains(searchString) ||
                                                                      c.PersonId.ToString().Contains(searchString) ||
                                                                      c.PersonLink.LastName.Contains(searchString) ||
                                                                      c.PersonLink.FirstName.Contains(searchString));

            foreach (var procurement in procurements)
            {
                var procurementModel = new ProcurementViewModel(procurement.ProcurementId, procurement.ShipmentItemLink.ShipmentLink.ShipperInvoiceNumber, procurement.PersonLink.GetFullName(),
                    procurement.ShipmentItemVendorId, procurement.PersonId);
                ProcurementList.Add(procurementModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchProcurement(_searchText);
            }
        }
    }
}
