Inventory Management System
Overview
The Inventory Management System is a simple console application written in C# for managing product inventory. The system includes classes for basic products and perishable products, an inventory manager class, and functionalities for adding products, updating product information, and displaying the inventory.

Getting Started
Prerequisites
.NET SDK must be installed on your machine.
Running the Program
Clone the repository:

bash
Copy code
git clone https://github.com/your-username/inventory-management.git
Navigate to the project directory:

bash
Copy code
cd inventory-management
Run the program:

bash
Copy code
dotnet run
Follow the on-screen instructions to interact with the Inventory Management System.

Classes

1. Product
   Properties:

Id: Unique identifier for the product.
Name: Name of the product.
Price: Price of the product.
Quantity: Quantity of the product in stock.
Methods:

Display(): Displays the product information.
UpdateProductInfo(string name, decimal price, int quantity): Updates the product information based on the provided parameters. 2. PerishableProduct (Inherits from Product)
Properties:

ExpiryDate: Expiry date for perishable products.
Methods:

Display(): Overrides the base method to display perishable product information. 3. InventoryManager
Properties:

products: List of products in the inventory.
Methods:

AddProduct(Product product): Adds a product to the inventory.
UpdateProductInformation(int productId, string name, decimal price, int quantity): Updates the information of an existing product.
DisplayInventory(): Displays all products in the inventory.
Error Handling
Adding Products:

Validates that the product ID is greater than 0.
Checks for duplicate product IDs in the inventory.
Displays appropriate error messages in case of validation failures.
Updating Product Information:

Validates that the product exists in the inventory.
Displays an error message if the product is not found.
Guidelines Satisfaction
The program satisfies the provided guidelines in the following ways:

Abstraction:

The classes provide abstraction by encapsulating the details of product and inventory management.
Encapsulation:

Internal details of the classes are private, and public methods are available for external behaviors.
Inheritance:

The PerishableProduct class inherits from the base Product class, avoiding code duplication.
Polymorphism:

The Display method is overridden in the PerishableProduct class, demonstrating polymorphism.
