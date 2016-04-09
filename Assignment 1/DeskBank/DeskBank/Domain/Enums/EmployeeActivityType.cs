using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Domain
{
    public enum EmployeeActivityType
    {
        CreateClient = 0,
        ViewClient = 1,
        UpdateClient = 2,
        CreateClientAccount = 3,
        ViewClientAccount = 4,
        UpdateClientAccount = 5,
        DeleteClientAccount,
        ProcessBillCash,
        ProcessBill,
        TransferMoney,
        AddNewAccount,
        AddNewClient,
        UpdateEmployee,
        DeleteEmployee,
        AddEmployee
    }
}