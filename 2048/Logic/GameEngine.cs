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


        static GameEngine()
        {
            Engine = new Thread(run);
        }

        static public void start(TileModel[][] tiles)
        {
            Tiles = tiles;
            Engine.SetApartmentState(ApartmentState.STA);
            Engine.Start();
        }

        static public void stop()
        {
            Engine.Abort();
            Tiles = null;
        }

        static private void run()
        {
            while (true)
            {
                getKBInput();
                Thread.Sleep(5);
                if (direction != "No direction")
                {
                    TileMover.moveTiles(Tiles, direction);

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
        }
    }
}




