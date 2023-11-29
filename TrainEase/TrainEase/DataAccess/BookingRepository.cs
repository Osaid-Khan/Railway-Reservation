using System;
using System.Collections.Generic;
using System.Linq;
using TrainEase.Models;

namespace TrainEase.DataAccess
{
    

    public class BookingRepository
    {
        private readonly TrainTicketDbContext _dbContext;

        public BookingRepository()
        {
            _dbContext = new TrainTicketDbContext();
        }

        public List<Booking> GetAllBookings()
        {
            return _dbContext.Bookings.ToList();
        }

        public Booking GetBookingById(int bookingId)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.BookingID == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            var existingBooking = _dbContext.Bookings.Find(booking.BookingID);
            if (existingBooking != null)
            {
                // Update properties of existingBooking with the values of booking
                existingBooking.SeatNumber = booking.SeatNumber;
                existingBooking.Price = booking.Price;
                // Update other properties...

                existingBooking.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteBooking(int bookingId)
        {
            var bookingToDelete = _dbContext.Bookings.Find(bookingId);
            if (bookingToDelete != null)
            {
                _dbContext.Bookings.Remove(bookingToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
