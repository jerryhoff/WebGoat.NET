using System;

namespace OWASP.WebGoat.NET.App_Code
{
    public class WeakRandom
    {
        private uint _seed = 7;
        
        public WeakRandom(uint seed)
        {
            //Get a first high number so it looks random.
            if (seed < 100)
                _seed = _seed ^ 3;
            else
                _seed = seed;
        }
        
        public uint Next(uint min, uint max)
        {
            if (min >= max)
                throw new Exception("Min must be smaller than max");
                
            unchecked
            {
                _seed = _seed ^ 2;
            }
            
            return _seed % (max - min) + min;
        }
    }
}