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

        private void Generate_LFSR(object sender, RoutedEventArgs e)
        {
            string seed = LFSR_Seed.Text.ToString();
            string polynomial = LFSR_Polynomial.Text.ToString();

            LFSR_Output.Text = streamCipherService.LFSR_Generator(seed, polynomial);
        }

        private void Encode_Synchronous_Stream_Cipher(object sender, RoutedEventArgs e)
        {

        }

        private void Decode_Synchronous_Stream_Cipher(object sender, RoutedEventArgs e)
        {

        }

        private void Encode_Ciphertext_Autokey(object sender, RoutedEventArgs e)
        {

        }

        private void Decode_Ciphertext_Autokey(object sender, RoutedEventArgs e)
        {

        }
    }
}
