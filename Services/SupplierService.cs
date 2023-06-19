using Northwind.DbConnector;
using Northwind.DTOs;
using AutoMapper;
using Northwind.Models;


namespace Northwind.Services
{
    public class SupplierService
    {
        // Instance variables.
        private readonly MyAppDbContext _context;
        private readonly IMapper _mapper;

        //Constructor.
        public SupplierService(MyAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Get all Suppliers.
        public List<SupplierDTO> GetAllSuppliers() 
        {
        var suppliers = _context.Suppliers.ToList();
        var supplierDTOs = _mapper.Map<List<SupplierDTO>>(suppliers);
        return supplierDTOs;
        }

        public SupplierDTO AddSupplier(SupplierDTO supplierDTO)
        {
            var supplier = _mapper.Map<Supplier>(supplierDTO); // Map DTO to entity

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            var addedSupplierDTO = _mapper.Map<SupplierDTO>(supplier); // Map entity back to DTO
            return addedSupplierDTO;
        }



        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new InvalidOperationException("Supplier not found");
            }
            _context.Suppliers.Remove(supplier);

            _context.SaveChanges();
        }







    }
}
