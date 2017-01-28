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
using System.Web.Helpers;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
namespace weather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Item
    {
        public int millis;
        public string stamp;
        public DateTime datetime;
        public string light;
        public float temp;
        public float vcc;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string apiStr = "http://api.openweathermap.org/data/2.5/weather?q=Polava,ua&appid=478b547e0a226c53095708abf9fe3a3a&units=metric";
            WeatherData weatherData = MakeRequest(apiStr);
            if(weatherData!=null)
            {
                this.DataContext = weatherData;
            }
            LoadJson();
        }
        //public static List<City> LoadAllCities()
        //{
        //    DynamicJsonArray[] arr = new DynamicJsonArray[210000];
        //    List<City> AllCities = new List<City>();
        //    using (StreamReader r = File.OpenText("city.list.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        JsonConvert.DeserializeObject(json);
        //    }

            public void LoadJson()
        {
            List<City> items = null;
            using (StreamReader r = new StreamReader("city.list2.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<City>>(json);
            }
            string a = "asdf";
        }


            //try
            //{
            //    HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            //    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //    {
            //        if (response.StatusCode != HttpStatusCode.OK)
            //            throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

            //        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WeatherData));
            //        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
            //        WeatherData jsonResponse = objResponse as WeatherData;
            //        return jsonResponse;
            //    }
            //}
            //catch (Exception e)
            //{
            //    return null;
            //}
        //    return AllCities;
        //}
        public static WeatherData MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WeatherData));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    WeatherData jsonResponse = objResponse as WeatherData;
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
