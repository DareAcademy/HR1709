using AutoMapper;
using HR1709.data;
using HR1709.Models;
using Microsoft.EntityFrameworkCore;

namespace HR1709.services
{
    public class EmployeeServices: IEmployeeServices
    {
        HRContext context;
        IMapper mapper;
        public EmployeeServices(HRContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Insert(EmployeeDTO employeeDTO)
        {
          

            Employee employee = mapper.Map<Employee>(employeeDTO);


            context.Employees.Add(employee);
            context.SaveChanges();

        }

        public List<EmployeeDTO> GetByName(string name)
        {

            //List<Employee> allemployees = (from e in context.Employees
            //                               where e.FirstName == fname
            //                               select e).ToList();

            //List<Employee> allemployees = context.Employees.Include("department").Include("position").Where(e => e.FirstName == fname).ToList();
            List<Employee> allemployees = context.Employees.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name)).ToList();


            List <EmployeeDTO> employees = mapper.Map<List<EmployeeDTO>>(allemployees);
           

            return employees;
        }

        public void Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);

            context.Employees.Remove(employee);
            context.SaveChanges();

        }

        public List<EmployeeDTO> GetAll()
        {
            List<Employee> allemployees = context.Employees.ToList();
            List<EmployeeDTO> employees = mapper.Map<List<EmployeeDTO>>(allemployees);
            return employees;

        }

        public EmployeeDTO Get(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            EmployeeDTO employeeDTO = mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;

        }

        public void Update(EmployeeDTO employeeDTO)
        {
            Employee newEmployee = mapper.Map<Employee>(employeeDTO);

            context.Employees.Attach(newEmployee);
            context.Entry(newEmployee).State = EntityState.Modified;
            context.SaveChanges();


        }


    }
}
