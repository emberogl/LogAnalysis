using LogAnalysis.Model;
using LogAnalysis.View;

namespace LogAnalysis.Controller
{
    public class Main
    {
        public void Controller()
        {
            Analyzer analyzer = new Analyzer();

            /// Analyzing file
            string feedback = analyzer.AnalyzeLogFile("C:\\Users\\emreb\\Documents\\H1\\LogAnalysis\\errorlog1.txt"); // Copy full path of errorlog.txt in solution directory to test 3 different logs

            Database db = new Database();

            /// Adding analysis data to list
            db.AddLogAnalysis(feedback);

            Gui gui = new Gui();
            gui.Print($"Super Awesome AI Algorithm (include additional marketing buzzwords here) analysis of error log: \n\n{feedback}\n");
            gui.Print($"Saved analyses in database: \n\n{db.GetDatabaseAnalyses()}\n");

        }
    }
}