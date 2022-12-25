using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfProjetoLuz
{
    /// <summary>
    /// Interaction logic for CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        public CadastroUsuario()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void Button_btnCadastrar(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, TextChangedEventArgs e)
        {
            //BindingExpression be = (sender as TextBox).GetBindingExpression(TextBox.TextProperty);
            //be.UpdateSource();
        }

        private void Button_btnLimpar(object sender, RoutedEventArgs e)
        {
            LimparTudo();
        }

        private void LimparTudo()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
        }
    }
}
