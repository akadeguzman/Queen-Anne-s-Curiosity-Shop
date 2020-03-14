using System;
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
        private string _receivingClerk;
        private string _purchasingAgent;
        private string _condition;
        private DateTime _arrivalDate;
        private DateTime _departureDate;

        public int ProcurementId
        {
            get => _procurementId;
            internal set
            {
                _procurementId = value;
                RaisePropertyChanged(nameof(ProcurementId));
            }
        }

        public string ReceivingClerk
        {
            get => _receivingClerk;
            internal set
            {
                _receivingClerk = value;
                RaisePropertyChanged(nameof(ReceivingClerk));
            }
        }

        public string PurchasingAgent
        {
            get => _purchasingAgent;
            internal set
            {
                _purchasingAgent = value;
                RaisePropertyChanged(nameof(PurchasingAgent));
            }
        }
        public string Condition
        {
            get => _condition;
            internal set
            {
                _condition = value;
                RaisePropertyChanged(nameof(Condition));
            }
        }
        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            internal set
            {
                _arrivalDate = value;
                RaisePropertyChanged(nameof(ArrivalDate));
            }
        }
        public DateTime DepartureDate
        {
            get => _departureDate;
            internal set
            {
                _departureDate = value;
                RaisePropertyChanged(nameof(DepartureDate));
            }
        }

        public int ShipmentItemVendorId { get; set; }
        public int ReceivingClerkId { get; set; }
        public int PurchasingAgentId { get; set; }

        public ProcurementViewModel(int procurementId, 
            string condition, 
            string receivingClerk, 
            string purchasingAgent, 
            int shipmentItemVendorId, 
            int receivingClerkId, 
            int purchasingAgentId,
            DateTime arrivalDate,
            DateTime departureDate)
        {
            ProcurementId = procurementId;
            Condition = condition;
            PurchasingAgent = purchasingAgent;
            ReceivingClerk = receivingClerk;
            ShipmentItemVendorId = shipmentItemVendorId;
            ReceivingClerkId = receivingClerkId;
            PurchasingAgentId = purchasingAgentId;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
        }


        public ProcurementViewModel(QAShop_System.EfClasses.Procurement procurement)
        {
            ProcurementId = procurement.ProcurementId;
            Condition = procurement.Condition;
            ReceivingClerk = procurement.ReceivingClerkLink.GetFullName();
            PurchasingAgent = procurement.PurchasingAgentLink.PersonLink.GetFullName();
            ShipmentItemVendorId = procurement.ShipmentItemVendorId;
            ReceivingClerkId = procurement.ReceivingClerkId;
            PurchasingAgentId = procurement.PurchasingAgentId;
        }

        public ProcurementViewModel()
        {
            
        }
        #endregion
    }
}