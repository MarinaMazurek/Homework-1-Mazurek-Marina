namespace HOMEWORK_5_Telephones
{
    public class Port
    {       
        public PortState PortState { get; set; }        
        public Port(PortState portState)
        {
            PortState = portState;
        }              
    }

    public enum PortState
    {
        Connected,
        Disconnected
    }
}
