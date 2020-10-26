using _2048.View;
using _2048.ViewModels.Base;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048.ViewModels
{
    public class TileModel : ObservableObject
    {
        #region Private members

        private int _title_level;

        #endregion
        #region Public properties

        public int TileLevel {
            get { return _title_level; }
            set
            {
                _title_level = value;
                setupTile(value);
            }
        }
        public SolidColorBrush BackgroundColor { get; set; }
        public SolidColorBrush FontColor { get; set; }
        public string Text { get; set; }

        #endregion
        #region Constructors

        public TileModel(int number = 0)
        {
            _title_level = number;
            setupTile(number);
        }

        #endregion
        #region Private methods

        private void setupTile(int number)
        {
            switch (number)
            {
                case 0:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("Grey");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("WarmGrey");
                    Text = "";
                    break;
                case 1:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("1");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("WarmGrey");
                    Text = "2";
                    break;
                case 2:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("2");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("WarmGrey");
                    Text = "4";
                    break;
                case 3:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("3");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "8";
                    break;
                case 4:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("4");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "16";
                    break;
                case 5:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("5");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "32";
                    break;
                case 6:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("6");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "64";
                    break;
                case 7:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("7");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "128";
                    break;
                case 8:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("8");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "256";
                    break;
                case 9:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("9");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "512";
                    break;
                case 10:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("10");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "1024";
                    break;
                case 11:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("11");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "2048";
                    break;
                case 12:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("12");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "4096";
                    break;
                case 13:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("13");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "8192";
                    break;
                case 14:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("14");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "16384";
                    break;
                case 15:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("15");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "32768";
                    break;
                case 16:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("16");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "65536";
                    break;
                case 17:
                    BackgroundColor = (SolidColorBrush)Application.Current.TryFindResource("17");
                    FontColor = (SolidColorBrush)Application.Current.TryFindResource("LightGrey");
                    Text = "131072";
                    break;
                default:
                        Text = "Err";
                    break;
            }
        }

        #endregion
        #region Model functions

        public static bool tileIsBlank(TileModel tile)
        {
            return tile.TileLevel == 0;
        }

        #endregion
    }
}
