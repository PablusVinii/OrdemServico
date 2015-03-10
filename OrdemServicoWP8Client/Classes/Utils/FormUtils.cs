using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrdemServicoWP8Client.Classes.Utils
{
    public class FormUtils
    {
        public static void InternetDesconectada()
        {
            MessageBox.Show("Internet Desconectada. Aguarda até que a conexão seja reestabelecida ou encerre a aplicação.");
        }
    }
}
