using System;

namespace HOMEWORK_5_Telephones
{
    public class Call
    {       
        public Client Caller { get; set; }
        public Client Answerer { get; set; }
        public DateTime TimeOfStartCall { get; set; }
        public DateTime TimeOfFinishCall { get; set; }
        public bool IsStartTalk { get; set; }
        
        public double CalculateDurationOfCall(DateTime timeStart, int durationOfCall)
        {
            var finishTime = timeStart.AddSeconds(durationOfCall); 

            return finishTime.Subtract(timeStart).TotalSeconds;
        }

        public void StartCall()
        {
            TimeOfStartCall = DateTime.Now.AddSeconds(new Random().Next(500));
        }

        public void EndCall(DateTime value)
        {
            TimeOfFinishCall = value;
        }
    }
}
