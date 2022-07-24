namespace HOMEWORK_5_Telephones
{
    public class Terminal
    {
        public Port Port { get; set; }                
        public int PhoneNumber { get; set; }
        public bool IsOnCall { get; set; }
        public Terminal(Port port, int phoneNumber)
        {
            Port = port;
            PhoneNumber = phoneNumber;
        }      
    }
}
