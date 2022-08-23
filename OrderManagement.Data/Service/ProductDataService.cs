using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using OrderManagement.Data.Interface.Service;
using OrderManagement.Model;

namespace OrderManagement.Data.Service
{
    public class ProductDataService : IProductDataService
    {
        private const string CONNECTION_STRING = "Data/ProductList.json";
        public ProductDataService()
        { 
        }

        public async Task<List<Product>> GetProductList()
        {
            using (StreamReader reader = new StreamReader(CONNECTION_STRING))
            {
                string productData = await reader.ReadToEndAsync();
                List<Product> productList = JsonSerializer.Deserialize<List<Product>>(productData);
                return productList;
            }  
        }
    }
}
