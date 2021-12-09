using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nettleieKalkulator1._0._0.debug
{
    public class logToFile
    {
        //Location to log
        public string logFileLocation { get; set; }

        //tag to log
        public string logTag { get; set; }

        /// <summary>
        ///     init object
        /// </summary>
        /// <param name="argLogFileLocation">
        ///     folder name to store logs
        /// </param>
        /// <param name="argLogTag"></param>
        public logToFile(string argLogTag, string argLogFileLocation = "logs")
        {
            logFileLocation = argLogFileLocation;
            logTag = argLogTag;
        }
        /// <summary>
        ///     Writes a message to log(text file)
        /// </summary>
        /// <param name="message">
        ///     String to be logged, keep it a "one liner"
        /// </param>
        /// <returns>
        ///     False if it was not logged, else true
        /// </returns>
        public bool writeToLog(string message)
        {
            //TODO: consider adding decryption on this. 
            StreamWriter writer;
            try
            {
                //Create logs folder if it is not there
                System.IO.Directory.CreateDirectory(logFileLocation);
                //Check if we need a new log file due to size
                if (checkIfFileIsTooLarge())
                {
                    //Get a sorted list from the log file location
                    string[] fileList = getLogFiles();
                    //Write to the first file
                    if (fileList != null)
                    {
                        writer = File.AppendText(fileList[0].ToString());
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            if (formatMessage(message, writer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Dumps the whole logfile to the console
        /// </summary>
        public void DumpLatestLogFileToConsole()
        {
            try
            {
                string[] fileList = getLogFiles();
                StreamReader r = File.OpenText(fileList[0].ToString());
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                r.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"failed to read file: {e}");
            }

        }

        /// <summary>
        ///     will truncate given file
        /// </summary>
        /// <param name="file">
        ///     filename to truncate
        /// </param>
        /// <returns>
        ///     false if it failed to truncate, otherwise true.
        /// </returns>
        public bool truncateFile(string file)
        {
            try
            {
                StreamWriter writer = new StreamWriter(file, false);
                writer.Write("");
                writer.Flush();
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool checkIfFileIsTooLarge()
        {
            try
            {

                string[] file = getLogFiles();
                if (file.Count() < 1)
                {
                    if (createNewFile())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if ((new FileInfo(file[0]).Length >= ((19 * 1024) * 1024)))
                {
                    if (createNewFile())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool formatMessage(string logMessage, TextWriter writer)
        {
            try
            {
                string time = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff");
                writer.Write($"{time}");
                writer.WriteLine($" : {logTag} : {logMessage}");
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool createNewFile()
        {
            try
            {
                //Get unix time
                DateTime foo = DateTime.UtcNow;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                //Set filename and path
                string fileNameAndPath = logFileLocation + "/" + unixTime.ToString() + ".slog";
                //Create new file.
                if (truncateFile(fileNameAndPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }
        private string[] getLogFiles()
        {
            try
            {
                string[] fileArray = new string[] { };
                fileArray = Directory.GetFiles(logFileLocation, "*.slog").OrderByDescending(d => d).ToArray();
                return fileArray;
            }
            catch
            {
                return null;
            }
        }
    }
}
