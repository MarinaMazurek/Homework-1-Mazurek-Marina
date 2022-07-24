using System;

namespace HOMEWORK_5_Telephones
{
    public enum TariffName
    {
        Simple,
        Unlimited,
        Super,
        ForBissness
    }

    public class Tariff
    {
        public TariffName TariffName { get; set; }
        public double CostOfMinute { get; set; }
        public DateTime CreationDate { get; set; }

        public Tariff(TariffName tariffName, double cost)
        {
            TariffName = tariffName;
            CostOfMinute = cost;
            CreationDate = DateTime.Now;
        }  
    }
}
