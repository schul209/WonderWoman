using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderWoman.DAL
{
    public class DataSettings
    {
        public string dataFilePath = HttpContext.Current.Server.MapPath("~App_Data/Enemies.xml");
    }
}