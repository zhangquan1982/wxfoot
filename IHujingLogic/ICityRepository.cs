using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IHujingLogic
{
    public interface ICityRepository
    {
        List<City> GetCityList();
    }


    public class City
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
