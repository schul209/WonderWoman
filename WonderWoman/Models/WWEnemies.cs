using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WonderWoman.Models
{
    [XmlRoot("WWEnemies")]
    public class WWEnemies
    {
        [XmlElement("WWEnemy")]
        public List<WWEnemy> enemies;

    }
}