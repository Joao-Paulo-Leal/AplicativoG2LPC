using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Xml.Linq;
using AppGlobo.Pags;
using AppGlobo.Entidades;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace AppGlobo
{
    public partial class PaginaInicial : PhoneApplicationPage
    {
        RssGlobo rss;
        public string cidade;
        public string uf;
        Previsao CidadeDoJson = null;
        IList<Previso> PrevisaoDoJson = null;
        public PaginaInicial()
        {
            InitializeComponent();
        }
        private void LoadPivot(object sender, PivotItemEventArgs e)
        {
            if (e.Item == concursos)
            {
                ApplicationBarIconButton appBarMais_Click = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                appBarMais_Click.IsEnabled = true;
                ApplicationBarIconButton appBarSobre_Save = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                appBarSobre_Save.IsEnabled = true;
                CarregaConcurso();
            }

            if (e.Item == agora)
            {
                ApplicationBarIconButton appBarMais_Click = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                appBarMais_Click.IsEnabled = false;
                ApplicationBarIconButton appBarSobre_Save = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                appBarSobre_Save.IsEnabled = false;
                try 
                {
                    CarregaAgora();
                }
                catch
                {
                    MessageBox.Show("Espere um pouco, esta carregando.\nPasse A Pagina para recarregar.");
                }

            }
            if (e.Item == PrevisaoPivot)
            {
                ApplicationBarIconButton appBarMais_Click = (ApplicationBarIconButton)ApplicationBar.Buttons[0];
                appBarMais_Click.IsEnabled = false;
                ApplicationBarIconButton appBarSobre_Save = (ApplicationBarIconButton)ApplicationBar.Buttons[1];
                appBarSobre_Save.IsEnabled = false;
                try 
                {
                    CarregaPrevisão();
                }
                catch
                {
                    MessageBox.Show("Espere um pouco, esta carregando.\nPasse A Pagina para recarregar.");
                }
            }
        }
        void CarregaAgora()
        {
            TxtCidadeAgora.Text = CidadeDoJson.cidade;
            TxtDataAgora.Text = CidadeDoJson.data_hora;
            TxtDescricaoAgora.Text = CidadeDoJson.descricao;
            TxtNascerAgora.Text = CidadeDoJson.nascer_do_sol;
            TxtPorAgora.Text = CidadeDoJson.por_do_sol;
            TxtPressaoAgora.Text = CidadeDoJson.pressao;
            TxtPressaoStatusAgora.Text = CidadeDoJson.pressao_status;
            TxtTemperaturaAgora.Text = CidadeDoJson.temperatura;
            TxtUmidadeAgora.Text = CidadeDoJson.umidade;
            TxtVendoDirecaoAgora.Text = CidadeDoJson.vento_direcao;
            TxtVentoVelocidadeAgora.Text = CidadeDoJson.vento_velocidade;
            TxtVisibilidadeAgora.Text = CidadeDoJson.visibilidade;
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                ImageSource ImgT = new BitmapImage(new Uri(CidadeDoJson.imagem, UriKind.Absolute));
                ImgTempoAgora.Source = ImgT;
            });
        }
        void CarregaPrevisão()
        {
            for (int i = 0; i < PrevisaoDoJson.Count; i++)
                {
                    if (i == 0)
                    {
                        TxtDescPreviUm.Text = PrevisaoDoJson[i].descricao;
                        TxtDataPreviUm.Text = PrevisaoDoJson[i].data;
                        TxtMaxPreviUm.Text = PrevisaoDoJson[i].temperatura_max;
                        TxtMinPreviUm.Text = PrevisaoDoJson[i].temperatura_min;

                        ImageSource ImgTum = new BitmapImage(new Uri(PrevisaoDoJson[i].imagem, UriKind.Absolute));
                        ImgPreviUm.Source = ImgTum;

                    }
                    if (i == 1)
                    {
                        TxtDescPreviUm_Copy.Text = PrevisaoDoJson[i].descricao;
                        TxtDataPreviUm_Copy.Text = PrevisaoDoJson[i].data;
                        TxtMaxPreviUm_Copy.Text = PrevisaoDoJson[i].temperatura_max;
                        TxtMinPreviUm_Copy.Text = PrevisaoDoJson[i].temperatura_min;

                        ImageSource ImgTum1 = new BitmapImage(new Uri(PrevisaoDoJson[i].imagem, UriKind.Absolute));
                        ImgPreviUm_Copy.Source = ImgTum1;

                    }
                    if (i == 2)
                    {
                        TxtDescPreviUm_Copy1.Text = PrevisaoDoJson[i].descricao;
                        TxtDataPreviUm_Copy1.Text = PrevisaoDoJson[i].data;
                        TxtMaxPreviUm_Copy1.Text = PrevisaoDoJson[i].temperatura_max;
                        TxtMinPreviUm_Copy1.Text = PrevisaoDoJson[i].temperatura_min;

                        ImageSource ImgTum2 = new BitmapImage(new Uri(PrevisaoDoJson[i].imagem, UriKind.Absolute));
                        ImgPreviUm_Copy1.Source = ImgTum2;

                    }
                    if (i == 3)
                    {
                        TxtDescPreviUm_Copy2.Text = PrevisaoDoJson[i].descricao;
                        TxtDataPreviUm_Copy2.Text = PrevisaoDoJson[i].data;
                        TxtMaxPreviUm_Copy2.Text = PrevisaoDoJson[i].temperatura_max;
                        TxtMinPreviUm_Copy2.Text = PrevisaoDoJson[i].temperatura_min;

                        ImageSource ImgTum3 = new BitmapImage(new Uri(PrevisaoDoJson[i].imagem, UriKind.Absolute));
                        ImgPreviUm_Copy2.Source = ImgTum3;

                    }
                    if (i == 4)
                    {
                        TxtDescPreviUm_Copy3.Text = PrevisaoDoJson[i].descricao;
                        TxtDataPreviUm_Copy3.Text = PrevisaoDoJson[i].data;
                        TxtMaxPreviUm_Copy3.Text = PrevisaoDoJson[i].temperatura_max;
                        TxtMinPreviUm_Copy3.Text = PrevisaoDoJson[i].temperatura_min;

                        ImageSource ImgTum4 = new BitmapImage(new Uri(PrevisaoDoJson[i].imagem, UriKind.Absolute));
                        ImgPreviUm_Copy3.Source = ImgTum4;

                    }
                }

            }
        
        private void CarregaConcurso()
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {

                WebClient rssClient = new WebClient();
                rssClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(rssClient_DownloadStringCompleted);
                //rssClient.Encoding = System.Text.Encoding.GetEncoding("ISO8859-1");
                rssClient.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                progress.Visibility = System.Windows.Visibility.Visible;

                rssClient.DownloadStringAsync(new Uri(@"http://feeds.pciconcursos.com.br/feed/" + uf.ToLower() + "?format=xml"));
            });
        }
        void rssClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {


                var rssData = from rss in XElement.Parse(e.Result).Descendants("item")
                              select new RssGlobo
                              {
                                  title = rss.Element("title").Value,
                                  pubDate = rss.Element("pubDate").Value,
                                  description = rss.Element("description").Value,
                                  link = rss.Element("link").Value
                              };
                listRSS.ItemsSource = rssData;
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception)
            {
                MessageBox.Show("Opss algo errado.");
            }



        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (cidade != null)
                    {

                        CarregaJson();
                    }
                });
            }
            catch
            {
                MessageBox.Show("Cidade ou Estado com erro");
            }
        }
        private void CarregaJson()
        {
            try
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    WebClient jsonClient = new WebClient();
                    jsonClient.DownloadStringCompleted +=
                        new DownloadStringCompletedEventHandler(jsonClient_DownloadStringCompleted);
                    //jsonClient.Encoding = System.Text.Encoding.GetEncoding("ISO8859-1");
                    jsonClient.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
                    jsonClient.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/tempo/json/" + cidade + "-" + uf));
                });
            }
            catch
            {
                MessageBox.Show("Erro ao carregar Site do Tempo");
            }


        }
        private void jsonClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                ParseJson(e.Result);

                
            }
            catch
            {
                MessageBox.Show("Cidade ou Estado esta Incorreto");
            }
        }
        private Previsao ParseJson(string pJson)
        {

            //cria objeto para lista do tipo carro

            if (pJson != null)
            {
                //faz o parse para um tipo jobject
                JObject jobject = JObject.Parse(pJson);
                JObject jobjectclima = (JObject)jobject["agora"];
                //JObject jobjectprevisao = (JObject)jobject["previsoes"];
                IList<Previso> CID = jobject["previsoes"].ToObject<IList<Previso>>();
                //le a lista carros
                CidadeDoJson = new Previsao
                {
                    cidade = (string)jobject["cidade"],
                    temperatura = (string)jobjectclima["temperatura"],
                    descricao = (string)jobjectclima["descricao"],
                    imagem = (string)jobjectclima["imagem"],
                    nascer_do_sol = (string)jobjectclima["nascer_do_sol"],
                    por_do_sol = (string)jobjectclima["por_do_sol"],
                    pressao = (string)jobjectclima["pressao"],
                    pressao_status = (string)jobjectclima["pressao_status"],
                    umidade = (string)jobjectclima["umidade"],
                    vento_direcao = (string)jobjectclima["vento_direcao"],
                    vento_velocidade = (string)jobjectclima["vento_velocidade"],
                    visibilidade = (string)jobjectclima["visibilidade"],
                    data_hora = (string)jobjectclima["data_hora"]

                };
                PrevisaoDoJson = CID;

            }

            return CidadeDoJson;


        }

        private void onSelecioChange(object sender, SelectionChangedEventArgs e)
        {
            rss = (sender as ListBox).SelectedItem as RssGlobo;
        }
        #region APPBAR
        private void appBarMais_Save(object sender, EventArgs e)
        {
            try
            {
                AppGlobo.Entidades.Favoritos fav = new AppGlobo.Entidades.Favoritos
                {
                    //Id = int.Parse(TxtId.Text),
                    titleB = rss.title,
                    descriptionB = rss.description,
                    pubDateB = rss.pubDate,
                    linkB = rss.link

                };
                if (fav != null)
                {
                    Repositorio.Repositorio.Adicionar(fav);
                    MessageBox.Show("Adicionado com Sucesso");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ops nada selecionado");
            }
        }

        private void appBarVerFavoritos_Save(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pags/PaginaFavoritos.xaml", UriKind.Relative));
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Navegador page = e.Content as Navegador;
            if (page != null)
            {
                page.rssG = rss;
            }
            
        }

        private void appBarSobre_Save(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pags/Sobre.xaml", UriKind.Relative));
        }

        private void appBarMais_Click(object sender, EventArgs e)
        {
            try
            {
                if (rss == null)
                {
                    MessageBox.Show("Opss nada Selecinado");
                }
                else
                {
                    NavigationService.Navigate(new Uri("/Pags/Navegador.xaml", UriKind.Relative));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Opss nada Selecinado");
            }



        }
        #endregion

    }
}