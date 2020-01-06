using Data.Entities.Characterize;
using Data.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace WriteToJson
{
    public class ImportData
    {
        #region Attributs        
        private string[] _characterize;
        private Factory _factory;
        private List<string> _features;
        private List<string> _specialAbilities;       
        private List<string> _fields;
        List<string> _missed;
        private Dictionary<string, int> _dictionnaryFeatures;
        private Dictionary<string, int> _dictionnarySpecials;
        private Dictionary<string, int> _dictionnarySkills;
        private Dictionary<string, int> _dictionnaryResources;
        #endregion
        #region Properties
        #endregion

        #region Constructor
        public ImportData()
        {
            Init();
        }
        #endregion

        #region Public Methods
        public void ImportText(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new CharacterException("Le texte ne peut pas être vide");
            }

            SetFormat(content);

            if (!CheckFields())
            {
                throw new CharacterException(string.Concat(_missed));
            }

            SetCorpo();
            SetCharacter();
        }
        #endregion

        #region Private Methods

        private void Init()
        {
            _dictionnaryFeatures = new Dictionary<string, int>();
            _factory = new Factory();
            _missed = new List<string>();
            _features = _factory.GetEnumList(new FeaturesList());
            _specialAbilities = _factory.GetEnumList(new SpecialAbilitiesList());
            _fields = _factory.GetEnumList(new FieldsList());
        }

        private void SetFormat(string content)
        {
            content = content.Replace(Environment.NewLine, "|");

            List<string> lst = new List<string>();
            string item = string.Empty;

            foreach (var c in content.Split('|'))
            {
                if (string.IsNullOrEmpty(c))
                {
                    continue;
                }

                foreach (var f in _fields)
                {
                    //bool match = Regex.IsMatch(c, f);
                    //item = Regex.Replace(c, f, "carac",RegexOptions.IgnoreCase);
                    if (Regex.IsMatch(c, f, RegexOptions.IgnoreCase))
                    {
                        item = c.Replace(c, f);
                        //lst.Add(item);
                        break;
                    }
                    else
                    {
                        item = c;
                    }
                }

                lst.Add(item);
            }
            _characterize = lst.ToArray();
        }
        private void SetCorpo()
        {
            string[] charac = _characterize[0].Split('(');
            string[] corpo;

            if (charac.Length != 1)
            {
                charac[1] = charac[1].Trim(')');
                corpo = charac[1].Split(' ');
            }
            else
            {
                corpo = new string[2] { "*****", "freelance" };
            }

            _factory.CreateCorporation(corpo[1], corpo[0]);
        }

        private void SetCharacter()
        {
            string[] charac = _characterize[0].Split('(');
            string[] name = charac[0].Split(' ');

            if (name.Length < 2)
            {
                throw new CharacterException("Le nom doit être composé d'un prénom et nom");
            }
            if (!SetCharacterize())
            {
                return;
            }

            // name[0] -> FirstName, name[1] -> LastName
            _factory.Features = _dictionnaryFeatures;
            _factory.SpecialAbilities = _dictionnarySpecials;
            _factory.Skills = _dictionnarySkills;
            _factory.Resources = _dictionnaryResources;            
            _factory.CreateCharacter(name[0], name[1]);
        }

        private bool SetCharacterize()
        {
            _missed.Clear();
            _missed.Insert(0, string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine));


            if (!CheckCharacterize(FieldsList.Carac, out string[] features))
            {
                throw new CharacterException(string.Concat(_missed));
            }

            if (!CheckValue(new Features(), features, out _dictionnaryFeatures))
            {
                return false;
            }

            //_dictionnaryFeatures = CheckValueFeature();

            _missed.Clear();
            _missed.Insert(0, string.Concat("Aucune des capacitées spéciales ci-dessous n'est renseignée :", Environment.NewLine, Environment.NewLine));

            if (!CheckCharacterize(FieldsList.Capac, out string[] specials))
            {
                throw new CharacterException(string.Concat(_missed));
            }

            if (!CheckValue(new SpecialAbilities(), specials, out _dictionnarySpecials))
            {
                throw new CharacterException(string.Concat(_missed));
            }


            //string[] skills = Standardize(new Skills(), string[] skills);
            if (!CheckCharacterize(FieldsList.Comp, out string[] skills))
            {
                throw new CharacterException(string.Concat(_missed));
            }

            if (!CheckValue(new Skills(), skills, out _dictionnarySkills))
            {
                throw new CharacterException(string.Concat(_missed));
            }
            // Ressources ne sont pas obligatoires
            ExtractResources(out _dictionnaryResources);

            return true;
        }

        private void ExtractResources(out Dictionary<string,int> resourcesList)
        {
            if (!IsNotFeatureListEmpty(FieldsList.Res, out string resources))
            {
                resourcesList = new Dictionary<string, int>();                
            }

            resourcesList = GetResources(resources);
            
        }

        private Dictionary<string, int> GetResources(string resources)
        {
            
            //resources = Regex.Replace(resources, "+", string.Empty);
            List<string> res = new List<string>();
            res.AddRange(resources.Split(' '));
            res.Remove(string.Empty);

            if (res.Count%2 != 0)
            {
                _missed.Clear();
                _missed.Insert(0, string.Concat("Les données ne semblent pas être cohérentes :", Environment.NewLine));
                _missed.Add(string.Concat("Veuillez consulter les exemples", Environment.NewLine));
                throw new CharacterException(string.Concat(_missed));
            }
            // La valeur des ressources est mise avant la corpo
            if (int.TryParse(res[0],out int value))
            {
                Array.Reverse(res.ToArray());
            }

            if (!CheckValue(new Resources(), res.ToArray(), out _dictionnaryResources))
            {
                throw new CharacterException(string.Concat(_missed));
            }

            return _dictionnaryResources;
        }

        private bool CheckCharacterize(FieldsList field, out string[] characterize)
        {
            characterize = new string[0];
            if (!IsNotFeatureListEmpty(field, out string lineCharacterize))
            {
                return false;
            }

            List<string> pattern = new List<string>();

            switch (field)
            {
                case FieldsList.Carac:
                    characterize = Standardize(new FeaturesList(), Regex.Replace(lineCharacterize, @"\s+", " ").Split(' '));
                    return CheckItems(characterize, _features, true);
                case FieldsList.Capac:
                    characterize = Standardize(new SpecialAbilitiesList(), Regex.Replace(lineCharacterize, @"\s+", " ").Split(' '));
                    return CheckItems(characterize, _specialAbilities, false);

                case FieldsList.Comp:
                    characterize = Standardize(new SkillsList(), Regex.Replace(lineCharacterize, @"\s+", " ").Split(' '));
                    return CheckItems(characterize);

                case FieldsList.Res:
                    //characterize = 
                    return true;
                case FieldsList.Cyber:
                    // Ces champs sont optionnels donc pas de checking dessus
                    return true;
                default:
                    return true;
            }
        }

        private bool CheckItems(string[] datas, List<string> pattern, bool allFields = false)
        {
            Dictionary<string, bool> checkedFields = new Dictionary<string, bool>();

            List<string> items = new List<string>();

            pattern.Sort();

            // Eliminer les valeurs : on ne garde que les intitulés
            foreach (var d in datas)
            {
                if (!int.TryParse(d, out int result))
                {
                    items.Add(d.ToUpper());
                }
            }

            int i = 0;
            items.Sort();

            foreach (var p in pattern)
            {
                if (items.BinarySearch(p.ToUpper()) < 0)
                {
                    _missed.Add(string.Concat(p, Environment.NewLine));
                }
                else
                {
                    i++;
                }
            }

            if (allFields)
            {
                return (_missed.Count < 2);
            }
            else
            {
                _missed.Add(string.Concat(Environment.NewLine, "Veuillez svp regarder les exemples."));
                return (i > 0);
            }
        }
        private bool CheckItems(string[] datas)
        {
            Dictionary<string, bool> checkedFields = new Dictionary<string, bool>();

            List<string> items = new List<string>();

            // Eliminer les valeurs : on ne garde que les intitulés
            foreach (var d in datas)
            {
                if (!int.TryParse(d, out int result))
                {
                    items.Add(d.ToUpper());
                }
            }

            //int i = 0;

            return (items.Count > 0);

            //foreach (var p in pattern)
            //{
            //    if (items.BinarySearch(p.ToUpper()) < 0)
            //    {
            //        _missed.Add(string.Concat(p, Environment.NewLine));
            //    }
            //    else
            //    {
            //        i++;
            //    }
            //}

            //if (allFields)
            //{
            //    return (_missed.Count < 2);
            //}
            //else
            //{
            //    _missed.Add(string.Concat(Environment.NewLine, "Veuillez svp regarder les exemples."));
            //    return (i > 0);
            //}
        }
        
        private bool CheckValue<T>(T t, string[] datas, out Dictionary<string, int> characterize)
        {
            int value = 0;
            string name = string.Empty;
            bool error = false;
            bool canAdd = false;


            List<string> items = new List<string>();
            characterize = new Dictionary<string, int>();

            switch (t)
            {
                case Features f:
                    items = _features;
                    break;
                case SpecialAbilities s:
                    items = _specialAbilities;
                    break;
                case Skills s:
                    //items = _skills;
                    canAdd = true;
                    break;
                case Resources r:
                    canAdd = true;
                    //items = new List<string>();
                    break;
                default:
                    break;
            }

            _missed.Clear();

            if (datas.Length % 2 != 0)
            {
                _missed.Insert(0, string.Concat("Les données ne semblent pas être cohérentes :", Environment.NewLine));
                _missed.Add(string.Concat("Veuillez consulter les exemples", Environment.NewLine));
                throw new CharacterException(string.Concat(_missed));
            }

            _missed.Insert(0, string.Concat("La valeur doit être un entier pour :", Environment.NewLine));

            for (int i = 0; i < datas.Length; i++)
            {
                if (i % 2 == 0)
                {
                    name = datas[i];
                }
                else
                {
                    if (!Int32.TryParse(datas[i], out value))
                    {
                        _missed.Add(string.Concat(datas[i - 1], Environment.NewLine));
                        error = true;
                    }

                    if (canAdd || items.Exists(f => f == name.ToLower()))
                    {
                        characterize.Add(name, value);
                    }
                }
            }
            if (error)
            {
                throw new CharacterException(string.Concat(_missed));
            }

            return true;
        }

        private string[] Standardize<T>(T t, string[] datas)
        {
            List<string> listDatas = new List<string>();
            IDictionary<string, string> standard = new Dictionary<string, string>();

            listDatas.AddRange(datas);
            int index;
            string type = string.Empty;
            try
            {
                switch (t)
                {
                    case FeaturesList f:
                        //Caracteristiques
                        type = "Caracteristiques";
                        break;
                    case SpecialAbilitiesList s:
                        type = "Capacites speciales";
                        break;
                    case SkillsList s:
                        type = "Competences";
                        break;
                    case Resources r:

                        break;
                    default:
                        throw new StandardException("Erreur : Type inconnu");
                }
                standard = Standardization.GetStandard(type);

            }
            catch (StandardException e)
            {
                throw new StandardException(e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
            }
            foreach (KeyValuePair<string, string> s in standard)
            {
                index = listDatas.IndexOf(listDatas.Find(d => d.ToUpper() == s.Key.ToUpper()));
                try
                {
                    listDatas[index]
                        = Regex.Replace(listDatas[index], s.Key, s.Value, RegexOptions.IgnoreCase);
                    listDatas[index]
                            = Regex.Replace(listDatas[index], string.Concat(s.Key, "$"), s.Value, RegexOptions.IgnoreCase);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Do nothing
                }
            }

            listDatas.Remove(string.Empty);
            return listDatas.ToArray();
        }

        private bool CheckFields()
        {
            _missed.Clear();
            // TODO : A voir comment optimiser cela
            _missed.Insert(0, string.Concat("Il manque les champs suivants :", Environment.NewLine));

            //IEnumerable<FieldsList> fields = Enum.GetValues(typeof(FieldsList)).Cast<FieldsList>();
            //List<string> required = new List<string>();
            //foreach (var f in fields)
            //{
            //    required.Add(f.ToString());
            //}

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

        private bool IsNotFeatureListEmpty(FieldsList field, out string datas)
        {
            Regex match = new Regex(field.ToString().ToLower(), RegexOptions.IgnoreCase);
            datas = string.Empty;
            bool isMatch = false;

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
                        //isMatch = false;
                        break;
                    }
                    datas += a + " ";
                }
            }

            if (string.IsNullOrEmpty(datas))
            {
                _missed.Add(string.Concat("Aucune caractéristique n'a été renseigné",
                                 Environment.NewLine,
                                 "Veuillez regarder un exemple",
                                 Environment.NewLine));
                return false;
            }
            return true;
        }

        #endregion

    }
}
