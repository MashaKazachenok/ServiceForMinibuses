using ServiceForMinibuses.Manager;
using System.Web.Mvc;
using Models;
using ServiceForMinibuses.Web.Models;

namespace ServiceForMinibuses.Web.Controllers
{
    public class StopController : Controller
    {
        //
        // GET: /Stop/
         private readonly IStopStore _stopStore;

        public StopController(
         
            IStopStore stopStore)
        {
            _stopStore = stopStore;
        }
        public ActionResult CreateStop()
        {
            return View();
        }

        //
        // GET: /Stop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Stop/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Stop/Create
        [HttpPost]
        public ActionResult CreateStop(CreateStopViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                var stop = new Stop();
                stop.Name = model.Name;
                stop.XCoord = model.XCoord;
                stop.YCoord = model.YCoord;

                _stopStore.AddStop(stop);

                return RedirectToAction("Index", "Home");
            }
                return View();
        }

        public ActionResult ViewStops()
        {
            var model = new RouteListViewModel();
          

            return View("ViewStops", model);
        }
        //
        // GET: /Stop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Stop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Stop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Stop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }
    }
}
