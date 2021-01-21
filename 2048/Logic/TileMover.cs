using _2048.ViewModels;
using System;


namespace _2048.Logic
{
    public static class TileMover
    {
        private static bool tilesMoved = false;
        private static int matrixSize = 4;

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
                    if (tileIsBlank(tiles, i, j))
                        for (int k = 1; k < matrixSize; k++)
                            if (j < matrixSize - k && !tileIsBlank(tiles, i, j + k))
                            {
                                tiles[i][j].TileLevel = tiles[i][j + k].TileLevel;
                                tiles[i][j + k].TileLevel = 0;
                                tilesMoved = true;
                                break;
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
                    if (tileIsBlank(tiles, i, j))
                        for (int k = 1; k < matrixSize; k++)
                            if (j >= k && !tileIsBlank(tiles, i, j - k))
                            {
                                tiles[i][j].TileLevel = tiles[i][j - k].TileLevel;
                                tiles[i][j - k].TileLevel = 0;
                                tilesMoved = true;
                                break;
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
            for (int j = 0; j < matrixSize; j++)
                for (int i = 0; i < matrixSize; i++)
                {
                    if (tileIsBlank(tiles, i, j))
                        for (int k = 1; k < matrixSize; k++)
                            if (i < matrixSize - k && !tileIsBlank(tiles, i + k, j))
                            {
                                tiles[i][j].TileLevel = tiles[i + k][j].TileLevel;
                                tiles[i + k][j].TileLevel = 0;
                                tilesMoved = true;
                                break;
                            }
                    if (i > 0 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i - 1][j].TileLevel)
                        {
                            tiles[i - 1][j].TileLevel++;
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
                    if (tileIsBlank(tiles, i, j))
                        for (int k = 1; k < matrixSize; k++)
                            if (i >= k && !tileIsBlank(tiles, i - k, j))
                            {
                                tiles[i][j].TileLevel = tiles[i - k][j].TileLevel;
                                tiles[i - k][j].TileLevel = 0;
                                tilesMoved = true;
                                break;
                            }
                    if (i < 3 && tiles[i][j].TileLevel > 0)
                        if (tiles[i][j].TileLevel == tiles[i + 1][j].TileLevel)
                        {
                            tiles[i + 1][j].TileLevel++;
                            tiles[i][j].TileLevel = 0;
                            tilesMoved = true;
                            i++;
                        }
                }
        }

        private static bool tileIsBlank(TileModel[][] tiles, int i, int j)
        {
            return TileModel.tileIsBlank(tiles[i][j]);
        }


    }
}
