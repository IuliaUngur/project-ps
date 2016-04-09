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

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Updated client name and address for pnc: " + selectedPNC + ". ( name : " + name + ", address: " + address + ")",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.UpdateClient
            });
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

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Added new client ( pnc: " + newPNC + ", name:  " + newName + ", address " + newAddress + ")",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.AddNewClient
            });
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

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Update client account " + accountId + ". Updated values ( " + moneyAmount + ", " + createdOn.ToString() + ", " + type + ")",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.UpdateClientAccount
            });
        }

        internal void DeleteClientAccount(int p)
        {
            ClientAccount.Gateway.Remove(p);

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Deleted client account " + p,
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.DeleteClientAccount
            });
        }

        internal void SaveNewClientAccount(int newPNC, int newType, DateTime newCreatedOn)
        {
            ClientAccount.Gateway.Add(new ClientAccount()
            {
                OwnerPNC = newPNC,
                Type = (AccountType)newType,
                CreatedOn = newCreatedOn,
                MoneyAmount = 0
            });

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Added new client account for PNC " + newPNC,
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.AddNewAccount
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


            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Transfered money " + amount + " from " + fromAccountId + " account id to " + toAccountId + " account id.",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.TransferMoney
            });
        }

        internal void ProcessBillAddCash(int fromAccountId, int toAccountId, int amount, string billId)
        {
            var to = ClientAccount.Gateway.Get(toAccountId);

            to.MoneyAmount += amount;
            ClientAccount.Gateway.Update(toAccountId, to);

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Added " + amount + " cash from " + fromAccountId + " account id to " + toAccountId + " account id. Bill ID " + billId,
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.ProcessBillCash
            });
        }

        internal void ProcessBill(int fromAccountId, int toAccountId, int amount, string billId)
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

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Added " + amount + " from " + fromAccountId + " account id to " + toAccountId + " account id. Bill ID " + billId,
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.ProcessBill
            });
        }

        internal List<Employee> GetAllEmployees()
        {
            return Employee.Gateway.GetAll().ToList();
        }

        internal int GetEmployeeType(string userName)
        {
            return Convert.ToInt32(Employee.Gateway.GetAll().First(ele => ele.UserName == userName).Type);
        }

        internal string GetEmployeePassword(string userName)
        {
            return Employee.Gateway.GetAll().First(ele => ele.UserName == userName).Password;
        }

        internal void UpdateEmployeePasswordAndType(string userName, string password, int type)
        {
            Employee e = Employee.Gateway.GetAll().First(ele => ele.UserName == userName);
            e.Password = password;
            e.Type = (EmployeeType)type;

            Employee.Gateway.Update(e.Id, e);

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Updated employee user name: " + userName + " ( password: " + password + ", type: " + type + ")",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.UpdateEmployee
            });
        }

        internal void DeleteEmployee(string userName)
        {
            Employee e = Employee.Gateway.GetAll().First(ele => ele.UserName == userName);
            Employee.Gateway.Remove(e.Id);

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Deleted employee with user name: " + userName,
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.DeleteEmployee
            });
        }

        internal void SaveEmployee(string userName, string password, int type)
        {
            Employee.Gateway.Add(new Employee() { UserName = userName, Password = password, Type = (EmployeeType)type });

            EmployeeActivity.Gateway.Add(new EmployeeActivity()
            {
                Date = DateTime.Now,
                Description = "Added employee with user name: " + userName + " ( password: " + password + ", type: " + type + ")",
                EmployeeId = currentEmployee.Id,
                Type = EmployeeActivityType.AddEmployee
            });
        }

        internal List<string> GetAllEmployeeActivities(string userName)
        {
            Employee e = Employee.Gateway.GetAll().First(el => el.UserName == userName);

            return EmployeeActivity.Gateway.GetAll().Where(ele => ele.EmployeeId == e.Id).Select(ele => ele.Description).ToList();
        }
    }
}
