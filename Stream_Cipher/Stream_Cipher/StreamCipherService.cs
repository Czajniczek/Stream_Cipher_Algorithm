using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream_Cipher
{
    class StreamCipherService
    {
        public string LFSR_Generator(string seed, string polynomial)
        {
            string output = "";
            int counter = 0;
            string score = "";

            for (int i = 0; i < seed.Length; i++)
            {
                counter = 0;
                score = "";
                //string newSeed = seed;

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
    }
}
