using _12_dto_automapper_announcement.Models;

namespace _12_dto_automapper_announcement.Repositories;

public interface IAnnoucementRepository
{
    public Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync();
    public Task<Announcement?> GetAnnouncementByIdAsync(Guid? id);
    public Task CreateAnnouncementAsync(Announcement announcement);
    public Task UpdateAnnouncementAsync(Announcement announcement);
    public Task DeleteAnnouncementAsync(Guid? id);
}
