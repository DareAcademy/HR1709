using HR1709.data;
using HR1709.Models;
using HR1709.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR1709.Controllers
{
    [Authorize]
    public class NationalityController : Controller
    {
        INationalityService nationalityService;
        public NationalityController(INationalityService _nationalityService) {
            nationalityService = _nationalityService;
        }

        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            return View("NewNationality");
        }

        public IActionResult SaveData(NationalityDTO nationality)
        {
            

            nationalityService.Insert(nationality);

            ViewData["IsEdit"] = false;
            return View("NewNationality");
        }

        public IActionResult Index1()
        {
            //read from Db
            // send to view


            //NationalityService nationalityService = new NationalityService();
            List<NationalityDTO> nationalities= nationalityService.getAll();

            return View("NationalityList", nationalities);
        }

        public IActionResult Delete(int Id)
        {
            nationalityService.Delete(Id);
            List<NationalityDTO> nationalities = nationalityService.getAll();

            return View("NationalityList", nationalities);
        }

        public IActionResult Edit(int Id)
        {
            ViewData["IsEdit"] = true;
            NationalityDTO nationalityDTO= nationalityService.Get(Id);
            return View("NewNationality", nationalityDTO);
        }

        public IActionResult UpdateData(NationalityDTO nationality)
        {

            ViewData["IsEdit"] = true;
            nationalityService.Update(nationality);
            return View("NewNationality");
        }
    }
}
