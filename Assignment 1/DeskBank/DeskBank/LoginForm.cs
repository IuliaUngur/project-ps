using DeskBank.Aspects;
using DeskBank.Exceptions;
using DeskBank.Services;
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

        [OnExceptionMessage(new Type[] {
            typeof(NullReferenceException),
            typeof(UnauthorizedException)
        }, new string[] {
            "Some error",
            "User not registered"
        })]
        private void LoginButtonClick(object sender, EventArgs e)
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
            if (authorizedForm != null)
            {
                authorizedForm.Show();
                this.Hide();
            }
        }

    }
}
