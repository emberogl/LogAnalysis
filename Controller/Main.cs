using LogAnalysis.Model;
using LogAnalysis.View;

namespace LogAnalysis.Controller
{
    public class Main
    {
        public void Controller()
        {
            Analyzer analyzer = new Analyzer();
            string feedback = analyzer.AnalyzeLogFile("C:\\Users\\zbc23emrb\\Documents\\GitHub\\LogAnalysis\\errorlog1.txt");

            Database db = new Database();
            db.AddLogAnalysis(feedback);

            Gui gui = new Gui();
            gui.Print($"Super Awesome AI Algorithm (include additional marketing buzzwords here) analysis of error log: \n\n{feedback}\n");
            gui.Print($"Saved analyses in database: \n\n{db.GetDatabaseAnalyses()}\n");

        }
    }
}