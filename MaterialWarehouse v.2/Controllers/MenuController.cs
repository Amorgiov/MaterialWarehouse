using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MaterialWarehouse.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MaterialWarehouse_v._2.Models;
using Models;

namespace MaterialWarehouse_v._2.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        public MaterialRepository Repo;
        
        public MenuController(ILogger<MenuController> logger, MaterialRepository repo)
        {
            Repo = repo;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult InputMaterial()
        {
            return View();
        }
        
        public IActionResult Materials()
        {
            return View(Repo.GetMaterials());
        }
        
        public IActionResult InputMaterials()
        {
            return View(Repo.GetInputMaterials());
        }
        
        public IActionResult OutputMaterials()
        {
            return View(Repo.GetOutputMaterials());
        }
        
        public IActionResult IransferMaterials()
        {
            return View(Repo.GetTransferMaterials());
        }
        
        public IActionResult Material()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult InputMaterial(InputMaterials inputMaterials)
        {
            Repo.CreateInputMaterial(inputMaterials);
            return RedirectToAction("InputMaterial");
        }
        
        [HttpPost]
        public ActionResult Material(Materials materials)
        {
            Repo.CreateNewMateral(materials);
            return RedirectToAction("Material");
        }

        public IActionResult OutputMaterial()
        {
            return View();
        }
        
        public IActionResult TransferMaterial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransferMaterial(TransferMaterials transferMaterials)
        {
            Repo.CreateTransferMaterial(transferMaterials);
            return RedirectToAction("TransferMaterial");
        }
        
        [HttpPost]
        public ActionResult OutputMaterial(OutputMaterials outputMaterials)
        {
            Repo.CreateOutputMaterial(outputMaterials);
            return RedirectToAction("OutputMaterial");
        }

        

        public ActionResult Edit(int id)
        {
            Materials materials = Repo.Get(id);
            return View(materials);
        }
        [HttpPost]
        public ActionResult Edit(Materials materials)
        {
            Repo.UpdateMaterial(materials);
            return RedirectToAction("Edit");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        
    }
}