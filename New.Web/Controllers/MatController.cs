using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New.Domain.Abstract;
using New.Domain.Entities;
using New.Web.Models;

namespace New.Web.Controllers
{
    public class MatController : Controller
    {
        private IMatRepository repository;
        private ISheetRepository repSheet;
        public int pageSize = 6;
         public MatController(IMatRepository repo, ISheetRepository r)
        {
            repository = repo;
            repSheet = r;
        }

        public ViewResult List(string category,int page=1)
        {
            MatListViewModel model=new MatListViewModel
            {
                Materials=repository.Materials
                .Where(p => category == null || p.type == category)
                .OrderBy(material => material.index)
                .Skip((page - 1)*pageSize)
                .Take(pageSize),
                  PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                     TotalItems = category == null ?
                     repository.Materials.Count() :
        repository.Materials.Where(game => game.type == category).Count()
                    
                },
                CurrentCategory = category,
                Sheets=repSheet.Sheets,
            };
            return View(model);

        
        }
	}
}