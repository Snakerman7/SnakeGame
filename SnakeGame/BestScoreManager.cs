using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class BestScoreManager
    {
        private const string FILE_NAME = "best.scores";
        private static BestScoreManager _instance;

        private int[] _bestScores;

        private BestScoreManager()
        {
        }

        public int[] GetScores()
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

        public void AddScores(int score)
        {
            if (_bestScores == null)
            {
                _bestScores = new int[5];
                LoadScores();
            }
            bool isScoresChanged = false;
            for(int i = 0; i < _bestScores.Length; i++)
            {
                if(_bestScores[i] < score)
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

        private void LoadScores()
        {
            if (File.Exists(FILE_NAME))
            {
                string text;
                using (StreamReader sr = File.OpenText(FILE_NAME))
                {
                    text = sr.ReadToEnd();
                }
                string[] bestScores = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for(int i = 0; i < bestScores.Length; i++)
                {
                    if(int.TryParse(bestScores[i], out var res))
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

        private void SaveScores()
        {
            using(StreamWriter sw = File.CreateText(FILE_NAME))
            {
                for(int i = 0; i < _bestScores.Length; i++)
                {
                    sw.WriteLine(_bestScores[i]);
                }
            }
        }

        public static BestScoreManager GetInstance()
        {
            if(_instance == null)
            {
                _instance = new BestScoreManager();
            }
            return _instance;
        }
    }
}
