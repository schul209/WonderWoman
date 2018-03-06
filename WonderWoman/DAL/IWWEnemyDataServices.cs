using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderWoman.Models;

namespace WonderWoman.DAL
{   /// <summary>
/// Reads and writes entire file based on the WWEnemy Class
/// </summary>
    interface IWWEnemyDataServices
    {
        List<WWEnemy> Read();
        void Write(List<WWEnemy> WWEnemies);
    }
}
