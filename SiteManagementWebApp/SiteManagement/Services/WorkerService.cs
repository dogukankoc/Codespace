using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
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
    }
}
