using _2048.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace _2048.Logic
{
    public static class TileMover
    {
        private static int pp = 0;

        public static void moveTiles(TileModel[][] tiles, string direction)
        {
            switch (direction)
            {
                case "Up":
                    pp++;
                    moveTilesUp(tiles);
                    break;
                case "Down":
                    moveTilesDown(tiles);
                    break;
                case "Left":
                    moveTilesLeft(tiles);
                    break;
                case "Right":
                    moveTilesRight(tiles);
                    break;
                default:
                    break;
            }
        }

        private static void moveTilesUp(TileModel[][] tiles)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (tileIsBlank(tiles[i][j]))
                        if (j < 3 && !tileIsBlank(tiles[i][j + 1]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 1].TileLevel;
                            tiles[i][j + 1].TileLevel = 0;
                        }
                        else if (j < 2 && !tileIsBlank(tiles[i][j + 2]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 2].TileLevel;
                            tiles[i][j + 2].TileLevel = 0;
                        }
                        else if (j < 1 && !tileIsBlank(tiles[i][j + 3]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 3].TileLevel;
                            tiles[i][j + 3].TileLevel = 0;
                        }
                    if (j > 0 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i][j - 1].TileLevel)
                        {
                            tiles[i][j - 1].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            j--;
                        }
                }
        }

        private static void moveTilesDown(TileModel[][] tiles)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 3; j >= 0; j--)
                {
                    if (tileIsBlank(tiles[i][j]))
                        if (j > 0 && !tileIsBlank(tiles[i][j - 1]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 1].TileLevel;
                            tiles[i][j - 1].TileLevel = 0;
                        }
                        else if (j > 1 && !tileIsBlank(tiles[i][j - 2]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 2].TileLevel;
                            tiles[i][j - 2].TileLevel = 0;
                        }
                        else if (j > 2 && !tileIsBlank(tiles[i][j - 3]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 3].TileLevel;
                            tiles[i][j - 3].TileLevel = 0;
                        }
                    if (j < 3 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i][j + 1].TileLevel)
                        {
                            tiles[i][j + 1].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            j++;
                        }
                }
        }

        private static void moveTilesLeft(TileModel[][] tiles)
        {
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (tileIsBlank(tiles[i][j]))
                        if (i < 3 && !tileIsBlank(tiles[i+1][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+1][j].TileLevel;
                            tiles[i+1][j].TileLevel = 0;
                        }
                        else if (i < 2 && !tileIsBlank(tiles[i+2][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+2][j].TileLevel;
                            tiles[i+2][j].TileLevel = 0;
                        }
                        else if (i < 1 && !tileIsBlank(tiles[i+3][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+3][j].TileLevel;
                            tiles[i+3][j].TileLevel = 0;
                        }
                    if (i > 0 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i-1][j].TileLevel)
                        {
                            tiles[i-1][j].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            i--;
                        }
                }
        }

        private static void moveTilesRight(TileModel[][] tiles)
        {
            for (int j = 0; j < 4; j++)
                for (int i = 3; i >= 0; i--)
                {
                    if (tileIsBlank(tiles[i][j]))
                        if (i > 0 && !tileIsBlank(tiles[i-1][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-1][j].TileLevel;
                            tiles[i-1][j].TileLevel = 0;
                        }
                        else if (i > 1 && !tileIsBlank(tiles[i-2][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-2][j].TileLevel;
                            tiles[i-2][j].TileLevel = 0;
                        }
                        else if (i > 2 && !tileIsBlank(tiles[i-3][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-3][j].TileLevel;
                            tiles[i-3][j].TileLevel = 0;
                        }
                    if (i < 3 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i+1][j].TileLevel)
                        {
                            tiles[i+1][j].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            i++;
                        }
                }
        }

        private static bool tileIsBlank(TileModel tile)
        {
            return tile.TileLevel == 0;
        }
    }
}
