namespace Theater.Logging {
    using System;
    using System.IO; // Asegúrate de tener este using para acceder a File

    public class LogMethod : ILogMethod {
        private readonly string _logFilePath = @"..\Logging\TheaterLogs.txt";

        public void LogError(Exception ex, string message) {
         
                string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] | ERROR: {message} - Exception: {ex.Message}";
                // Esto creará el archivo si no existe y añadirá el mensaje de log al final si ya existe.
                File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
         
        }
    }
}
