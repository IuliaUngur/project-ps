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
        public EmployeeService authEmpl;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(EmployeeService authEmpl)
        {
            this.authEmpl = authEmpl;
        }

    }
}
