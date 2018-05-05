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

            // Here I call my method that adds items to the combobox
            addLangsToComboBox();
        }

        // Add items to the combobox (aka. add languages)
        private void addLangsToComboBox()
        {
            // Create a string array of languages
            string[] languages = { "en-de", "en-fr", "de-en" };
            // Make a foreach loop to iterate through the array of languages and add each to the combobox
            foreach (string language in languages)
            {
                // Now add the each language to the combobox
                languageComboBox.Items.Add(language);
            }
            // Now set the default item to be the first item from the array of combobox items
            languageComboBox.SelectedItem = languageComboBox.Items[0];
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            // Take the selected language from combobox and call the method to translate
            string selectedLanguage = languageComboBox.SelectedItem.ToString();
            translate(selectedLanguage);
        }

        // Make the get request and get the translation
        private void translate(string languageDirection)
        {
            var client = new WebClient();
            string apiurl = string.Format("https://translate.yandex.net/api/v1.5/tr.json/translate?key={0}&text={1}&lang={2}", Constants.apikey, txt1.Text, languageDirection);
            string response = client.DownloadString(apiurl);
            var result = JsonConvert.DeserializeObject<myJSON.Object>(response);
            txt2.Text = result.text[0];
        }
}
}
