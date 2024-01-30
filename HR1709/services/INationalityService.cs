using HR1709.Models;

namespace HR1709.services
{
    public interface INationalityService
    {
        List<NationalityDTO> getAll();
        void Insert(NationalityDTO nationalityDTO);

        void Delete(int Id);

        NationalityDTO Get(int Id);

        void Update(NationalityDTO nationalityDTO);
    }
}
