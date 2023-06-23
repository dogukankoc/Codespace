using Microsoft.AspNetCore.Mvc;
using SiteManagement.Models.Db;
using SiteManagement.Models.Db.Entities;
using SiteManagement.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteManagement.Controllers
{
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("worker/workerlist/{siteId}")]
        public IActionResult WorkerList(int siteId)
        {
            using (var context = new SiteManagementDbContext())
            {
                ViewBag.SiteName = context.Sites.Where(s => s.Id == siteId).Select(s => s.Name).FirstOrDefault();
                ViewBag.SiteId = siteId;
                ViewBag.WorkerList = context.Workers.Where(w => w.SiteId == siteId).ToList();
                
               
            }
            return View(siteId);
        }

        [Route("worker/deleteworker")]
        [HttpPost]
        public IActionResult DeleteWorker(int workerId)
        {
            using (var context = new SiteManagementDbContext())
            {
                var toBeDeletedWorker = context.Workers.FirstOrDefault(x => x.Id == workerId);
                context.Workers.Remove(toBeDeletedWorker);
                return Ok(context.SaveChanges());
            }
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
