using Cookie.DAO;
using Cookie.Models;
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
using System.Windows.Shapes;

namespace Cookie
{
    /// <summary>
    /// Lógica interna para CadastarCookie.xaml
    /// </summary>
    public partial class CadastarCookie : Window
    {
        public CadastarCookie()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CookieClass cookie = new CookieClass()
            {
                Sabor = txtSabor.Text,
                Valor = Convert.ToDecimal(txtValor.Text)
            };

            CookieDAO dao = new CookieDAO();
            dao.inserirCookie(cookie);
            MessageBox.Show("cookie cadastrado com sucesso!!");
            txtSabor.Clear();
            txtValor.Clear();
        }
    }
}
