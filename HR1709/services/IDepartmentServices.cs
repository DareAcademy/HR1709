using HR1709.Models;

namespace HR1709.services
{
    public interface IDepartmentServices
    {
        List<DepartmentDTO> GetAll();

        void Insert(DepartmentDTO departmentDTO);
    }
}
