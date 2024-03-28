using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Dapper.Abstract;
using SignalR.DataAccessLayer.UnitOfWork;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IUoWDal _uowDal;
        private readonly IProductDapperRepository _productDapperRepository;

		public ProductManager(IProductDal productDal, IUoWDal uowDal, IProductDapperRepository productDapperRepository)
		{
			_productDal = productDal;
			_uowDal = uowDal;
			_productDapperRepository = productDapperRepository;
		}

		public void TAdd(Product entity)
        {
            _productDal.Add(entity);
            _uowDal.Save();
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
            _uowDal.Save();
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

		public int TProductCount()
		{
			return _productDapperRepository.ProductCount();
		}

		public int TProductCountByCategoryNameDrink()
		{
			return _productDapperRepository.ProductCountByCategoryNameDrink();
		}

		public int TProductCountByCategoryNameHamburger()
		{
			return _productDapperRepository.ProductCountByCategoryNameHamburger();
		}

		public string TProductNameByMaxPrice()
		{
			return _productDapperRepository.ProductNameByMaxPrice();
		}

		public string TProductNameByMinPrice()
		{
			return _productDapperRepository.ProductNameByMinPrice();
		}

		public decimal TProductPriceAvg()
		{
			return _productDapperRepository.ProductPriceAvg();
		}

		public decimal TProductAvgPriceByHamburger()
		{
			return _productDapperRepository.ProductAvgPriceByHamburger();
		}

		public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
            _uowDal.Save();
        }
    }
}
