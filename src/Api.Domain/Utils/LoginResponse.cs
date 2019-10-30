namespace Api.Domain.Utils
{
    public class LoginResponse
    {
        public bool authenticated { get; set; }
        public string message { get; set; }
        public string created { get; set; }
        public string expiration { get; set; }
        public string acessToken { get; set; }
        public string userName { get; set; }
        public int sessionId { get; set; }
    }
}