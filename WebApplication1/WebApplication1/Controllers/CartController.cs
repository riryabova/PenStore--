using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PenStore.Domain.Entities;
using PenStore.Domain.Abstract;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private IPenRepository repository;
        private IOrderProcessor orderProcessor;


        public CartController(IPenRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }


        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }



        public RedirectToRouteResult AddToCart(Cart cart, int penId, string returnUrl)
        {
            Pen pen = repository.Pens
                .FirstOrDefault(g => g.PenId == penId);

            if (pen != null)
            {
                cart.AddItem(pen, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int penId, string returnUrl)
        {
            Pen pen = repository.Pens
                .FirstOrDefault(g => g.PenId == penId);

            if (pen != null)
            {
                cart.RemoveLine(pen);
            }
            return RedirectToAction("Index", new { returnUrl });
     
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        
    }

   

}