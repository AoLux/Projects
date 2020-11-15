using CarServices.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace CarServices.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            //starting page
            return View(DapperORM.ExecuteReturnList<ServiceModel>("GetMasterPage"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            //Adding new thru insert or update

           if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id_service", id);
                return View(DapperORM.ExecuteReturnList<ServiceModel>("ServicesViewById", param).FirstOrDefault<ServiceModel>());
            }
        }



        [HttpPost]
        public ActionResult AddOrEdit(ServiceModel ser)
        {
            //Saving new entry to DB
            DynamicParameters param = new DynamicParameters();
            param.Add("@id_service", ser.id_service);
            param.Add("@Service_name", ser.Service_name);
            param.Add("@Priority", ser.Priority);
            param.Add("@Description", ser.Description);
            param.Add("@Status", ser.Status);
            param.Add("@Service_date", ser.Service_date);
            param.Add("@id_car", ser.id_car);
            DapperORM.ExecuteNoReturn("ServiceAddOrEdit", param);
            //returning to index to see the new entries
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id_service", id);
            DapperORM.ExecuteNoReturn("ServiceDeleteById", param);
            return RedirectToAction("Index");

        }

        public ActionResult Done(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id_service", id);
            DapperORM.ExecuteNoReturn("ServiceEditStatus", param);
            return RedirectToAction("Index");


        }
    }
}