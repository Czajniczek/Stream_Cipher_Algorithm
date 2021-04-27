using NUnit.Framework;
using Stream_Cipher;

namespace Stream_Cipher_Tests
{
    public class StreamCipherServiceTests
    {
        private StreamCipherService streamCipherService;

        [SetUp]
        public void Setup()
        {
            streamCipherService = new StreamCipherService();
        }

        #region ZADANIE 2
        [TestCase("11101001", "0010", "1001", "10010011")]
        [TestCase("11101001", "0011", "0110", "01010000")]
        [TestCase("1101011011001100", "110011", "101101", "1100001111110011")]
        [TestCase("1001111111110101", "0110110", "1111000", "1010111001111001")]
        [TestCase("1100111100110110", "10101110", "11100001", "1101000101000000")]
        public void Synchronous_Stream_Cipher_Encode(string input, string seed, string polynomial, string output)
        {
            var result = streamCipherService.Synchronous_Stream_Cipher_Encode_Decode(input, seed, polynomial);

            Assert.AreEqual(output, result);
        }

        [TestCase("11101001", "0010", "1001", "10010011")]
        [TestCase("11101001", "0011", "0110", "01010000")]
        [TestCase("1101011011001100", "110011", "101101", "1100001111110011")]
        [TestCase("1001111111110101", "0110110", "1111000", "1010111001111001")]
        [TestCase("1100111100110110", "10101110", "11100001", "1101000101000000")]
        public void Synchronous_Stream_Cipher_Decode(string output, string seed, string polynomial, string input)
        {
            var result = streamCipherService.Synchronous_Stream_Cipher_Encode_Decode(input, seed, polynomial);

            Assert.AreEqual(output, result);
        }
        #endregion

        #region ZADANIE 3
        [TestCase("11101001", "0011", "1001", "00110011")]
        [TestCase("11101001", "0011", "0110", "01111000")]
        [TestCase("1101011011001100", "110011", "101101", "1001110010111100")]
        [TestCase("1001111111110101", "0110110", "1111000", "1110011100110110")]
        [TestCase("1100111100110110", "10101110", "11100001", "1011110000001111")]
        public void Ciphertext_Autokey_Encode(string input, string seed, string polynomial, string output)
        {
            var result = streamCipherService.Ciphertext_Autokey_Encode(input, seed, polynomial);

            Assert.AreEqual(output, result);
        }

        [TestCase("00110011", "0011", "1001", "11101001")]
        [TestCase("01111000", "0011", "0110", "11101001")]
        [TestCase("1001110010111100", "110011", "101101", "1101011011001100")]
        [TestCase("1110011100110110", "0110110", "1111000", "1001111111110101")]
        [TestCase("1011110000001111", "10101110", "11100001", "1100111100110110")]
        public void Ciphertext_Autokey_Decode(string input, string seed, string polynomial, string output)
        {
            var result = streamCipherService.Ciphertext_Autokey_Decode(input, seed, polynomial);

            Assert.AreEqual(output, result);

        }
        #endregion
    }
}