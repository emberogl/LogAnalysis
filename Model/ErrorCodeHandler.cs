namespace LogAnalysis.Model
{
    /// <summary>
    /// Used by Analyzer class, gets a feedback response based on the occuring error codes in the log file
    /// </summary>
    public class ErrorCodeHandler
    {
        private List<ErrorCodes> errorCodes = new List<ErrorCodes>();

        public enum ErrorCodes
        {
            D0, D1, D2, D3, D4, D5
        }

        public void AddErrorCode(ErrorCodes code)
        {
            errorCodes.Add(code);
        }

        /// Lorem ipsum-grade nonsensical responses just for testing
        public string GiveFeedback()
        {
            if (errorCodes.Contains(ErrorCodes.D0) && errorCodes.Contains(ErrorCodes.D2) && errorCodes.Contains(ErrorCodes.D5)) 
            {
                return "Server starts sucessfully, but db server fails to run first try, but runs second try.\n" +
                       "Eventually check if server is not set to auto-close.";
            }
            else if (errorCodes.Contains(ErrorCodes.D0) && errorCodes.Contains(ErrorCodes.D2) && errorCodes.Contains(ErrorCodes.D4)) {
                return "Server starts successfully, but db server fails to run, even when trying to reconnect.\n" +
                       "Here are some possible reasons:\n"+
                       "Service account password was changed but not updated on db Server\n"+
                       "Startup Parameters have Incorrect File Path Locations\n"+
                       "Database Files Missing Due to Accidental Deletion or Disk Failure\n";
            }
            else
            {
                return "Server and db server start successfully.";
            } 
        }
    }
}