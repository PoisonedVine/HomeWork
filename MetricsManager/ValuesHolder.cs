using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager
{
    public class ValuesHolder
    {
        int _i = -1;
        public List<WeatherForecast> Values { get; set; }
        public WeatherForecast Current => Values[_i];
        public ValuesHolder()
        {
            Values = new List<WeatherForecast>();
        }
        public ValuesHolder(List<WeatherForecast> values)
        {
            Values = values;
        }
        public ValuesHolder GetEnumerator()
        {
            _i = -1;
            return this;            
        }
        public bool MoveNext()
        {
            _i++;
            if (_i < Values.Count)
            {                
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}
