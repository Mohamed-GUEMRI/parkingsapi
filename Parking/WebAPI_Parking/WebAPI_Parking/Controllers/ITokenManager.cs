namespace WebAPI_Parking.Controllers
{
    internal interface ITokenManager
    {
        bool Authentificate(string user, string pswd);
        bool VerifyToken(string token);

        public Token NewToken();
    }
}