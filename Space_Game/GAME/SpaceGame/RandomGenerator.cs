using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    public class RandomGenerator
    {
        private static Random generator;

        private RandomGenerator()
        {
        }

        public static Random Generator
        {
            get
            {
                if (generator == null)
                {
                    generator = new Random();
                }
                return generator;
            }
        }
    }
}
