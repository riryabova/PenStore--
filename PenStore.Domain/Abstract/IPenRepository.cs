using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PenStore.Domain.Entities;

namespace PenStore.Domain.Abstract
{
    public interface IPenRepository
    {
        IEnumerable<Pen> Pens { get; }
        void SavePen(Pen pen);
       Pen DeletePen(int penId);
    }
}
