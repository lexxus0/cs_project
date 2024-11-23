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
    private readonly List<Business> businessList = new List<Business>();

    public void GetBusinessList()
    {
        if (businessList.Count != 0)
        {
            Console.WriteLine("\nID | Title          | Description        | Completed");
            Console.WriteLine("-----------------------------------------------------");
            foreach (var business in businessList)
            {
                Console.WriteLine($"{business.Id,-2} | {business.Title,-14} | {business.Description,-18} | {business.IsCompleted}");
            }
        }
        else
        {
            Console.WriteLine("\nNo businesses found.");
        }
        Pause();
    }

    public void AddBusiness()
    {
        int id = ReadIntInput("Enter business ID: ");
        Console.Write("Enter title: ");
        string? title = Console.ReadLine();

        Console.Write("Enter description: ");
        string? description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("\nTitle and description cannot be empty.");
            return;
        }

        if (businessList.Any(b => b.Id == id))
        {
            Console.WriteLine("\nBusiness with this ID already exists.");
        }
        else
        {
            businessList.Add(new Business { Id = id, Title = title, Description = description, IsCompleted = false });
            Console.WriteLine("\nYour business was created successfully.");
        }
        Pause();
    }

    public void UpdateBusiness()
    {
        int id = ReadIntInput("Enter business ID to update: ");
        var business = FindBusiness(id);

        if (business != null)
        {
            Console.Write("Enter new title: ");
            string? newTitle = Console.ReadLine();

            Console.Write("Enter new description: ");
            string? newDescription = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newTitle) || string.IsNullOrWhiteSpace(newDescription))
            {
                Console.WriteLine("\nTitle and description cannot be empty.");
                return;
            }

            business.Title = newTitle;
            business.Description = newDescription;
            Console.WriteLine("\nYour business was updated successfully.");
        }
        else
        {
            Console.WriteLine("\nBusiness not found.");
        }
        Pause();
    }

    public void RemoveBusiness()
    {
        int id = ReadIntInput("Enter business ID to delete: ");
        var business = FindBusiness(id);

        if (business != null)
        {
            businessList.Remove(business);
            Console.WriteLine("\nYour business was deleted successfully.");
        }
        else
        {
            Console.WriteLine("\nBusiness not found.");
        }
        Pause();
    }

    public void MarkAsCompleted()
    {
        int id = ReadIntInput("Enter business ID to mark as completed: ");
        var business = FindBusiness(id);

        if (business != null)
        {
            business.IsCompleted = true;
            Console.WriteLine("\nYour business was marked as completed successfully.");
        }
        else
        {
            Console.WriteLine("\nBusiness not found.");
        }
        Pause();
    }

    private Business? FindBusiness(int id)
    {
        return businessList.FirstOrDefault(x => x.Id == id);
    }

    static private int ReadIntInput(string prompt)
    {
        int result;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return result;
    }

    static private void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
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
            Console.WriteLine("1. View all businesses");
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
                    businessManager.AddBusiness();
                    break;
                case "3":
                    businessManager.UpdateBusiness();
                    break;
                case "4":
                    businessManager.RemoveBusiness();
                    break;
                case "5":
                    businessManager.MarkAsCompleted();
                    break;
                case "6":
                    Console.WriteLine("See you!");
                    return;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        } while (input != "6");
    }
}
