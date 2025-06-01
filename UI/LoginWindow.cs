using System;
using System.Windows.Forms;
using Domain;
using Service;
using Service.observer;

namespace UI
{
    public partial class LoginWindow : AppForm
    {
        IObserver Client;
        public LoginWindow(IAppService appService, IObserver client) : base(appService)
        {
            InitializeComponent();
            Client = client;
        }
    
        public Employee ConnectedEmployee = null;

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var agencyName = AgencyNameBox.Text;
            var password = PasswordBox.Text;

            try
            {
                ConnectedEmployee = AppService.Login(agencyName, password, Client);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error during logibn " + ex.Message);
                return;
            }

            if (ConnectedEmployee == null)
            {
                MessageBox.Show("Invalid agency name or password");
                return;
            }
        
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}