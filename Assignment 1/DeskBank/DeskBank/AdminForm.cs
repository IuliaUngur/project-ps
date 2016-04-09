using DeskBank.Domain;
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
    public partial class AdminForm : Form
    {
        public EmployeeService service;

        public AdminForm(EmployeeService authEmpl)
        {
            this.service = authEmpl;
            InitializeComponent();
            InitializeListViews();
        }

        private void InitializeListViews()
        {
            this.employeeListView.Items.Clear();
            service.GetAllEmployees().ForEach(el => this.employeeListView.Items.Add(el.UserName));

            this.employeeListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(
                (obj, args) =>
                {
                    this.adminSelectedUserNameTextBox.Text = args.Item.Text;
                    this.adminSelectedTypeComboBox.SelectedIndex = service.GetEmployeeType(args.Item.Text);
                    this.adminSelectedPasswordTextBox.Text = service.GetEmployeePassword(args.Item.Text);

                    this.employeeActivityListView.Items.Clear();
                    service.GetAllEmployeeActivities(this.adminSelectedUserNameTextBox.Text).
                        ForEach(el => this.employeeActivityListView.Items.Add(el));
                }
            );

        }

        private void AdminUpdateSelectedEmployeeButtonClick(object sender, EventArgs e)
        {
            service.UpdateEmployeePasswordAndType(
                this.adminSelectedUserNameTextBox.Text, 
                this.adminSelectedPasswordTextBox.Text,
                this.adminSelectedTypeComboBox.SelectedIndex
            );

            this.adminSelectedUserNameTextBox.Text = "";
            this.adminSelectedTypeComboBox.SelectedIndex = -1;
            this.adminSelectedPasswordTextBox.Text = "";
            InitializeListViews();
        }

        private void AdminDeleteSelectedEmployeeButtonClick(object sender, EventArgs e)
        {
            service.DeleteEmployee(this.adminSelectedUserNameTextBox.Text);
            InitializeListViews();
        }

        private void AdminSaveNewEmployeeButtonClick(object sender, EventArgs e)
        {
            service.SaveEmployee(
                this.adminNewUserNameTextBox.Text,
                this.adminNewPasswordTextBox.Text,
                this.adminNewTypeComboBox.SelectedIndex
            );

            this.adminNewUserNameTextBox.Text = "";
            this.adminNewTypeComboBox.SelectedIndex = -1;
            this.adminNewPasswordTextBox.Text = "";
            InitializeListViews();
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
