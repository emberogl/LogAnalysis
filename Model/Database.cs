using System.Text;

namespace LogAnalysis.Model
{
    /// <summary>
    /// "Database" to store analysis data, and output to console
    /// </summary>
    public class Database
    {
        private List<string> _db = new List<string>();

        public void AddLogAnalysis(string feedback)
        {
            _db.Add(feedback);
        }

        public string GetDatabaseAnalyses()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 1;
            foreach (string analysis in _db)
            {
                stringBuilder.Append($"{index}: {analysis}");
            }
            return stringBuilder.ToString();
        }
    }
}