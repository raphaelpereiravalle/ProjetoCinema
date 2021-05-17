using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ProjetoCinema.Core.Security
{
    public class SigningConfigurations
    {
        public string Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            Key = "WxejR7WN7KGVt08dvxr6AzMn8XRrJs3EYelZIoIkkHocddasdasdsaLsroLC95ivzAGDUSXw2qN1XiCOR5sVNEts8zS9v4ImxIl1cyzKrUpiVZGYKadI"; //Chave
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
