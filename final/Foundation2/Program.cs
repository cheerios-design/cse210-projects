using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create two orders with products
        Product product1 = new Product("Laptop", "P001", 1200.00, 2);
        Product product2 = new Product("Headphones", "P002", 150.00, 3);
        Product product3 = new Product("Mouse", "P003", 30.00, 5);

        Customer customer1 = new Customer("John Doe", new Address("123 Main St", "Cityville", "CA", "USA"));
        Customer customer2 = new Customer("Jane Smith", new Address("456 Oak St", "Townsville", "ON", "Canada"));

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display results
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("\nOrder 1 Total Price: $" + order1.GetTotalPrice());

        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine("\nOrder 2 Total Price: $" + order2.GetTotalPrice());
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in products)
        {
            totalPrice += product.GetTotalPrice();
        }

        // Adding shipping cost based on customer's location
        if (customer.IsInUSA())
        {
            totalPrice += 5.00;
        }
        else
        {
            totalPrice += 35.00;
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in products)
        {
            packingLabel += $"{product.Name} - {product.ProductId}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{customer.Name}\n{customer.GetAddressString()}";
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return price * quantity;
    }

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string Name { get { return name; } }

    public string GetAddressString()
    {
        return address.ToString();
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public override string ToString()
    {
        return $"{streetAddress}\n{city}, {state}\n{country}";
    }
}
