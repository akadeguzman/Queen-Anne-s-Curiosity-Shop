namespace QAShopWPF.ViewModel.Shipper
{
    public class AddShipperViewModel
    {
        public AddShipperViewModel()
        {
            var blankShipper = new QAShop_System.EfClasses.Shipper();
            ShipperViewModel = new ShipperViewModel(blankShipper.ShipperId, blankShipper.ShipperName, blankShipper.ShipperContact, blankShipper.ShipperContact);

        }

        public ShipperViewModel ShipperViewModel { get; }

        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperContact { get; set; }
        public string ShipperFax { get; set; }


        public void Add()
        {
            var shipperToAd = new QAShop_System.EfClasses.Shipper();
            shipperToAd.ShipperName = ShipperName;
            shipperToAd.ShipperContact = ShipperContact;
            shipperToAd.ShipperFax = ShipperFax;


            QAShopService.ShipperService.AddShipper(shipperToAd);

            ShipperViewModel.ShipperId = shipperToAd.ShipperId;
            ShipperViewModel.ShipperName = shipperToAd.ShipperName;
            ShipperViewModel.ShipperContact = shipperToAd.ShipperContact;
            ShipperViewModel.ShipperFax = shipperToAd.ShipperFax;
        }
    }
}