using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lng_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            public string language= new string language;
                switch (language)
                {
                case "de": "en-de";break;
                case "es": "en-es"; break;
                default: "en-fr"; break;
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var Client = new WebClient();
            string apiurl = string.Format ("https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}", Constants.apikey, txt1.Text, //pozvati string language)
            string response = client.DownloadString(apiurl);
        var result = JsonConvert.DeserializeObject<myJSON.Object>(response);
        DisplayLabel.Content = result.text[0];

        }
}
}
