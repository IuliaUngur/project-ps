using DeskBank.Aspects;
using DeskBank.Domain;
using DeskBank.Exceptions;
using DeskBank.Services;
using MySql.Data.MySqlClient;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeskBank
{
    [OnExceptionMessage(new Type[] {
        typeof(OverflowException),
        typeof(MySqlException),
        typeof(FormatException),
        typeof(GatewayException),
        typeof(InsufficientFundsException)
    }, new string[] {
        "Number too big",
        "Duplicate",
        "Invalid Number Provided",
        "Not found!",
        "Insuficient funds!"
    })]
    public partial class EmployeeForm : Form
    {
        private EmployeeService service;

        public EmployeeForm(EmployeeService es)
        {
            service = es;
            InitializeComponent();
            InitializeComboBoxes();
        }

        private void InitializeComboBoxes()
        {
            List<ComboBox> pncComboBoxes = new List<ComboBox>() {
                this.accountNewPNCComboBox,
                this.accountSelectClientPNCComboBox,
                this.clientSelectPNCComboBox,
                this.transferMoneyFromPNCComboBox,
                this.transferMoneyToPNCComboBox,
                this.processBillFromPNCComboBox,
                this.processBillToPNCComboBox
            };

            //this.accountNewTypeComboBox;
            //this.accountSelectClientAccountIDComboBox;
            //this.accountSelectedTypeComboBox;
            //this.processBillFromAccountIDComboBox;
            //this.processBillToAccountIDComboBox;
            //this.transferMoneyFromAccountIDComboBox;
            //this.transferMoneyToAccountIDComboBox;

            var clientPNCs = service.GetClientsPNC();

            pncComboBoxes.ForEach(cb => {
                cb.Items.Clear();
                cb.Items.AddRange(clientPNCs);
            });

            Dictionary<ComboBox, ComboBox> accountIDsComboBoxesLoadedByPNC = new Dictionary<ComboBox, ComboBox>()
            {
                { this.accountSelectClientPNCComboBox, this.accountSelectClientAccountIDComboBox },
                { this.transferMoneyFromPNCComboBox, this.transferMoneyFromAccountIDComboBox },
                { this.transferMoneyToPNCComboBox, this.transferMoneyToAccountIDComboBox },
                { this.processBillFromPNCComboBox, this.processBillFromAccountIDComboBox },
                { this.processBillToPNCComboBox, this.processBillToAccountIDComboBox }
            };

            accountIDsComboBoxesLoadedByPNC.ToList().ForEach(cb =>
            {
                cb.Key.SelectedIndexChanged -= GetAccountIDsLoaderForPNCLambda(cb.Key, cb.Value);
                cb.Key.SelectedIndexChanged += GetAccountIDsLoaderForPNCLambda(cb.Key, cb.Value);
            });

            this.clientSelectPNCComboBox.SelectedIndexChanged -= ClientSelectPNCComboBoxSelectedindexChanged;
            this.clientSelectPNCComboBox.SelectedIndexChanged += ClientSelectPNCComboBoxSelectedindexChanged;

            this.accountSelectClientAccountIDComboBox.SelectedIndexChanged -= AccountSelectClientAccountIDComboBoxSelectedIndexChanged;
            this.accountSelectClientAccountIDComboBox.SelectedIndexChanged += AccountSelectClientAccountIDComboBoxSelectedIndexChanged;
        }

        private void AccountSelectClientAccountIDComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedAccountID = Convert.ToInt32(((ComboBox)sender).Text);

            this.accountSelectedMoneyAmountTextBox.Text = service.GetClientAccountMoneyAmount(selectedAccountID);
            this.accountSelectedTypeComboBox.SelectedIndex = service.GetClientAccountType(selectedAccountID);
            this.accountSelectedCreatedOnDateTimePicker.Value= service.GetClientAccountCreatedOn(selectedAccountID);
        }

        private void ClientSelectPNCComboBoxSelectedindexChanged(object sender, EventArgs e)
        {
            int selectedPNC = Convert.ToInt32(((ComboBox)sender).Text);

            this.clientSelectedNameTextBox.Text = service.GetClientNameForPNC(selectedPNC);
            this.clientSelectedAddressRichTextBox.Text = service.GetClientAddressForPNC(selectedPNC);
        }

        private EventHandler GetAccountIDsLoaderForPNCLambda(ComboBox pNCComboBox, ComboBox accountIdComboBox)
        {
            return new EventHandler(
                (Object obj, EventArgs e) =>
                {
                    accountIdComboBox.Items.Clear();
                    accountIdComboBox.Items.AddRange(
                        service.GetClientAccountIDsForPNC(
                            Convert.ToInt32(pNCComboBox.Text)
                        )
                    );
                }
            );
        }

        private void ClientUpdateSelectedButtonClick(object sender, EventArgs e)
        {
            service.UpdateClientNameAndAddressForPNC(
                Convert.ToInt32(clientSelectPNCComboBox.Text),
                clientSelectedNameTextBox.Text,
                clientSelectedAddressRichTextBox.Text
            );
        }

        private void ClientSaveNewButtonClick(object sender, EventArgs e)
        {
            service.SaveNewClient(
                Convert.ToInt32(clientNewPNCTextBox.Text),
                clientNewNameTextBox.Text,
                clientNewAddressRichTextBox.Text
            );

            this.InitializeComboBoxes();
            clientNewPNCTextBox.Text = "";
            clientNewNameTextBox.Text = "";
            clientNewAddressRichTextBox.Text = "";
        }

        private void AccountUpdateSelectedButtonClick(object sender, EventArgs e)
        {
            service.UpdateClientAccountMoneyAmmountCreatedOnAndType(
                Convert.ToInt32(this.accountSelectClientAccountIDComboBox.Text),
                Convert.ToSingle(accountSelectedMoneyAmountTextBox.Text),
                accountSelectedCreatedOnDateTimePicker.Value,
                accountSelectedTypeComboBox.SelectedIndex        
            );
        }

        private void AccountDeleteSelectedButtonClick(object sender, EventArgs e)
        {
            service.DeleteClientAccount(Convert.ToInt32(this.accountSelectClientAccountIDComboBox.Text));

            this.InitializeComboBoxes();

            this.accountSelectedMoneyAmountTextBox.Text = "0";
            this.accountSelectedCreatedOnDateTimePicker.Value = DateTime.Now;
            this.accountSelectedTypeComboBox.SelectedIndex = -1;       
        }

        private void AccountSaveNewButtonClick(object sender, EventArgs e)
        {
            service.SaveNewClientAccount(
                Convert.ToInt32(accountNewPNCComboBox.Text),
                Convert.ToInt32(accountNewTypeComboBox.SelectedIndex),
                accountNewCreatedOnDateTimePicker.Value
            );

            this.InitializeComboBoxes();
            accountNewTypeComboBox.SelectedIndex = -1;
            accountNewPNCComboBox.SelectedIndex = -1;
            accountNewCreatedOnDateTimePicker.Value = DateTime.Now;
        }

        private void TransferMoneyTransferButtonClick(object sender, EventArgs e)
        {
            service.TransferMoney(
                Convert.ToInt32(this.transferMoneyFromAccountIDComboBox.Text),
                Convert.ToInt32(this.transferMoneyToAccountIDComboBox.Text),
                Convert.ToInt32(this.transferMoneyAmountTextBox.Text)
            );
        }

        private void ProcessBillsPayButtonClick(object sender, EventArgs e)
        {
            if (this.processBillCashCheckBox.Checked)
            {
                service.ProcessBillAddCash(
                    Convert.ToInt32(this.processBillFromAccountIDComboBox.Text),
                    Convert.ToInt32(this.processBillToAccountIDComboBox.Text),
                    Convert.ToInt32(this.processBillMoneyAmountTextBox.Text),
                    processBillIDTextBox.Text
                );
            }
        }
    }
}
