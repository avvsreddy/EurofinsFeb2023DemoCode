namespace Delegates3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account();
            acc1.notify += Notification.SendEmail; // subscription
            acc1.notify += SmsNotification.SendSms;
            //acc1.Subscribe(Notification.SendEmail);

            //acc1.notify("Your account has been increased by $99999999999999999");
            //acc1.notify -= Notification.SendEmail;
            acc1.Deposit(5000);
            //System.Console.WriteLine(acc1.Balance);
            //acc1.Withdraw(1000);
            //System.Console.WriteLine(acc1.Balance);
        }
    }

    public delegate void Notify(string msg);


    public class Account
    {
        public int Balance { get; private set; }
        public event Notify notify;

        //public void Subscribe(Notify alert)
        //{
        //    notify += alert;
        //}
        //public void Unsubscribe(Notify alert)
        //{
        //    notify -= alert;
        //}
        public void Deposit(int amount)
        {
            Balance += amount;
            // write code to send email
            string msg = $"Your account has been increased by {amount}";
            //Notification.SendEmail(msg);
            if (notify != null)
                notify(msg);
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            string msg = $"Your account has been decreased by {amount}";
            //Notification.SendEmail(msg);
            if (notify != null)
                notify(msg);
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


    public class SmsNotification
    {
        public static void SendSms(string msg)
        {
            System.Console.WriteLine($"SMS: {msg}");
        }
    }
}
