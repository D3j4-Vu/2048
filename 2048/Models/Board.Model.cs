using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048
{
    public class BoardModel: ObservableObject
    {
        #region Private members

        private const int defaultBoardSize = 4;
        private bool tilesMoved = false;

        #endregion
        #region Public properties

        public int BoardSize { get; }
        public int CurretScore { get; private set; }
        public TileModel[][] Tiles { get; set; }
        public bool IsLeftUndoMoves { get; set; }

        #endregion
        #region Constructors

        public BoardModel() : this(defaultBoardSize) { }

        public BoardModel(int boardSize)
        {
            this.BoardSize = boardSize;
            setupBoard();
            generateTiles(2);
        }

        #endregion
        #region Public methods

        public void moveTiles(string direction)
        {
            if (moveTiles(Tiles, direction))
            {
                generateTile();
                //AddUndo(this, "Tiles", cloned, Tiles);
            }
        }

        public void reset()
        {
            clearTilesLevel();
            resetScore();
            deleteUndos();
            generateTiles(2);
        }

        public void undo()
        {
            UndoManager.Undo();
        }

        #endregion
        #region Private methods

        private void clearTilesLevel()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Tiles[i][j].TileLevel = 0;
        }

        private void resetScore(){ }

        private void deleteUndos()
        {
            UndoManager.ClearAll();
        }

        private void generateTiles(int timesToGenerate = 1)
        {
            for (int i = 0; i < timesToGenerate; i++)
                generateTile();
        }

        private void setupBoard()
        {
            Tiles = new TileModel[BoardSize][];
            for (int i = 0; i < BoardSize; i++)
            {
                Tiles[i] = new TileModel[BoardSize];
                for (int j = 0; j < BoardSize; j++)
                    Tiles[i][j] = new TileModel(0);
            }
        }

        #region Tile moving

        public bool moveTiles(TileModel[][] tiles, string direction)
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

        private void moveTilesUp(TileModel[][] tiles)
        {
            bool isMergeOn = true;
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (j < BoardSize - k && !Tiles[i][j + k].isTileBlank)
                            {
                                tiles[i][j].moveHere(tiles[i][j + k]);
                                tilesMoved = true;
                                break;
                            }
                    if (j > 0 && tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (tiles[i][j].TileLevel == tiles[i][j - 1].TileLevel)
                        {
                            tiles[i][j - 1].mergeTiles(tiles[i][j]);
                            tilesMoved = true;
                            j--;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }

        private void moveTilesDown(TileModel[][] tiles)
        {
            bool isMergeOn = true;
            for (int i = 0; i < BoardSize; i++)
                for (int j = BoardSize-1; j >= 0; j--)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (j >= k && !Tiles[i][j - k].isTileBlank)
                            {
                                tiles[i][j].moveHere(tiles[i][j - k]);
                                tilesMoved = true;
                                break;
                            }
                    if (j < 3 && tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (tiles[i][j].TileLevel == tiles[i][j + 1].TileLevel)
                        {
                            tiles[i][j + 1].mergeTiles(tiles[i][j]);
                            tilesMoved = true;
                            j++;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }

        private void moveTilesLeft(TileModel[][] tiles)
        {
            bool isMergeOn = true;
            for (int j = 0; j < BoardSize; j++)
                for (int i = 0; i < BoardSize; i++)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (i < BoardSize - k && !Tiles[i + k][j].isTileBlank)
                            {
                                tiles[i][j].moveHere(tiles[i + k][j]);
                                break;
                            }
                    if (i > 0 && tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (tiles[i][j].TileLevel == tiles[i - 1][j].TileLevel)
                        {
                            tiles[i - 1][j].mergeTiles(tiles[i][j]);
                            tilesMoved = true;
                            i--;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }

        private void moveTilesRight(TileModel[][] tiles)
        {
            bool isMergeOn = true;
            for (int j = 0; j < 4; j++)
                for (int i = BoardSize-1; i >= 0; i--)
                {
                    if (Tiles[i][j].isTileBlank)
                        for (int k = 1; k < BoardSize; k++)
                            if (i >= k && !Tiles[i - k][j].isTileBlank)
                            {
                                tiles[i][j].moveHere(tiles[i - k][j]);
                                tilesMoved = true;
                                break;
                            }
                    if (i < 3 && tiles[i][j].TileLevel > 0 && isMergeOn)
                        if (tiles[i][j].TileLevel == tiles[i + 1][j].TileLevel)
                        {
                            tiles[i + 1][j].mergeTiles(tiles[i][j]);
                            tilesMoved = true;
                            i++;
                            isMergeOn = false;
                            continue;
                        }
                    isMergeOn = true;
                }
        }

        #endregion

        #region Tile generating

        private void generateTile()
        {
            Random rnd = new Random();
            List<int> new_levels = new List<int> { 1, 1, 1, 2 };
            bool isGenerated = false;
            int rndIdx1;
            int rndIdx2;

            //not optimised, this is temporary jus for testing... to do: Redesign algorithm.
            while (!isGenerated)
            {
                rndIdx1 = rnd.Next(0, 4);
                rndIdx2 = rnd.Next(0, 4);
                if (Tiles[rndIdx1][rndIdx2].TileLevel == 0)
                {
                    Tiles[rndIdx1][rndIdx2].TileLevel = new_levels[rnd.Next(0, 4)];
                    isGenerated = true;
                }
            }
        }

        #endregion

        #endregion








    }
}
