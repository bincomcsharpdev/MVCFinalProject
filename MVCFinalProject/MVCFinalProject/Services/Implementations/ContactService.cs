using MVCFinalProject.Email;
using MVCFinalProject.Interfaces;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IContactMessageRepository _repository;
        private readonly IEmailService _emailService;

        public ContactService(IContactMessageRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }


        public async Task HandleContactMessageAsync(YahyContactMessage message)
        {
            await _repository.AddMessageAsync(message);

            string emailBody = $@"
    <html>
        <body style='font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f4f4f4;'>
            <table align='center' cellpadding='0' cellspacing='0' width='600' 
                   style='border-collapse: collapse; background-color: white;'>
                <tr>
                    <td align='center' style='padding: 40px 0; background-color: #007bff;'>
                        <h1 style='color: white; margin: 0;'>You've Got a Message!</h1>
                    </td>
                </tr>
                <tr>
                    <td style='padding: 20px;'>
                        <h2 style='color: #333;'>Hello,</h2>
                        <p style='font-size: 16px; color: #555;'>
                            You have received a new message from <b>{message.Email}</b> with the following content:
                        </p>
                        <p style='font-size: 16px; padding: 10px; background-color: #f9f9f9; border-left: 4px solid #007bff;'>
                            {message.Message}
                        </p>
                    </td>
                </tr>
                <tr>
                    <td style='padding: 20px;'>
                        <h3 style='color: #333;'>Message Details</h3>
                        <ul style='font-size: 16px; color: #555; list-style: none; padding: 0;'>
                            <li><strong>Email:</strong> {message.Email}</li>
                            <li><strong>Subject:</strong> {message.Subject}</li>
                            <li><strong>Date:</strong> {DateTime.UtcNow.ToString("f")}</li>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td align='center' style='padding: 20px; background-color: #f4f4f4;'>
                        <p style='font-size: 14px; color: #777;'>
                            Thank you for reaching out! We'll get back to you shortly.
                        </p>
                    </td>
                </tr>
            </table>
        </body>
    </html>";

            await _emailService.SendEmailAsync(
                message.Email, 
                message.Subject,
                emailBody
            );
        }



       
        //    adefolarin.adeniji+bincom@gmail.com
       
    }
}
