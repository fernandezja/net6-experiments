// See https://aka.ms/new-console-template for more information
using MimeKit.Text;
using MimeKit;

Console.WriteLine("Send email with MimeKit + MailKit!");

var from = new MailboxAddress(name: "Demo From", address: "...@outlook.com");
var to = new MailboxAddress(name: "Demo To", address: "...@gmail.com");


var msj = new MimeMessage();
msj.From.Add(from);
msj.To.Add(to);
msj.Subject = "Episode IV";
msj.Body = new TextPart(TextFormat.Html)
{
    Text = "Starwars!"
};

var client = new MailKit.Net.Smtp.SmtpClient();

client.Connect(host: "smtp.office365.com",
               port: 587,
               options: MailKit.Security.SecureSocketOptions.StartTls);

//https://support.microsoft.com/es-es/account-billing/uso-de-contrase%C3%B1as-de-la-aplicaci%C3%B3n-con-aplicaciones-que-no-admiten-la-verificaci%C3%B3n-en-dos-pasos-5896ed9b-4263-e681-128a-a6f2979a7944
client.Authenticate("....@outlook.com", "!#$%&");

client.Send(msj);

client.Disconnect(true);
