using System;
using System.IO;

namespace SnakeGame.Utils
{
    public static class BestScoreManager
    {
        private const string FILE_NAME = "best.scores";
        private static int[] _bestScores;

        public static int[] GetScores()
        {
            if (_bestScores == null)
            {
                _bestScores = new int[5];
                LoadScores();
            }

            int[] res = new int[5];
            Array.Copy(_bestScores, 0, res, 0, 5);
            return res;
        }

        public static void AddScores(int score)
        {
            if (_bestScores == null)
            {
                _bestScores = new int[5];
                LoadScores();
            }
            bool isScoresChanged = false;
            for (int i = 0; i < _bestScores.Length; i++)
            {
                if (_bestScores[i] < score)
                {
                    isScoresChanged = true;
                    int temp = score;
                    score = _bestScores[i];
                    _bestScores[i] = temp;
                }
            }
            if (isScoresChanged)
            {
                SaveScores();
            }
        }

        private static void LoadScores()
        {
            if (File.Exists(FILE_NAME))
            {
                string text;
                using (StreamReader sr = File.OpenText(FILE_NAME))
                {
                    text = sr.ReadToEnd();
                }
                string[] bestScores = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < bestScores.Length; i++)
                {
                    if (int.TryParse(bestScores[i], out var res))
                    {
                        _bestScores[i] = res;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void SaveScores()
        {
            using (StreamWriter sw = File.CreateText(FILE_NAME))
            {
                for (int i = 0; i < _bestScores.Length; i++)
                {
                    sw.WriteLine(_bestScores[i]);
                }
            }
        }
    }
}
