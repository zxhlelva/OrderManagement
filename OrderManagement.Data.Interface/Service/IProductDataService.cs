using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Model;

namespace OrderManagement.Data.Interface.Service
{
    public interface IProductDataService
    {
        Task<List<Product>> GetProductList();
    }
}
