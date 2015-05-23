using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PenStore.Domain.Entities;

namespace WebApplication1.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}