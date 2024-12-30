
//using Microsoft.EntityFrameworkCore;
//using ProjectArti.Api.Data;
//using ProjectArti.Api.Model;
//using ProjectArti.Api.Responses;
//namespace ProjectArti.Api.Service
//{
//    public class UnitService //(AppDbContext context)
//    {
//        private readonly My_dbContext _context;

//        public UnitService(My_dbContext context)
//        {
//            _context = context;
//        }
//        public async Task<Unit> GetByIdAsync(int Id)
//        {
//            return await _context.units.FirstOrDefaultAsync(x => x.Id == Id);
//        }
         

//        public async Task UpsertAsync(Unit unit)
//        {
//            var enitiy = await _context.units.FindAsync(unit.Id); // await FindAsync to get the result
//             // إذا لم يتم العثور على الكيان، قم بإضافة الكيان الجديد
//            if (enitiy is null)
//            {
//                _context.units.Add(unit);
//            }
          
//            else
//            {

//                // إذا تم العثور على الكيان، قم بتحديث القيم الحالية بالقيم الجديدة
//                _context.Entry(enitiy).CurrentValues.SetValues(unit);

//            }
//            await _context.SaveChangesAsync();
//            // اذ حصلته عدل علية م حصلته روح سوي اضافه
//        }


//        public async Task<List<UnitSummary>> GetAllAsync()
//        {
//           var units=   await _context.units.ToListAsync();
//            return units.Select(unit =>
//            {
//                return new UnitSummary
//                {
//                    Id = unit.Id,
//                    Type = unit.Type.ToString(),
//                    UnitSize = unit.UnitSize,
//                    Amenities = unit.GetAmenities()
//                };
//            }).ToList();

//        }

//        public async Task DeleteAsync(int id)
//        {
//            var entity = await _context.units.FindAsync(id);

//            if (entity != null)
//            {
//                _context.units.Remove(entity);
//                await _context.SaveChangesAsync();
//            }
//        }

//    }
//}
