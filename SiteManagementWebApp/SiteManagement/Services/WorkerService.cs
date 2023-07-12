using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Services
{
    public class WorkerService
    {
        readonly SiteManagementDbContext _context;
        public WorkerService(SiteManagementDbContext context)
        {
            _context = context;
        }

        public List<Worker> GetWorkerList(int siteId)
        {
            return _context.Workers.Where(w => w.SiteId == siteId).ToList();
        }

        public void DeleteWorker(int workerId)
        {
            var toBeDeletedWorker = _context.Workers.FirstOrDefault(x => x.Id == workerId);
            _context.Workers.Remove(toBeDeletedWorker);
            _context.SaveChanges();
        }

        public void CreateWorker(CreateWorkerDTO createWorkerDTO, int siteId)
        {
            var worker = new Worker()
            {
                NameSurname = createWorkerDTO.NameSurname,
                Duty = createWorkerDTO.Duty,
                SiteId = siteId
            };
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }

        public UpdateWorkerDTO WorkerToUpdate(int siteId, int workerId)
        {
            var worker = _context.Workers
                   .Where(w => w.SiteId == siteId && w.Id == workerId)
                   .Select(w => new UpdateWorkerDTO
                   {
                       WorkerId = w.Id,
                       NameSurname = w.NameSurname,
                       Duty = w.Duty,
                       SiteId = siteId
                   })
                   .FirstOrDefault();
            return worker;
        }

        public void UpdateWorker(UpdateWorkerDTO updateWorkerDTO)
        {
            var toBeUpdatedWorker = _context.Workers.FirstOrDefault(a => a.Id == updateWorkerDTO.WorkerId);
            toBeUpdatedWorker.NameSurname = updateWorkerDTO.NameSurname;
            toBeUpdatedWorker.Duty = updateWorkerDTO.Duty;
            _context.SaveChanges();
        }
    }
}
