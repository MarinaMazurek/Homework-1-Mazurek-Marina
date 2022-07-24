using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HOMEWORK_5_Telephones
{
    class Program
    {
        public const string path = @"F:\1 С #\IT ACADEMIA\writeHistoryOfCalls.txt";
        public const string path2 = @"F:\1 С #\IT ACADEMIA\writeHistoryOfTariffes.txt";

        static void Main(string[] args)
        {
            Client client1 = new Client("Petia", "Pavlov", new DateTime(2000, 10, 25), "Kosmonavtov 26-84",
                new Terminal(new Port(PortState.Connected), 1111111),
                new Agreement(new Tariff(TariffName.Simple, 1.1)));

            Client client2 = new Client("Igor", "Vasilevskiy", new DateTime(2001, 10, 25), "Pravdy 46-105",
                new Terminal(new Port(PortState.Connected), 2222222),
                new Agreement(new Tariff(TariffName.ForBissness, 1.5)));

            Client client3 = new Client("Ivan", "Bobric", new DateTime(1999, 8, 16), "Shevchenko 20-210",
                new Terminal(new Port(PortState.Connected), 3333333),
                new Agreement(new Tariff(TariffName.Super, 1.7)));

            Client client4 = new Client("Yury", "Mihaylov", new DateTime(2000, 7, 15), "Neptyna 12-10",
                new Terminal(new Port(PortState.Connected), 4444444),
                new Agreement(new Tariff(TariffName.Super, 1.7)));

            TelephoneStation station = new TelephoneStation();

            station.ListOfClient.Add(client1);
            station.ListOfClient.Add(client2);
            station.ListOfClient.Add(client3);
            station.ListOfClient.Add(client4);

            //изменение тарифа            
            station.NotifyChangeTariff += DisplayMessageChangeTariff;
            station.ChangeTariff(client1, new Tariff(TariffName.Super, 1.7));
            station.ChangeTariff(client1, new Tariff(TariffName.ForBissness, 1.5));

            Console.WriteLine(new string('-', 50) + "\n" + new string('-', 50));

            //изменение состояния порта
            station.NotifyChangePortState += DisplayMessageChangePortState;
            station.ChangePortState(client2);

            station.NotifyCall += DisplayMessageCall;
            Console.WriteLine(new string('-', 50));

            //звонки
            Console.WriteLine(new string('-', 50));
            station.CallTo(client1, client2);
            Console.WriteLine(new string('-', 50));
            station.CallTo(client1, client4);
            Console.WriteLine(new string('-', 50));
            station.CallTo(client1, client3);
            Console.WriteLine(new string('-', 50));
            station.CallTo(client2, client1);
            Console.WriteLine(new string('-', 50) + "\n" + new string('-', 50));

            //вывод в файл историю звонков, историю изменения тарифов клиентами
            WriteHistoryOfCalls(path, station.ListOfCall, station.ListOfClient);
            Console.WriteLine("Data about clients and their calls were written in the file");

            WriteHistoryOfTariffes(path2, client1.HistoryOfTariffs, station.ListOfClient);
            Console.WriteLine("Data about changing history of tariffes of clients were written in the file");


            void DisplayMessageCall(string message) => Console.WriteLine(message);

            void DisplayMessageChangePortState(TelephoneStation station, AccountEventArgsPortState e) => Console.WriteLine(e.Message);

            void DisplayMessageChangeTariff(TelephoneStation station, AccountEventArgsTariff e) => Console.WriteLine(e.Message);

            //отчет по звонкам
            Console.WriteLine(new string('-', 50) + "\n" + new string('-', 50) + "\n");
            Console.WriteLine(new string(':', 50));
            Billing.GetCallReport(station.ListOfClient[0], station.ListOfCall);
            Console.WriteLine(new string(':', 50));
            Billing.GetCallReport(station.ListOfClient[1], station.ListOfCall);
            Console.WriteLine(new string(':', 50));
            Billing.GetCallReport(station.ListOfClient[2], station.ListOfCall);
            Console.WriteLine(new string(':', 50));
            Billing.GetCallReport(station.ListOfClient[3], station.ListOfCall);

            Console.WriteLine("\n" + new string('!', 50));
            Billing.GetCallReportOrder(station.ListOfClient[0], station.ListOfCall);
        }
                
        public static void WriteHistoryOfCalls(string path, List<Call> listOfCall, List<Client> listOfClient)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (listOfCall.Any())
                {
                    foreach (var client in listOfClient)
                    {
                        writer.WriteLine($"\nHistory of calls of client \"{client.Agreement.NumberOfAgreement}\":");
                        writer.WriteLine($"Client: {client.FirstName} {client.SecondName}");

                        foreach (var item in listOfCall)
                        {
                            if (item.Caller == client || item.Answerer == client)
                            {
                                writer.WriteLine($"Time of start of call: {item.TimeOfStartCall}. Time of finish of call: {item.TimeOfFinishCall}");
                            }
                        }
                    }
                }
            }
        }

        public static void WriteHistoryOfTariffes(string path2, List<Tariff> listOfTariff, List<Client> listOfClient)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                if (listOfTariff.Any())
                {
                    foreach (var client in listOfClient)
                    {
                        writer.WriteLine($"\nHistory of calls of client \"{client.Agreement.NumberOfAgreement}\":");
                        writer.WriteLine($"Client: {client.FirstName} {client.SecondName}");

                        foreach (var item in client.HistoryOfTariffs)
                        {
                            writer.WriteLine($"Tariff name: {item.TariffName}. Creation date: {item.CreationDate}");
                        }
                    }
                }
            }
        }
    }
}


