namespace SQLWorking
{
    public class User
    {
        public int age;
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 1 || value > 120)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The age must be in the range from 1 to 120");
                    Console.ResetColor();
                }
                else
                    age = value;
            }
        }
    }
}
