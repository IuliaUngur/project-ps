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
    public partial class EmployeeForm : Form
    {
        public EmployeeService emplServ;

        public EmployeeForm(EmployeeService e)
        {
            InitializeComponent();
            emplServ = e;
        }

        private void clientInfoSearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                Client c = emplServ.SearchClientInfo(Convert.ToInt32(clientInfoSearchByNumericUpDown.Value));
                clientInfoNameTextBox.Text = c.Name;
                clientInfoPNCNumericUpDown.Value = c.PNC;
                clientInfoAddressTextBox.Text = c.Address;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Client Not Registered");
            }
        }

        private void clientInfoSaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                string clientName = clientInfoNameTextBox.Text;
                int clientPNC = Convert.ToInt32(clientInfoPNCNumericUpDown.Value);
                string clientAddress = clientInfoAddressTextBox.Text;
                emplServ.SaveClientInfo(clientName, clientPNC, clientAddress);

                clientInfoNameTextBox.Text = "";
                clientInfoPNCNumericUpDown.Value = 0;
                clientInfoAddressTextBox.Text = "";
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void accountInfoSearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                ClientAccount ca = emplServ.SearchAccountInfo(Convert.ToInt32(accountInfoSearchByNumericUpDown.Value));
                accountInfoIDNumericUpDown.Value = accountInfoSearchByNumericUpDown.Value;
                accountInfoTypeComboBox.SelectedIndex = Convert.ToInt32(ca.Type);
                accountInfoCreatedOnDateTimePicker.Value = ca.CreatedOn;
            }
            catch 
            {
                System.Windows.Forms.MessageBox.Show("Account Not Found");
            }
        }

        private void accountInfoSaveButtonClick(object sender, EventArgs e)
        {
            try
            {
                emplServ.SaveClientAccountInfo(
                    (AccountType)accountInfoTypeComboBox.SelectedIndex,
                    Convert.ToInt32(accountInfoIDNumericUpDown.Value),
                    accountInfoCreatedOnDateTimePicker.Value
                );

                accountInfoTypeComboBox.SelectedIndex = -1;
                accountInfoIDNumericUpDown.Value = 0;
                accountInfoCreatedOnDateTimePicker.Value = new DateTime(0);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void accountInfoDeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                emplServ.DeleteClientInfo(
                    Convert.ToInt32(accountInfoIDNumericUpDown.Value)
                );
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void transferAccountConfirmButtonClick(object sender, EventArgs e)
        {
            try
            {
                emplServ.TransferMoney(
                    Convert.ToInt32(transferAccountFromIDNumericUpDown.Value),
                    Convert.ToInt32(transferAccountToIDNumericUpDown.Value),
                    Convert.ToInt32(transferAccountFromAmountNumericUpDown.Value)
                );

                transferAccountFromAmountNumericUpDown.Value = 0;
                transferAccountFromIDNumericUpDown.Value = 0;
                transferAccountToIDNumericUpDown.Value = 0;

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void transferAccountSearchButtonClick(object sender, EventArgs e)
        {
            try
            {
                transferAccountToNameTextBox.Text = 
                    emplServ.SearchTransferAccount(
                        Convert.ToInt32(transferAccountFromIDNumericUpDown.Value),
                        Convert.ToInt32(transferAccountToIDNumericUpDown.Value)
                    );
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void processBillsConfirmPaymentButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (!emplServ.CompanyExists(
                        Convert.ToInt32(processBillsCompanyAccountNumericUpDown.Value)
                    )
                )
                {
                    return;
                }
                if (processBillsClientPaymentNumericCheckBox.Checked)
                {
                    emplServ.PayCompanyCash(
                        Convert.ToInt32(processBillsCompanyAccountNumericUpDown.Value),
                        Convert.ToInt32(processBillsClientIDNumericUpDown.Value),
                        Convert.ToInt32(processBillsAmountPaymentNumericUpDown.Value)
                    );
                }
                else
                {
                    emplServ.PayCompanyFromAccount(
                        Convert.ToInt32(processBillsClientIDNumericUpDown.Value),
                        Convert.ToInt32(processBillsClientAccountIDNumericUpDown.Value),
                        Convert.ToInt32(processBillsCompanyAccountNumericUpDown.Value),
                        Convert.ToInt32(processBillsAmountPaymentNumericUpDown.Value)
                    );
                }
                System.Windows.Forms.MessageBox.Show("Payment processed");

                processBillsCompanyAccountNumericUpDown.Value = 0;
                processBillsAmountPaymentNumericUpDown.Value = 0;
                processBillsClientIDNumericUpDown.Value = 0;
                processBillsClientAccountIDNumericUpDown.Value = 0;
                processBillsClientPaymentNumericCheckBox.Checked = false;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }
}
