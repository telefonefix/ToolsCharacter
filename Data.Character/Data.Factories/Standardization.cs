using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Data.Factories
{
    public static class Standardization
    {
        public static Dictionary<string, string> GetStandard(string type)
        {
            string sesssion = @"^\[\w+\]|\[\w+\s\w+\]$";

            Dictionary<string, string> output = new Dictionary<string, string>();
            bool read = false;
            //^\[\w+\]|\[\w+\s\w+\]$
            using (var stream = File.OpenRead(@".\Standard.ini"))
            {

                if (stream == null)
                {
                    throw new FileNotFoundException("Erreur : le fichier Standard.ini est manquant");
                }

                using (var reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = Regex.Replace(reader.ReadLine(), @"^\s+|\s+$", string.Empty);

                        // Ne prend pas en compte les lignes commençant par #
                        if (!Regex.IsMatch(line, @"^\s+#|^#") && !string.IsNullOrEmpty(line))
                        {
                            if (Regex.IsMatch(line, sesssion))
                            {
                                // Lecture du parametre entre crochet
                                if (line.Trim(new char[] { '[', ']' }).ToLower() == type.ToLower())
                                {
                                    read = true;
                                }
                                else
                                {
                                    read = false;
                                }
                            }
                            if (read && !Regex.IsMatch(line, @"^\["))
                            {
                                //line = Regex.Replace(line, @"\s+", string.Empty);
                                if (!line.Contains("="))
                                {
                                    throw new StandardException(string.Concat("Erreur : Format incorrect :",
                                        Environment.NewLine,
                                        "\"KEY\"=\"VALUE\""));
                                }

                                string[] item = line.Split('=');
                                string key = GetCleanValue(item[0]);
                                string value = GetCleanValue(item[1]);
                                output.Add(key, value);
                            }
                        }
                    }
                }

            }
            return output;
        }
        private static string GetCleanValue(string value)
        {
            //^\s +|\s +$
            return value.Replace("\"",string.Empty).Trim();
            //return Regex.Replace(value, @"^\s+|\s+$", string.Empty).Trim(new char[] { '\"',',' }).Trim();
        }
    }
}
