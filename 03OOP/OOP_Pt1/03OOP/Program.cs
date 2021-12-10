/*
 * 1. public, private, protected, internal, protected internal, private protected
 * 2. static members are common to all instances of an object. Constants are implicitly static and can be accessed without an instance of object. Readonly variables can not.
 * 3. Call statements after an object is first ntialized
 * 4. It allows people to seperate work on the definition for a class
 * 5. data structure that holds multiple elements of different data types
 * 6.
 * 7. Overloading is when multiple methods in the same class with different parameters are compiled. Overriding is when a child class specifies implementation for a method in the parent class of the same name and parameters
 * 8.Fields are data holding variables of the class. Properties are accesor methods.
 * 9. Optional attributes or default values
 * 10. interfaces only have abstract methods and cannot have variable fields. Multiple interfaces can be implemented but a class can only inherit one abstract class as it's parent.
 * 11. public by default but they can be declared to be any of the 6
 * 12. true
 * 13. true
 * 14. false
 * 15. false
 * 16. true
 * 17. true
 * 18. false
 * 19. false
 * 20. true
 * 21. true
 * 22. false
 * 23. true
 * 
 *
 **/





public class test
{
    static public void Main(string[] args)
    {
        int[] numbers = GenerateNumbers();
        PrintNumbers(numbers);
        Reverse(ref numbers);
        PrintNumbers(numbers);
    }
    static int[] GenerateNumbers()
    {
        int[] nums = new int[10];
        for (int i = 0; i < nums.Length; i++)
        {

            Random rnd = new Random();
            nums[i] = rnd.Next(1, 10);
        }
        return nums;
    }
    static void Reverse(ref int[] numbers)
    {
        for(int i = 0; i < numbers.Length/2 ; i++)
        {
            int temp = numbers[i];
            numbers[i] = numbers[numbers.Length - 1 - i];
            numbers[numbers.Length - 1 - i] = temp;
        }

    }
    static void PrintNumbers(int[] numbers)
    {
        
        foreach (int number in numbers)
        {
            Console.Write(number);
        }
        Console.WriteLine("\n");
    }
}

/*

public class Fib
{
    static public void Main(string[] args)
    {
        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine(Fibonacci(i));
        }  
    }
    static int Fibonacci(int it)
    {
        if (it <= 1) return it;
        else return Fibonacci(it - 1) + Fibonacci(it - 2);
    }
}
*/