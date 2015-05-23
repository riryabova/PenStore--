using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenStore.Domain.Entities;
using PenStore.Domain.Abstract;

namespace PenStore.Domain.Concrete
{
    public class EFPenRepository : IPenRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Pen> Pens
        {
            get { return context.Pens; }
        }

        public void SavePen(Pen pen)
        {
            if (pen.PenId == 0)
                context.Pens.Add(pen);
            else
            {
                Pen dbEntry = context.Pens.Find(pen.PenId);
                if (dbEntry != null)
                {
                    dbEntry.Name = pen.Name;
                    dbEntry.Description = pen.Description;
                    dbEntry.Price = pen.Price;
                    dbEntry.Category = pen.Category;
                    dbEntry.ImageData = pen.ImageData;
                    dbEntry.ImageMimeType = pen.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Pen DeletePen(int penId)
        {
            Pen dbEntry = context.Pens.Find(penId);
            if (dbEntry != null)
            {
                context.Pens.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
