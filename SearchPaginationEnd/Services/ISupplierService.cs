using SearchPaginationEnd.Models;

namespace SearchPaginationEnd.Services
{
    public interface ISupplierService
    {
        List<Supplier> GetSuppliers(string sortColumn, string sortOrder);
    }
}
