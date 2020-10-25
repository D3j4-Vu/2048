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

        static public void start(TileModel[][] tiles)
        {
            Tiles = tiles;
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

        static private void run()
        {
            //not optimised... to do: Redesign algorithm.
            TileGenerator.generateTile(Tiles);
            TileGenerator.generateTile(Tiles);
            while (true)
            {
                Thread.Sleep(5);
                getKBInput();
                if (!direction.Equals("No direction"))
                {
                    if(TileMover.moveTiles(Tiles, direction))
                    {
                        TileGenerator.generateTile(Tiles);

                    }
                    direction = "No direction";
                }
            }
        }

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
    }
}




