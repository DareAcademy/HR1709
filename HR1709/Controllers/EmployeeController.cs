using HR1709.data;
using HR1709.Models;
using HR1709.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR1709.Controllers
{
    [Authorize(Roles ="Employee")]
    
    public class EmployeeController : Controller
    {
        INationalityService nationalityService;
        IPositionServices positionServices;
        IWorkingTypeService workingTypeService;
        IDepartmentServices departmentServices;
        IEmployeeServices employeeServices;
        public EmployeeController(INationalityService _nationalityService,
                                  IPositionServices _positionServices,
                                  IWorkingTypeService _workingTypeService,
                                  IDepartmentServices _departmentServices,
                                  IEmployeeServices _employeeServices)
        {
            nationalityService = _nationalityService;
            positionServices = _positionServices;
            workingTypeService = _workingTypeService;
            departmentServices = _departmentServices;
            employeeServices = _employeeServices;
        }

        public IActionResult Index()
        {
            

            List<NationalityDTO> nationalities = nationalityService.getAll();
            List<PositionDTO> positions =positionServices.getAll();
            List<WorkingTypeDTO> WorkingTypes = workingTypeService.GetAll();
            List<DepartmentDTO> Departments = departmentServices.GetAll();

            vmEmployee vm = new vmEmployee();

            vm.EmployeeDTO = new EmployeeDTO();
            
            vm.liDepartmentDTO = Departments;

            vm.liPositionDTO = positions;
            vm.liNationalityDTO = nationalities;
            vm.liWorkingTypeDTO = WorkingTypes;

            ViewData["IsEdit"] =false;

            return View("NewEmployee", vm);
        }

        public IActionResult SaveData(vmEmployee v)
        {

            string filename=Guid.NewGuid().ToString()+"."+ v.EmployeeDTO.fuProfile.FileName.Split('.')[1];
            v.EmployeeDTO.fuProfile.CopyTo(new FileStream(Directory.GetCurrentDirectory()+ @"\wwwroot\"+filename, FileMode.Create));
            // copy file from client to server
            // save data to Db

            v.EmployeeDTO.ImageName = filename;
            employeeServices.Insert(v.EmployeeDTO);


            List<NationalityDTO> nationalities = nationalityService.getAll();


            List<PositionDTO> positions = positionServices.getAll();


            List<WorkingTypeDTO> WorkingTypes = workingTypeService.GetAll();


            List<DepartmentDTO> Departments = departmentServices.GetAll();

            vmEmployee vm = new vmEmployee();
            vm.EmployeeDTO = new EmployeeDTO();

            vm.liDepartmentDTO = Departments;

            vm.liPositionDTO = positions;
            vm.liNationalityDTO = nationalities;
            vm.liWorkingTypeDTO = WorkingTypes;

            ViewData["IsEdit"] = false;
            return View("NewEmployee", vm);
        }


        public IActionResult EmployeeList()
        {
            List<EmployeeDTO> li = new List<EmployeeDTO>();
            return View("EmployeeList",li);
        }

        public IActionResult Search()
        {
            string fname = Request.Form["txtfirstName"];
            List<EmployeeDTO> employees= employeeServices.GetByName(fname);

            return View("EmployeeList", employees);
        }

        public IActionResult Delete(int Id)
        {
            employeeServices.Delete(Id);
            List<EmployeeDTO> employees = employeeServices.GetAll();
            return View("EmployeeList", employees);

        }

        public IActionResult Edit(int Id)
        {
            vmEmployee vm = new vmEmployee();

            vm.EmployeeDTO = employeeServices.Get(Id);

            List<NationalityDTO> nationalities = nationalityService.getAll();
            List<PositionDTO> positions = positionServices.getAll();
            List<WorkingTypeDTO> WorkingTypes = workingTypeService.GetAll();
            List<DepartmentDTO> Departments = departmentServices.GetAll();
            vm.liDepartmentDTO = Departments;
            vm.liPositionDTO = positions;
            vm.liNationalityDTO = nationalities;
            vm.liWorkingTypeDTO = WorkingTypes;
            ViewData["IsEdit"] = true;
            return View("NewEmployee", vm);
        }

        public IActionResult UpdateDate(vmEmployee v)
        {
            if (v.EmployeeDTO.fuProfile != null)
            {
                string filename = Guid.NewGuid().ToString() + "." + v.EmployeeDTO.fuProfile.FileName.Split('.')[1];
                v.EmployeeDTO.fuProfile.CopyTo(new FileStream(Directory.GetCurrentDirectory() + @"\wwwroot\" + filename, FileMode.Create));
                v.EmployeeDTO.ImageName = filename;
            }
            

            employeeServices.Update(v.EmployeeDTO);



            List<NationalityDTO> nationalities = nationalityService.getAll();
            List<PositionDTO> positions = positionServices.getAll();
            List<WorkingTypeDTO> WorkingTypes = workingTypeService.GetAll();
            List<DepartmentDTO> Departments = departmentServices.GetAll();
            v.liDepartmentDTO = Departments;
            v.liPositionDTO = positions;
            v.liNationalityDTO = nationalities;
            v.liWorkingTypeDTO = WorkingTypes;
            ViewData["IsEdit"] = true;
            return View("NewEmployee", v);

        }


    }
}