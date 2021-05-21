using ControleFinanceiro.Domain.Services.Contracts;
using ControleFinanceiro.Domain.ValueObjects;
using ControleFinanceiro.Shared;
using Vonage;
using Vonage.Request;

namespace ControleFinanceiro.Infra.Services
{
    public class SmsService : ISmsService
    {

        private readonly Credentials _credentials;
        private readonly VonageClient _vonageClient;
        
        public SmsService()
        {
            _credentials = Credentials.FromApiKeyAndSecret(
                Settings.ApiKeyVonage,
                Settings.SecretVonage
                );

            _vonageClient = new VonageClient(_credentials);
        }

        public void Send(Phone to, string message)
        {
            var response = _vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = to.ToString(),
                From = "ControleFin",
                Text = message
            });
        }
    }
}
