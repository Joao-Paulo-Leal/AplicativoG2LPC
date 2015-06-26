using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using AppGlobo.Entidades;
using AppGlobo.Pags;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Microsoft.Phone.Net.NetworkInformation;

namespace AppGlobo
{
    public partial class Cidade : PhoneApplicationPage
    {
        public CidadeClasse City;
        public string Estate;
        public string NomeDaCidade;
        
        public Cidade()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
            InitializeComponent();
            CarregarImagem();
            }
            else
                MessageBox.Show("Por favor, ative sua conexão de dados.");
        
        }

        private void CarregarImagem()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                ImageSource imgSource = new BitmapImage(new Uri("/Icons/concurso.png", UriKind.Relative));
                imgThumb.Source = imgSource;
            });
        }
        private void BtnConfirmaCidade_Click(object sender, RoutedEventArgs e)
        {
            
            //Cria um objeto da classe IsolatedStorageSettings para armazenamento das chaves
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            
            if ((bool)ckbLembrar.IsChecked)
            {
                //É necessário perguntar se a chave já existe para evitar que se crie chaves duplicadas, o que fatalmente irá provocar erros
                if (iso.Contains("login.Cidade")) //Apenas atualiza os valores das chaves
                {
                    iso["login.Cidade"] = TxtCidade.Text;
                    iso["login.Uf"] = TxtUf.Text;
                }
                else //Cria novas chaves
                {
                    iso.Add("login.Cidade", TxtCidade.Text);
                    iso.Add("login.Uf", TxtUf.Text);
                }
                iso.Save(); //Necessário para armazenar os valores das chaves
            }
            else
            {
                //Caso o usuário não queira mais armazenar suas credenciais, podemos remover as chaves
                if (iso.Contains("login.Cidade"))
                {
                    iso.Remove("login.Cidade");
                    iso.Remove("login.Uf");
                }
            }
            //Direciona o usuário para uma página qualquer, caso ele acerte o login
            //NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.Navigate(new Uri("/PaginaInicial.xaml", UriKind.Relative));

        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            while (NavigationService.BackStack.Any())
            {
                NavigationService.RemoveBackEntry();
            }
            base.OnBackKeyPress(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            string cidadeS, ufS;
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            BtnConfirmaCidade.IsEnabled = false;
            if (iso.TryGetValue<string>("login.Uf", out ufS))
                TxtUf.Text = ufS;
            
            if (iso.TryGetValue<string>("login.Cidade", out cidadeS))
            {
                
                TxtCidade.Text = cidadeS;
                ckbLembrar.IsChecked = true;
                
            }
            
            
            if (City != null || TxtUf != null)
            {
                if (City != null) 
                { 
                TxtUf.Text = City.sigla;
                TxtCidade.Text = "";
                }
                
                TxtCidade.Visibility = System.Windows.Visibility.Visible;
                TxtCidadeBlock.Visibility = System.Windows.Visibility.Visible;
                if (NomeDaCidade != null || TxtCidade != null)
                {
                    
                    if (NomeDaCidade != null)
                    {
                        TxtCidade.Text = NomeDaCidade;
                        
                    }
                    if (TxtCidade.Text != "")
                    {
                        BtnConfirmaCidade.IsEnabled = true;
                    }
                    

                }
            }    
        }
       
            
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            
            
            ListaCid pageCid = e.Content as ListaCid;

            if (pageCid != null)
            {
                pageCid.NC = City;
            }
            PaginaInicial pageInit = e.Content as PaginaInicial;
            if (pageInit != null)
            {
                pageInit.cidade = TxtCidade.Text;
                pageInit.uf = TxtUf.Text;
            }


        }
        //Tap para os textos
        private void TxtEstado_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pags/ListaEstados.xaml", UriKind.Relative));
        }

        private void TxtCidade_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pags/ListaCid.xaml", UriKind.Relative));
            
        }
        
    }
}