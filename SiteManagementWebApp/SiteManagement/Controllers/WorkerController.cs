using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using SiteManagement.Services;
using System;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class WorkerController : Controller
    {
        readonly WorkerService _workerService;
        readonly SiteService _siteService;
        public WorkerController(WorkerService workerService, SiteService siteService)
        {
            _workerService = workerService;
            _siteService = siteService;
        }   

        [Route("worker/workerlist/{siteId}")]
        public IActionResult WorkerList(int siteId)
        {
            var site = _siteService.GetSiteWithWorkers(siteId);
            ViewBag.SiteName = site.Name;
            ViewBag.WorkerList = site.Workers.ToList();
            return View(siteId);
        }

        [Route("worker/deleteworker")]
        [HttpPost]
        public IActionResult DeleteWorker(int workerId)
        {
                _workerService.DeleteWorker(workerId);
                return Ok();
        }

        [Route("worker/createworker/{siteId}")]
        public IActionResult CreateWorker(int siteId)
        {
            ViewBag.SiteId = siteId;
            return View();
        }

        [Route("worker/createworker/{siteId}")]
        [HttpPost]
        public IActionResult CreateWorker(CreateWorkerDTO createWorkerDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var worker = new Worker()
                {
                    NameSurname = createWorkerDTO.NameSurname,
                    Duty = createWorkerDTO.Duty,
                    SiteId = Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault())
                };
                context.Workers.Add(worker);
                context.SaveChanges();
                return RedirectToAction("workerlist", new { siteId = worker.SiteId });
            }
        }

        [Route("worker/updateworker/{siteId}/{workerId}")]
        public IActionResult UpdateWorker(int siteId, int workerId)
        {
            ViewBag.SiteId = siteId;
            using(var context = new SiteManagementDbContext())
            {
                var worker = context.Workers
                    .Where(w => w.SiteId == siteId && w.Id == workerId)
                    .Select(w => new UpdateWorkerDTO
                    {
                        WorkerId = w.Id,
                        NameSurname = w.NameSurname,
                        Duty = w.Duty,
                    })
                    .FirstOrDefault();
                return View(worker); //Model içini doldurup gönderdik.
            }
        }

        [HttpPost]
        [Route("worker/updateworker/{siteId}/{workerId}")]
        public IActionResult UpdateWorker(UpdateWorkerDTO updateWorkerDTO)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeUpdatedWorker = context.Workers.FirstOrDefault(a => a.Id == updateWorkerDTO.WorkerId);
                toBeUpdatedWorker.NameSurname = updateWorkerDTO.NameSurname;
                toBeUpdatedWorker.Duty = updateWorkerDTO.Duty;
                context.SaveChanges();
                return RedirectToAction("workerlist", new { siteId = toBeUpdatedWorker.SiteId });
            }
        }

    }
}
