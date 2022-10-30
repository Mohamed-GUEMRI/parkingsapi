using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI_Parking.Controllers
{
    public class TokenManager : ITokenManager
    {
        private List<Token> _tokens;
        public TokenManager()
        {
            _tokens = new List<Token>();
        }

        public bool Authentificate(string user, string pswd)
        {
            if (user == "admin" && pswd == "password")
                return true;
            return false;
        }

        public Token NewToken()
        {
            var token = new Token {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddMinutes(10)
            };
            _tokens.Add(token);
            return token;
        }

        public bool VerifyToken(string Token)
        {
            if (_tokens.Any(x => x.Value == Token && x.ExpiryDate > DateTime.Now))
                return true;
            return false;
        }

       
    }
}