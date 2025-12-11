namespace Catalog.API.Data;

public class CatalogInitData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation))
            return;
        
        session.Store(GetPreconfiguredProducts());

        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
        {
            // --- SMARTPHONES ---
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "IPhone 15 Pro",
                Category = new List<string> { "Smart Phone", "Apple" },
                Description = "Điện thoại Apple mới nhất với khung titan.",
                ImageFile = "iphone-15-pro.png",
                Price = 25000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S24 Ultra",
                Category = new List<string> { "Smart Phone", "Samsung" },
                Description = "Điện thoại Android mạnh mẽ với bút S-Pen.",
                ImageFile = "samsung-s24.png",
                Price = 23000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Google Pixel 8",
                Category = new List<string> { "Smart Phone", "Google" },
                Description = "Trải nghiệm Android thuần khiết và camera AI.",
                ImageFile = "pixel-8.png",
                Price = 18000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Xiaomi 14",
                Category = new List<string> { "Smart Phone", "Xiaomi" },
                Description = "Cấu hình khủng trong tầm giá hợp lý.",
                ImageFile = "xiaomi-14.png",
                Price = 15000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Oppo Find X6",
                Category = new List<string> { "Smart Phone", "Oppo" },
                Description = "Thiết kế thời trang và camera selfie đẹp.",
                ImageFile = "oppo-find-x6.png",
                Price = 16500000
            },

            // --- LAPTOPS ---
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "MacBook Pro M3",
                Category = new List<string> { "Laptop", "Apple" },
                Description = "Laptop hiệu năng cao cho lập trình viên và designer.",
                ImageFile = "macbook-m3.png",
                Price = 45000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 13",
                Category = new List<string> { "Laptop", "Dell" },
                Description = "Laptop Windows mỏng nhẹ và sang trọng.",
                ImageFile = "dell-xps-13.png",
                Price = 32000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Asus ROG Strix",
                Category = new List<string> { "Laptop", "Gaming" },
                Description = "Laptop gaming cấu hình mạnh mẽ chiến mọi game.",
                ImageFile = "asus-rog.png",
                Price = 35000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "HP Spectre x360",
                Category = new List<string> { "Laptop", "HP" },
                Description = "Laptop xoay gập 2 trong 1 linh hoạt.",
                ImageFile = "hp-spectre.png",
                Price = 29000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Lenovo ThinkPad X1",
                Category = new List<string> { "Laptop", "Business" },
                Description = "Bàn phím tốt nhất thế giới, dành cho doanh nhân.",
                ImageFile = "thinkpad-x1.png",
                Price = 38000000
            },

            // --- CAMERAS ---
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sony A7 IV",
                Category = new List<string> { "Camera", "Sony" },
                Description = "Máy ảnh Mirrorless full-frame đa dụng.",
                ImageFile = "sony-a7iv.png",
                Price = 55000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Canon EOS R6",
                Category = new List<string> { "Camera", "Canon" },
                Description = "Máy ảnh chụp tốc độ cao và lấy nét chính xác.",
                ImageFile = "canon-r6.png",
                Price = 52000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fujifilm X-T5",
                Category = new List<string> { "Camera", "Fujifilm" },
                Description = "Thiết kế hoài cổ với giả lập màu film đẹp.",
                ImageFile = "fuji-xt5.png",
                Price = 41000000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "GoPro Hero 12",
                Category = new List<string> { "Camera", "Action" },
                Description = "Camera hành trình chống rung tuyệt đỉnh.",
                ImageFile = "gopro-12.png",
                Price = 10000000
            },

            // --- ACCESSORIES & OTHERS ---
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "AirPods Pro 2",
                Category = new List<string> { "Accessories", "Audio" },
                Description = "Tai nghe chống ồn chủ động tốt nhất của Apple.",
                ImageFile = "airpods-pro.png",
                Price = 5500000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sony WH-1000XM5",
                Category = new List<string> { "Accessories", "Audio" },
                Description = "Tai nghe chụp tai chống ồn hàng đầu.",
                ImageFile = "sony-xm5.png",
                Price = 7500000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Logitech MX Master 3S",
                Category = new List<string> { "Accessories", "PC Gear" },
                Description = "Chuột không dây công thái học cho năng suất cao.",
                ImageFile = "mx-master-3s.png",
                Price = 2500000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Keychron Q1 Pro",
                Category = new List<string> { "Accessories", "Keyboard" },
                Description = "Bàn phím cơ custom nhôm nguyên khối.",
                ImageFile = "keychron-q1.png",
                Price = 4500000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "LG UltraGear Monitor",
                Category = new List<string> { "Electronics", "Monitor" },
                Description = "Màn hình 27 inch 144Hz cho game thủ.",
                ImageFile = "lg-monitor.png",
                Price = 8900000
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple Watch Series 9",
                Category = new List<string> { "Accessories", "Watch" },
                Description = "Đồng hồ thông minh theo dõi sức khỏe.",
                ImageFile = "apple-watch-s9.png",
                Price = 10500000
            }
        };
    }
}