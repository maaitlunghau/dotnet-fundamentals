using _12_dto_automapper_announcement.Models;
using _12_dto_automapper_announcement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _12_dto_automapper_announcement.Controllers
{
    public class AnnoucementController : Controller
    {
        private readonly IAnnoucementRepository _repo;
        public AnnoucementController(IAnnoucementRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var announcements = await _repo.GetAllAnnouncementsAsync();
            return View(announcements);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Announcement ann)
        {
            if (ModelState.IsValid)
            {
                await _repo.CreateAnnouncementAsync(ann);
                return RedirectToAction(nameof(Index));
            }

            return View(ann);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id)
        {
            var announcement = await _repo.GetAnnouncementByIdAsync(id);
            if (announcement is null) return NotFound();

            return View(announcement);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Announcement ann)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateAnnouncementAsync(ann);
                return RedirectToAction(nameof(Index));
            }

            return View(ann);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            await _repo.DeleteAnnouncementAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
