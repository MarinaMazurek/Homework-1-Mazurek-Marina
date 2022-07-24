using System;
using System.Collections.Generic;
using System.Linq;

namespace HOMEWORK_5_Telephones
{
    public static class Billing
    {
               
        public static void GetCallReport(Client client, List<Call> listOfCall)
        {
            var reports = from x in listOfCall
                          where x.Caller == client || x.Answerer == client
                          select new
                          {
                              anotherAbonent = x.Caller == client
                                  ? x.Caller
                                  : x.Answerer,
                              OutputCall = x.Caller == client,
                              StartTalkTime = x.TimeOfStartCall,
                              EndCalltime = x.TimeOfFinishCall,
                              DurationOfCall = x.TimeOfFinishCall - x.TimeOfStartCall,
                              CostOfCall = x.Caller == client
                                  ? ((x.TimeOfFinishCall - x.TimeOfStartCall).TotalMinutes * client.Agreement.Tariff.CostOfMinute).ToString("n2")
                                  : "0"                                 
                          };
            Console.WriteLine("Call Report of client: \"{0}\"", client.Agreement.NumberOfAgreement);
            Console.WriteLine("Client: {0} {1}", client.FirstName, client.SecondName);
            Console.WriteLine("Number of phone: {0}", client.Terminal.PhoneNumber);
            Console.WriteLine(new string(':', 50));

            foreach (var call in reports.ToList())
            {
                Console.WriteLine("Abonent:{0}.\nTime of start call:{1}.\nTime of finish call:{2}.\nDuration of call:{3}.\nCost of call:{4}.\n", 
                    call.anotherAbonent.FirstName, call.StartTalkTime, call.EndCalltime, call.DurationOfCall, call.CostOfCall);
            }
        }


        public static void GetCallReportOrder(Client client, List<Call> listOfCall)
        {
            var reports = from x in listOfCall
                          where x.Caller == client
                          select new
                          {
                              Answerer = x.Answerer,
                              StartTalkTime = x.TimeOfStartCall,
                              EndCalltime = x.TimeOfFinishCall,
                              DurationOfCall = x.TimeOfFinishCall - x.TimeOfStartCall,
                              CostOfCall = ((x.TimeOfFinishCall - x.TimeOfStartCall).TotalMinutes * client.Agreement.Tariff.CostOfMinute).ToString("n2")
                          };

            Console.WriteLine("Client:{0}.\n", client.FirstName);
            Console.WriteLine("Sort by first name of answerer:");
            var sortedCallerByFirstName = reports.ToList().OrderBy(s => s.Answerer.FirstName);            

            foreach (var call in sortedCallerByFirstName)
            {                
                Console.WriteLine("Answerer:{0}.\nTime of start call:{1}.\nTime of finish call:{2}.\nDuration of call:{3}.\nCost of call:{4}.\n",
                    call.Answerer.FirstName, call.StartTalkTime, call.EndCalltime, call.DurationOfCall, call.CostOfCall);
            }

            Console.WriteLine("Sort by date of call:");
            var sortedCallerByDate = reports.ToList().OrderBy(s => s.StartTalkTime);

            foreach (var call in sortedCallerByDate)
            {
                Console.WriteLine("Answerer:{0}.\nTime of start call:{1}.\nTime of finish call:{2}.\nDuration of call:{3}.\nCost of call:{4}.\n",
                    call.Answerer.FirstName, call.StartTalkTime, call.EndCalltime, call.DurationOfCall, call.CostOfCall);
            }

            Console.WriteLine("Sort by cost of call:");
            var sortedCallerByCostOfCall = reports.ToList().OrderBy(s => s.CostOfCall);

            foreach (var call in sortedCallerByCostOfCall)
            {
                Console.WriteLine("Answerer:{0}.\nTime of start call:{1}.\nTime of finish call:{2}.\nDuration of call:{3}.\nCost of call:{4}.\n",
                    call.Answerer.FirstName, call.StartTalkTime, call.EndCalltime, call.DurationOfCall, call.CostOfCall);
            }
        }
    }
}
