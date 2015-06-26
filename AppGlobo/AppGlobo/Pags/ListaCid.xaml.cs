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

namespace AppGlobo.Pags
{   
   
    public partial class ListaCid : PhoneApplicationPage
    {
        public CidadeClasse NC;
        string C;
        
        public ListaCid()
        {
            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try { 
            if (NC != null)
            {
                LstCidades.ItemsSource = NC.cidades;  
            }
            else
            {

                MessageBox.Show("Escolha Novamente um estado");
                NavigationService.Navigate(new Uri("/Cidade.xaml", UriKind.Relative));
                Cidade pageTC = e.Content as Cidade;

                if (pageTC != null)
                {
                    pageTC.TxtCidade.Text = "";
                }
            }
                
            }
            catch
            {
                MessageBox.Show("Ops algo errado recarregue o aplicativo");
            }
                  
        }

        private void SelectionEstado(object sender, SelectionChangedEventArgs e)
        {
            C = (sender as ListBox).SelectedItem as string;
            NavigationService.Navigate(new Uri("/Cidade.xaml", UriKind.Relative));
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Cidade page = e.Content as Cidade;

            if (page != null)
            {
                page.NomeDaCidade = C;
                page.City = NC;
            }
        }
    }
}