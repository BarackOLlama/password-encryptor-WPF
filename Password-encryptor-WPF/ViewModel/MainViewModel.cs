using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Password_encryptor_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Password { get; set; }
        public string SaltedPassword { get; set; }
        public string Salt { get; set; }

        public RelayCommand EncryptCommand { get; set; }

        public MainViewModel()
        {
            EncryptCommand = new RelayCommand(Encrypt);
        }

        private void Encrypt()
        {
            if (string.IsNullOrEmpty(Password)) return;

            Salt = BCrypt.Net.BCrypt.GenerateSalt();
            SaltedPassword = BCrypt.Net.BCrypt.HashPassword(Password, Salt);
            base.RaisePropertyChanged(nameof(SaltedPassword));
            base.RaisePropertyChanged(nameof(Salt));
        }
    }
}