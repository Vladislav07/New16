using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New.Domain.Abstract;

namespace New.Web.Controllers
{
    public class NavController : Controller
    {
        private IMatRepository repository;

        public NavController(IMatRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Materials
                .Select(game => game.type)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }


	}
}