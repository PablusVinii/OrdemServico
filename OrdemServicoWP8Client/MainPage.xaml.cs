using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrdemServicoWP8Client.Resources;
using OrdemServicoWP8Client.Classes.ObjectDomain;
using OrdemServicoWP8Client.Classes.Repository.Interface;
using OrdemServicoWP8Client.Classes.Repository;
using OrdemServicoWP8Client.Classes.Errors;
using OrdemServicoWP8Client.Classes.Utils;
using System.IO.IsolatedStorage;

namespace OrdemServicoWP8Client
{
    public partial class MainPage : PhoneApplicationPage
    {
        IAutenticacaoRepository autenticacaoRepository = null;

        bool primeiroClique = true;

        public MainPage()
        {
            InitializeComponent();           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
            if (!appSettings.Contains("urlWebService"))
            {
                this.NavigationService.Navigate(new Uri("/Modulos/Configuracoes/ConfigurarAplicacao.xaml?FirstTime=true", UriKind.Relative));
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {            
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.autenticacaoRepository = new AutenticacaoRepository();

                if (primeiroClique)
                {
                    DataBaseUtils.ImportarDados();
                }

                this.primeiroClique = false;

                try
                {
                    var username = txtNomeUsuario.Text.Trim();
                    var password = txtSenha.Password.Trim();
                    var salvarSenha = chkManterConectado.IsChecked != null ? true : false;

                    Usuario umUsuario = this.autenticacaoRepository.Login(username, password);
                    this.autenticacaoRepository.SalvarSenha(salvarSenha);

                    if (umUsuario != null)
                    {
                        this.NavigationService.Navigate(new Uri("/Modulos/Index.xaml", UriKind.Relative));
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha inválidos");
                    }
                }
                catch (Exception ex)
                {
                    Error.GerenciarErro(ex);
                }
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }
    }
}