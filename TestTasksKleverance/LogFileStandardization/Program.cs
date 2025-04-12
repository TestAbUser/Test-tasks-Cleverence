using LogFileStandardization;

string logFile = Path.Combine(Environment.CurrentDirectory, "log.txt");
string? log = default;
FileSystem file = new();

try
{
    log = file.Read(logFile);
}
catch (IOException ex)
{
    Console.WriteLine(ex.Message);
}

LogFormatter formatter = new();

var formattedLog = formatter.Format(log);
if (log == formattedLog)
{
    string problemsLogPath = Path.Combine(Environment.CurrentDirectory, "problems.txt");
    file.Write(problemsLogPath, formattedLog);
}

var path = Path.Combine(Environment.CurrentDirectory, "formattedLog.txt");
file.Write(path, formattedLog);
