using System.Linq;


namespace _2048
{
    public static class TwoDimArrayExtensions
    {
        public static void DefaultInit<T>(this T[][] TDArr, int rowsNumber) where T : new()
        {
            for (int i = 0; i < TDArr.Length; i++)
            {
                TDArr[i] = new T[rowsNumber];
                for (int j = 0; j < rowsNumber; j++)
                    TDArr[i][j] = new T();
            }
        }
    }
}
