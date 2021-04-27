using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_Cipher
{
    public class StreamCipherService
    {
        #region ZADANIE 1
        public string LFSR_Generator(string input, string seed, string polynomial)
        {
            string output = "", row;
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < polynomial.Length; j++)
                {
                    if (seed[j] == '1' && polynomial[j] == '1') counter++;
                }

                if (counter % 2 == 0) row = "0";
                else row = "1";

                row += seed.Substring(0, seed.Length - 1);
                seed = row;
                counter = 0;

                output += row[0];
            }

            return output;
        }
        #endregion

        #region ZADANIE 2
        public string Synchronous_Stream_Cipher_Encode_Decode(string input, string seed, string polynomial)
        {
            string output = "", LFSR = LFSR_Generator(input, seed, polynomial);

            for (int i = 0; i < input.Length; i++)
            {
                output += input[i] ^ LFSR[i];
            }

            return output;
        }
        #endregion

        #region ZADANIE 3
        public string Ciphertext_Autokey_Encode(string input, string seed, string polynomial)
        {
            return Ciphertext_Autokey(input, seed, polynomial, "encode");
        }

        public string Ciphertext_Autokey_Decode(string input, string seed, string polynomial)
        {
            return Ciphertext_Autokey(input, seed, polynomial, "decode");
        }

        public string Ciphertext_Autokey(string input, string seed, string polynomial, string choose)
        {
            string output = "", row = "";
            char origin;
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < polynomial.Length; j++)
                {
                    if (seed[j] == '1' && polynomial[j] == '1') counter++;
                }

                if (counter % 2 == 0) origin = '0';
                else origin = '1';

                int xor = input[i] ^ origin;

                if (choose == "encode") row += xor;
                else row += input[i];

                seed = seed.Substring(0, seed.Length - 1);
                row += seed;
                seed = row;
                row = "";
                counter = 0;

                output += xor;
            }

            return output;
        }
        #endregion
    }
}
