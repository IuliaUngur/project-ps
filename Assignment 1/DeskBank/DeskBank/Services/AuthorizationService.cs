using DeskBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank
{
    class AuthorizationService
    {
        internal Employee Authorize(string user, string pass)
        {
            Employee emp =  Employee.Gateway.GetAll().FirstOrDefault(element => 
                element.UserName == user &&
                element.Password == pass
            );
            if (emp == null)
            {
                throw new Exception("User not registered");
            }
            return emp;
        }
    }
}
