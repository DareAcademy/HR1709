using HR1709.data;
using HR1709.Models;

namespace HR1709.services
{
    public class NationalityService: INationalityService
    {
        HRContext context;
        public NationalityService(HRContext _context)
        {
            context = _context;
        }

        public List<NationalityDTO> getAll()
        {
            //HRContext context = new HRContext();

            //List<Nationality> allNationality = (from n in context.Nationalities
            //                                    select n).ToList();

            List<Nationality> allNationality = context.Nationalities.ToList();

            List<NationalityDTO> nationalities = new List<NationalityDTO>();

            foreach (Nationality item in allNationality)
            {
                NationalityDTO obj = new NationalityDTO();
                obj.Id = item.Id;
                obj.Name = item.Name;
                nationalities.Add(obj);

            }

            return nationalities;
        }

        public void Insert(NationalityDTO nationalityDTO)
        {
            //HRContext context = new HRContext();

            Nationality newNationality = new Nationality();
            newNationality.Name = nationalityDTO.Name;

            context.Nationalities.Add(newNationality);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            Nationality nationality = context.Nationalities.Find(Id);
            context.Nationalities.Remove(nationality);
            context.SaveChanges();
        }

        public NationalityDTO Get(int Id)
        {
            Nationality nationality =context.Nationalities.Find(Id);
            NationalityDTO dto = new NationalityDTO();
            dto.Id = nationality.Id;
            dto.Name = nationality.Name;
            return dto;
        }

        public void Update(NationalityDTO nationalityDTO)
        {
            Nationality newNationality = new Nationality();
            newNationality.Id = nationalityDTO.Id;
            newNationality.Name = nationalityDTO.Name;


            context.Nationalities.Attach(newNationality);
            context.Entry(newNationality).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

    }
}
