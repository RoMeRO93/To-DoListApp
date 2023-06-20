using System;
using System.Collections.Generic;

class TaskItem
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title)
    {
        Title = title;
        IsCompleted = false;
    }
}

class ToDoListApp
{
    static List<TaskItem> taskList = new List<TaskItem>();

    static void Main()
    {
        Console.WriteLine("Welcome to To-Do List App!");

        bool continueManaging = true;

        while (continueManaging)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Add a new task");
            Console.WriteLine("2. Mark a task as completed");
            Console.WriteLine("3. View all tasks");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    MarkTaskAsCompleted();
                    break;
                case "3":
                    ViewTasks();
                    break;
                case "4":
                    continueManaging = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\nThank you for using the To-Do List App!");
    }

    static void AddTask()
    {
        Console.Write("\nEnter the title of the task: ");
        string title = Console.ReadLine();

        TaskItem task = new TaskItem(title);
        taskList.Add(task);

        Console.WriteLine("\nTask added to the to-do list.");
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("\nEnter the title of the task you want to mark as completed: ");
        string title = Console.ReadLine();

        bool taskFound = false;

        foreach (TaskItem task in taskList)
        {
            if (task.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                if (!task.IsCompleted)
                {
                    task.IsCompleted = true;
                    Console.WriteLine($"\nThe task '{task.Title}' has been marked as completed.");
                }
                else
                {
                    Console.WriteLine($"\nThe task '{task.Title}' is already marked as completed.");
                }

                taskFound = true;
                break;
            }
        }

        if (!taskFound)
        {
            Console.WriteLine("\nTask not found in the to-do list.");
        }
    }

    static void ViewTasks()
    {
        if (taskList.Count > 0)
        {
            Console.WriteLine("\nTo-Do List:");
            foreach (TaskItem task in taskList)
            {
                string status = task.IsCompleted ? "[Completed]" : "[Pending]";
                Console.WriteLine($"{status} {task.Title}");
            }
        }
        else
        {
            Console.WriteLine("\nThe to-do list is empty.");
        }
    }
}
