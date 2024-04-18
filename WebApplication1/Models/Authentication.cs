namespace WebApplication1.Models
{
    public class Authentication
    {
        public string Token { get; set; }
        public string AccessToken { get; set; }
        public string ErrorMessages { get; set; }

        public Authentication() { }
        public Authentication(string Token, string AccessToken, string ErrorMessages)
        {
            this.Token = Token;
            this.AccessToken = AccessToken;
            this.ErrorMessages = ErrorMessages;
        }
    }
}
