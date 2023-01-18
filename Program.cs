using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("1. Add Task\n2. Edit Task\n3. Delete Task\n4. Exit Program");
        Menu();
    }

    static void Menu()
    {
        start:
            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    // TODO: add task
                        break;

                    case 2:
                    // TODO: edit task
                        break;

                    case 3:
                    // TODO: delete task
                        break;
                    
                    case 4:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("This option does not exist in the menu!");
                        break;
                }
            }

            catch (FormatException)
            {
                Console.Write("Please enter number: ");
                goto start;
            }
    }
}