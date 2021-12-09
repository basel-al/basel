using System.Text;

public class ex3
{
    static public void Main()
    {
        /*
        //1
        for(int i = 1; i<=100; i++)
        {

            if(i %3==0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
            else if(i % 3 ==0) Console.WriteLine("Fizz");
            else if (i % 5==0) Console.WriteLine("Buzz");
            else Console.WriteLine(i);
        }
        */
        /*
        The code below needs a checked block to prevent it from running with an overflowed numeric data type. Otherwise it is an infinite loop because bytes are too small to iterate to the int max value of 500
        checked
        {
            int max = 500;
            for (byte i = 0; i < max; i++)
            {
                Console.WriteLine(i);
            }
        }
        */
        
        //2
        /*
        StringBuilder sb = new StringBuilder("    *    ");
        Console.WriteLine(sb.ToString());
        for (int i =1; i<5; i++)
        {
            
            sb[4 + i] = '*';
            sb[4 - i] = '*';
            Console.WriteLine(sb.ToString());
        }
        */
        //3
        /*
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Enter Number from 1-3");
        int guessedNumber = int.Parse(Console.ReadLine());
        if (correctNumber == guessedNumber) Console.WriteLine("Correct");
        else if(guessedNumber < 1 || guessedNumber > 3) Console.WriteLine("Invalid Number");
        else if (correctNumber < guessedNumber) Console.WriteLine("Too High");
        else if( correctNumber > guessedNumber) Console.WriteLine("Too Low");
        */
        //4
        /*
        DateTime basel = new DateTime(1997, 1, 10);
        DateTime today = DateTime.Today;
        double x = (today.Year - basel.Year)*365.25;
        double y = (today.Month - basel.Month) * 30.5;
        double z = (today.Day - basel.Day);
        Console.WriteLine(x+y+z);
        */
        
        //5
        /*
        DateTime now = DateTime.Now;
        if(now.Hour >= 5 && now.Hour <=11) Console.WriteLine("Good Morning");
        if (now.Hour >= 12 && now.Hour <= 17) Console.WriteLine("Good Afternoon");
        if (now.Hour >= 18 && now.Hour <= 21) Console.WriteLine("Good Evening");
        if ((now.Hour >= 22 && now.Hour <= 24)||(now.Hour >= 1 && now.Hour <= 4))Console.WriteLine("Good Night");
        */
        //6
        /*
        for (int i = 1; i <= 4; i++)
        {
            for(int j = 0; j<=24; j=j+i)
            {
                Console.Write(j + " ");
            }
            Console.Write("\n");
        }
        */


    }
}