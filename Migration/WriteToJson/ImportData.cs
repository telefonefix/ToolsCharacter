using Data.Entities.Characterize;
using Data.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace WriteToJson
{
   


    public class ImportData
    {
        #region Attributs        
        private List<string> _characterize;
        private IFactory _factory;

        private List<string> _fields;

        private string _json;
        private string _fileName;
        
        #endregion

        #region Properties  
        public string Message { get; private set; }
        public bool Success { get; private set; }
        #endregion

        #region Constructor
        public ImportData()
        {
            Init();
        }
        #endregion

        #region Private Methods
        private void Init()
        {   
            _factory = new Factory();         
            _fields = _factory.GetEnumList(new FieldsList());
            Success = false;
        }

        private void SetFormat(string content)
        {   
            List<string> lst = new List<string>();
            string item = string.Empty;
            string[] newContent = Transtorm(content);

            foreach (var c in newContent)
            {
                // If first charactere is a #, it is a comment
                if (string.IsNullOrWhiteSpace(c) || c.Trim().Substring(0,1).Equals("#"))
                {
                    continue;
                }

                foreach (var f in _fields)
                {
                    if (Regex.IsMatch(c, f, RegexOptions.IgnoreCase))
                    {
                        item = c.Replace(c, f);
                        break;
                    }
                    else
                    {
                        item = c;
                    }
                }

                lst.Add(item);
            }
            _characterize = lst;
        }

        /// <summary>
        /// Transforme le contenu en un tableau de string en remplacant [éèàùç] par [eauc]
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string[] </returns>
        private string[] Transtorm(string input)
        {

            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string output = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            output = Regex.Replace(output,"capacites speciales", "capacites_speciales",RegexOptions.IgnoreCase);
            output = Regex.Replace(output, @"cyber & brevets", "brevets", RegexOptions.IgnoreCase);
            output = output.Replace(Environment.NewLine, "|");
            return output.Split('|');
        }
        

        #endregion

        #region Public Methods
        public void ImportText(string content, string gender)
        {
            SetFormat(content);
            
            _factory.CreateCharacter(_characterize, gender);
            
            _fileName = _factory.FirstName + "_" + _factory.Name+"_";
            _json = JsonConvert.SerializeObject(_factory, Formatting.Indented);
            File.WriteAllText(string.Format(@".\Output\{0}.json", _fileName), _json);

            Success = _factory.Success;

            if (Success && File.Exists(string.Format(@".\Output\{0}.json", _fileName)))
            {
                Message = string.Format("Fichier {0}.Json {1} exporté avec succés", _fileName,Environment.NewLine);
            }

        }
        #endregion

        

    }
}
