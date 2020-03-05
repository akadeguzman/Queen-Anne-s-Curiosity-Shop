using GalaSoft.MvvmLight;

namespace QAShopWPF.ViewModel.Procurement
{
    public class ProcurementViewModel : ObservableObject
    {
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
    }
}