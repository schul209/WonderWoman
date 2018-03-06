using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WonderWoman.Models;

namespace WonderWoman.DAL
{
    public class WWEnemyRepository : IWWEnemyRepository, IDisposable
    {
        private List<WWEnemy> _wwEnemies;

        public WWEnemyRepository()
        {
            WWEnemyXmlDataServices wWEnemyXmlDataServices = new WWEnemyXmlDataServices();

            using (wWEnemyXmlDataServices)
            {
                _wwEnemies = wWEnemyXmlDataServices.Read() as List<WWEnemy>;
            }
        }
        public IEnumerable<WWEnemy> SelectAll()
        {
            return _wwEnemies;
        }
        public void Delete(int id)
        {
            var wwEnemy = _wwEnemies.Where(e => e.Id == id).FirstOrDefault();

            if (wwEnemy != null)
            {
                _wwEnemies.Remove(wwEnemy);
            }
            Save();
        }

        public void Insert(WWEnemy wwEnemy)
        {
            wwEnemy.Id = NextIdValue();
            _wwEnemies.Add(wwEnemy);

            Save();
        }

        private void Save()
        {
            WWEnemyXmlDataServices wWEnemyXmlDataServices = new WWEnemyXmlDataServices();

            using (wWEnemyXmlDataServices)
            {
                wWEnemyXmlDataServices.Write(_wwEnemies);
            }
        }

        private int NextIdValue()
        {
            int currentMaxId = _wwEnemies.OrderByDescending(b => b.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public WWEnemy SelectOne(int id)
        {
            //Add LINQ HERE?
            WWEnemy selectedEnemy = _wwEnemies.Where(p => p.Id == id).FirstOrDefault();
                return selectedEnemy;
        }

        public void Update(WWEnemy UpdateWWEnemy)
        {
            var oldEnemy = _wwEnemies.Where(e => e.Id == UpdateWWEnemy.Id).FirstOrDefault();

            if (oldEnemy != null)
            {
                _wwEnemies.Remove(oldEnemy);
                _wwEnemies.Add(UpdateWWEnemy);
            }

            Save();
        }
        public void Dispose()
        {
            _wwEnemies = null;
        }


    }
}