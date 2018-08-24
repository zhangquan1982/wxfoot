using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IHujingLogic;

namespace HujingLogic
{
    public class CityRepository : ICityRepository
    {
        public List<City> GetCityList()
        {
            List<City> lst = new List<City>();
            City cty = new City();
            cty.Name="aaa";
            cty.Code="001";
            lst.Add(cty);
            return lst;
        }

    }
}