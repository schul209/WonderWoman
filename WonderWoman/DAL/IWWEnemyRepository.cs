using WonderWoman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderWoman.DAL
{
    interface IWWEnemyRepository
    {
        IEnumerable<WWEnemy> SelectAll();
        WWEnemy SelectOne(int id);
        void Insert(WWEnemy wwEnemy);
        void Update(WWEnemy wwEnemy);
        void Delete(int id);

    }
}
