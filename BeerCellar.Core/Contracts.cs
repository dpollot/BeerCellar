using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCellar.Core
{
    public interface IBeerCellarRepository
    {
        IEnumerable<CellarEntry> GetCollection();
        CellarEntry InsertEntry(CellarEntry entry);
        CellarEntry UpdateEntry(CellarEntry entry);
    }
}
