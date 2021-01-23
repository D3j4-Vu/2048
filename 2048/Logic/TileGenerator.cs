using System;
using System.Collections.Generic;

namespace _2048
{
    public static class TileGenerator
    {
        private static Random rnd = new Random();
        private static List<int> new_levels = new List<int> { 1,1,1,2};

        public static void generateTile(TileModel[][] tiles)
        {
            bool isGenerated = false;
            int rndIdx1;
            int rndIdx2;

            //not optimised... to do: Redesign algorithm.
            while (!isGenerated)
            {
                rndIdx1 = rndIdx();
                rndIdx2 = rndIdx();
                if (tiles[rndIdx1][rndIdx2].TileLevel==0)
                {
                    tiles[rndIdx1][rndIdx2].TileLevel = new_levels[rndIdx()];
                    isGenerated = true;
                }
            }
        }

        

        private static int rndIdx()
        {
            return rnd.Next(0, 4);
        }
    }
}
