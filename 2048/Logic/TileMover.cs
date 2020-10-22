using _2048.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace _2048.Logic
{
    public static class TileMover
    {
        public static void moveTiles(TileModel[] tiles, string direction)
        {
            switch (direction)
            {
                case "Up":
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

        private static void moveTilesUp(TileModel[] tiles)
        {
            for (int reapeat = 0; reapeat < 4; reapeat++)
                for (int i = 15; i >= 0; i--)
                    if (!tileIsBlank(tiles[i]) && (i > 3))
                    {
                        if (tileIsBlank(tiles[i - 4]))
                        {
                            tiles[i - 4] = tiles[i];
                            tiles[i] = new TileModel();
                        }
                        else if (tiles[i - 4].TileLevel == tiles[i].TileLevel && reapeat == 0)
                        {
                            tiles[i - 4].TileLevel++;
                            tiles[i].TileLevel = 0;
                        }
                    }
        }

        private static void moveTilesDown(TileModel[] tiles)
        {
            for (int reapeat = 0; reapeat < 4; reapeat++)
                for (int i = 0; i <= 15; i++)
                    if (!tileIsBlank(tiles[i]) && (i < 12))
                    {
                        if (tileIsBlank(tiles[i + 4]))
                        {
                            tiles[i + 4] = tiles[i];
                            tiles[i] = new TileModel();
                        }
                        else if (tiles[i + 4].TileLevel == tiles[i].TileLevel && reapeat == 0)
                        {
                            tiles[i + 4].TileLevel++;
                            tiles[i].TileLevel = 0;
                        }
                    }
        }

        private static void moveTilesLeft(TileModel[] tiles)
        {
            for (int reapeat = 0; reapeat < 4; reapeat++)
                for(int column_idx = 3; column_idx > 0; column_idx--)
                for (int i = 12+column_idx; i >= 0; i-=4)
                    if (!tileIsBlank(tiles[i]) && (i > 0))
                    {
                        if (tileIsBlank(tiles[i -1]))
                        {
                            tiles[i -1] = tiles[i];
                            tiles[i] = new TileModel();
                        }
                        else if (tiles[i - 1].TileLevel == tiles[i].TileLevel && reapeat == 0)
                        {
                            tiles[i - 1].TileLevel++;
                            tiles[i].TileLevel = 0;
                        }
                    }
        }

        private static void moveTilesRight(TileModel[] tiles)
        {
            for (int reapeat = 0; reapeat < 4; reapeat++)
                for (int column_idx = 0; column_idx < 3; column_idx++)
                    for (int i = 0 + column_idx; i <= 15; i += 4)
                        if (!tileIsBlank(tiles[i]) && (i < 15))
                        {
                            if (tileIsBlank(tiles[i + 1]))
                            {
                                tiles[i + 1] = tiles[i];
                                tiles[i] = new TileModel();
                            }
                            else if (tiles[i + 1].TileLevel == tiles[i].TileLevel && reapeat == 0)
                            {
                                tiles[i + 1].TileLevel++;
                                tiles[i].TileLevel = 0;
                            }
                        }
        }

        private static bool tileIsBlank(TileModel tile)
        {
            return tile.TileLevel == 0;
        }
    }
}
