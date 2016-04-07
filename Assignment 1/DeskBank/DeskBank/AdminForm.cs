using DeskBank.Domain;
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
    public partial class AdminForm : Form
    {
        public EmployeeService authEmpl;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(EmployeeService authEmpl)
        {
            this.authEmpl = authEmpl;
        }

        private void adminEmployeeSearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                Employee employeeFound = authEmpl.SearchEmployee(Convert.ToInt32(adminSearchEmployeeNumericUpDown.Value));
                adminEmployeeIDNumericUpDown.Value = employeeFound.Id;
                adminEmployeeUserNameTextBox.Text = employeeFound.UserName;
                adminEmployeePasswordTextBox.Text = employeeFound.Password;
                adminEmployeeTypeComboBox.SelectedIndex = (int) employeeFound.Type;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void adminEmployeeGetActivitiesButtonClick(object sender, EventArgs e)
        {
            try
            {
                Employee employeeFound = authEmpl.SearchEmployee(Convert.ToInt32(adminSearchEmployeeNumericUpDown.Value));

                System.Windows.Forms.MessageBox.Show("The employee activities are: \n[" + String.Join(",", employeeFound.Activities.Select(el=>el.ToString())) + "]");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void adminEmployeeSaveInformationButtonClick(object sender, EventArgs e)
        {
            try
            {
                authEmpl.SaveEmployeeInfo(Convert.ToInt32(adminEmployeeIDNumericUpDown.Value), adminEmployeeUserNameTextBox.Text, adminEmployeePasswordTextBox.Text, (EmployeeType)adminEmployeeTypeComboBox.SelectedIndex);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
