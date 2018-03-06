using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WonderWoman.DAL;
using WonderWoman.Models;
using PagedList;

namespace WonderWoman.Controllers
{
    public class EnemiesController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sortOrder, int? page)
        {
            WWEnemyRepository enemyRepository = new WWEnemyRepository();

            //
            //create distinct comic list
            //
            ViewBag.Comics = ListOfComics();
            
            IEnumerable<WWEnemy> wwEnemies;
            using (enemyRepository)
            {
                wwEnemies = enemyRepository.SelectAll() as IList<WWEnemy>;
            }
            switch (sortOrder)
            {
                case "Id":
                    wwEnemies = wwEnemies.OrderBy(wwEnemy => wwEnemy.Id);
                    break;
                case "Name":
                    wwEnemies = wwEnemies.OrderBy(wwEnemy => wwEnemy.Name);
                    break;
                default:
                    wwEnemies = wwEnemies.OrderBy(wwEnemy => wwEnemy.Name);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            wwEnemies = wwEnemies.ToPagedList(pageNumber, pageSize);

            return View(wwEnemies);
        }
        [HttpPost]
        public ActionResult Index(string searchCriteria, string enemyFilter, int? page)
        {
            WWEnemyRepository enemyRepository = new WWEnemyRepository();

            ViewBag.Comics = ListOfComics();

            IEnumerable<WWEnemy> wwEnemies;
            using (enemyRepository)
            {
                wwEnemies = enemyRepository.SelectAll() as IList<WWEnemy>;
            }
            //enemy name search
            if (searchCriteria != null)
            {
                wwEnemies = wwEnemies.Where(wwEnemy => wwEnemy.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }
            //comic search
            if (enemyFilter != "" || enemyFilter == null)
            {
                wwEnemies = wwEnemies.Where(wwEnemy => wwEnemy.Comic == enemyFilter);
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            wwEnemies = wwEnemies.ToPagedList(pageNumber, pageSize);

            return View(wwEnemies);
        }

        [NonAction]
        private IEnumerable<string> ListOfComics()
        {
            //
            //instantiate the repository
            //
            WWEnemyRepository wwEnemyRepository = new WWEnemyRepository();

            //
            //return as IEnumerable
            //
            IEnumerable<WWEnemy> wwEnemies;
            using (wwEnemyRepository)
            {
                wwEnemies = wwEnemyRepository.SelectAll() as IList<WWEnemy>;
            }

            //
            //distinct comic list
            //
            //var comics = wwEnemies.Select(w => w.Comic).Distinct().OrderBy(c => c);
            var comics = wwEnemies.Select(w => w.Comic).Distinct();

            return comics;


        }

        // GET: Enemies/Details/5
        public ActionResult Details(int id)
        {
            //instantiate repository
            WWEnemyRepository wwEnemyRepository = new WWEnemyRepository();
            WWEnemy wwEnemy = new WWEnemy();

            using (wwEnemyRepository)
            {
                
                wwEnemy = wwEnemyRepository.SelectOne(id);
            }
            return View(wwEnemy);
        }

        [HttpGet]
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(WWEnemy wwEnemy)
        {
            try
            {
                WWEnemyRepository enemyRepository = new WWEnemyRepository();
               
                using (enemyRepository)
                {
                    enemyRepository.Insert(wwEnemy);
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //Need Error message
               return View();
            }
        }
        
        private int NextID()
        {
            WWEnemyRepository enemyRepository = new WWEnemyRepository();

            IEnumerable<WWEnemy> wwEnemies;

            using (enemyRepository)
            {
                wwEnemies = enemyRepository.SelectAll() as IList<WWEnemy>;
            }

            int maxId = wwEnemies.Max(s => s.Id);

            return maxId + 1;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            WWEnemyRepository enemyRepository = new WWEnemyRepository();
            WWEnemy wwEnemy = new WWEnemy();

            using (enemyRepository)
            {
                wwEnemy = enemyRepository.SelectOne(id);
            }
            return View(wwEnemy);
        }

        // POST: Enemies/Edit/5
        [HttpPost]
        public ActionResult Edit(WWEnemy wwEnemy)
        {
            try
            {
                WWEnemyRepository enemyRepository = new WWEnemyRepository();

                using (enemyRepository)
                {
                    enemyRepository.Update(wwEnemy);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enemies/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            WWEnemyRepository enemyRepository = new WWEnemyRepository();
            WWEnemy wwEnemy = new WWEnemy();

            using (enemyRepository)
            {
                wwEnemy = enemyRepository.SelectOne(id);
            }

            return View(wwEnemy);
        }

        // POST: Enemies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                WWEnemyRepository enemyRepository = new WWEnemyRepository();

                using (enemyRepository)
                {
                    enemyRepository.Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
