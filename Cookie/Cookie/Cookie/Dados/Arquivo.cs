using Cookie.DAO;
using Cookie.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cookie.Dados
{
    public class Arquivo
    {
        public void gerarJson()
        {
            CookieDAO cdao = new CookieDAO();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CookieClass>));
            diretorioExiste();
            FileStream fs = new FileStream(@"C:\Cookie\cookie.json", FileMode.OpenOrCreate);
            ser.WriteObject(fs, cdao.listarCookie());
            fs.Close();
            MessageBox.Show("Arquivo criado !! - C:\\Cookie\\cookie.json");
        }

        public List<CookieClass> lerJson(String FileName)
        {
            List<CookieClass> cafes = new List<CookieClass>();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CookieClass>));
            FileStream fs = new FileStream(@FileName, FileMode.OpenOrCreate);
            cafes = (List<CookieClass>)ser.ReadObject(fs);
            fs.Close();
            return cafes;
        }
        private void diretorioExiste()
        {
            string diretorio = @"C:\Cookie";

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);

            }

        }
    }
}
