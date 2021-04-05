using System;
using System.Windows;
using System.Windows.Controls;

using MailKit.Net.Smtp;

using MimeKit;

namespace MailClient
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        #region Fields

        private readonly SmtpClient m_client;
        private readonly string m_sender;

        #endregion Fields

        #region Constructors

        public ClientPage(SmtpClient client, string sender) {
            InitializeComponent();
            m_client = client;
            m_sender = sender;
        }

        #endregion Constructors

        #region Methods

        private void btnSend_Click(object sender, RoutedEventArgs e) {
            try {
                var msg = new MimeMessage();
                msg.To.Add(new MailboxAddress(tbAddress.Text));
                msg.From.Add(new MailboxAddress(m_sender));
                msg.Body = new TextPart("plain") { Text = tbText.Text };
                msg.Subject = tbSubject.Text;
                m_client.Send(msg);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        #endregion Methods
    }
}