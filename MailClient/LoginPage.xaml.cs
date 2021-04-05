using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

using MailKit.Net.Smtp;

namespace MailClient
{
    public partial class LoginPage : Page
    {
        #region Constructors

        public LoginPage() {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            try {
                var client = new SmtpClient();
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(tbLogin.Text, tbPassword.Text);
                NavigationService.GetNavigationService(this).Navigate(new ClientPage(client, tbLogin.Text));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnPrivacy_Click(object sender, RoutedEventArgs e) {
            Process.Start(new ProcessStartInfo {
                FileName = "https://myaccount.google.com/u/2/lesssecureapps",
                UseShellExecute = true
            });
        }

        #endregion Methods
    }
}