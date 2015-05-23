using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PenStore.Domain.Abstract;
using PenStore.Domain.Entities;



namespace WebApplication1.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IPenRepository repository;

        public AdminController(IPenRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {

            return View(repository.Pens);
        }

        public ViewResult Edit(int penId)
        {
            Pen pen = repository.Pens
                .FirstOrDefault(g => g.PenId == penId);
            return View(pen);
        }
        // Перегруженная версия Edit() для сохранения изменений
        [HttpPost]
        public ActionResult Edit(Pen pen, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                   pen.ImageMimeType = image.ContentType;
                    pen.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(pen.ImageData, 0, image.ContentLength);
                }
                repository.SavePen(pen);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", pen.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(pen);
            }
        }
        public ViewResult Create()
        {
            return View("Edit", new Pen());
        }

        [HttpPost]
        public ActionResult Delete(int penId)
        {
            Pen deletedPen = repository.DeletePen(penId);
            if (deletedPen != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedPen.Name);
            }
            return RedirectToAction("Index");
        }
    }
}