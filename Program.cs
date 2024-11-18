using System;
using System.Collections.Generic;
using System.Linq;

public class Business
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }
}

public class BusinessManager
{
    private readonly List<Business> businessList = [];

    public void GetBusinessList()
    {
        if (businessList.Count != 0)
        {
            Console.WriteLine("ID | Title\t\t| Description\t\t| Completed");
            Console.WriteLine("------------------------------------------------------");
            foreach (var business in businessList)
            {
                Console.WriteLine($"{business.Id}  | {business.Title,-12} | {business.Description,-18} | {business.IsCompleted}");
            }
        }
        else
        {
            Console.WriteLine("No businesses found.");
        }
    }

    public void AddBusiness(int id, string title, string description)
    {
        if (businessList.Any(b => b.Id == id))
        {
            Console.WriteLine("Business with this ID already exists.");
        }
        else
        {
            businessList.Add(new Business { Id = id, Title = title, Description = description, IsCompleted = false });
            Console.WriteLine("Your business was created successfully");
        }
    }

    public void UpdateBusiness(int id, string newTitle, string newDescription)
    {
        var business = businessList.FirstOrDefault(x => x.Id == id);
        if (business != null)
        {
            business.Title = newTitle;
            business.Description = newDescription;
            Console.WriteLine("Your business was updated successfully");
        }
        else
        {
            Console.WriteLine("Business not found");
        }
    }

    public void RemoveBusiness(int id)
    {
        var business = businessList.FirstOrDefault(x => x.Id == id);
        if (business != null)
        {
            businessList.Remove(business);
            Console.WriteLine("Your business was deleted successfully");
        }
        else
        {
            Console.WriteLine("Business not found");
        }
    }

    public void MarkAsCompleted(int id)
    {
        var business = businessList.FirstOrDefault(x => x.Id == id);
        if (business != null)
        {
            business.IsCompleted = true;
            Console.WriteLine("Your business setted as completed successfully");
        }
        else
        {
            Console.WriteLine("Business not found");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var businessManager = new BusinessManager();

        string? input;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to your business list\n");
            Console.WriteLine("Please, write a number to continue:\n");
            Console.WriteLine("1. View all business");
            Console.WriteLine("2. Add new business");
            Console.WriteLine("3. Update your business");
            Console.WriteLine("4. Delete your business");
            Console.WriteLine("5. Mark as completed");
            Console.WriteLine("6. Exit");

            input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    businessManager.GetBusinessList();
                    break;
                case "2":
                    Console.Write("Enter business ID: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Enter title: ");
                        string? title = Console.ReadLine();

                        Console.Write("Enter description: ");
                        string? description = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
                        {
                            Console.WriteLine("Title and description cannot be empty.");
                        }
                        else
                        {
                            businessManager.AddBusiness(id, title, description);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a number.");
                    }
                    break;
                case "3":
                    Console.Write("Enter business ID: ");
                    if (int.TryParse(Console.ReadLine(), out int updId))
                    {
                        Console.Write("Enter new title: ");
                        string? newTitle = Console.ReadLine();

                        Console.Write("Enter new description: ");
                        string? newDescription = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newDescription))
                        {
                            Console.WriteLine("Title and description cannot be empty.");
                        }
                        else
                        {
                            businessManager.UpdateBusiness(updId, newTitle, newDescription);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;
                case "4":
                    Console.Write("Enter business ID: ");
                    if (int.TryParse(Console.ReadLine(), out int delId))
                    {
                        businessManager.RemoveBusiness(delId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;
                case "5":
                    Console.Write("Enter business ID to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int markId))
                    {
                        businessManager.MarkAsCompleted(markId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        } while (input != "6");
    }
}
