using Microsoft.AspNetCore.Mvc;
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
            int siteId = Convert.ToInt32(HttpContext.Request.Path.Value.Split('/').LastOrDefault());
            _workerService.CreateWorker(createWorkerDTO, siteId);

            return RedirectToAction("workerlist", new { siteId = siteId });
        }

        [Route("worker/updateworker/{siteId}/{workerId}")]
        public IActionResult UpdateWorker(int siteId, int workerId)
        {
            return View(_workerService.WorkerToUpdate(siteId, workerId));
        }

        [HttpPost]
        [Route("worker/updateworker/{siteId}/{workerId}")]
        public IActionResult UpdateWorker(UpdateWorkerDTO updateWorkerDTO, int siteId)
        {
            _workerService.UpdateWorker(updateWorkerDTO);
            return RedirectToAction("workerlist", new { siteId = siteId }); 
        }
    }
}
