using System;
using System.Collections.Generic;
using System.Linq;

namespace GC_Sharp
{
    public class Employees
    {
        private Dictionary<string, string> DataBase = new Dictionary<string, string>();

        public void AddEmployee(string password, string login)
        {
            DataBase[password] = login;
        }

        public void DeleteEmployee(string password)
        {
            if (DataBase.ContainsKey(password))
            {
                DataBase.Remove(password);
            }
            else
            {
                Console.WriteLine("Password is incorrect");
            }
        }

        public void ChangeData(string old_password, string new_login, string new_password)
        {
            if (DataBase.ContainsKey(old_password))
            {
                string old_login = DataBase[old_password];

                DataBase.Remove(old_password);
                DataBase[new_password] = new_login;
            }
            else
            {
                Console.WriteLine("Password is incorrect");
            }
        }

        public string GetLogin(string password)
        {
            if (DataBase.ContainsKey(password))
            {
                return DataBase[password];
            }
            else
            {
                Console.WriteLine("Password is incorrect");
                return null;
            }
        }

        public override string ToString()
        {
            string result = "\nEmployees:\n";

            foreach (var pair in DataBase)
            {
                result += $"Password: {pair.Key}\nLogin: {pair.Value}\n\n";
            }
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees();

            employees.AddEmployee("123", "qwe");
            employees.AddEmployee("456", "zxc");

            string login = employees.GetLogin("123");
            Console.WriteLine(login);

            employees.ChangeData("123", "asd", "890");
            Console.WriteLine(employees.ToString());

            employees.DeleteEmployee("890");
            Console.WriteLine(employees.ToString());
        }
    }
}
