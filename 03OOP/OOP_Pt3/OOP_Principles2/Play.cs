using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Principles2
{
    public class Play
    {
        static void Main(string[] args)
        {
            Color sample = new Color(9, 12, 3);
           
            Console.WriteLine(sample.Grayscale());
            sample.Blue = 0;
            Console.WriteLine(sample.Grayscale());
            sample.Red = 0;
            Console.WriteLine(sample.Grayscale());

            Ball first = new Ball();
            Ball second = new Ball();
            Ball third = new Ball();
            Console.WriteLine(first.ThrowCount());
            first.Throw();
            second.Throw();
            first.Throw();
            first.Throw();
            Console.WriteLine(first.ThrowCount());
            first.Pop();
            first.Throw();
            Console.WriteLine(first.ThrowCount());
        }

    }
} 

