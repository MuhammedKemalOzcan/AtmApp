using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp
{
    internal class User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }

        public User(string firstName, string lastName, int ıd, string password, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = ıd;
            Password = password;
            Balance = balance;
        }
    }
}
