using DeskBank.Domain;
using DeskBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Services
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

        internal object[] GetClientsPNC()
        {
            return Client.Gateway.GetAll().Select(el => (object)el.PNC).ToArray();
        }


        internal object[] GetClientAccountIDsForPNC(int selectedPNC)
        {
            return ClientAccount.Gateway.GetAll().Where(el => el.OwnerPNC == selectedPNC).
                Select(el => (object)el.Id).ToArray();
        }

        internal string GetClientNameForPNC(int selectedPNC)
        {
            return Client.Gateway.GetAll().Where(el => el.PNC == selectedPNC).
                First().Name;
        }

        internal string GetClientAddressForPNC(int selectedPNC)
        {
            return Client.Gateway.GetAll().Where(el => el.PNC == selectedPNC).
                First().Address;
        }

        internal void UpdateClientNameAndAddressForPNC(int selectedPNC, string name, string address)
        {
            int id = Client.Gateway.GetAll().Where(el => el.PNC == selectedPNC).First().Id;
            Client c = new Client()
            {
                Name = name,
                Address = address
            };
            Client.Gateway.Update(id, c);
        }

        internal void SaveNewClient(int newPNC, string newName, string newAddress)
        {
            Client.Gateway.Add(
                new Client()
                {
                    Name = newName,
                    PNC = newPNC,
                    Address = newAddress
                }
            );
        }

        internal string GetClientAccountMoneyAmount(int selectedAccountID)
        {
            return ClientAccount.Gateway.Get(selectedAccountID).MoneyAmount.ToString();
        }

        internal int GetClientAccountType(int selectedAccountID)
        {
            return Convert.ToInt32(ClientAccount.Gateway.Get(selectedAccountID).Type);
        }

        internal DateTime GetClientAccountCreatedOn(int selectedAccountID)
        {
            return ClientAccount.Gateway.Get(selectedAccountID).CreatedOn;
        }

        internal void UpdateClientAccountMoneyAmmountCreatedOnAndType(int accountId, float moneyAmount, DateTime createdOn, int type)
        {
            ClientAccount.Gateway.Update(accountId, new ClientAccount()
            {
                MoneyAmount = moneyAmount,
                Type = (AccountType)type,
                CreatedOn = createdOn
            });
        }

        internal void DeleteClientAccount(int p)
        {
            ClientAccount.Gateway.Remove(p);
        }

        internal void SaveNewClientAccount(int newPNC, int newType, DateTime newCreatedOn)
        {
            ClientAccount.Gateway.Add(new ClientAccount() { 
                OwnerPNC = newPNC, 
                Type = (AccountType)newType,
                CreatedOn = newCreatedOn, 
                MoneyAmount = 0 
            });
        }

        internal void TransferMoney(int fromAccountId, int toAccountId, int amount)
        {
            var from = ClientAccount.Gateway.Get(fromAccountId);
            var to = ClientAccount.Gateway.Get(toAccountId);

            if (from.MoneyAmount < amount)
            {
                throw new InsufficientFundsException("Insuficient funds exeption");
            }

            from.MoneyAmount -= amount;
            to.MoneyAmount += amount;

            ClientAccount.Gateway.Update(fromAccountId, from);
            ClientAccount.Gateway.Update(toAccountId, to);
        }

        internal void ProcessBillAddCash(int fromAccountId, int toAccountId, int amount, string billId)
        {
            // TODO update the employee activity with the corect description
            var to = ClientAccount.Gateway.Get(toAccountId);

            to.MoneyAmount += amount;
            ClientAccount.Gateway.Update(toAccountId, to);
        }

        internal void ProcessBill(int fromAccountId, int toAccountId, int amount, string billId)
        {
            // TODO update the employee activity with the corect description
            var from = ClientAccount.Gateway.Get(fromAccountId);
            var to = ClientAccount.Gateway.Get(toAccountId);

            if (from.MoneyAmount < amount)
            {
                throw new InsufficientFundsException("Insuficient funds exeption");
            }

            from.MoneyAmount -= amount;
            to.MoneyAmount += amount;

            ClientAccount.Gateway.Update(fromAccountId, from);
            ClientAccount.Gateway.Update(toAccountId, to);
        }
    }
}
