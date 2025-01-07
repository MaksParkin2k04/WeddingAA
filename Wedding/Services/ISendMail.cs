namespace Wedding.Services
{
    public interface ISendMail  {
        public Task SendMessage(string message);
    }
}
