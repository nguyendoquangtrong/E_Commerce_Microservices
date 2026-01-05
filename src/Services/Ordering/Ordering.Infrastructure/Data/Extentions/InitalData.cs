namespace Ordering.Infrastructure.Data.Extentions;

public class InitalData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            // User 1: Nguyễn Văn A
            Customer.Create(
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                "Nguyen Van A",
                "nguyenvana@test.com"
            ),

            // User 2: Trần Thị B
            Customer.Create(
                CustomerId.Of(new Guid("74f391a6-871d-4074-b911-396a9e8677c7")),
                "Tran Thi B",
                "tranthib@test.com"
            ),

            // User 3: Lê Văn C
            Customer.Create(
                CustomerId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")),
                "Le Van C",
                "levanc@test.com"
            ),

            // User 4: Phạm Minh D
            Customer.Create(
                CustomerId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f6a7e0a09")),
                "Pham Minh D",
                "phamminhd@test.com"
            ),

            // User 5: Hoàng Yến E
            Customer.Create(
                CustomerId.Of(new Guid("d94827d3-05c0-4493-8671-298e3b006231")),
                "Hoang Yen E",
                "hoangyene@test.com"
            )
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
    {
        // Sản phẩm 1: Điện thoại High-end
        Product.Create(
            ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 
            "IPhone 15 Pro Max", 
            30000000m // 30 triệu
        ),

        // Sản phẩm 2: Điện thoại Android
        Product.Create(
            ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 
            "Samsung Galaxy S24 Ultra", 
            25000000m // 25 triệu
        ),

        // Sản phẩm 3: Laptop
        Product.Create(
            ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f6a7e0a09")), 
            "MacBook Pro M3 14 inch", 
            45000000m // 45 triệu
        ),

        // Sản phẩm 4: Phụ kiện
        Product.Create(
            ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 
            "Sony WH-1000XM5 Headphones", 
            8500000m // 8.5 triệu
        ),

        // Sản phẩm 5: Màn hình
        Product.Create(
            ProductId.Of(new Guid("b786103d-c621-4f5a-b498-23452610f88c")), 
            "Dell UltraSharp U2723QE", 
            12000000m // 12 triệu
        )
    };
    
    public static IEnumerable<Order> Orders
    {
        get
        {
            var orders = new List<Order>();

            // ==========================================================
            // ORDER 1: Của Customer A (Mua iPhone và Tai nghe)
            // ==========================================================
            var order1 = Order.Create(
                id: OrderId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")),
                customerId: CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), // ID của Nguyen Van A
                orderName: OrderName.Of("ORD-2024-001"),
                shippingAddress: Address.Of("Nguyen Van", "A", "123 Le Loi", "nguyenvana@test.com", "Ho Chi Minh", "Vietnam", "700000"),
                billingAddress: Address.Of("Nguyen Van", "A", "123 Le Loi", "nguyenvana@test.com", "Ho Chi Minh", "Vietnam", "700000"),
                payment: Payment.Of("Nguyen Van A", "1234567890123456", "12/25", "123", 1) // 1 = CreditCard
            );

            // Thêm Order Items (Gọi hàm Add của Domain)
            // 1. IPhone 15 Pro Max (Giá 30tr, mua 1 cái)
            order1.Add(
                ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 
                1, 
                30000000m
            );

            // 2. Sony Headphones (Giá 8.5tr, mua 2 cái)
            order1.Add(
                ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 
                2, 
                8500000m
            );

            orders.Add(order1);

            // ==========================================================
            // ORDER 2: Của Customer B (Mua MacBook)
            // ==========================================================
            var order2 = Order.Create(
                id: OrderId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")),
                customerId: CustomerId.Of(new Guid("74f391a6-871d-4074-b911-396a9e8677c7")), // ID của Tran Thi B
                orderName: OrderName.Of("ORD-2024-002"),
                shippingAddress: Address.Of("Tran Thi", "B", "456 Tran Hung Dao", "tranthib@test.com", "Ha Noi", "Vietnam", "100000"),
                billingAddress: Address.Of("Tran Thi", "B", "456 Tran Hung Dao", "tranthib@test.com", "Ha Noi", "Vietnam", "100000"),
                payment: Payment.Of("Tran Thi B", "9876543210987654", "10/26", "999", 1)
            );

            // Thêm Order Items
            // 1. MacBook Pro (Giá 45tr, mua 1 cái)
            order2.Add(
                ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f6a7e0a09")), 
                1, 
                45000000m
            );

            orders.Add(order2);

            return orders;
        }
    }
    
}