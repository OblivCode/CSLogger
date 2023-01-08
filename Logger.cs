namespace LoggerCS
{
    public class Log
    {
        private string log_file;
        private bool print;
        public Log(string log_file, bool print)
        {
            this.log_file = log_file;
            this.print = print;
        }
        private void Print(string text)
        {
            if (print) { 
                Console.WriteLine(text);
            }
        }
        private Task AppendToFile(string text, string file)
        {
            if (file == "")
                file = log_file;
            if(!File.Exists(file)) {
                File.Create(file).Close();
            }
            File.AppendAllText(file, text);
            return Task.CompletedTask;
        }
        public Task Info(string info, bool print=false, string log_file = "")
        {
            string formatted = $"{DateTime.Now.ToString("G")}::INFO::{info}";
            if(print) { Console.WriteLine(formatted); }
            else { Print(formatted); }
            AppendToFile(formatted, log_file);
            return Task.CompletedTask;
        }
        public Task Warn(string warning, bool print = false, string log_file = "")
        {
            string formatted = $"{DateTime.Now.ToString("G")}::WARN::{warning}";
            if (print) { Console.WriteLine(formatted); }
            else { Print(formatted); }
            AppendToFile(formatted, log_file);
            return Task.CompletedTask;
        }
        public Task Error(string error, bool print = false, string log_file = "")
        {
            string formatted = $"{DateTime.Now.ToString("G")}::ERROR::{error}";
            if (print) { Console.WriteLine(formatted); }
            else { Print(formatted); }
            AppendToFile(formatted, log_file);
            return Task.CompletedTask;
        }
    }
}