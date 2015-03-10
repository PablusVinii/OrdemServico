using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrdemServicoWP8Client.Classes.Utils;

namespace OrdemServicoWP8Client.Modulos.OrdemServico
{
    public partial class PivotOrdemServico : PhoneApplicationPage
    {
        public PivotOrdemServico()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.NavigationService.Navigate(new Uri("/Modulos/OrdemServico/List.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }
    }
}