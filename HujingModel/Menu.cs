using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHis.Model
{
    public class Menu
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public Menu[] ChildrenMenus { get; set; }

        public string Url { get; set; }

        public string Rel { get; set; }
    }

    public enum MenuOpen
    {
        NavigateTab=0,
        Dialog=1
    }
}