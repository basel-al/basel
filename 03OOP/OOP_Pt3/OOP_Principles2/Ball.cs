using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Principles2
{
    public class Ball
    {
        int size;
        Color color;
        int thrown;
        public Ball()
        {
            size = 4;
        }
        public void Pop()
        {
            size = 0;
        }
        public void Throw()
        {
            if(size != 0)
            {
                thrown++;
            }
        }
        public int ThrowCount()
        {
            return thrown;
        }
    }
}
