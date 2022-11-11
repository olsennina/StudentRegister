using System.Linq;

namespace StudentRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var dbContext = new DbContextStudent();
            bool exit = false;
            do
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Register of students");
                Console.WriteLine("--------------------");
                Console.WriteLine("Choose an option:");

                string[] menu = { "1. Register a new student", "2. Edit data of students", "3. Apply course", "4. List of students", "5. Exit program" };

                for (int i = 0; i < menu.Length; i++)
                {
                    Console.WriteLine(menu[i]);
                }
                string selectMenu = Console.ReadLine()??"";

                switch (selectMenu)
                {
                    case "1":
                        Console.Clear();
                        StudentHelper.AddStudent();
                        break;
                    case "2":
                        Console.Clear();
                        StudentHelper.EditStudent();
                        break;
                    case "3":
                        Console.Clear();
                        StudentHelper.AddCourse();
                        break;
                    case "4":
                        Console.Clear();
                        if (dbContext != null && dbContext.Students != null)
                        {
                            foreach (var item in dbContext.Students)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "5":
                        Console.Clear();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Unavailable choice, try again");
                        break;

                }

            } while (exit == false);


        }


    }
}