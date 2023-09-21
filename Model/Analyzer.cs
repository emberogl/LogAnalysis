namespace LogAnalysis.Model
{
    /// <summary>
    /// Retrieves all error codes in every line of error log,
    /// adds those error codes to a list,
    /// and delivers feedback based on which error codes appear
    /// </summary>
    public class Analyzer
    {
        public string AnalyzeLogFile(string path)
        {
            ErrorCodeHandler errorCodeHandler = new ErrorCodeHandler();
            StreamReader reader = null!;
            try
            {
                reader = new StreamReader(path);
                string line;

                /// While text file is not empty, do a foreach to find any error code that occurs in every line, and add it to a list
                while ((line = reader.ReadLine()!) != null)
                {
                    foreach (ErrorCodeHandler.ErrorCodes code in Enum.GetValues(typeof(ErrorCodeHandler.ErrorCodes))) {
                        if (line.Contains(code.ToString()))
                        {
                            errorCodeHandler.AddErrorCode(code);
                        }
                    }
                }
                return errorCodeHandler.GiveFeedback(path); // The feedback delivered is based on which error codes occur
            }
            catch (FileNotFoundException) 
            {
                throw new FileNotFoundException("Log file to analyze could not be found. (Did you specify the correct path?)");
            }
            catch (IOException ex)
            {
                throw new IOException("Unable to read the file.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}
