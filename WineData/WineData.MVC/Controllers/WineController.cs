using HospitalDoctoerRecord.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WineData.MVC.Models;

namespace WineData.MVC.Controllers
{
    public class WineController : Controller
    {
        // GET: Wines
        public ActionResult Index()
        {
            IEnumerable<WineModel> wnList;
            HttpResponseMessage response = APIContent.Client.GetAsync("Wines").Result;
            wnList = response.Content.ReadAsAsync<IEnumerable<WineModel>>().Result;
            return View(wnList);
        }
        [HttpGet]
        public ActionResult SaveAndUpdate(int id = 0)
        {
            if (id == 0)
                return View(new WineModel());
            else
            {
                HttpResponseMessage response = APIContent.Client.GetAsync("Wines/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<WineModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult SaveAndUpdate(WineModel wnModel)
        {
            if (wnModel.ID == 0)
            {
                HttpResponseMessage response = APIContent.Client.PostAsJsonAsync("Wines", wnModel).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = APIContent.Client.PutAsJsonAsync("Wines/" + wnModel.ID, wnModel).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = APIContent.Client.DeleteAsync("Wines/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}