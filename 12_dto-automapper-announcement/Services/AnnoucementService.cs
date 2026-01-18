using _12_dto_automapper_announcement.Models;
using _12_dto_automapper_announcement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _12_dto_automapper_announcement.Services;

public class AnnoucementService : IAnnoucementRepository
{
    private readonly DataContext _dbContext;
    public AnnoucementService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync()
    {
        return await _dbContext.Announcements.ToListAsync();
    }

    public async Task<Announcement?> GetAnnouncementByIdAsync(Guid? id)
    {
        return await _dbContext.Announcements.FindAsync(id);
    }

    public async Task CreateAnnouncementAsync(Announcement announcement)
    {
        await _dbContext.Announcements.AddAsync(announcement);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAnnouncementAsync(Announcement announcement)
    {
        _dbContext.Announcements.Update(announcement);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAnnouncementAsync(Guid? id)
    {
        var announcement = _dbContext.Announcements.Find(id);
        if (announcement != null)
        {
            _dbContext.Announcements.Remove(announcement);
            await _dbContext.SaveChangesAsync();
        }
    }
}
