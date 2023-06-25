using Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using BusinessLogic.Models.DTO.ProductDTO;
using AutoMapper;

namespace BusinessLogic.Logics.ProductLogic
{
    public class ProductLogic
    {
        public ProductLogic(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public IGenericRepository<Product> _productRepo { get; }
        public IMapper _mapper { get; }

        public async Task<bool> AddProduct(ProductAddUIDTO addProduct)
        {
            if (addProduct is not null)
            {
                var addProductEntity = _mapper.Map<Product>(addProduct);
                await _productRepo.AddAndCommit(addProductEntity);
                return true;
            }
            else
            {
                return false;   
            }
            
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepo.GetAll();
        }

        public async Task<bool> UpdateProduct(ProductUpdateUIDTO productDTO)
        {
            var product = _productRepo.GetById(productDTO.Id);
            if (product is not null)
            {
                _mapper.Map(productDTO, product);
                _productRepo.Update(product);
                await _productRepo.Commit();
                return true;
            }
            else
            {
                return false;   
            }
            
        }

        public async Task<bool> DeleteProduct(ProductDeleteUIDTO productDTO)
        {
            var product = _productRepo.GetById(productDTO.Id);
            if (product is not null)
            {
                _productRepo.Delete(product);
                await _productRepo.Commit();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
