using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PenStore.Domain.Abstract;
using PenStore.Domain.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PenController : Controller
    {
       private IPenRepository repository;

       public int pageSize = 4;
        public PenController(IPenRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int page = 1)
        {
            PensListViewModel model = new PensListViewModel
            {
                Pens = repository.Pens
                 .Where(p => category == null || p.Category == category)
                    .OrderBy(game => game.PenId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        repository.Pens.Count() :
        repository.Pens.Where(game => game.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
       
        
        public FileContentResult GetImage(int penId)
        {
            Pen pen = repository.Pens
                .FirstOrDefault(g => g.PenId == penId);

            if (pen != null)
            {
                return File(pen.ImageData, pen.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}