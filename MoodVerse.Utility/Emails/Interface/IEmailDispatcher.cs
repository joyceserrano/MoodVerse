namespace MoodVerse.Utility.Emails.Interface
{
    public interface IEmailDispatcher
    {
        Task SendAsync(string subject, string content);
    }
}
