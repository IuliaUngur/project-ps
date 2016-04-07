using DeskBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank
{
    public class EmployeeService
    {
        private Employee currentEmployee;
        public EmployeeService(Employee e)
        {
            this.currentEmployee = e;
        }

        internal bool IsAdmin()
        {
           return currentEmployee.Type == EmployeeType.Admin ? true : false;
        }

        internal Client SearchClientInfo(int p)
        {
            return Client.Gateway.GetAll().Find(e=>e.PNC ==p);
        }

        internal void SaveClientInfo(string clientName, int clientPNC, string clientAddress)
        {
            Client c = Client.Gateway.GetAll().Find(e => e.PNC == clientPNC);
            if (c == null)
                Client.Gateway.Add(new Client()
                {
                    Name = clientName,
                    PNC = clientPNC,
                    Address = clientAddress
                });
            else
            {
                c.Name = clientName;
                c.Address = clientAddress;
                Client.Gateway.Update(c.Id, c);
            }
        }

        internal ClientAccount SearchAccountInfo(int p)
        {
            return ClientAccount.Gateway.Get(p);
        }

        internal void SaveClientAccountInfo(AccountType accountType, int p, DateTime dateTime)
        {
            ClientAccount.Gateway.Add(new ClientAccount() { CreatedOn = dateTime, Type = accountType, MoneyAmount = p });
        }

        internal void DeleteClientInfo(int p)
        {
            ClientAccount.Gateway.Remove(p);
        }

        internal void TransferMoney(int from, int to, int amount)
        {
            var fromClientAccount = ClientAccount.Gateway.Get(from);
            var toClientAccount = ClientAccount.Gateway.Get(to);

            if (amount > fromClientAccount.MoneyAmount)
                throw new Exception("Insufficent Funds");

            fromClientAccount.MoneyAmount -= amount;
            toClientAccount.MoneyAmount += amount;

            ClientAccount.Gateway.Update(fromClientAccount.Id, fromClientAccount);
            ClientAccount.Gateway.Update(toClientAccount.Id, toClientAccount);
        }

        internal string SearchTransferAccount(int accountFrom, int accountTo)
        {
            //returns name of to owner
            return "nu e clar ce se intampla aici?";
        }

        internal bool CompanyExists(int p)
        {
            return Client.Gateway.Get(p) != null;
        }

        //needs rethinking
        internal void PayCompanyCash(int companyID, int clientID, int amount)
        {
            var comp = ClientAccount.Gateway.Get(companyID);
            var client = ClientAccount.Gateway.Get(clientID);

            if (client == null)
                throw new Exception("Client not found");

            if (comp == null)
                throw new Exception("Company not found");

            comp.MoneyAmount += amount;
        }

        internal void PayCompanyFromAccount(int p1, int p2, int p3, int p4)
        {
            throw new NotImplementedException();
        }

        internal Employee SearchEmployee(int p)
        {
            throw new NotImplementedException();
        }

        internal void SaveEmployeeInfo(int p1, string p2, string p3, EmployeeType employeeType)
        {
            throw new NotImplementedException();
        }
    }
}
