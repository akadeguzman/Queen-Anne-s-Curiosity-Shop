using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Procurement
{
    public class ProcurementViewModel : ObservableObject
    {
        #region Properties

        private int _procurementId;
        private string _shipmentItemVendor;
        private string _person;

        public int ProcurementId
        {
            get => _procurementId;
            internal set
            {
                _procurementId = value;
                RaisePropertyChanged(nameof(ProcurementId));
            }
        }

        public string ShipmentItemVendor
        {
            get => _shipmentItemVendor;
            internal set
            {
                _shipmentItemVendor = value;
                RaisePropertyChanged(nameof(ShipmentItemVendor));
            }
        }

        public string Person
        {
            get => _person;
            internal set
            {
                _person = value;
                RaisePropertyChanged(nameof(Person));
            }
        }

        public int ShipmentItemVendorId { get; set; }
        public int PersonId { get; set; }

        public ProcurementViewModel(int procurementId, string shipmentItemVendor, string person, int shipmentItemVendorId, int personId)
        {
            ProcurementId = procurementId;
            ShipmentItemVendor = shipmentItemVendor;
            Person = person;
            ShipmentItemVendorId = shipmentItemVendorId;
            PersonId = personId;
        }


        public ProcurementViewModel(QAShop_System.EfClasses.Procurement procurement)
        {
            ProcurementId = procurement.ProcurementId;
            ShipmentItemVendor = procurement.ShipmentItemLink.ToString();
            Person = procurement.PersonLink.GetFullName();
            ShipmentItemVendorId = procurement.ShipmentItemVendorId;
            PersonId = procurement.PersonId;
        }

        #endregion

        private ProcurementService _procurementService;
        private ProcurementViewModel _selectedProcurement;
        private string _searchText;
        private int _procurementCount;

        public ProcurementViewModel()
        {
            GenerateProcurements();
        }

        public void GenerateProcurements()
        {
            var procurement = _procurementService.GetProcurements()
                .Select(c => new ProcurementViewModel(c)).ToList();

            ProcurementList = new ObservableCollection<ProcurementViewModel>(procurement);
            PersonCount = ProcurementList.Count;
        }


        public ObservableCollection<ProcurementViewModel> ProcurementList { get; set; } = new ObservableCollection<ProcurementViewModel>();
        
        public int PersonCount
        {
            get => _procurementCount;
            set => Set(ref _procurementCount, value);
        }

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