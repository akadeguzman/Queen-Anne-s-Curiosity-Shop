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
        private string _procurementCount;

        public ProcurementListViewModel(ProcurementService procurementService)
        {
            _procurementService = procurementService;

            var procurement = _procurementService.GetProcurements()
                .Select(c => new ProcurementViewModel(c));

            ProcurementList = new ObservableCollection<ProcurementViewModel>(procurement);
        }


        public ObservableCollection<ProcurementViewModel> ProcurementList { get; }

        public ProcurementViewModel SelectedProcurement { get; set; }

        public string ProcurementCount
        {
            get => _procurementCount;
            set
            {
                _procurementCount = value;
                GetProcurementCount();
            }
        }
        public string GetProcurementCount()
        {
            var count = $"{ProcurementList.Count}";
            return count;
        }


        public void SearchProcurement(string searchString)
        {
            ProcurementList.Clear();

            var procurements = _procurementService.GetProcurements().Where(c => c.ProcurementId.ToString().Contains(searchString) ||
                                                                      c.ShipmentItemVendorId.ToString().Contains(searchString) ||
                                                                      c.ReceivingClerkLink.FirstName.Contains(searchString) ||
                                                                      c.ReceivingClerkLink.LastName.Contains(searchString) ||
                                                                      c.PurchasingAgentLink.PersonLink.FirstName.Contains(searchString) ||
                                                                      c.PurchasingAgentLink.PersonLink.LastName.Contains(searchString) ||
                                                                      c.ShipmentItemLink.ShipmentLink.ShipperLink.ShipperName.Contains(searchString) ||
                                                                      c.Condition.Contains(searchString) ||
                                                                      c.ShipmentItemLink.ShipmentLink.CountryOfOrigin.Contains(searchString) ||
                                                                      c.ShipmentItemLink.ShipmentLink.ShipperLink.ShipperName.Contains(searchString));

            foreach (var procurement in procurements)
            {
                var procurementModel = new ProcurementViewModel(procurement.ProcurementId, procurement.Condition, procurement.ReceivingClerkLink.GetFullName(),
                    procurement.PurchasingAgentLink.PersonLink.GetFullName(), procurement.ShipmentItemVendorId, procurement.ReceivingClerkId, procurement.PurchasingAgentId,
                    procurement.ArrivalDate, procurement.DepartureDate, procurement.ShipmentItemLink.ShipmentLink.ShipperLink.ShipperName, procurement.ShipmentItemLink.ShipmentLink.CountryOfOrigin);
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
