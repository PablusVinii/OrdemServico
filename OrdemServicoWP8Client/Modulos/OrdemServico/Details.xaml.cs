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
using OrdemServicoWP8Client.Resources;
using OrdemServicoWP8Client.Classes.Utils;

namespace OrdemServicoWP8Client.Modulos.OrdemServico
{
    public partial class Details : PhoneApplicationPage
    {
        public Dto.OrdemServico OrdemServico { get; set; }

        public Details()
        {
            InitializeComponent();
            InitializeApplicationBar();
        }

        /// <summary>
        ///     O componente ApplicationBar não permite localização em modo Design, portanto
        /// foi necessário realizar o procedimento em tempo de execução.
        /// </summary>
        /// <see cref="http://www.braincastexception.com/wp7-localization-application-bar/"/>
        private void InitializeApplicationBar()
        {
            ApplicationBar = new ApplicationBar
            {
                IsVisible = true,
                IsMenuEnabled = false
            };

            var editButton = new ApplicationBarIconButton();
            editButton.Text = AppResources.EditButton;
            editButton.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative);
            editButton.Click += Editar_Click;

            var deleteButton = new ApplicationBarIconButton();
            deleteButton.Text = AppResources.DeleteButton;
            deleteButton.IconUri = new Uri("/Toolkit.Content/ApplicationBar.Delete.png", UriKind.Relative);
            deleteButton.Click += Excluir_Click;
            
            ApplicationBar.Buttons.Add(editButton);
            ApplicationBar.Buttons.Add(deleteButton);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.OrdemServico != null)
            {
                this.myPartialDetails.OrdemServico = this.OrdemServico;
            }
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                MessageBox.Show("Excluindo");
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }

        private void Editar_Click(object sender, EventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.NavigationService.Navigate(new Uri("/Modulos/OrdemServico/Edit.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }
    }
}