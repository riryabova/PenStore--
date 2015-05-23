using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PenStore.Domain.Abstract;
namespace WebApplication1.Controllers
{
    public class NavController : Controller
    {
        private IPenRepository repository;

        public NavController(IPenRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Pens
                .Select(pen => pen.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}