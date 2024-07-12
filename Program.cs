namespace SQLWorking
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("\nEnter the name of the database: ");
                string? nameDatabase = Console.ReadLine();
                using (FirstApplicationContext db = new FirstApplicationContext($"Data Source={nameDatabase}"))
                {
                    //Add
                    Console.Write("\nInput the quantity of database's members: ");
                    int quantityAdd = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < quantityAdd; i++)
                    {
                        Console.Write("Input the name of the person: ");
                        string? name = Console.ReadLine();
                        Console.Write("Input the age of the person: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        if (age > 1 && age < 120)
                        {
                            User? user = new User { Name = name, Age = age };
                            db.Users.Add(user);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The age must be in the range from 1 to 120");
                            Console.ResetColor();
                        }     
                    }
                    db.SaveChanges();
                    User[] users = db.Users.ToArray();
                    if (users.Length == 0)
                        return;
                    Console.WriteLine("\nThe objects are successfully saved:");
                }

                using (SecondApplicationContext db = new SecondApplicationContext(nameDatabase))
                {
                    bool isAvailable = db.Database.CanConnect();
                    if (isAvailable)
                    {
                        Console.WriteLine("\nThe Database is available:");
                        //Get
                        var users = db.Users.ToList();
                        OutputData(users);
                    }
                    else
                        Console.WriteLine("\nThe Database is unavailable:");

                    //Update
                    Console.Write("\nInput the quantity of database's members you want to update: ");
                    int quantityUpdate = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < quantityUpdate; i++)
                    {
                        Console.Write("Input the id of the person: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        User? userUpdate = db.Users.FirstOrDefault(u => u.Id == index);
                        if (userUpdate != null)
                        {
                            Console.Write("Input the changed name of the person: ");
                            string? name = Console.ReadLine();
                            Console.Write("Input the changed age of the person: ");
                            int age = Convert.ToInt32(Console.ReadLine());
                            userUpdate.Name = name;
                            userUpdate.Age = age;
                            db.Users.Update(userUpdate);
                        }
                    }
                    db.SaveChanges();
                    Console.WriteLine("\nData after updating:");
                    var usersUpdate = db.Users.ToList();
                    OutputData(usersUpdate);

                    //Delete
                    Console.Write("\nInput the quantity of database's members you want to delete: ");
                    int quantityDelete = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < quantityDelete; i++)
                    {
                        Console.Write("Input the id of the person: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        User? user = db.Users.FirstOrDefault(u => u.Id == index);
                        if (user != null && user != null && user != null)
                        {
                            db.Users.Remove(user);
                        }
                    }
                    db.SaveChanges();
                    Console.WriteLine("\nData after deleting:");
                    var usersDelete = db.Users.ToList();
                    OutputData(usersDelete);
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect data");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        private static void OutputData(List<User> users)
        {
            Console.WriteLine("\nThe List of The Objects:");
            foreach (User user in users)
            {
                Console.Write("| {0,3} ", user.Id);
                Console.Write("| {0,15} |", user.Name);
                Console.WriteLine(" {0,3} |", user.Age);
            }
        }
    }
}
