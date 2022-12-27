namespace MediatorDesignPattern.Abstract
{
    public interface IMediator
    {
        public void SignIn(User baseUser);

        public void SendMessage(string sebder, string receiver, string message);
    }
}
