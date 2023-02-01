using RazorPlusServices.Models;

namespace RazorPlusServices.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetSuppliers(string sortColumn, string sortOrder);
    }
}
