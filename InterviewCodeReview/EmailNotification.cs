using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCodeReview
{
    public interface INotificationService
    {
        void SendNotification(string email, char[] subject, string body, Int64 notificationType);  
    }

    public class emailNotificationService : INotificationService
    {
        public static string Host;
        public static int Port;

        public emailNotificationService(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public void SendNotification(string email, char[] subject, string body, Int64 notificationType)
        {
            SmtpClient client = new SmtpClient(Host, Port);
            var from = string.Empty;

            switch (notificationType)
            {
                case 1:
                    from = "admin";
                    break;
                case 2:
                    from = "support";
                    break;
                case 3: 
                    from = "billing";
                    break;
            }

            from = from + "@testapp.com";

            try
            {
                client.Send(from, email, new string(subject), body);
            }
            catch(Exception ex)
            {
                LogHelper.LogError(ex);
                throw ex;
            }
        }
    }
}
