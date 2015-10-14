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
        private readonly IStopStore _stopStore;

        public RouteController(
            IRouteStore routeStore,  IStopStore stopStore
          )
        {
            _stopStore = stopStore;
            _routeStore = routeStore;

        }

        // GET: Route
        public ActionResult CreateRoute()
        {
            var model = new CreateRouteViewModel();
            model.Stops = _stopStore.GetStops();
            return View(model);
        }

        public ActionResult ViewRoutes()
        {
           
            var routes = _routeStore.GetRoutes();
            var allStops = _stopStore.GetStops();
            Mapper.CreateMap<Route, CreateRouteViewModel>();
            Mapper.CreateMap<Stop, CreateStopViewModel>();

            var model = new RouteListViewModel
            {
                Routes = Mapper.Map<List<CreateRouteViewModel>>(routes),
                AllStops = Mapper.Map<List<CreateStopViewModel>>(allStops)
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
        public ActionResult CreateRoute( List<string> stops, string name)
        {
                var route = new Route();
                route.Name = name;

                if (stops != null)
                {
                    foreach (var stop in stops)
                    {
                        var findStop = _stopStore.GetStopByName(stop);
                      
                        route.Stops.Add(findStop);
                      //  findStop.Routes.Add(route);
                       // _stopStore.UpdateStop(findStop);
                    }
                }

                _routeStore.AddRoute(route);
                
                return RedirectToAction("Index", "Home");
        } 

        public ActionResult EditRoute(int routeId)
        {
            var route = _routeStore.GetRouteById(routeId);
            var model = new CreateRouteViewModel();
            model.Name = route.Name;

            return PartialView("EditRoute", model);
        }

        [HttpPost]
        public ActionResult EditRoute(CreateRouteViewModel model)
        {
       
           // _routeStore.AddRoute(route);

            return RedirectToAction("ViewRoutes", "Route");
        } 

        // POST: Route/Delete/5
        public ActionResult DeleteRoute(int routeId)
        {
            _routeStore.RemoveRoute(routeId);

            return RedirectToAction("ViewRoutes");
        }
    }
}
