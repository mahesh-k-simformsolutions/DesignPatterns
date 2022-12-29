using EventSourcing.Data;
using EventSourcing.Events;
using EventSourcing.Repository;
using System;

// Simple console application to demonstrate event sourcing design pattern
namespace EventSourcing
{
    internal class Program
    {
        private static void Main()
        {
            ProductRepository productRepository = new();

            Projection projection = new(new AppDbContext());
            productRepository.Subscribe(projection.ReceiveEvent);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Simple console application to demonstrate event sourcing design pattern");
            Console.ResetColor();

            string key = string.Empty;
            while (key != "X")
            {
                Console.WriteLine("R: Receive Inventory");
                Console.WriteLine("S: Ship Inventory");
                Console.WriteLine("A: Inventory Adjustment");
                Console.WriteLine("Q: Available Quantity");
                Console.WriteLine("E: Events");
                Console.WriteLine("P: Projection");
                Console.Write("> ");
                key = Console.ReadLine()?.ToUpper();
                Console.WriteLine();

                // Read Id
                Console.Write("id: ");
                string id = Console.ReadLine();
                WarehouseProduct warehouseProduct = productRepository.Get(id);

                switch (key)
                {
                    case "R":
                        (int Quantity, bool IsValid) = GetQuantity();
                        if (IsValid)
                        {
                            warehouseProduct.ReceiveProduct(Quantity);
                            Console.WriteLine($"{id} Received: {Quantity}");
                        }
                        break;
                    case "S":
                        (int Quantity, bool IsValid) shipInput = GetQuantity();
                        if (shipInput.IsValid)
                        {
                            warehouseProduct.ShipProduct(shipInput.Quantity);
                            Console.WriteLine($"{id} Shipped: {shipInput.Quantity}");
                        }
                        break;
                    case "A":
                        (int Quantity, bool IsValid) adjustmentInput = GetQuantity();
                        if (adjustmentInput.IsValid)
                        {
                            // Read reason
                            Console.Write("Reason: ");
                            string reason = Console.ReadLine();
                            warehouseProduct.AdjustInventory(adjustmentInput.Quantity, reason);
                            Console.WriteLine($"{id} Adjusted: {adjustmentInput.Quantity} {reason}");
                        }
                        break;
                    case "Q":
                        int availableQuantity = warehouseProduct.GetAvailableQuantity();
                        Console.WriteLine($"{id} Available Quantity: {availableQuantity}");
                        break;
                    case "E":
                        Console.WriteLine($"Events: {id}");
                        foreach (IEvent evnt in warehouseProduct.GetAllEvents())
                        {
                            switch (evnt)
                            {
                                case ProductShippedEvent shipProduct:
                                    Console.WriteLine($"{shipProduct.DateTime} {id} Shipped: {shipProduct.Quantity}");
                                    break;
                                case ProductReceivedEvent receiveProduct:
                                    Console.WriteLine($"{receiveProduct.DateTime} {id} Received: {receiveProduct.Quantity}");
                                    break;
                                case InventoryAdjustedEvent inventoryAdjusted:
                                    Console.WriteLine($"{inventoryAdjusted.DateTime} {id} Adjusted: {inventoryAdjusted.Quantity} {inventoryAdjusted.Reason}");
                                    break;
                            }

                        }
                        break;
                    case "P":
                        Console.WriteLine($"Projection: {id}");
                        Product productProjection = projection.GetProduct(id);
                        Console.WriteLine($"{id} Received: {productProjection.Received}");
                        Console.WriteLine($"{id} Shipped: {productProjection.Shipped}");
                        break;
                }

                productRepository.Save(warehouseProduct);

                _ = Console.ReadLine();
                Console.WriteLine();
            }
        }

        private static (int Quantity, bool IsValid) GetQuantity()
        {
            Console.Write("Quantity: ");
            if (int.TryParse(Console.ReadLine(), out int quantity))
            {
                return (quantity, true);
            }
            else
            {
                Console.WriteLine("Invalid Quantity.");
                return (0, false);
            }
        }
    }
}
