namespace LogAnalysis.Model
{
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
                while ((line = reader.ReadLine()!) != null)
                {
                    foreach (ErrorCodeHandler.ErrorCodes code in Enum.GetValues(typeof(ErrorCodeHandler.ErrorCodes))) {
                        if (line.Contains(code.ToString()))
                        {
                            errorCodeHandler.AddErrorCode(code);
                        }
                    }
                }
                return errorCodeHandler.GiveFeedback();
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
