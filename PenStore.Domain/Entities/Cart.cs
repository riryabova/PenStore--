using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Pen pen, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Pen.PenId == pen.PenId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                   Pen = pen,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Pen pen)
        {
            lineCollection.RemoveAll(l => l.Pen.PenId == pen.PenId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Pen.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Pen Pen { get; set; }
        public int Quantity { get; set; }
    }
}