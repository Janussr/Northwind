using Northwind.DbConnector;
using Northwind.DTOs;
using AutoMapper;
using Northwind.Models;

namespace Northwind.Services
{
    public class ProductService
    {
        // Instance variables
        private readonly MyAppDbContext _context;
        private readonly IMapper _mapper;
        
        
        //Constructor
        public ProductService(MyAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //Get all products
        public List<ProductDTO> GetAllProducts()
        {
            var products = _context.Products.ToList();
            var productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }

        //Get a product by its ID
        public ProductDTO GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            var productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        //Create a new product
        public ProductDTO AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto); // Map DTO to entity

            _context.Products.Add(product);
            _context.SaveChanges();

            var addedProductDto = _mapper.Map<ProductDTO>(product); // Map entity back to DTO
            return addedProductDto;
        }

        //Change the product
        public ProductDTO UpdateProduct(int productId, ProductDTO model)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }

            // Map properties from DTO to entity
            _mapper.Map(model, product);

            _context.SaveChanges();

            // Map updated entity back to DTO
            var updatedProductDto = _mapper.Map<ProductDTO>(product);
            return updatedProductDto;
        }


        //Delete a product
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            _context.Products.Remove(product);

            _context.SaveChanges();
        }



    }
}
