using Data.Entities.Corporation;
using Data.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace WriteToJson
{
    public class ImportData
    {
        private string _content;
        private string[] _appointment;
        private Factory _factory;

        List<string> _missedFields;


        //public Exception Exp { get; private set; }


        public ImportData(string content)
        {
            if (string.IsNullOrEmpty(content)) throw new CharacterException("Le texte ne peut pas être vide");
            _content = content;
            _factory = new Factory();
        }

        public void ImportText()
        {
            _content = _content.Replace(System.Environment.NewLine, "|");
            string[] characterize = _content.Split('|');

            List<string> lst = new List<string>();

            foreach (var c in characterize)
            {
                if (string.IsNullOrEmpty(c)) continue;
                lst.Add(c);
            }

            _appointment = lst.ToArray();
            SetCorpo();
            SetCharacter();
            //SetCharacterize();
        }

        private void SetCorpo()
        {
            Category category = Category.Star;
            //string rank;
            string[] charac = _appointment[0].Split('(');
            string name = "freelance";

            int qty = 5;
            if (charac.Length != 1)
            {
                charac[1] = charac[1].Trim(')');
                string[] corpo = charac[1].Split(' ');
                qty = corpo[0].Length;
                switch (corpo[0].Substring(0,1))
                {
                    case "o":
                        category = Category.Circle;
                        break;
                    case "^":
                        category = Category.Triangle;
                        break;
                    case "*":
                        category = Category.Star;
                        break;
                    default:
                        category = Category.Circle;
                        break;
                }
                name = corpo[1];                    
            }

            _factory.CreateCorporation(name,category,qty);
            //SetName(charac[0]);
        }

        private void SetCharacter()
        {
            string[] charac = _appointment[0].Split('(');
            string[] name = charac[0].Split(' ');
            if (name.Length < 2)
            {
                throw new CharacterException("Le nom doit être composeé d'un prénom et nom");
            }
            if (!SetFeature()) return;
            // name[0] -> FirstName, name[1] -> LastName
            _factory.CreateCharacter(name[0], name[1]);
            // TODO:
            // TODO: Faire methods pour renseigner les Features
            //_factory.SetFeatures();
        }

        private bool SetFeature()
        {   
            if (!CheckFeature())
            {
                _missedFields.Insert(0, string.Concat("Il manque les champs suivants :",Environment.NewLine));
                throw new CharacterException(string.Concat(_missedFields));
            }
            return true;
        }

        private bool CheckFeature()
        {
            if (!CheckFields()) return false;
            return true;
        }

        private bool CheckFields()
        {
            string[] pattern = { "carac", "capac", "comp", "res", "cyber" };
            Dictionary<string, bool>  checkedFeatures = new Dictionary<string, bool>();
            _missedFields = new List<string>();
            foreach (var p in pattern)
            {
                checkedFeatures.Add(p, false);

                Regex match = new Regex(p,RegexOptions.IgnoreCase);
                foreach (var a in _appointment)
                {
                    if (match.IsMatch(a))
                    {
                        checkedFeatures[p] = true;
                        break;
                    }
                }
            }

            if (checkedFeatures.ContainsValue(false))
            {
                foreach (var c in checkedFeatures)
                {
                    if (c.Value == false) _missedFields.Add(string.Concat(c.Key,Environment.NewLine));
                }
                return false;
            }
            
            return true;
        }
    }
}
