using Microsoft.AspNetCore.Mvc;
using ORM1.Data;
using ORM1.Models;

namespace ORM1.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly AppDbContext _context;

        public RoomTypeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(
                _context.RoomTypes_BCS240051.ToList());
        }

        public IActionResult Delete(int id)
        {
            var roomType =
                _context.RoomTypes_BCS240051
                .FirstOrDefault(x => x.Id == id);

            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var roomType =
                _context.RoomTypes_BCS240051
                .FirstOrDefault(x => x.Id == id);

            if (roomType == null)
            {
                return NotFound();
            }

            bool isUsed =
                _context.Rooms_BCS240051
                .Any(r => r.RoomTypeId == id);

            if (isUsed)
            {
                TempData["Error"] =
                    "Không thể xóa loại phòng đang được sử dụng.";

                return RedirectToAction("Index");
            }

            _context.RoomTypes_BCS240051.Remove(roomType);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}