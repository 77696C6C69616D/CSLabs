namespace CSLab13
{
    public partial class Branch
    {
        public int[,] MatrixInit(int height = 0, int width = 0)
        {
            if (height == 0 & width == 0) return null;
            if (height < 0) width = Math.Abs(height);
            if (width < 0) height = Math.Abs(width);
            int[,] matrix = new int[width, height];
            return matrix;
        }
        public void ViewResult(){    
        }
        public int GetTime(int time = 0)
        {
            return time;
        }
        public int GetScore(int score = 0)
        {
            return score;
        }
        public int[,] ScoreTable(int[,] table)
        {
            return table;
        }
    }
}
