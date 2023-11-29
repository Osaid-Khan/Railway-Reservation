using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainEase.Models;

namespace TrainEase.DataAccess
{
    public class TrainRepository
    {
        private readonly TrainTicketDbContext _dbContext;

        public TrainRepository()
        {
            _dbContext = new TrainTicketDbContext();
        }

        public List<Train> GetAllTrains()
        {
            return _dbContext.Trains.ToList();
        }

        public Train GetTrainById(int trainId)
        {
            return _dbContext.Trains.FirstOrDefault(t => t.TrainID == trainId);
        }

        public void AddTrain(Train train)
        {
            _dbContext.Trains.Add(train);
            _dbContext.SaveChanges();
        }

        public void UpdateTrain(Train train)
        {
            var existingTrain = _dbContext.Trains.Find(train.TrainID);
            if (existingTrain != null)
            {
                // Update the properties of existingTrain with the values of train
                existingTrain.TrainName = train.TrainName;
                existingTrain.DepartureStation = train.DepartureStation;
                existingTrain.ArrivalStation = train.ArrivalStation;
                // Update other properties...

                existingTrain.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteTrain(int trainId)
        {
            var trainToDelete = _dbContext.Trains.Find(trainId);
            if (trainToDelete != null)
            {
                _dbContext.Trains.Remove(trainToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
