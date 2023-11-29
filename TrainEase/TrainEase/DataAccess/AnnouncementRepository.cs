using System;
using System.Collections.Generic;
using System.Linq;
using TrainEase.Models;

namespace TrainEase.DataAccess
{
    

    public class AnnouncementRepository
    {
        private readonly TrainTicketDbContext _dbContext;

        public AnnouncementRepository()
        {
            _dbContext = new TrainTicketDbContext();
        }

        public List<Announcement> GetAllAnnouncements()
        {
            return _dbContext.Announcements.ToList();
        }

        public Announcement GetAnnouncementById(int announcementId)
        {
            return _dbContext.Announcements.FirstOrDefault(a => a.AnnouncementID == announcementId);
        }

        public void AddAnnouncement(Announcement announcement)
        {
            _dbContext.Announcements.Add(announcement);
            _dbContext.SaveChanges();
        }

        public void UpdateAnnouncement(Announcement announcement)
        {
            var existingAnnouncement = _dbContext.Announcements.Find(announcement.AnnouncementID);
            if (existingAnnouncement != null)
            {
                // Update properties of existingAnnouncement with the values of announcement
                existingAnnouncement.AnnouncementText = announcement.AnnouncementText;
                // Update other properties...

                existingAnnouncement.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteAnnouncement(int announcementId)
        {
            var announcementToDelete = _dbContext.Announcements.Find(announcementId);
            if (announcementToDelete != null)
            {
                _dbContext.Announcements.Remove(announcementToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
