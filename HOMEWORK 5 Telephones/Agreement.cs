using System;

namespace HOMEWORK_5_Telephones
{
    public class Agreement
    {
        public Guid NumberOfAgreement { get; set; }
        public DateTime DateOfAgreement { get; set; }
        public Tariff Tariff { get; set; }

        public Agreement(Tariff tariff)
        {
            NumberOfAgreement = Guid.NewGuid();
            DateOfAgreement = DateTime.Now.AddDays(-40);
            Tariff = tariff;
        }
    }
}
