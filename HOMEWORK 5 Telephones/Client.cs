using System;
using System.Collections.Generic;

namespace HOMEWORK_5_Telephones
{
    public class Client
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Terminal Terminal { get; set; }
        public Agreement Agreement { get; set; }

        public List<Tariff> HistoryOfTariffs = new List<Tariff>();

        public List<double> ListOfCostOfCall = new List<double>();

        public Client(string name, string surname, DateTime dateOfBirth, string address, Terminal terminal, Agreement agreement)
        {
            FirstName = name;
            SecondName = surname;
            DateOfBirth = dateOfBirth;
            Address = address;
            Terminal = terminal;
            Agreement = agreement;
        }
    }
}
