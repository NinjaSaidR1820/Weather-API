using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Main;

namespace Domain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string APIKey = "5c61e63c6e9600c959150c6ca9326226";

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            GetWeather();
        }
         public void GetWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", txtcity.Text,   APIKey);
                var Json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(Json);


                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                lblcondicion.Text = Info.weather[0].main;
                lbldetalles.Text = Info.weather[0].description;
                lblsunset.Text = Info.sys.sunset.ToString();
                lblsunrise.Text = Info.sys.sunrise.ToString();
                lblwindspeed.Text = Info.wind.speed.ToString();
                lblpressure.Text = Info.main.preasure.ToString();

            }
        }
    }
}
