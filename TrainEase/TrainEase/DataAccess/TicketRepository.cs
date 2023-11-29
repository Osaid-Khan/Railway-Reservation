using System;
using System.Collections.Generic;
using System.Linq;
using TrainEase.Models;

namespace TrainEase.DataAccess
{
    public class TicketRepository
    {
        private readonly TrainTicketDbContext _dbContext;

        public TicketRepository()
        {
            _dbContext = new TrainTicketDbContext();
        }

        public List<Ticket> GetAllTickets()
        {
            return _dbContext.Tickets.ToList();
        }

        public Ticket GetTicketById(int ticketId)
        {
            return _dbContext.Tickets.FirstOrDefault(t => t.TicketID == ticketId);
        }

        public void AddTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
        }

        public void UpdateTicket(Ticket ticket)
        {
            var existingTicket = _dbContext.Tickets.Find(ticket.TicketID);
            if (existingTicket != null)
            {
                // Update properties of existingTicket with the values of ticket
                existingTicket.SeatNumber = ticket.SeatNumber;
                existingTicket.Price = ticket.Price;
                // Update other properties...

                existingTicket.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteTicket(int ticketId)
        {
            var ticketToDelete = _dbContext.Tickets.Find(ticketId);
            if (ticketToDelete != null)
            {
                _dbContext.Tickets.Remove(ticketToDelete);
                _dbContext.SaveChanges();
            }
        }
    }

}
