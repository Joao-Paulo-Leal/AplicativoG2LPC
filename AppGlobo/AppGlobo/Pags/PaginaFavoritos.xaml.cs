using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppGlobo.Entidades;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;

namespace AppGlobo.Pags
{
    
    public partial class PaginaFavoritos : PhoneApplicationPage
    {
        Favoritos favorito;
        public PaginaFavoritos()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Reflesh();
            CarregarImagem();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Navegador page = e.Content as Navegador;
            if (page != null)
            {
                page.rssC = favorito;
            }

        }
        private void appBarMais_Click(object sender, EventArgs e)
        {
            
            
            try
            {
            
            NavigationService.Navigate(new Uri("/Pags/Navegador.xaml", UriKind.Relative));
                //Função desativada, antes navegava para o navegador do celular
            /*
            WebBrowserTask wb = new WebBrowserTask();

            wb.Uri = new Uri(favorito.linkB, UriKind.Absolute);
            wb.Show();
            */
            }catch (Exception)
            {
                MessageBox.Show("Ops nada selecionado");
            }
        }
        private void CarregarImagem()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                ImageSource imgSource = new BitmapImage(new Uri("/Icons/icone.png", UriKind.Relative));
                imgThumb.Source = imgSource;
            });
        }
        private void Reflesh()
        {
            List<Favoritos> fav = Repositorio.Repositorio.Get();
            listFAVORITOS.ItemsSource = fav;
        }

        private void appBarDeletar_Click(object sender, EventArgs e)
        {
            try { 
            if (favorito != null)
            {
                if (MessageBox.Show("Excluir o Concurso ?") == MessageBoxResult.OK)
                {
                    Repositorio.Repositorio.Delete(favorito);
                    Reflesh();
                    MessageBox.Show("Concurso Excluido");
                }
                else
                    MessageBox.Show("Ufa Tche");
            }
            else
            {
                MessageBox.Show("Ops nada selecionado");
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Ops nada selecionado");
            }
        }

        private void onSelecioChange(object sender, SelectionChangedEventArgs e)
        {
            favorito = (sender as ListBox).SelectedItem as Favoritos;
        }
    }
}