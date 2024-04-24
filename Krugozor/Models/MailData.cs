namespace Krugozor.Models
{
    public class MailData
    {
            // Receiver
            public string To { get; }

            // Sender
            public string? From { get; }

            public string? DisplayName { get; }


            // Content
            public string Subject { get; }

            public string? Body { get; set; }

            public MailData(
                string to,
                string subject,
                string? body = null,
                string? from = null,
                string? displayName = null
            )
            {
                // Receiver
                To = to;

                // Sender
                From = from;
                DisplayName = displayName;

                // Content
                Subject = subject;
                Body = body;
            }
        }
    
}
