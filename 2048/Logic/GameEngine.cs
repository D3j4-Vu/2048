using _2048.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2048.Logic
{
    static public class GameEngine
    {
        static private string direction = "No direction";

        static private Thread Engine;
        static private TileModel[][] Tiles;
        static private TileModel[][] OldTiles;

        #region Public methods
        static public void start(TileModel[][] tiles)
        {
            Tiles = tiles;
            OldTiles = setupTiles();

            Engine = new Thread(run);
            Engine.SetApartmentState(ApartmentState.STA);
            Engine.IsBackground = true;
            Engine.Start();
        }
        static public void stop()
        {
            Engine.Abort();
            Engine = null;
            Tiles = null;
        }
        static public void undoMove()
        {
            cloneTiles(OldTiles, Tiles);
        }
        static private void run()
        {
            //not optimised... to do: Redesign algorithm.
            TileGenerator.generateTile(Tiles);
            TileGenerator.generateTile(Tiles);
            TileModel[][] temp_tiles = setupTiles();
            while (true)
            {
                Thread.Sleep(5);
                getKBInput();
                if (!direction.Equals("No direction"))
                {
                    cloneTiles(Tiles,temp_tiles);
                    if (TileMover.moveTiles(Tiles, direction))
                    {
                        cloneTiles(temp_tiles,OldTiles);
                        TileGenerator.generateTile(Tiles);
                    }
                    direction = "No direction";
                }
            }
        }
        #endregion
        #region Helpers  
        static private void getKBInput() 
        {

            if (Keyboard.IsKeyDown(Key.W))
            {
                direction = "Up";
            }
            else if (Keyboard.IsKeyDown(Key.S))
            {
                direction = "Down";
            }
            else if (Keyboard.IsKeyDown(Key.A))
            {
                direction = "Left";
            }
            else if (Keyboard.IsKeyDown(Key.D))
            {
                direction = "Right";
            }
            else direction = "No direction";
            while (!Keyboard.IsKeyUp(Key.W)||!Keyboard.IsKeyUp(Key.A)||!Keyboard.IsKeyUp(Key.S)||!Keyboard.IsKeyUp(Key.D)) { Thread.Sleep(5); }
        }
        static private void cloneTiles(TileModel[][] from, TileModel[][] to)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    to[i][j].TileLevel = from[i][j].TileLevel;
        }
        private static TileModel[][] setupTiles()
        {
            TileModel[][] tiles;
            tiles = new TileModel[4][];
            for (int i = 0; i < 4; i++)
            {
                tiles[i] = new TileModel[4];
                for (int j = 0; j < 4; j++)
                    tiles[i][j] = new TileModel(0);
            }
            return tiles;
        }
        #endregion
    }
}
