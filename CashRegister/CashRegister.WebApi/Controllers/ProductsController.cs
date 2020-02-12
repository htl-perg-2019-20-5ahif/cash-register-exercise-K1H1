using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CashRegister.Shared;
using CashRegister.WebApi;

namespace CashRegister.WebApi.Controllers
{

	[ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly CashRegisterDataContext DataContext;

		// Note the use of constructor injection to get the data context
		public ProductsController(CashRegisterDataContext dataContext)
		{
			DataContext = dataContext;
		}

		[HttpGet]
		public async Task<IEnumerable<Product>> Get([FromQuery]string nameFilter = null)
		{
			IQueryable<Product> products = DataContext.Products;

			// Apply filter if one is given
			if (!string.IsNullOrEmpty(nameFilter))
			{
				products = products.Where(p => p.ProductName.Contains(nameFilter));
			}

			return await products.ToListAsync();
		}
	}
}
