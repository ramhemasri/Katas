using System;
using System.Collections.Generic;
using System.Text;

namespace Katas.SnakeAndLadders
{
    public interface IDice
    {
        int Roll();
    }

    public class Dice : IDice
    {
        private readonly Random randomGenerator;
        public Dice()
        {
            randomGenerator = new Random();
        }

        public int Roll() => randomGenerator.Next(1, 6);
        
    }
}
