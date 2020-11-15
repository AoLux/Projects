using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using CarServices.Models;

namespace CarServices.Controllers
{
    public class CarController : Controller
    {
        // GET: Car

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            //starting page
            //Adding new thru insert or update

            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id_car", id);
                return View(DapperORM.ExecuteReturnList<CarModel>("CarsViewById", param).FirstOrDefault<CarModel>());
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(CarModel car)
        {
            //Saving new entry to DB
            DynamicParameters param = new DynamicParameters();
            param.Add("@id_car", car.id_car);
            param.Add("@Car_name", car.Car_name);
          
            DapperORM.ExecuteNoReturn("CarAddOrEdit", param);

            //return Redirect(Request.UrlReferrer.ToString());
            return RedirectToAction("ViewAll");
        }
        
            //Overview of all cars
        public ActionResult ViewAll()
        {
            return View(DapperORM.ExecuteReturnList<CarModel>("CarsViewAll"));
        }

            //Delete a car from the record
        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id_car", id);
            DapperORM.ExecuteNoReturn("CarsDeleteById", param);
            return RedirectToAction("ViewAll");

        }

        public ActionResult Overview(int id)
        {
            //listing services per cars

            DynamicParameters param = new DynamicParameters();
            param.Add("@id_car", id);
            return View(DapperORM.ExecuteReturnList<SerPerCar>("GetServicesPerCar", param));
            
        }
    }
}