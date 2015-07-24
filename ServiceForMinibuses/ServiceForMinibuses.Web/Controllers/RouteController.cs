using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ServiceForMinibuses.Manager;
using ServiceForMinibuses.Web.Models;
using Models;

namespace ServiceForMinibuses.Web.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteStore _routeStore;

        public RouteController(
            IRouteStore routeStore
          )
        {
            _routeStore = routeStore;

        }

        // GET: Route
        public ActionResult CreateRoute()
        {
            return View();
        }

        public ActionResult ViewRoutes()
        {
           
            var routes = _routeStore.GetRoutes();

            Mapper.CreateMap<Route, CreateRouteViewModel>();
            var model = new RouteListViewModel
            {
                Routes = Mapper.Map<List<CreateRouteViewModel>>(routes)
            };

            return View(model);

    
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        public ActionResult CreateRoute(CreateRouteViewModel model)
        {
            try
            {
                var route = new Route();
                route.Name = model.Name;

                _routeStore.AddRoute(route);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        } 

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
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

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
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
