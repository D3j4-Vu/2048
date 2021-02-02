using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Xml.Serialization;

namespace _2048
{
    [XmlInclude(typeof(MatrixTransform))]
    public class BoardModel : Undoable<BoardModel>
    {
        #region Private members
        private const int defaultBoardSize = 4;
        private bool tilesMoved = false;
        #endregion
        #region Public properties
        public int BoardSize { get; }
        public TileModel[][] Tiles { get; set; }
        public Score MyScore { get; set; }
        #endregion
        #region Constructors
        public BoardModel() : this(defaultBoardSize) { }
        public BoardModel(int boardSize)
        {
            this.BoardSize = boardSize;
            this.MyScore = new Score();
            Tiles = new TileModel[BoardSize][];
            Tiles.DefaultInit(boardSize);
            generateTiles(2);
        }
        #endregion
        #region Public methods
        public void moveTiles(string direction)
        {
            tilesMoved = false;
            switch (direction)
            {
                case "Up":
                    moveTilesUp();
                    break;
                case "Down":
                    moveTilesDown();
                    break;
                case "Left":
                    moveTilesLeft();
                    break;
                case "Right":
                    moveTilesRight();
                    break;
                default:
                    break;
            }
            if (tilesMoved)
            {
                generateTile();
            }
        }
        public void reset()
        {
            clearTilesLevel();
            resetScore();
            generateTiles(2);
        }
        #endregion
        #region Private methods
        private void clearTilesLevel()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Tiles[i][j].TileLevel = 0;
        }
        private void resetScore() 
        {
            MyScore.MyValue = 0;
        }
        private void generateTiles(int timesToGenerate = 1)
        {
            for (int i = 0; i < timesToGenerate; i++)
                generateTile();
        }

        #region Tile moving
        private void moveTilesUp()
        {
            bool isMergeOn = true;
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (j < BoardSize - k && !Tiles[i][j + k].isTileBlank)
                            {
                                Tiles[i][j].moveHere(Tiles[i][j + k]);
                                tilesMoved = true;
                                break;
                            }
                    if (j > 0 && Tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (Tiles[i][j].TileLevel == Tiles[i][j - 1].TileLevel)
                        {
                            Tiles[i][j - 1].mergeTiles(Tiles[i][j]);
                            MyScore.add(Tiles[i][j - 1].Text.Value);
                            tilesMoved = true;
                            j--;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }
        private void moveTilesDown()
        {
            bool isMergeOn = true;
            for (int i = 0; i < BoardSize; i++)
                for (int j = BoardSize - 1; j >= 0; j--)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (j >= k && !Tiles[i][j - k].isTileBlank)
                            {
                                Tiles[i][j].moveHere(Tiles[i][j - k]);
                                tilesMoved = true;
                                break;
                            }
                    if (j < 3 && Tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (Tiles[i][j].TileLevel == Tiles[i][j + 1].TileLevel)
                        {
                            Tiles[i][j + 1].mergeTiles(Tiles[i][j]);
                            MyScore.add(Tiles[i][j + 1].Text.Value);
                            tilesMoved = true;
                            j++;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }
        private void moveTilesLeft()
        {
            bool isMergeOn = true;
            for (int j = 0; j < BoardSize; j++)
                for (int i = 0; i < BoardSize; i++)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (i < BoardSize - k && !Tiles[i + k][j].isTileBlank)
                            {
                                Tiles[i][j].moveHere(Tiles[i + k][j]);
                                break;
                            }
                    if (i > 0 && Tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (Tiles[i][j].TileLevel == Tiles[i - 1][j].TileLevel)
                        {
                            Tiles[i - 1][j].mergeTiles(Tiles[i][j]);
                            MyScore.add(Tiles[i - 1][j].Text.Value);
                            tilesMoved = true;
                            i--;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }
        private void moveTilesRight()
        {
            bool isMergeOn = true;
            for (int j = 0; j < 4; j++)
                for (int i = BoardSize - 1; i >= 0; i--)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (i >= k && !Tiles[i - k][j].isTileBlank)
                            {
                                Tiles[i][j].moveHere(Tiles[i - k][j]);
                                tilesMoved = true;
                                break;
                            }
                    if (i < 3 && Tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (Tiles[i][j].TileLevel == Tiles[i + 1][j].TileLevel)
                        {
                            Tiles[i + 1][j].mergeTiles(Tiles[i][j]);
                            MyScore.add(Tiles[i + 1][j].Text.Value);
                            tilesMoved = true;
                            i++;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }
        #endregion
        private void generateTile() //not optimised, this is temporary just for testing... to do: Redesign algorithm.

        {
            Random rnd = new Random();
            List<int> new_levels = new List<int> { 1, 1, 1, 2 };
            bool isGenerated = false;
            int rndIdx1;
            int rndIdx2;

            while (!isGenerated)
            {
                rndIdx1 = rnd.Next(0, 4);
                rndIdx2 = rnd.Next(0, 4);
                if (Tiles[rndIdx1][rndIdx2].TileLevel != 0)
                    continue;
                Tiles[rndIdx1][rndIdx2].TileLevel = new_levels[rnd.Next(0, 4)];
                isGenerated = true;
            }
        }
        #endregion
    }
}
