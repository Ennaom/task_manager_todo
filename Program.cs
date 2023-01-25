using System;

public class Program
{
    static List<string> tasks = new List<string>();
    static string filename;

    static void Main()
    {
        // handle the database (txt file based)
        Console.Write("Your name: ");
        string name = Console.ReadLine().ToUpper();
        filename = "profiles\\" + name + ".txt";
        if (File.Exists(filename))
        {
            using (var sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    tasks.Add(sr.ReadLine());
                }
            }
        }

        Update();
    }

    static void Menu()
    {
        // Handle menu functionality
        start:
            try
            {
                Console.Write("Option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Update();
                        break;

                    case 1:
                        AddTask();
                        break;

                    case 2:
                        EditTask();
                        break;

                    case 3:
                        DeleteTask();
                        break;
                    
                    case 4:
                        ExitProgram();
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

    static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }

        else
        {
            foreach (string item in tasks)
            {
                Console.WriteLine(tasks.IndexOf(item)+1 + ". " + item.ToUpper());
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Task name: ");
        string x = Console.ReadLine();

        if (x != "0")
        {
            tasks.Add(x);
        }
        Update();
    }

    static void ListMenu()
    {
        // List menu options
        Console.WriteLine();
        Console.WriteLine("--------MENU--------");
        Console.WriteLine("0. Go back to menu\n1. Add Task\n2. Edit Task\n3. Delete Task\n4. Exit Program");
        Menu();
    }

    static void Update()
    {
        Console.Clear();
        Console.WriteLine("Your current tasks: ");
        ListTasks();
        ListMenu();
    }

    static void EditTask()
    {
        if (tasks.Count>0)
        {
            start:
                try
                {
                    Console.Write("Choose task to edit: ");
                    int i = int.Parse(Console.ReadLine());

                    if (i != 0)
                    {
                        if (i<=tasks.Count && i>0)
                        {
                            Console.Write("Task's new name: ");
                            tasks[i-1] = Console.ReadLine();
                        }

                        else
                        {
                            Console.WriteLine("Invalid range!");
                            goto start;
                        }
                    }

                    else
                    {
                        Update();
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter number!");
                    goto start;
                }
        }

        else
        {
            Console.WriteLine("There is no task to edit.");
            System.Threading.Thread.Sleep(1000);
        }
        Update();
    }

    static void DeleteTask()
    {
        if (tasks.Count>0)
        {
            start:
                try
                {
                    Console.Write("Choose task to delete: ");
                    int i = int.Parse(Console.ReadLine());

                    if (i != 0)
                    {
                        if (i<=tasks.Count && i>0)
                        {
                            tasks.RemoveAt(i-1);
                        }

                        else
                        {
                            Console.WriteLine("Invalid range!");
                            goto start;
                        }
                    }

                    else
                    {
                        Update();
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Please enter number!");
                    goto start;
                }
        }

        else
        {
            Console.WriteLine("There is no task to edit");
            System.Threading.Thread.Sleep(1000);
        }
        Update();
    }

    static void ExitProgram()
    {
        Console.Write("Do you want to save your file? (Y/N): ");
        string answer = Console.ReadLine().ToUpper();
        if (answer == "Y")
        {
            using (var sw = new StreamWriter(filename)) 
            {
                foreach (var item in tasks)
                {
                    sw.WriteLine(item);
                }
            }

            Console.WriteLine("Data written succesfully!");
        }
        Environment.Exit(0);
    }
}