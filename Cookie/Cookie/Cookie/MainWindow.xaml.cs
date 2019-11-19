using Cookie.Dados;
using Cookie.DAO;
using Cookie.Models;
using Microsoft.Win32;
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

namespace Cookie
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CadastarCookie cCookie = new CadastarCookie();
            cCookie.Show();
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            ListarCookies cookie = new ListarCookies();
            cookie.Show();
        }

        private void BtnArquivo_Importar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json) | *.json";
            if (openFileDialog.ShowDialog() == true)
            {
                Arquivo relatorio = new Arquivo();
                CookieDAO dao = new CookieDAO();
                foreach (CookieClass cafe in relatorio.lerJson(openFileDialog.FileName))
                {
                    dao.inserirCookie(cafe);
                }
            }
        }

        private void BtnArquivo_Exportar_Click(object sender, RoutedEventArgs e)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.gerarJson();
        }
    }
}
