namespace Delegates3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account();
            acc1.Deposit(5000);
            //System.Console.WriteLine(acc1.Balance);
            acc1.Withdraw(1000);
            //System.Console.WriteLine(acc1.Balance);
        }
    }

    public class Account
    {
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            Balance += amount;
            // write code to send email
            string msg = $"Your account has been increased by {amount}";
            Notification.SendEmail(msg);
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            string msg = $"Your account has been decreased by {amount}";
            Notification.SendEmail(msg);
        }
    }

    public class Notification
    {
        public static void SendEmail(string msg)
        {
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = "smtp.gmail.com";
            //smtpClient.Port = 465;
            //smtpClient.Credentials = null;

            //MailMessage mail = new MailMessage();
            //mail.From = "";
            //mail.To = "";
            //mail.Subject = "";
            //mail.Body= msg;
            //mail.Attachments.Add("");

            //smtpClient.Send(mail);
            System.Console.WriteLine($"Mail: {msg}");



        }
    }
}
