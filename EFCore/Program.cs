using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var ctx = new AppDbContext())
        {
            ctx.Database.EnsureCreated();
        }

        while (true)
        {
            Console.WriteLine("=== User Management EF Core ===");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign Up");
            Console.WriteLine("3. Exit");
            Console.Write("Secim: ");
            string choice = Console.ReadLine();

            if (choice == "1")
                SignIn();
            else if (choice == "2")
                SignUp();
            else if (choice == "3")
                break;
            else
                Console.WriteLine("Yanlis secim!");

            Console.WriteLine();
        }
    }

    static void SignIn()
    {
        Console.Write("UserName: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        using (var ctx = new AppDbContext())
        {
            var user = ctx.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
                Console.WriteLine($"Salam {user.FirstName} {user.LastName}!");
            else
                Console.WriteLine("UserName ve ya Password yanlisdir!");
        }
    }

    static void SignUp()
    {
        Console.Write("UserName: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        Console.Write("FirstName: ");
        string firstName = Console.ReadLine();
        Console.Write("LastName: ");
        string lastName = Console.ReadLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Gender (1=Kisi, 0=Qadin): ");
        bool gender = Console.ReadLine() == "1";

        using (var ctx = new AppDbContext())
        {
            if (ctx.Users.Any(u => u.UserName == username))
            {
                Console.WriteLine("Bu UserName artiq movcuddur!");
                return;
            }

            ctx.Users.Add(new User
            {
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            });

            ctx.SaveChanges();
            Console.WriteLine("Qeydiyyat ugurla tamamlandi!");
        }
    }
}
