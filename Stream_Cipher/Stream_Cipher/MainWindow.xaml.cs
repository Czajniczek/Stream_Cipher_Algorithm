using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stream_Cipher
{
    public partial class MainWindow : Window
    {
        private readonly StreamCipherService streamCipherService = new StreamCipherService();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region ZADANIE 1
        private void Generate_LFSR(object sender, RoutedEventArgs e)
        {
            string input = LFSR_Input.Text.ToString();
            string seed = LFSR_Seed.Text.ToString();
            string polynomial = LFSR_Polynomial.Text.ToString();

            LFSR_Output.Text = streamCipherService.LFSR_Generator(input, seed, polynomial);
        }
        #endregion

        #region ZADANIE 2
        private void Encode_Decode_Synchronous_Stream_Cipher(object sender, RoutedEventArgs e)
        {
            string input = Synchronous_Stream_Cipher_Input.Text.ToString();
            string seed = Synchronous_Stream_Cipher_Seed.Text.ToString();
            string polynomial = Synchronous_Stream_Cipher_Polynomial.Text.ToString();

            Synchronous_Stream_Cipher_Output.Text = streamCipherService.Synchronous_Stream_Cipher_Encode_Decode(input, seed, polynomial);
        }
        #endregion

        #region ZADANIE 3
        private void Encode_Ciphertext_Autokey(object sender, RoutedEventArgs e)
        {
            string input = Ciphertext_Autokey_Input.Text.ToString();
            string seed = Ciphertext_Autokey_Seed.Text.ToString();
            string polynomial = Ciphertext_Autokey_Polynomial.Text.ToString();

            Ciphertext_Autokey_Output.Text = streamCipherService.Ciphertext_Autokey_Encode(input, seed, polynomial);
        }

        private void Decode_Ciphertext_Autokey(object sender, RoutedEventArgs e)
        {
            string input = Ciphertext_Autokey_Input.Text.ToString();
            string seed = Ciphertext_Autokey_Seed.Text.ToString();
            string polynomial = Ciphertext_Autokey_Polynomial.Text.ToString();

            Ciphertext_Autokey_Output.Text = streamCipherService.Ciphertext_Autokey_Decode(input, seed, polynomial);
        }
        #endregion
    }
}
