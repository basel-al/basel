/*
 * 1. StringBuilder is necessary when the string must be mutable aside from concatenation.
 * 2. The Array class
 * 3. Array.Sort()
 * 4. Length
 * 5. yes if they are cast as objects
 * 6. CopyTo moves elements from one array to a preexisting array object. Clone creates a new array object
 * 
 * 
*/
using System.Collections;

public class ArraysStrings
{
    static public void Main()
    {
        /**
        
                string[] colors = new string[10];
                colors[0] = "Red";
                colors[1] = "Orange";
                colors[2] = "Yellow";
                colors[3] = "Green";
                colors[4] = "Blue";
                colors[5] = "Purple";
                colors[6] = "Pink";
                colors[7] = "Brown";
                colors[8] = "White";
                colors[9] = "Black";

                string[] second = new string[colors.Length];
                foreach (string s in colors)
                {
                    second[Array.IndexOf(colors, s)] = s;
                }

                foreach (string x in colors)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine("\n");
                foreach (string y in second)
                {

                    Console.WriteLine(y);
                }

                var groceries = new ArrayList();
                bool done = false;
                while (done == false)
                {
                    Console.WriteLine("\nEnter command(+item, -item, or-- to clear). Type \"done\" when finished");
                    String input = Console.ReadLine();
                    if (input.Equals("done"))
                        done = true;
                    else if(input[0].Equals('+'))
                    {

                        groceries.Add(input.Substring(1));
                    }
                    else if (input[0].Equals('-') && input[1].Equals('-'))
                    {

                        groceries.Clear();
                    } 
                    else if (input[0].Equals('-'))
                    {

                        groceries.Remove(input.Substring(1));
                    }


                    Console.WriteLine("\nList:");
                    foreach (String s in groceries)
                    {
                        Console.WriteLine(s);
                    }


                }
        int[] primes = FindPrimesInRange(1, 100);
        foreach (int x in primes)
        {
            Console.WriteLine(x);
        }

               Console.WriteLine("Enter a series of integers"); 
                string[] numbers = Console.ReadLine().Split();
                for ()
                {
                    for()
                    {

                    }
                }
        */

        //4
        /*
        Console.WriteLine("Enter a series of integers");
        string[] numstrings = Console.ReadLine().Split();
        int[] nums = new int[numstrings.Length];
        Console.WriteLine("Enter number of rotations");
        string te = Console.ReadLine();
        int rotationnum = int.Parse(te);

        for (int i = 0; i < numstrings.Length; i++)
        {
            nums[i] = int.Parse(numstrings[i]);
        }
        List<int[]> rotations = new List<int[]>();  
        for (int i = 0;i < rotationnum;i++)
        {
            rotations.Add(new int[nums.Length]);
            int temp=nums[i];
            for (int j = 0; j < nums.Length; j++)
            {
                rotations[i][j] = (temp + rotationnum) % nums.Length;
            }

        }
        for (int i = 0; i < rotations.Count; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                Console.WriteLine(rotations[i][j]);
            }
        }
        */
        //5
        /*
        Console.WriteLine("Enter a series of integers");
        string[] numstrings = Console.ReadLine().Split();
        int[] nums = new int[numstrings.Length];
        for (int i = 0; i < numstrings.Length; i++)
        {
            nums[i] = int.Parse(numstrings[i]);
        }
        int curr = 0;
        int longestnum = nums[0];
        int longestlength = 1;
        int currcount = 1;


        for (int i = 0; i < nums.Length; i++)
        {
            curr = nums[i];
            if (i == 0) continue;
            if (curr == nums[i - 1])
            {
                currcount++;
            }
            else
            {
                currcount = 1;
            }
            if (currcount > longestlength)
            {
                longestlength = currcount;
                longestnum = curr;

            }
        }
        for (int i = 0; i < longestlength; i++)
        {
            Console.Write(longestnum + " ");
        }
        Console.Write("\n");
        */

        //6/7
        
        Console.WriteLine("Enter a series of integers");
        string[] numstrings = Console.ReadLine().Split();
        int[] array = new int[numstrings.Length];
        for (int i = 0; i < numstrings.Length; i++)
        {
            array[i] = int.Parse(numstrings[i]);
        }
        int count = 1
        int aq;
        int common = array[0];
        int temps = 0;
        for (int i = 0; i < (array.Length - 1); i++)
        {
            temps = array[i];
            aq = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (temps == array[j])
                {
                    aq++;
                }
            }
            if (aq > count)
            {
                common = temps;
                count = aq;
            }
        }
        Console.WriteLine("The number {0} is most common (occurs {1} time(s)).", common, count);
        



    }
    public static int[] FindPrimesInRange(int startNum, int endNum)
{
    List<int> primeList = new List<int>();
    bool prime = true;
    for (int i = startNum; i <= endNum; i++)
    {
        prime = true;
        if (i == 2)
        {
            primeList.Add(i);
            continue;
        }
        if (i < 2 || i > endNum) continue;
        for (int j = i - 1; j > 1; j--)
        {
            if ((i % j) == 0)
            {
                prime = false;
                break;
            }

        }
        if (prime == true)
        {
            primeList.Add(i);
        }
    }
    return primeList.ToArray();

}

/*  public static int[] RotateandSum(int[] inf)
    {
        
    }*/
}
