namespace RoverCommandService
{
    public interface IRoverCommandReceiver
    {
        void ReceiveCommands(char[] commands);
    }
}
