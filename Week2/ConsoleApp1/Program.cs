namespace VariablesAndDatatypes
{
    class Program
    {
        static void Main()
        {
            string userName = "Sumit";
            int LuckyNumber = 7;
            byte tiny = 200;
            short small = 30000;
            int i = 100;
            long l = 9_000_000_000L;
            float f = 3.14f;
            double d = 2.71828;
            decimal m = 19.99m;
            char c = 'A';
            bool b = true;
            string fortyTwoText = 42.ToString();
            double piValue = double.Parse("3.14");


            int[] numbers = { 42, 7, 19, 3, 88 };


            Console.WriteLine($"Hello, {userName}! Your lucky number is {LuckyNumber}.");
            Console.WriteLine($"Circle.PI = {Circle.PI}");
            Console.WriteLine($"byte    = {tiny}        (type: byte)");
            Console.WriteLine($"short   = {small}       (type: short)");
            Console.WriteLine($"int     = {i}         (type: int)");
            Console.WriteLine($"long    = {l}   (type: long)");
            Console.WriteLine($"float   = {f}       (type: float)");
            Console.WriteLine($"double  = {d}   (type: double)");
            Console.WriteLine($"decimal = {m}       (type: decimal)");
            Console.WriteLine($"char    = {c}           (type: char)");
            Console.WriteLine($"bool    = {b}        (type: bool)");
            Console.WriteLine($"string  = {fortyTwoText}        (type: string, from int)");
            Console.WriteLine($"double  = {piValue}      (type: double, from string)");

            Console.WriteLine("Original : " + string.Join(", ", numbers));
            Array.Sort(numbers);
            Console.WriteLine("Sorted   : " + string.Join(", ", numbers));
            Array.Reverse(numbers);
            Console.WriteLine("Reversed : " + string.Join(", ", numbers));
            for (int idx = 0; idx < numbers.Length; idx++)
                Console.WriteLine($"  [{idx}] = {numbers[idx]}");
            Console.WriteLine($"IndexOf(19)  = {Array.IndexOf(numbers, 19)}");
            Console.WriteLine($"IndexOf(100) = {Array.IndexOf(numbers, 100)}");


            DateTime birthDate = new DateTime(2004, 10, 26);

            DateTime today = DateTime.Now;
            TimeSpan ageSpan = today - birthDate;
            int years = (int)(ageSpan.TotalDays / 365.25);

            Console.WriteLine($"Birth date : {birthDate:yyyy-MM-dd}");
            Console.WriteLine($"Today      : {today:yyyy-MM-dd}");
            Console.WriteLine($"Total days : {ageSpan.TotalDays}");
            Console.WriteLine($"Age        : {years} years");
            Console.WriteLine($"Birth + 10 days : {birthDate.AddDays(10):yyyy-MM-dd}");


            List<string> fruits = new() { "Apple", "Mango", "Banana" };
            fruits.Add("Orange");
            fruits.Remove("Mango");

            foreach (var fruit in fruits)
                Console.WriteLine($"  {fruit}");

            Dictionary<int, string> byId = new()
{
    { 1, "Apple" },
    { 2, "Mango" },
    { 3, "Banana" }
};
            byId[4] = "Orange";
            foreach (var pair in byId)
                Console.WriteLine($"  {pair.Key} -> {pair.Value}");
        }
    }
}