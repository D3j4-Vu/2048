using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048
{
    public static class ScoreCounter
    {
        public static void countScore(TileModel[][] tiles, string score)
        {
            int int_score = 0;
            for(int i = 0; i < 4; i ++)
                for(int j = 0; j < 4; j++)
                {
                    if (!tiles[i][j].Text.Equals(""))
                    {
                        int_score += Int32.Parse(tiles[i][j].Text);
                    }
                }
            score = score.Replace(score,int_score.ToString());
        }
    }
}
