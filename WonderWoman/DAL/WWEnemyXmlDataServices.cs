using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using WonderWoman.Models;

namespace WonderWoman.DAL
{
    public class WWEnemyXmlDataServices : IWWEnemyDataServices, IDisposable
    {
       
        public List<WWEnemy> Read()
        {
            WWEnemies wwEnemiesObject;
            //initialize filestream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            XmlSerializer deserializer = new XmlSerializer(typeof(WWEnemies));

            using (sReader)
            {
                object xmlObject = deserializer.Deserialize(sReader);

                wwEnemiesObject = (WWEnemies)xmlObject;
            }
            return wwEnemiesObject.enemies;
        }

        public void Write(List<WWEnemy> wwEnemies)
        {
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

           XmlSerializer serializer = new XmlSerializer(typeof(List<WWEnemy>), new XmlRootAttribute("WWEnemies"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, wwEnemies);
            }
        }
        public void Dispose()
        {
            Console.WriteLine("disposed");
        }
    }
}