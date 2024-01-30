using HR1709.data;
using HR1709.Models;

namespace HR1709.services
{
    public class WorkingTypeService: IWorkingTypeService
    {
        HRContext context;
        public WorkingTypeService(HRContext _context)
        {
            context = _context;
        }
        public List<WorkingTypeDTO> GetAll()
        {

            List<WorkingType> liWorkingType = (from w in context.WorkingType
                                               select w).ToList();
            List<WorkingTypeDTO> WorkingTypes = new List<WorkingTypeDTO>();
            foreach (WorkingType item in liWorkingType)
            {
                WorkingTypeDTO dto = new WorkingTypeDTO();
                dto.Id = item.Id;
                dto.Name = item.Name;
                WorkingTypes.Add(dto);
            }

            return WorkingTypes;
        }
    }
}
