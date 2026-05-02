namespace _2048WinFormsApp
{
    public class SaveData
    {
        public int BestScore { get; set; }

        public List<GameResult> History { get; set; }

        public SaveData()
        {
            BestScore = 0;
            History = new List<GameResult>();
        }
    }
}
