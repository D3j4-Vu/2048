using _2048.ViewModels;
using System;


namespace _2048.Logic
{
    public static class TileMover
    {
        private static bool tilesMoved = false;

        public static bool moveTiles(TileModel[][] tiles, string direction)
        {
            tilesMoved = false;
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
            return tilesMoved;
        }

        private static void moveTilesUp(TileModel[][] tiles)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (TileModel.tileIsBlank(tiles[i][j]))
                        if (j < 3 && !TileModel.tileIsBlank(tiles[i][j + 1]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 1].TileLevel;
                            tiles[i][j + 1].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (j < 2 && !TileModel.tileIsBlank(tiles[i][j + 2]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 2].TileLevel;
                            tiles[i][j + 2].TileLevel = 0;
                            tilesMoved = true;

                        }
                        else if (j < 1 && !TileModel.tileIsBlank(tiles[i][j + 3]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j + 3].TileLevel;
                            tiles[i][j + 3].TileLevel = 0;
                            tilesMoved = true;

                        }
                    if (j > 0 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i][j - 1].TileLevel)
                        {
                            tiles[i][j - 1].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            tilesMoved = true;
                            j--;
                        }
                }
        }

        private static void moveTilesDown(TileModel[][] tiles)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 3; j >= 0; j--)
                {
                    if (TileModel.tileIsBlank(tiles[i][j]))
                        if (j > 0 && !TileModel.tileIsBlank(tiles[i][j - 1]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 1].TileLevel;
                            tiles[i][j - 1].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (j > 1 && !TileModel.tileIsBlank(tiles[i][j - 2]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 2].TileLevel;
                            tiles[i][j - 2].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (j > 2 && !TileModel.tileIsBlank(tiles[i][j - 3]))
                        {
                            tiles[i][j].TileLevel = tiles[i][j - 3].TileLevel;
                            tiles[i][j - 3].TileLevel = 0;
                            tilesMoved = true;
                        }
                    if (j < 3 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i][j + 1].TileLevel)
                        {
                            tiles[i][j + 1].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            tilesMoved = true;
                            j++;
                        }
                }
        }

        private static void moveTilesLeft(TileModel[][] tiles)
        {
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (TileModel.tileIsBlank(tiles[i][j]))
                        if (i < 3 && !TileModel.tileIsBlank(tiles[i+1][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+1][j].TileLevel;
                            tiles[i+1][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (i < 2 && !TileModel.tileIsBlank(tiles[i+2][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+2][j].TileLevel;
                            tiles[i+2][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (i < 1 && !TileModel.tileIsBlank(tiles[i+3][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i+3][j].TileLevel;
                            tiles[i+3][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                    if (i > 0 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i-1][j].TileLevel)
                        {
                            tiles[i-1][j].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            tilesMoved = true;
                            i--;
                        }
                }
        }

        private static void moveTilesRight(TileModel[][] tiles)
        {
            for (int j = 0; j < 4; j++)
                for (int i = 3; i >= 0; i--)
                {
                    if (TileModel.tileIsBlank(tiles[i][j]))
                        if (i > 0 && !TileModel.tileIsBlank(tiles[i-1][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-1][j].TileLevel;
                            tiles[i-1][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (i > 1 && !TileModel.tileIsBlank(tiles[i-2][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-2][j].TileLevel;
                            tiles[i-2][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                        else if (i > 2 && !TileModel.tileIsBlank(tiles[i-3][j]))
                        {
                            tiles[i][j].TileLevel = tiles[i-3][j].TileLevel;
                            tiles[i-3][j].TileLevel = 0;
                            tilesMoved = true;
                        }
                    if (i < 3 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i+1][j].TileLevel)
                        {
                            tiles[i+1][j].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            tilesMoved = true;
                            i++;
                        }
                }
        }


    }
}
