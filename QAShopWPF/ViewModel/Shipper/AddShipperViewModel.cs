using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipper
{
    public class AddShipperViewModel
    {
        private ShipperService _shipperService;

        public AddShipperViewModel(ShipperService shipperService)
        {
            _shipperService = shipperService;

            var blankShipper = new QAShop_System.EfClasses.Shipper();
            ShipperViewModel = new ShipperViewModel(blankShipper.ShipperId, blankShipper.ShipperName, blankShipper.ShipperContact, blankShipper.ShipperContact);

        }

        public ShipperViewModel ShipperViewModel { get; }

        public string ShipperName { get; set; }
        public string ShipperContact { get; set; }
        public string ShipperFax { get; set; }


        public void Add()
        {
            var shipperToAd = new QAShop_System.EfClasses.Shipper();
            shipperToAd.ShipperName = ShipperName;
            shipperToAd.ShipperContact = ShipperContact;
            shipperToAd.ShipperFax = ShipperFax;


            _shipperService.AddShipper(shipperToAd);

            ShipperViewModel.ShipperId = shipperToAd.ShipperId;
            ShipperViewModel.ShipperName = shipperToAd.ShipperName;
            ShipperViewModel.ShipperContact = shipperToAd.ShipperContact;
            ShipperViewModel.ShipperFax = shipperToAd.ShipperFax;
        }
    }
}