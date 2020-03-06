﻿using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;

namespace QAShopWPF.ViewModel.Vendor
{
    public class VendorViewModel : ObservableObject
    {
        private int _vendorId;
        private string _firstName;
        private string _lastName;
        private string _contactNumber;
        [CanBeNull] public string _companyName;

        public int VendorId
        {
            get => _vendorId;
            internal set
            {
                _vendorId = value;
                RaisePropertyChanged(nameof(VendorId));
            }

        }

        public string FirstName
        {
            get => _firstName;
            internal set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }

        }

        public string LastName  
        {
            get => _lastName;
            internal set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }

        }

        public string ContactNumber
        {
            get => _contactNumber;
            internal set
            {
                _contactNumber = value;
                RaisePropertyChanged(nameof(ContactNumber));
            }

        }

        [CanBeNull]
        public string CompanyName
        {
            get => _companyName;
            internal set
            {
                _companyName = value;
                RaisePropertyChanged(nameof(CompanyName));
            }

        }

        public VendorViewModel(int vendorId, string firstName, string lastName, string contactNumber, [CanBeNull] string companyName)
        {
            VendorId = vendorId;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            CompanyName = companyName;
        }
    }
}