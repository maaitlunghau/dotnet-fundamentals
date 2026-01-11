using _02_layered_architecture.Models;

namespace _02_layered_architecture.Repository;

public interface IProductRepository
{
    // <>: Generic
    // dùng <> để nói với .NET rằng: 
    // "Kiểu dữ liệu này chưa cố định, sẽ được truyền vào sau"

    // mọi method có Task, bắt buộc phải có async / await

    // method bất đồng bộ
    // và khi hoàn thành sẽ trả về tập hợp các Product có thể duyệt được
    Task<IEnumerable<Product>> GetAllProductsAsync();

    // method bất đồng bộ
    // khi hoàn thành chỉ trả về 1 Product
    Task<Product?> GetProByIdAsync(int? id);

    Task AddProAsync(Product product);
    Task EditProAsync(Product product);
    Task DeleteProAsync(int id);
}
