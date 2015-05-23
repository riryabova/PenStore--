using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PenStore.Domain.Entities;

namespace WebApplication1.Models
{
    public class PensListViewModel
    {
        public IEnumerable<Pen> Pens { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}