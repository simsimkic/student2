using Bolnica.Model;
using Bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolnica.Service
{
    public class AppointementService : IAppointementService
    {

        private readonly AppointementRepository _repository;

        public AppointementService(AppointementRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Appointement> GetAppointementsWithoutRoom() => _repository.GetAppointementsWithoutRoom();
        public IEnumerable<Appointement> GetAppointementsByDate(DateTime date) => _repository.GetAppointementsByDate(date);
        public IEnumerable<Appointement> GetAppointementsByDoctor(Doctor date) => _repository.GetAppointementsByDoctor(date);

        public IEnumerable<Appointement> GetAll() => _repository.GetAllEager();

        public Appointement Create(Appointement doctor) => _repository.Create(doctor);

        public void Delete(Appointement doctor) => _repository.Delete(doctor);

        public Appointement GetOne(long id) => _repository.GetEager(id);

        public void Update(Appointement doctor) => _repository.Update(doctor);

        IEnumerable<Appointement> IService<Appointement, long>.GetAll() => _repository.GetAll();

        /*

        public Doctor[] ViewAvailableDoctors(DateTime start, DateTime end)
        {
            // TODO: implement+
            return null;
        }

        public int ViewAvailableDates(int doctorId)
        {
            // TODO: implement+
            return 0;
        }

        public DateTime[] ViewAvaliableDates(int doctorID)
        {
            // TODO: implement +
            return null;
        }

        public DateTime[] ViewAvaliableTerms(int doctorID, DateTime date)
        {
            // TODO: implement +
            return null;
        }
        */
    }
}
