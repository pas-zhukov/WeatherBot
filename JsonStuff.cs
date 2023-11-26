using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherBot
    
{
    
    public class WeatherForecast
        
    {
        
        public double Now { get; set; }
        public string Now_dt { get; set; }
        public class Info
            
        {
            
            public string Url { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
            
        }
        
        public Info info { get; set; }
        
        public class Fact
            
        {
            
            public double Obs_time { get; set; }
            public double Temp { get; set; }
            public string Condition { get; set; }
            public double Wind_speed { get; set; }
            public string Wind_dir { get; set; }
            public double Pressure_mm { get; set; }
            public double Pressure_pa { get; set; }
            public double Humidity { get; set; }
            public string Daytime { get; set; }
            public bool Polar { get; set; }
            public string Season { get; set; }
            public double Wind_gust { get; set; }
            
        }
        
        public Fact fact { get; set; }
        
        public class Forecast
            
        {
            
            public string Date { get; set; }
            public double Date_ts { get; set; }
            public double Week { get; set; }
            public string Sunrise { get; set; }
            public string Sunset { get; set; }
            public double Moon_code { get; set; }
            public string Moon_text { get; set; }
            public List<object> Parts { get; set; }
            
        }
        
        public Forecast forecast { get; set; }
        
    }
}
