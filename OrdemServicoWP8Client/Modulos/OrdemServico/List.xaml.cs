using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Dto = OrdemServicoWP8Client.Classes.ObjectDomain;
using OrdemServicoWP8Client.Classes.Utils;

namespace OrdemServicoWP8Client.Modulos.OrdemServico
{
    public partial class List : PhoneApplicationPage
    {
        public List()
        {
            InitializeComponent();
        }

        public Dto.OrdemServico OrdemServico { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Dto.OrdemServico> lista = new List<Dto.OrdemServico>();
            for (int i = 0; i < 10; i++)
            {
                Dto.OrdemServico os = new Dto.OrdemServico();
                os.Id = i;
                os.Cliente = new Dto.Cliente();
                os.Cliente.NomeReduzido = "Cliente " + i;
                os.Data = DateTime.Now;
                lista.Add(os);
            }

            lbOrdensServico.ItemsSource = lista;
            lbOrdensServico.SelectionChanged += lbOrdensServico_SelectionChanged;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Details page = e.Content as Details;

            if (page != null)
            {
                page.OrdemServico = this.OrdemServico;
            }
            lbOrdensServico.SelectionChanged -= lbOrdensServico_SelectionChanged;
        }

        private void lbOrdensServico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.OrdemServico = (sender as ListBox).SelectedItem as Dto.OrdemServico;
                this.NavigationService.Navigate(new Uri("/Modulos/OrdemServico/Details.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }
    }
}