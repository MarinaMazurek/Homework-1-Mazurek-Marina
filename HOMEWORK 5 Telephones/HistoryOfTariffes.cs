using System.Collections.Generic;

namespace HOMEWORK_5_Telephones
{
    public class HistoryOfTariffes
    {
        private List<Tariff> _history = new List<Tariff>();

        public HistoryOfTariffes(Tariff tariff)
        {
            _history.Add(tariff);
        }
    }
}
