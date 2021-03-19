using System;

namespace GenericsExercise.Console
{
    public class Program
    {
        static void Main(string[] args)
        {

            var persistenceManager = new PersistenceManager();

            int option = 1;
            while(option != 0)
            {
                
                System.Console.WriteLine("1. Print all students");
                System.Console.WriteLine("2. Print all universities");
                System.Console.WriteLine("3. Insert new Student");
                System.Console.WriteLine("4. Insert new University");
                System.Console.WriteLine("0. Exit\n");

                try
                {
                    option = Convert.ToInt32(System.Console.ReadLine());
                }
                catch (Exception)
                {
                    System.Console.WriteLine("[Invalid input] Input must be a number.\n");
                    continue;
                }

                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        var studentList = persistenceManager.GetAllAsyncVerbose<Student>().Result;
                        foreach(string item in studentList)
                        {
                            System.Console.WriteLine(item);
                        }
                        System.Console.WriteLine();
                        break;
                    case 2:
                        var universityList = persistenceManager.GetAllAsyncVerbose<University>().Result;
                        foreach (string item in universityList)
                        {
                            System.Console.WriteLine(item);
                        }
                        System.Console.WriteLine();
                        break;
                    case 3:
                        System.Console.WriteLine("Id: ");
                        string sid = System.Console.ReadLine();
                        System.Console.WriteLine("Last name: ");
                        string lastName = System.Console.ReadLine();
                        System.Console.WriteLine("First name");
                        string firstName = System.Console.ReadLine();
                        System.Console.WriteLine(persistenceManager.InsertAsyncVerbose(new Student(sid, firstName, lastName)).Result);
                        System.Console.WriteLine();
                        break;
                    case 4:
                        System.Console.WriteLine("Id: ");
                        string uid = System.Console.ReadLine();
                        System.Console.WriteLine("Name: ");
                        string name = System.Console.ReadLine();
                        System.Console.WriteLine("Address:");
                        string address = System.Console.ReadLine();
                        System.Console.WriteLine(persistenceManager.InsertAsyncVerbose(new University(uid, name, address)).Result);
                        System.Console.WriteLine();
                        break;
                    default:
                        System.Console.WriteLine("[Not found] There is no such option.\n");
                        break;
                }
            }
        }
    }
}