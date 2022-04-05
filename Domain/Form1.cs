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
using Main.WheatherInformation;

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

        string APIKey = "20bc102a5ad776f9690f50e95d1d73d4";

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
                root Info = JsonConvert.DeserializeObject<root>(Json);

                #region Picture
                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + Info.weather[0].icon + ".png";
                #endregion

                #region Condition & Details
                lblcondicion2.Text = Info.weather[0].main;
                lbldetalles2.Text = Info.weather[0].description;

                #endregion

                #region Sunset & Sunrise
                lblsunset.Text = convertir(Info.sys.sunset).ToLongTimeString();
                lblsunrise.Text = convertir(Info.sys.sunrise).ToLongTimeString();

                #endregion

                #region Wind & Pressure

                lblwindspeed.Text = Info.wind.speed.ToString();
                lblpressure.Text = Info.main.pressure.ToString();
                #endregion

              
            }
        }


        DateTime convertir(long twentyfourHours)
        {

            DateTime days = new DateTime(1900, 1, 1, 0, 0, 0, 0,  DateTimeKind.Utc).ToLocalTime();

            days = days.AddMilliseconds(twentyfourHours).ToLocalTime();

            return days;
        }
    }
}
