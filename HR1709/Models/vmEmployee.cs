namespace HR1709.Models
{
    public class vmEmployee
    {
        public EmployeeDTO EmployeeDTO { get; set; }
        public List<NationalityDTO> liNationalityDTO { get; set; }

        public List<DepartmentDTO> liDepartmentDTO { get; set; }
        public List<PositionDTO> liPositionDTO { get; set; }
        public List<WorkingTypeDTO> liWorkingTypeDTO { get; set; }
    }
}
