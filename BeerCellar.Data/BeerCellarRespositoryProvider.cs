using BeerCellar.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCellar.Data
{
    /// <summary>
    /// Provider
    /// </summary>
    public class BeerCellarRespositoryProvider
    {
        /// <summary>
        /// Factory method
        /// </summary>
        /// <returns></returns>
        public static IBeerCellarRepository GetRepository()
        {
            return new BeerCellarRepository();
        }
    }
}
