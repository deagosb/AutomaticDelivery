using Domain;
using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {

            if (Directory.Exists(Global.Path + @"\inputs\"))
            {

                // Get file in the path 
                string[] fileEntries = Directory.GetFiles(Global.Path + @"\inputs\");

                // Clean the output directory 
                CleanDirectory(Global.Path + @"\outputs\");

                // Process the list of files found in the directory.
                foreach (string filePath in fileEntries)
                {
                    if (filePath.Contains(".txt") && filePath.Contains("in"))
                    {
                        // Get substring with the file number 
                        string fileNumber = filePath.Substring(filePath.Length - 6, 2);

                        // Validate the number of files against the number of drones available
                        if (Convert.ToInt32(fileNumber) <= Global.Maximum_Number_Of_Drones)
                        {
                            // Process the file
                            ProcessFile(filePath, fileNumber);
                        }                        
                    }

                }
            }
        }

        /// <summary>
        /// The ProcessFile.
        /// </summary>
        /// <param name="filePath">The filePath<see cref="string"/>.</param>
        /// <param name="fileNumber">The fileNumber<see cref="string"/>.</param>
        public static void ProcessFile(string filePath, string fileNumber)
        {
            Console.WriteLine("Processed file '{0}'.", filePath);

            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null && counter < Global.Maximum_Number_Of_Lunches)
            {

                Dron dron = new Dron(new Point(0, 0), Orientation.North);
                dron.Run(line);
                Console.WriteLine("({0}, {1}) direction {2}", dron.Point.X, dron.Point.Y, dron.Orientation);


                // Set the output fileName  
                StringBuilder sbOutputFileName = new StringBuilder();
                sbOutputFileName.Append(Global.Path);
                sbOutputFileName.Append(@"\outputs\out");
                sbOutputFileName.Append(fileNumber);
                sbOutputFileName.Append(".txt");


                using (StreamWriter writer = new StreamWriter(sbOutputFileName.ToString(), true))
                {
                    writer.WriteLine("({0}, {1}) direction {2}", dron.Point.X, dron.Point.Y, dron.Orientation);
                }

                counter++;
            }

            file.Close();

            Console.WriteLine("There were {0} lines.", counter);
        }

        /// <summary>
        /// The CleanDirectory.
        /// </summary>
        /// <param name="path">The path<see cref="string"/>.</param>
        private static void CleanDirectory(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }
    }
}
