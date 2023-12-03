using System;
using System.Collections.Generic;
using System.IO;

class ToDoList
{
    private Dictionary<string, List<string>> tasks;

    public ToDoList()
    {
        tasks = new Dictionary<string, List<string>>();
        LoadData();
    }

    public void LoadData()
    {
        foreach (var day in Days.AllDays)
        {
            string fileName = $"To do list data\\{day}.txt";
            if (File.Exists(fileName))
            {
                List<string> taskList = new List<string>(File.ReadAllLines(fileName));
                tasks[day] = taskList;
            }
            else
            {
                tasks[day] = new List<string>();
            }
        }
    }

    public void DisplayToDoList()
    {
        foreach (var day in Days.AllDays)
        {
            Console.WriteLine($"{day}:");
            foreach (var task in tasks[day])
            {
                Console.WriteLine($"- {task}");
            }
            Console.WriteLine();
        }
    }

    public void AddTask()
    {
        Console.Write("Enter the day of the week: ");
        string day = Console.ReadLine();

        if (Days.IsValidDay(day))
        {
            Console.Write("Enter the task: ");
            string task = Console.ReadLine();

            tasks[day].Add(task);
            Console.WriteLine("Task added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid day. Please enter a valid day of the week.");
        }
    }

    public void MarkTaskAsCompleted()
    {
        Console.Write("Enter the day of the week: ");
        string day = Console.ReadLine();

        if (Days.IsValidDay(day))
        {
            Console.WriteLine($"{day}:");
            for (int i = 0; i < tasks[day].Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[day][i]}");
            }

            Console.Write("Enter the number of the task to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks[day].Count)
            {
                tasks[day].RemoveAt(taskNumber - 1);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task number. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid day. Please enter a valid day of the week.");
        }
    }

    public void SaveData()
    {
        foreach (var day in Days.AllDays)
        {
            string fileName = $"To do list data\\{day}.txt";
            File.WriteAllLines(fileName, tasks[day]);
        }
    }
}