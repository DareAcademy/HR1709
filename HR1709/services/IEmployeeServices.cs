using HR1709.Models;

namespace HR1709.services
{
    public interface IEmployeeServices
    {
        void Insert(EmployeeDTO employeeDTO);

        List<EmployeeDTO> GetByName(string fname);

        void Delete(int Id);

        List<EmployeeDTO> GetAll();

        EmployeeDTO Get(int Id);

        void Update(EmployeeDTO employeeDTO);
    }
}
