using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json.Linq;
using AppGlobo.Entidades;

namespace AppGlobo.Pags
{
    public partial class ListaEstados : PhoneApplicationPage
    {
        CidadeClasse cidadesel;
        public ListaEstados()
        {
            InitializeComponent();
            LstEstados.ItemsSource = GetEstados();

        }
        private List<CidadeClasse> GetEstados()
        {
            string Json =
                Utilidades.Utils.ReadFile("Resources/Json/EstadoseCidades.json");
            return ParseJson(Json);

        }
        private List<CidadeClasse> ParseJson(String pJson)
        {
            //cria objeto para lista do tipo carro
            List<CidadeClasse> EstadosDoJson = new List<CidadeClasse>();
            if (pJson != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(pJson);
                //le a lista carros
                //CidadeClasse. = jobject["cidades"].ToObject<IList<string>>();
                //captura o array carro
                JArray EST = (JArray)jobject["estados"];
                //JArray CID = (JArray)jobject["cidades"];
                //IList<string> CID = EST.ToArray<IList<string>>();

                //percorre o array e parsa parse o nosso
                foreach (JObject item in EST)
                {
                    CidadeClasse estado = new CidadeClasse
                    {
                        nome = (string)item["nome"],
                        sigla = (string)item["sigla"],
                        cidades = item["cidades"].ToObject<List<string>>() 
                    };
                    EstadosDoJson.Add(estado);
                }
            }
            return EstadosDoJson;
        }

        

        private void SelectionEstado(object sender, SelectionChangedEventArgs e)
        {
            cidadesel = (sender as ListBox).SelectedItem as CidadeClasse;
            NavigationService.Navigate(new Uri("/Cidade.xaml", UriKind.Relative));
            
            
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            
            Cidade page = e.Content as Cidade;

            if (page != null)
            {
                page.City = cidadesel;
            }
            
        }

        
    }
}