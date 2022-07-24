using System;
using System.Collections.Generic;
using System.Linq;

namespace HOMEWORK_5_Telephones
{
    public class TelephoneStation
    {
        public List<Client> ListOfClient = new List<Client>();

        public List<Call> ListOfCall = new List<Call>();

        public List<Tariff> ListOfCostOfTariff = new List<Tariff>();

        public List<Tariff> HistoryOfTariffs = new List<Tariff>();

        //изменение тарифа клиентом
        public delegate void ChangeTariffHandler(TelephoneStation sender, AccountEventArgsTariff e);
        public event ChangeTariffHandler? NotifyChangeTariff;

        public void ChangeTariff(Client client, Tariff newTariff)
        {
            if ((DateTime.Now.Month - client.Agreement.DateOfAgreement.Month) >= 1
                && ((31 - client.Agreement.DateOfAgreement.Day + 1) + (DateTime.Now.Day)) >= 31)
            {
                client.HistoryOfTariffs.Add(client.Agreement.Tariff);
                client.Agreement.Tariff = newTariff;
                NotifyChangeTariff?.Invoke(this, new AccountEventArgsTariff($"Tariff of client \"{client.Agreement.NumberOfAgreement}\" was changed. \nNew tariff is \"{newTariff.TariffName}\". " +
                    $"\nTime of change of tariff: {DateTime.Now}.\n", "", DateTime.Now));
            }
            else
            {
                Console.WriteLine("Уou can change the tariff once a month.");
            }
        }

        //подключение / отключение порта клиентом
        public delegate void ChangePortStateHandler(TelephoneStation sender, AccountEventArgsPortState e);
        public event ChangePortStateHandler? NotifyChangePortState;

        public void ChangePortState(Client client)
        {
            if (client.Terminal.Port.PortState == PortState.Connected)
            {
                client.Terminal.Port.PortState = PortState.Disconnected;
                NotifyChangePortState?.Invoke(this, new AccountEventArgsPortState($"\nPort state of client \"{client.Agreement.NumberOfAgreement}\" was changed. " +
                    $"\nNew port state is \"{client.Terminal.Port.PortState}\". \nTime of change of port state: {DateTime.Now}.", "", DateTime.Now));
            }
            else if (client.Terminal.Port.PortState == PortState.Disconnected)
            {
                client.Terminal.Port.PortState = PortState.Connected;
                NotifyChangePortState?.Invoke(this, new AccountEventArgsPortState($"\nPort state \"{client.Agreement.NumberOfAgreement}\" was changed. " +
                    $"\nNew port state is \"{client.Terminal.Port.PortState}\". \nTime of change of port state: {DateTime.Now}.", "", DateTime.Now));
            }
        }

        public delegate void AccountHandlerCall(string message);
        public event AccountHandlerCall NotifyCall;

        public void CallTo(Client caller, Client answerer)
        {
            Call call = new Call();

            call.Caller = caller;
            call.Answerer = answerer;

            caller.Terminal.IsOnCall = true;
            answerer.Terminal.IsOnCall = true;

            call.StartCall();
            var timeStart = call.TimeOfStartCall;

            if (!IsFree(caller, timeStart) || !IsFree(answerer, timeStart))
            {
                NotifyCall?.Invoke("ATTENTION!!!\nThe call is not possible. This line is busy!");
                return;
            }

            var durationOfCall = call.CalculateDurationOfCall(timeStart, new Random().Next(500));
            call.EndCall(timeStart.AddSeconds(durationOfCall));
            ListOfCall.Add(call);

            NotifyCall?.Invoke($"CALLING !!!\nCall is from {caller.FirstName} to {answerer.FirstName}:\nTimeStart: {timeStart}\nFinishTime: {call.TimeOfFinishCall}");

            var costOfCall = CostOfCall(caller, durationOfCall);
            NotifyCall?.Invoke($"Cost of call: {costOfCall}");

            caller.ListOfCostOfCall.Add(costOfCall);
        }

        //стоимость звонка
        public double CostOfCall(Client client, double durationOfCall)
        {
            var cost = durationOfCall * client.Agreement.Tariff.CostOfMinute;
            return Math.Round(cost, 2);
        }

        //проверка занят ли абонент
        public bool IsFree(Client client, DateTime startOfCall)
        {
            var calls = ListOfCall.Where(x => x.Answerer == client || x.Caller == client).Select(x => x).ToList();

            foreach (var item in calls)
            {
                if (startOfCall < item.TimeOfFinishCall && startOfCall > item.TimeOfStartCall)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class AccountEventArgsPortState
    {
        public string Message { get; }
        public string PortState { get; }
        public AccountEventArgsPortState(string message, string portState, DateTime dateTime)
        {
            Message = message;
            PortState = portState;
        }
    }

    public class AccountEventArgsTariff
    {
        public string Message { get; }
        public string Tariff { get; }
        public AccountEventArgsTariff(string message, string tariff, DateTime dateTime)
        {
            Message = message;
            Tariff = tariff;
        }
    }
}
