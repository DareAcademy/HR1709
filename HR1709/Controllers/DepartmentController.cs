using HR1709.data;
using HR1709.Models;
using HR1709.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HR1709.Controllers
{
    [Authorize(Roles ="Admin")]
    public class DepartmentController : Controller
    {
        
        IDepartmentServices departmentServices;
        IConfiguration config;
        public DepartmentController(IDepartmentServices _departmentServices,
                                    IConfiguration _config                  
                                   )
        {
            departmentServices = _departmentServices;
            config = _config;
        }

        public IActionResult Index()
        {
            vmDepartment vm = new vmDepartment();
            
           List<DepartmentDTO> departments= departmentServices.GetAll();

            string path = config["imagePath"];
            
            vm.liDepartmentDTO = departments;

            return View("Department", vm);
        }

        public IActionResult Save(vmDepartment vm)
        {
            departmentServices.Insert(vm.departmentDTO);
            List<DepartmentDTO> departments = departmentServices.GetAll();

            vm.liDepartmentDTO = departments;

            return View("Department", vm);
        }
    }
}
