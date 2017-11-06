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
    public class CartController : Controller
    {
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        private IMatRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(IMatRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;

        }

        public RedirectToRouteResult AddToCart(Cart cart, string returnUrl, int index = 1)
        {
            Material material = repository.Materials
                .FirstOrDefault(g => g.index == index);

            if (material != null)
            {
                cart.AddItem(material, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int index, string returnUrl)
        {
            Material Material = repository.Materials
                .FirstOrDefault(g => g.index == index);

            if (Material != null)
            {
                cart.RemoveLine(Material);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Material GetMat()
        {
            Material m = (Material)Session["Material"];
            if (m == null)
            {
                m = new Material();
                Session["Material"] = m;
            }
            return m;
        } 

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new RequestDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, RequestDetails requestDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, requestDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(requestDetails);
            } 
        }

        

	}
}