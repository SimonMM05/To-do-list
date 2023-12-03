using System;

class ToDoListProgram
{
    private ToDoList toDoList;

    public ToDoListProgram()
    {
        toDoList = new ToDoList();
        toDoList.LoadData();
        Run();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the To-Do List App!");

        while (true)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. View To-Do List");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    toDoList.DisplayToDoList();
                    break;
                case "2":
                    toDoList.AddTask();
                    break;
                case "3":
                    toDoList.MarkTaskAsCompleted();
                    break;
                case "4":
                    toDoList.SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void Main(string[] args)
    {
        new ToDoListProgram();
    }
}
