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
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
namespace weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string apiStr = "http://api.openweathermap.org/data/2.5/weather?q=Polava,ua&appid=478b547e0a226c53095708abf9fe3a3a&units=metric";
            RootObject weatherData = MakeRequest(apiStr);
            if(weatherData!=null)
            {
                this.DataContext = weatherData;
            }

        }
        public static RootObject MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(RootObject));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    RootObject jsonResponse = objResponse as RootObject;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
