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
using System.Windows.Media.Imaging;

namespace AppGlobo.Pags
{
    public partial class Navegador : PhoneApplicationPage
    {
        public Favoritos rssC;
        public RssGlobo rssG;
        public Navegador()
        {
            InitializeComponent();
            
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            progress.Visibility = System.Windows.Visibility.Visible;
            if (rssC != null)
            {
                web.Source = new Uri(rssC.linkB);
                
                    progress.Visibility = System.Windows.Visibility.Collapsed;
                
                    
            }
            
            if (rssG != null)
            {
                web.Source = new Uri(rssG.link);
                
                    progress.Visibility = System.Windows.Visibility.Collapsed;
                
                
            }

        }
    }
}