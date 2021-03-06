﻿using System;
using System.Windows;
using System.Windows.Input;

namespace _2048
{
    public class GameBoardViewModel: ViewModelBase
    {

        #region Public properties

        public GameBoardView View { get; set; }
        public BoardModel GameBoard { get; set; }
        public TileModel[][] Tiles
        {
            get { return GameBoard.Tiles; }
        }

        #endregion
        #region Constructors

        public GameBoardViewModel()
        {
            GameBoard = new BoardModel();
            View = new GameBoardView(this);
        }

        #endregion
        #region Public methods

        public void swipeBoard(string direction)
        {
            GameBoard.moveTiles(direction);
        }

        public void saveBoard()
        {
            Serializator.serialize(GameBoard, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\", "gameData.txt");
        }

        public void loadSavedBoard()
        {
            GameBoard = Serializator.deserialize<BoardModel>(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\game2048\gameData.txt");
        }
        public void resetBoard()
        {
            GameBoard.reset();
        }

        #endregion

    }
}
