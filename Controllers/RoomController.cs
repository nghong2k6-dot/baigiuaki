
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORM1.Data;
using ORM1.Models;

namespace ORM1.Controllers
{
    public class RoomController : Controller
    {
        private readonly AppDbContext _context;

        public RoomController(AppDbContext context)
        {
            _context = context;
        }

        // ======================
        // DANH SÁCH + TÌM KIẾM
        // ======================
        public IActionResult Index(
            string searchString,
            int? roomTypeId,
            bool? isAvailable,
            decimal? maxPrice,
            string sortOrder)
        {
            var rooms = _context.Rooms_BCS240051
                .Include(r => r.RoomType)
                .Include(r => r.RoomImages)
                .AsQueryable();

            // Tìm tên phòng
            if (!string.IsNullOrEmpty(searchString))
            {
                rooms = rooms.Where(r =>
                    r.Name.Contains(searchString));
            }

            // Lọc loại phòng
            if (roomTypeId.HasValue)
            {
                rooms = rooms.Where(r =>
                    r.RoomTypeId == roomTypeId);
            }

            // Lọc trạng thái
            if (isAvailable.HasValue)
            {
                rooms = rooms.Where(r =>
                    r.IsAvailable == isAvailable);
            }

            // Lọc giá tối đa
            if (maxPrice.HasValue)
            {
                rooms = rooms.Where(r =>
                    r.Price <= maxPrice);
            }

            // Sắp xếp
            switch (sortOrder)
            {
                case "price_asc":
                    rooms = rooms.OrderBy(r => r.Price);
                    break;

                case "price_desc":
                    rooms = rooms.OrderByDescending(r => r.Price);
                    break;

                case "area_desc":
                    rooms = rooms.OrderByDescending(r => r.Area);
                    break;
            }

            ViewBag.RoomTypes =
                _context.RoomTypes_BCS240051.ToList();

            return View(rooms.ToList());
        }

        // ======================
        // CHI TIẾT
        // ======================
        public IActionResult Details(int id)
        {
            var room = _context.Rooms_BCS240051
                .Include(r => r.RoomType)
                .Include(r => r.RoomImages)
                .FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound("Room không tồn tại");
            }

            return View(room);
        }

        // ======================
        // CREATE
        // ======================
        public IActionResult Create()
        {
            ViewBag.RoomTypes = new SelectList(
                _context.RoomTypes_BCS240051,
                "Id",
                "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room_BCS240051 room)
        {
            if (ModelState.IsValid)
            {
                _context.Rooms_BCS240051.Add(room);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomTypes = new SelectList(
                _context.RoomTypes_BCS240051,
                "Id",
                "Name");

            return View(room);
        }

        // ======================
        // EDIT
        // ======================
        public IActionResult Edit(int id)
        {
            var room =
                _context.Rooms_BCS240051.Find(id);

            if (room == null)
            {
                return NotFound();
            }

            ViewBag.RoomTypes = new SelectList(
                _context.RoomTypes_BCS240051,
                "Id",
                "Name",
                room.RoomTypeId);

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Room_BCS240051 room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(room);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.RoomTypes = new SelectList(
                _context.RoomTypes_BCS240051,
                "Id",
                "Name",
                room.RoomTypeId);

            return View(room);
        }

        // ======================
        // DELETE
        // ======================
        public IActionResult Delete(int id)
        {
            var room = _context.Rooms_BCS240051
                .Include(r => r.RoomType)
                .FirstOrDefault(r => r.Id == id);

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var roomType = _context.RoomTypes_BCS240051
                .Include(x => x.Rooms)
                .FirstOrDefault(x => x.Id == id);

            if (roomType == null)
            {
                TempData["Error"] = "Loại phòng không tồn tại";
                return RedirectToAction(nameof(Index));
            }

            if (roomType.Rooms.Any())
            {
                TempData["Error"] =
                    "Không thể xóa loại phòng đang có phòng sử dụng";

                return RedirectToAction(nameof(Index));
            }

            _context.RoomTypes_BCS240051.Remove(roomType);
            _context.SaveChanges();

            TempData["Success"] =
                "Xóa loại phòng thành công";

            return RedirectToAction(nameof(Index));
        }
    }
}
