using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskBank
{
    public partial class LoginForm : Form
    {
        private AuthorizationService auth = new AuthorizationService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            try
            {
                Form authorizedForm;
                EmployeeService authEmpl = new EmployeeService(
                    auth.Authorize(
                        userNameTextBox.Text, 
                        passwordTextBox.Text
                        )
                    );
                if (authEmpl.IsAdmin())
                {
                    authorizedForm = new AdminForm(authEmpl);
                }
                else
                {
                    authorizedForm = new EmployeeForm(authEmpl);
                }
                authorizedForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
