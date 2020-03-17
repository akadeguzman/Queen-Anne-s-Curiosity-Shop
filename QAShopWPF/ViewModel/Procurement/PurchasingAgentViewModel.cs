using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Procurement
{
    public class PurchasingAgentViewModel : ObservableObject
    {
        private int _purchasingAgentId;
        private string _purchasingAgent;

        public int PurchasingAgentId
        {
            get => _purchasingAgentId;
            internal set
            {
                _purchasingAgentId = value;
                RaisePropertyChanged(nameof(PurchasingAgentId));
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

        public int PersonId { get; set; }

        public PurchasingAgentViewModel(int purchasingAgentId, string purchasingAgent)
        {
            PurchasingAgentId = purchasingAgentId;
            PurchasingAgent = purchasingAgent;
        }

        public PurchasingAgentViewModel(PurchasingAgent purchasingAgent)
        {
            PurchasingAgentId = purchasingAgent.PurchasingAgentId;
            PurchasingAgent = purchasingAgent.PersonLink.GetFullName();
            PersonId = purchasingAgent.PersonId;
        }
    }
}