using Autofac;
using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data.Factories
{
    public enum FieldsList
    {
        caracteristiques,
        capacites_speciales,
        competences,
        ressources,
        brevets
    }

    public class Factory : IFactory
    {
        #region Attributs
        private IContainer _container;
        private List<string> _features;
        private Dictionary<Gender, string> _dicGender;
        private Dictionary<Type, string> _dictionnaryStandards;
        private Dictionary<string, int> _dico;
        private List<string> _missed;
        private List<string> _fields;
        private List<string> _characterize;
        #endregion
        #region Properties
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Pseudo { get; set; }
        public string Noun { get; set; }
        //public IDictionary<string, int> Features { get; set; }
        public Features[] Features { get; set; }
        public List<Skills> Skills { get; set; }
        public List<SpecialAbilities> SpecialAbilities { get; set; }
        public List<Ressources> Ressources { get; set; }
        public List<Patents> Patents { get; set; }
        public ICorporation Corporation { get; set; }

        public bool Success { get; set; }
        #endregion
        #region Constructor
        public Factory()
        {
            Init();
            BuildDependency();
        }
        #endregion

        #region Public Methods
        public void CreateCharacter(List<string> characterize, string gender)
        {
            _characterize = characterize;
            if (!CheckFields())
            {
                throw new CharacterException(string.Concat(_missed));
            }
            SetCorpo();
            SetCharacter(gender);
            Success = true;
        }

        public List<string> GetEnumList<T>(T t)
        {
            List<string> list = new List<string>();

            IEnumerable<T> enumItem = Enum.GetValues(typeof(T)).Cast<T>();

            foreach (var e in enumItem)
            {
                list.Add(e.ToString().ToLower());
            }
            return list;
        }

        #endregion

        #region Public Methods

        private void BuildDependency()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Character>().As<ICharacter>();
            builder.RegisterType<Skills>().As<IRepository<Skills>>();
            builder.RegisterType<Features>().As<IRepository<Features>>();
            builder.RegisterType<SpecialAbilities>().As<IRepository<SpecialAbilities>>();
            builder.RegisterType<Ressources>().As<IRepository<Ressources>>();
            builder.RegisterType<Corporation>().As<ICorporation>();
            builder.RegisterType<Grade>().As<IGrade>();
            builder.RegisterType<Patents>().As<IPatents>();

            _container = builder.Build();
        }
        private void Init()
        {
            _dico = new Dictionary<string, int>();
            _features = GetEnumList(new FeaturesList());
            Features = new Features[_features.Count];
            SpecialAbilities = new List<SpecialAbilities>();
            Skills = new List<Skills>();
            Ressources = new List<Ressources>();
            Patents = new List<Patents>();

            _dicGender = new Dictionary<Gender, string>()
            {
                {Gender.Male,"Mr"},
                {Gender.Female,"Mrs"},
                {Gender.CyberRobot,"Cyb"}
            };

            _dictionnaryStandards = new Dictionary<Type, string>()
            {
                {typeof(Features),"caracteristiques" },
                {typeof(Skills),"competences" },
                {typeof(SpecialAbilities),"capacites_speciales" },
                {typeof(Ressources),"ressources" },
                {typeof(Patents),"brevets" }
            };
            _fields = GetEnumList(new FieldsList());
        }
        private void SetCharacter(string gender)
        {
            Dictionary<string, Gender> dicGender = new Dictionary<string, Gender>()
            {
                {"Homme",Gender.Male },
                {"Femme",Gender.Female },
                {"Cyber Robot",Gender.CyberRobot }
            };

            Gender genderEnum = Gender.Male;
            dicGender.TryGetValue(gender, out genderEnum);
            Noun = gender;

            try
            {
                SetName(_characterize[0].Split('('), dicGender[gender]);
            }
            catch (Exception)
            {
                SetName(_characterize[0].Split('('), Gender.Male);
            }

            SetCharacterize(new Features());
            SetCharacterize(new SpecialAbilities());
            SetCharacterize(new Skills());
            SetCharacterize(new Ressources());
            ExtractPatents();
        }
        private void SetName(string[] line, Gender gender)
        {
            string[] temp = line[0].Split(' ');
            List<string> names = new List<string>();
            string other = string.Empty;

            names.AddRange(temp);

            if (names.Count < 2)
            {
                names.Insert(0, _dicGender[gender]);
                names[1] = temp[0];
                names.Add(string.Empty);
            }

            if (names.Count >= 3)
            {
                for (int i = 2; i < names.Count; i++)
                {
                    other += names[i] + " ";
                }

                names[2] = other;
            }

            FirstName = names[0];
            Name = names[1];
            Pseudo = names[2];
        }
        /// <summary>
        /// Rentre les valeurs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="dico"></param>
        private bool SetCharacterize<T>(T t) where T : IRepository<T>
        {
            List<string> items = new List<string>();
            List<Features> features = new List<Features>();
            Dictionary<string, int> dico = new Dictionary<string, int>();

            bool switchToArray = false;
            int i = 1;
            string message = string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine);
            _missed = new List<string>();

            if (t.GetType() == typeof(Features))
            {
                _missed.Add(string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine));
                message = string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine);
            }
            if (!CheckCharacterize(t, ref dico))
            {
                throw new CharacterException(string.Concat(_missed));
            }

            foreach (KeyValuePair<string, int> item in dico)
            {
                switch (t)
                {
                    case Features f:
                        f = new Features
                        {
                            Id = i,
                            Name = item.Key,
                            Value = item.Value
                        };
                        features.Add(f);
                        switchToArray = true;
                        break;
                    case Skills s:
                        s = new Skills
                        {
                            Id = i,
                            Name = item.Key,
                            Value = item.Value
                        };
                        Skills.Add(s);
                        break;
                    case SpecialAbilities sa:
                        sa = new SpecialAbilities
                        {
                            Id = i,
                            Name = item.Key,
                            Value = item.Value
                        };
                        SpecialAbilities.Add(sa);
                        break;
                    case Ressources r:
                        r = new Ressources
                        {
                            Id = i,
                            Name = item.Key,
                            Value = item.Value
                        };
                        Ressources.Add(r);
                        break;
                    default:
                        throw new CharacterException("Données inconnues");
                }
                i++;
            }

            if (switchToArray)
            {
                Features = features.ToArray();
            }
            return true;
        }
        /// <summary>
        /// Extrait les brevets
        /// </summary>
        private void ExtractPatents()
        {
            string patents = string.Empty;

            if (!ExtractDatas(new Patents(), ref patents))
            {
                return;
            }

            foreach (string p in patents.Split('|').ToList())
            {
                Patents patent = new Patents()
                {
                    Name = p
                    // Voir pour les caracteristiques des brevets
                };
                if (!string.IsNullOrWhiteSpace(p))
                {
                    Patents.Add(patent);
                }
            }
        }

        private bool CheckCharacterize<T>(T t, ref Dictionary<string, int> dico)
        {
            dico = new Dictionary<string, int>();
            string lineCharacterize = string.Empty;

            if (!ExtractDatas(t, ref lineCharacterize))
            {
                return false;
            }

            List<string> characterize = Standardize(t, Regex.Replace(lineCharacterize, @"\s+", " ").Split('|').ToList());

            // Dans le cas Features toutes les valeurs sont requises
            if (t.GetType() == typeof(Features))
            {
                return CheckFeatures(characterize, ref dico);
            }

            CheckValue(characterize, ref dico);

            return true;
        }
        /// <summary>
        /// Verifie que tous les champs de FeaturesList soit valides avec un intitulé et une valeur
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private bool CheckFeatures(List<string> datas, ref Dictionary<string, int> dico)
        {
            List<string> items = new List<string>();

            //pattern.Sort();

            int value = 0;
            string key = string.Empty;
            string message = string.Empty;

            foreach (var d in datas)
            {
                if (!CheckFieldValue(d, ref message, ref key, ref value))
                {
                    _missed.Add(string.Format("{0} a renvoyé l'erreur {1}", key, message));

                }
                items.Add(key + " " + value.ToString());
            }

            items.Sort();

            foreach (var f in _features)
            {
                IEnumerable<string> query = items.Where(i => i.ToUpper().Contains(f.ToUpper()));
                if (query.Count() != 1)
                {
                    _missed.Add(string.Concat(f, Environment.NewLine));
                }
            }
            CheckValue(items, ref dico);

            return (_missed.Count < 2);
        }
        /// <summary>
        /// Verifie que la valeur du champ soit un entier
        /// </summary>
        /// <param name="datas"></param>
        /// <param name="dico"></param>
        /// <returns></returns>
        private bool CheckValue(List<string> datas, ref Dictionary<string, int> dico)
        {
            _missed = new List<string>();

            string message = string.Empty;

            _missed.Add(string.Concat("La valeur doit être un entier pour :", Environment.NewLine));

            foreach (string d in datas)
            {
                string name = null;
                int value = 0;

                if (!CheckFieldValue(d, ref message, ref name, ref value))
                {
                    throw new CharacterException(message);
                }

                // Verifie l'existence de doublon, si doublon alors la nouvelle valeur ecrase l'ancienne
                if (dico.Keys.Contains(name))
                {
                    dico.Remove(name);
                }
                dico.Add(name, value);
            }
            return true;
        }
        private List<string> Standardize<T>(T t, List<string> datas)
        {
            List<string> listDatas = new List<string>();
            IDictionary<string, string> standard = new Dictionary<string, string>();

            listDatas.AddRange(datas);
            listDatas.Remove(string.Empty);

            //int index = 0;
            string type = string.Empty;
            try
            {
                //    switch (t)
                //    {
                //        case Features f:
                //            //Caracteristiques
                //            type = "caracteristiques";
                //            break;
                //        case SpecialAbilities s:
                //            type = "capacites_speciales";
                //            break;
                //        case Skills s:
                //            type = "competences";
                //            break;
                //        case Ressources r:
                //            type = "ressources";
                //            break;
                //        default:
                //            throw new StandardException("Erreur : Type inconnu");
                //}
                standard = Standardization.GetStandard(_dictionnaryStandards[t.GetType()]);

            }
            catch (StandardException e)
            {
                throw new StandardException(e.Message);
            }

            List<string> lstTemp = new List<string>();

            foreach (string l in listDatas)
            {
                int val = 0;
                string key = string.Empty;
                string message = string.Empty;
                string itemStandard = string.Empty;

                CheckFieldValue(l, ref message, ref key, ref val);
                string tmp = l;

                if (standard.TryGetValue(key, out itemStandard))
                {
                    tmp = Regex.Replace(l, key, itemStandard, RegexOptions.IgnoreCase);
                }

                lstTemp.Add(tmp);
            }

            return lstTemp;
        }
        /// <summary>
        /// Verifie que le nom du champ soit attribué à une valuer entière
        /// </summary>
        /// <param name="input"></param>
        /// <param name="message"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool CheckFieldValue(string input, ref string message, ref string name, ref int value)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                message = "Champ vide";
                return false;
            }

            string output = Regex.Replace(input, @"\s+", " ");
            //input = input.Replace(" ", "|");
            output = output.ToUpper();
            string checkValue = Regex.Replace(output, @"[A-ZÉÈ_\.]", string.Empty).Trim();


            //string[] toto = input.Split('|');

            //if (toto.Length <1 || toto.Length > 2)
            //{
            //    message = "Le champ n'est pas valide ou la valeur n'est pas un entier"+Environment.NewLine;
            //    message += "Il doit être de la forme NOM VALEUR";
            //    return false;
            //}

            name = Regex.Replace(output, @"\d+", string.Empty).Trim();
            name = Regex.Replace(name, "[+-]", string.Empty).Trim();

            if (checkValue.Contains(" "))
            {
                name += checkValue.Substring(0, checkValue.IndexOf(" "));
                checkValue = checkValue.Substring(checkValue.IndexOf(" "));
            }

            if (name == string.Empty || !int.TryParse(checkValue, out value))
            {
                message = "Le champ n'est pas valide ou la valeur n'est pas un entier";
                return false;
            }
            message = " OK";
            return true;
        }
        private bool ExtractDatas<T>(T t, ref string datas)
        {
            datas = string.Empty;
            bool isMatch = false;
            string requiredField = string.Empty;

            if (t.GetType() != typeof(Patents))
            {
                Regex match = new Regex(_dictionnaryStandards[t.GetType()], RegexOptions.IgnoreCase);

                foreach (var a in _characterize)
                {
                    if (match.IsMatch(a))
                    {
                        isMatch = true;
                        continue;
                    }

                    if (isMatch)
                    {
                        if (_fields.Exists(f => f == a))
                        {
                            break;
                        }
                        if (!string.IsNullOrWhiteSpace(a))
                        {
                            datas += a + "|";
                        }
                    }
                }
                switch (t)
                {
                    case Features f:
                        requiredField = "Caracteristique";
                        break;
                    case Skills s:
                        requiredField = "Competences";
                        break;
                    default:
                        requiredField = "Champ optionnel";
                        break;
                }
                if (string.IsNullOrEmpty(datas) && (t.GetType() != typeof(Ressources) || t.GetType() != typeof(SpecialAbilities)))
                {
                    _missed.Add(string.Concat(string.Format("Aucune {0} n'a été renseigné", requiredField),
                                     Environment.NewLine,
                                     "Veuillez regarder un exemple",
                                     Environment.NewLine));
                    return false;
                }
                return true;
            }

            // Concerne les brevets ou la cyber (Ceci est optionnel) donc si ce champ est vide non retour d'erreur
            int index = _characterize.FindIndex(c => c == _dictionnaryStandards[typeof(Patents)]);

            if (index > 0)
            {
                for (int i = index + 1; i < _characterize.Count; i++)
                {
                    datas += _characterize[i] + "|";
                }
            }

            return true;
        }
        private void SetCorpo()
        {
            // MR TOTO (^^^^ G500)
            // MR TOTO (^^^^ G500
            // MR TOTO ^^^^ G500)
            // MR TOTO ^^^^ G500

            string extract = FormatStandard(_characterize[0]);

            // Aucune corporation
            if (string.IsNullOrWhiteSpace(extract))
            {
                Corporation = null;
                return;
            }

            string output = extract.Split(new char[] { '(', ')' })[1].Trim();
            output = Regex.Replace(output, @"\s+", " ");

            CreateEmployee(output.Trim().Split('|'));
            _characterize[0] = extract;
        }
        private string FormatStandard(string input)
        {
            List<string> typeGrade = new List<string>()
            { " o ", " oo", "^", "^^", "*", "**" };
            string output = input;
            // TODO : Getion du grade (cas particulier le rond) à ne pas confondre avec le o ou O
            // o G500   => grade
            // ooo IMF  => grade
            // freelance, agent immobilier => pas grade
            // *** Waterloo => grade


            if (!typeGrade.Any(output.ToLower().Contains))
            {
                return null;
            }


            if (!output.Contains(")"))
            {
                output += ")";
            }

            foreach (string t in typeGrade)
            {
                int before = output.ToLower().IndexOf(t);
                int after = output.ToLower().LastIndexOf(t);

                if (before >= 0)
                {
                    output = output.Insert(after + 1, "|");

                    if (!output.Contains("("))
                    {
                        output = output.Insert(before, "(");
                    }
                    break;
                }
            }
            return output;
        }
        private bool CheckFields()
        {
            _missed = new List<string>();
            _missed.Add(string.Concat("Il manque les champs suivants :", Environment.NewLine));

            Dictionary<string, bool> checkedFields = new Dictionary<string, bool>();
            foreach (var f in _fields)
            {
                checkedFields.Add(f.ToLower(), false);

                Regex match = new Regex(f, RegexOptions.IgnoreCase);
                foreach (var a in _characterize)
                {
                    if (match.IsMatch(a))
                    {
                        checkedFields[f.ToLower()] = true;
                        break;
                    }
                }
            }

            if (checkedFields.ContainsValue(false))
            {
                foreach (var c in checkedFields)
                {
                    if (c.Value == false)
                    {
                        _missed.Add(string.Concat(c.Key, Environment.NewLine));
                    }
                }
                return false;
            }

            return true;
        }
        private void CreateEmployee(string[] employee)
        {
            string name = employee[1].ToUpper().Trim();
            string stGrade = employee[0].ToLower().Trim();
            int qty = stGrade.Length;
            Category category;

            switch (stGrade.Substring(0, 1))
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

            using (var scope = _container.BeginLifetimeScope())
            {
                ICorporation corpo = scope.Resolve<ICorporation>();
                IGrade grade = scope.Resolve<IGrade>();

                grade.Category = category;
                grade.Qty = qty;
                grade.Rank = SetRank(category, qty);

                corpo.Name = name;
                corpo.Grade = grade;

                Corporation = corpo;
            }
        }
        private string SetRank(Category category, int qty)
        {
            char r;
            char[] rk = { '\u25CB', '\u0394', '\u2605' };
            switch (category)
            {
                case Category.Circle:
                    r = rk[0];
                    break;
                case Category.Triangle:
                    r = rk[1];
                    break;
                case Category.Star:
                    r = rk[2];
                    break;
                default:
                    r = rk[0];
                    break;
            }

            return new string(r, qty);
        }

        #endregion


    }
}
