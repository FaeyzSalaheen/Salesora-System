using RoyalSoftSellingSystem.DTO;
using RoyalSoftSellingSystem.Models;

namespace RoyalSoftSellingSystem.Services
{
    public class SalesInvoiceServices
    {
        public class SalesInvoiceServicess
        {
             private readonly AppDbContext _context;

            public SalesInvoiceServicess(AppDbContext context)
            {
                _context = context;
            }
            public async Task<(bool Success, string Message)> CreateInvoiceAsync(SalesInvoiceDto dto)
            {
              


                return (true, "Sales invoice created successfully");
            }
        }
    }
}
