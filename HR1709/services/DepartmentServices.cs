using AutoMapper;
using HR1709.data;
using HR1709.Models;

namespace HR1709.services
{
    public class DepartmentServices: IDepartmentServices
    {
        HRContext context;
        IMapper mapper;
        public DepartmentServices(HRContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public List<DepartmentDTO> GetAll()
        {

            List<Department> liDepartment = (from d in context.Departments
                                             select d).ToList();
            //List<DepartmentDTO> Departments = new List<DepartmentDTO>();
            //foreach (Department item in liDepartment)
            //{
            //    DepartmentDTO dto = new DepartmentDTO();
            //    dto.Id = item.Id;
            //    dto.Name = item.Name;
            //    Departments.Add(dto);
            //}

            List<DepartmentDTO> Departments = mapper.Map<List<DepartmentDTO>>(liDepartment);

            return Departments;

        }

        public void Insert(DepartmentDTO departmentDTO)
        {
            //Department newDepartment = new Department();
            //newDepartment.Name = departmentDTO.Name;

            Department newDepartment = mapper.Map<Department>(departmentDTO);


            context.Departments.Add(newDepartment);
            context.SaveChanges();
        }
    }
}
