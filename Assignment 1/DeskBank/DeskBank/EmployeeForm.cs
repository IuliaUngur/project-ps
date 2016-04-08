using DeskBank.Aspects;
using DeskBank.Domain;
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
    public partial class EmployeeForm : Form
    {
        private EmployeeService service;

        public EmployeeForm(EmployeeService es)
        {
            InitializeComponent();
            InitializeComboBoxes();
            service = es;
        }

        private void InitializeComboBoxes()
        {
            List<ComboBox> pncComboBoxes = new List<ComboBox>() {
                this.accountNewPNCComboBox,
                this.accountSelectClientPNCComboBox,
                this.clientSelectPNCComboBox,
                this.transferMoneyFromPNCComboBox,
                this.processBillToPNCComboBox,
                this.transferMoneyToPNCComboBox
            };

            pncComboBoxes.ForEach(cb => cb.Items.AddRange(service.GetClientsPNC()));

            //this.accountNewTypeComboBox;
            //this.accountSelectClientAccountIDComboBox;
            //this.accountSelectedTypeComboBox;
            //this.processBillFromAccountIDComboBox;;
            //this.processBillToAccountIDComboBox;
            //this.transferMoneyFromAccountIDComboBox;
            //this.transferMoneyToAccountIDComboBox;;
        }

        [OnExceptionMessage(new Type[] {
           typeof(IOException) 
        }, new string[] {
            "IOException"
        })]
        private void ClientUpdateSelectedButtonClick(object sender, EventArgs e)
        {

        }

        private void ClientSaveNewButtonClick(object sender, EventArgs e)
        {

        }

        private void AccountUpdateSelectedButtonClick(object sender, EventArgs e)
        {

        }

        private void AccountDeleteSelectedButtonClick(object sender, EventArgs e)
        {

        }

        private void AccountSaveNewButtonClick(object sender, EventArgs e)
        {

        }

        private void TransferMoneyTransferButtonClick(object sender, EventArgs e)
        {

        }

        private void ProcessBillsPayButtonClick(object sender, EventArgs e)
        {

        }
    }
}
