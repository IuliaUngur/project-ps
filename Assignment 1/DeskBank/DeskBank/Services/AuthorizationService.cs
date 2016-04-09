using DeskBank.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeskBank.Exceptions;

namespace DeskBank.Services
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
                throw new UnauthorizedException("User not registered");
            }
            return emp;
        }
    }
}
