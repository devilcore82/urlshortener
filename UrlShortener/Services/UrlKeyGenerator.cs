using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace UrlShortener.Services
{
    public class UrlKeyGenerator : IUrlKeyGenerator
    {
        public const int KeyLength = 7;
        //private static char[] upperCaseChars = Enumerable.Range('A', 26).Select(x => (char)x).ToArray();
        //private static char[] lowerCaseChars = Enumerable.Range('a', 26).Select(x => (char)x).ToArray();
        //private static char[] numbers = Enumerable.Range('0', 9).Select(x => (char)x).ToArray();
        //private static char[] validCharacters = upperCaseChars.Concat(lowerCaseChars).Concat(numbers).ToArray();

        private static char[] validCharacters = Enumerable.Range('A', 26)
                          .Concat(Enumerable.Range('a', 26))
                          .Concat(Enumerable.Range('0', 10)).Select(x => (char)x).ToArray();
      

        public string Generate()
        {
            var charsToReturn = new char[KeyLength];
            var currentIndex = 0;

            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                while (currentIndex < KeyLength)
                {
                    byte[] randomBytes = new byte[KeyLength];
                    rngCryptoServiceProvider.GetBytes(randomBytes);

                    foreach (var b in randomBytes)
                    {
                        var c = Convert.ToChar(b);

                        if(!validCharacters.Contains(c)) { continue; }

                        charsToReturn[currentIndex] = c;
                        currentIndex++;

                        if(currentIndex == KeyLength) { break; }
                    }
                }

                return new string(charsToReturn);
            }
        }
    }
}
