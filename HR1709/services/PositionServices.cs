using HR1709.data;
using HR1709.Models;

namespace HR1709.services
{
    public class PositionServices: IPositionServices
    {
        HRContext context;
        public PositionServices(HRContext _context)
        {
            context = _context;
        }

        public List<PositionDTO> getAll()
        {

            List<Position> lipositions = (from p in context.Positions
                                          select p).ToList();

            List<PositionDTO> positions = new List<PositionDTO>();
            foreach (Position item in lipositions)
            {
                PositionDTO dto = new PositionDTO();
                dto.Id = item.Id;
                dto.Name = item.Name;
                positions.Add(dto);
            }

            return positions;
        }
    }
}
