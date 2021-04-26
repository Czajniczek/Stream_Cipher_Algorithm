using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_Cipher
{
    public class StreamCipherService
    {
        public string LFSR_Generator(string input, string seed, string polynomial)
        {
            string output = "";
            //int counter = 0;
            //string score = "";

            for (int i = 0; i < input.Length; i++)
            {
                int counter = 0;
                string score = "";

                for (int j = 0; j < polynomial.Length; j++)
                {
                    if (seed[j] == '1' && polynomial[j] == '1') counter++;
                }

                if (counter % 2 == 0) score += '0';
                else score += '1';

                seed = seed.Substring(0, seed.Length - 1);
                score += seed;
                seed = score;

                output += score[0];
            }

            return output;
        }

        #region Synchronous_Stream_Cipher
        public string Synchronous_Stream_Cipher_Encode_Decode(string input, string seed, string polynomial)
        {
            string output = "";
            string LFSR = LFSR_Generator(input, seed, polynomial);

            for (int i = 0; i < input.Length; i++)
            {
                output += input[i] ^ LFSR[i]; //"^" - XOR
            }

            return output;
        }

        //public char XOR(char a, char b)
        //{
        //    return a == b ? '0' : '1';
        //}
        #endregion

        public string Ciphertext_Autokey_Encode(string input, string seed, string polynomial)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string score = "";
                int counter = 0;

                for (int j = 0; j < polynomial.Length; j++)
                {
                    if (seed[j] == '1' && polynomial[j] == '1') counter++;
                }

                counter = counter % 2;

                char origin = '\0';
                if (counter == 0) origin = '0';
                else origin = '1';

                seed = seed.Substring(0, seed.Length - 1);

                var output2 = Convert.ToInt32(input[i]) ^ Convert.ToInt32(origin);

                score += output2;
                score += seed;

                seed = score;

                output += output2;
            }

            return output;
        }

        public string Ciphertext_Autokey_Decode(string input, string seed, string polynomial)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                string score = "";
                int counter = 0;

                for (int j = 0; j < polynomial.Length; j++)
                {
                    if (seed[j] == '1' && polynomial[j] == '1') counter++;
                }

                counter = counter % 2;

                char origin = '\0';
                if (counter == 0) origin = '0';
                else origin = '1';

                seed = seed.Substring(0, seed.Length - 1);

                var output2 = Convert.ToInt32(input[i]) ^ Convert.ToInt32(origin);

                score += input[i];
                score += seed;

                seed = score;

                output += output2;
            }

            return output;
        }
    }
}
