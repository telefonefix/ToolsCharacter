using Autofac;
using Data.Entities.Attribute;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Patent;
using Data.Entities.Person;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data.Factories
{
    public enum EnumFields
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
        private int _idCharactere;
        private int _idCorporation;
        private int _idGrade;

        private IContainer _container;
        private List<string> _features;
        private Dictionary<EnumGender, string> _dicGender;
        private Dictionary<Type, string> _dictionnaryStandards;
        private Dictionary<string, int> _dico;
        private List<string> _missed;
        private List<string> _fields;
        private List<string> _characterize;
        #endregion
        #region Properties
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Pseudo { get; set; }
        public string Noun { get; set; }
        //public IDictionary<string, int> Features { get; set; }
        public Feature[] Features { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SpecialAbility> SpecialAbilities { get; set; }
        public List<Resource> Ressources { get; set; }
        public List<Patent> Patents { get; set; }
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
        #region Private Methods

        private void BuildDependency()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Character>().As<ICharacter>();
            builder.RegisterType<Skill>().As<ICharacteristic<Skill>>();
            builder.RegisterType<Feature>().As<ICharacteristic<Feature>>();
            builder.RegisterType<SpecialAbility>().As<ICharacteristic<SpecialAbility>>();
            builder.RegisterType<Resource>().As<ICharacteristic<Resource>>();
            builder.RegisterType<Corporation>().As<ICorporation>();
            builder.RegisterType<Grade>().As<IGrade>();
            builder.RegisterType<Patent>().As<IPatent>();

            _container = builder.Build();
        }
        private void Init()
        {
            _dico = new Dictionary<string, int>();
            _features = GetEnumList(new EnumFeatures());
            Features = new Feature[_features.Count];
            SpecialAbilities = new List<SpecialAbility>();
            Skills = new List<Skill>();
            Ressources = new List<Resource>();
            Patents = new List<Patent>();

            _dicGender = new Dictionary<EnumGender, string>()
            {
                {EnumGender.Male,"Mr"},
                {EnumGender.Female,"Mrs"},
                {EnumGender.CyberRobot,"Cyb"}
            };

            _dictionnaryStandards = new Dictionary<Type, string>()
            {
                {typeof(Feature),"caracteristiques" },
                {typeof(Skill),"competences" },
                {typeof(SpecialAbility),"capacites_speciales" },
                {typeof(Resource),"ressources" },
                {typeof(Patent),"brevets" }
            };
            _fields = GetEnumList(new EnumFields());
        }
        private void SetCharacter(string gender)
        {
            Dictionary<string, EnumGender> dicGender = new Dictionary<string, EnumGender>()
            {
                {"Homme",EnumGender.Male },
                {"Femme",EnumGender.Female },
                {"Cyber Robot",EnumGender.CyberRobot }
            };

            EnumGender genderEnum = EnumGender.Male;
            if (!dicGender.TryGetValue(gender, out genderEnum))
            {
                genderEnum = EnumGender.Male;
            }

            SetName(_characterize[0].Split('('), genderEnum);

            SetCharacterize(new Feature());
            SetCharacterize(new SpecialAbility());

            // TODO : Revoir pour les compétences
            SetCharacterize(new Skill());

            // TODO : Revoir pour les ressources
            SetCharacterize(new Resource());
            ExtractPatents();
        }
        private void SetName(string[] line, EnumGender gender)
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

            // TODO : Faire Repository pour la création de personnage

            //CharacterRepository repository = new CharacterRepository();
            DbCharacterRepository repository = new DbCharacterRepository();
            repository.Create(names[0], names[1], names[2], gender, _idCorporation, _idGrade);
            _idCharactere = repository.Id;

            //repository.
            //FirstName = names[0];
            //LastName = names[1];
            //Pseudo = names[2];
        }
        /// <summary>
        /// Rentre les valeurs
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="dico"></param>
        private bool SetCharacterize<TEntity>(TEntity entity) where TEntity : class, ICharacteristic<TEntity>
        {
            List<string> items = new List<string>();
            List<Feature> features = new List<Feature>();
            Dictionary<string, int> dicCharacValue = new Dictionary<string, int>();
            Dictionary<string, string> dicSkillFeature = new Dictionary<string, string>();

            //bool switchToArray = false;
            int i = 1;
            string message = string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine);
            _missed = new List<string>();

            // For Features, all fields are required
            if (entity.GetType() == typeof(Feature))
            {
                _missed.Add(string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine));
                message = string.Concat("Il manque les caractéristiques suivantes :", Environment.NewLine);
            }

            if (entity.GetType() == typeof(Skill))
            {

                if (!CheckSkill(ref dicCharacValue, ref dicSkillFeature))
                {
                    throw new CharacterException(string.Concat(_missed));
                }
            }
            else
            {
                if (!CheckCharacterize(entity, ref dicCharacValue))
                {
                    throw new CharacterException(string.Concat(_missed));
                }
            }



            //DbCharacterizeRepository<TEntity> repoFeature = new DbCharacterizeRepository<TEntity>();

            // TODO: A voir pour optimiser cela

            DbCharacterizeRepository<TEntity> repository = new DbCharacterizeRepository<TEntity>();
            DbAttributeRepository<TEntity,TAttribute> attributeRepository = new DbAttributeRepository<TEntity, TAttribute>();

            //DbCharacterizeRepository<Feature> repoFeature = new DbCharacterizeRepository<Feature>();
            DbAttributeRepository <AttributeFeature> repoAttFeature = new DbAttributeRepository<AttributeFeature>();

            DbCharacterizeRepository<SpecialAbility> repoSpecial = new DbCharacterizeRepository<SpecialAbility>();
            DbAttributeRepository<AttributeSpecialAbility> repoAttSpecial = new DbAttributeRepository<AttributeSpecialAbility>();

            DbCharacterizeRepository<Skill> repoSkill = new DbCharacterizeRepository<Skill>();
            DbAttributeRepository<AttributeSkill> repoAttSkill = new DbAttributeRepository<AttributeSkill>();

            DbCharacterizeRepository<Resource> repoResource = new DbCharacterizeRepository<Resource>();
            DbAttributeRepository<AttributeResource> repoAttResource = new DbAttributeRepository<AttributeResource>();

            foreach (KeyValuePair<string, int> item in dicCharacValue)
            {
                switch (entity)
                {
                    case Feature f:

                        //AttributeFeature attributes = new AttributeFeature();

                        repository.Create<ICharacteristic<TEntity>>(entity, entity,item.Key);

                        repoAttFeature.Create<IAttribute<AttributeFeature>>
                            (
                                new AttributeFeature(),
                                new AttributeFeature(),
                                _idCharactere,
                                repository.Id,
                                item.Value
                             );
                        //f = new Feature
                        //{
                        //    Id = i,
                        //    Name = item.Key,
                        //};
                        //features.Add(f);
                        //switchToArray = true;
                        break;
                    case Skill s:
                        string feature = string.Empty;

                        if (dicSkillFeature.TryGetValue(item.Key, out feature))
                        {
                            repoSkill.Create<ICharacteristic<Skill>>(s, new Skill(), item.Key, feature);
                            repoAttSkill.Create<IAttribute<AttributeSkill>>
                                (
                                    new AttributeSkill(),
                                    new AttributeSkill(),
                                    _idCharactere,
                                    repoSkill.Id,
                                    item.Value
                                );
                        }



                        //s = new Skill
                        //{
                        //    Id = i,
                        //    Name = item.Key,
                        //    //Value = item.Value
                        //};
                        Skills.Add(s);
                        break;
                    case SpecialAbility sa:
                        repoSpecial.Create<ICharacteristic<SpecialAbility>>(sa, new SpecialAbility(), item.Key);
                        repoAttSpecial.Create<IAttribute<AttributeSpecialAbility>>
                            (
                                new AttributeSpecialAbility(),
                                new AttributeSpecialAbility(),
                                _idCharactere,
                                repoSpecial.Id,
                                item.Value
                            );
                        //sa = new SpecialAbility
                        //{
                        //    Id = i,
                        //    Name = item.Key,
                        //    //Value = item.Value
                        //};
                        //SpecialAbilities.Add(sa);
                        break;
                    case Resource r:
                        //repoResource.Create<ICharacteristic<Resource>>(r, new Resource(), item.Key);
                        //repoAttResource.Create<IAttribute<AttributeResource>>
                        //    (
                        //        new AttributeResource(),
                        //        new AttributeResource(),
                        //        _idCharactere,
                        //        repoResource.Id,
                        //        item.Value
                        //     );
                        //r = new Resource
                        //{
                        //    Id = i,
                        //    Name = item.Key,
                        //    //Value = item.Value
                        //};
                        //Ressources.Add(r);
                        break;
                    default:
                        throw new CharacterException("Données inconnues");
                }
                i++;
            }
            // TODO : Voir pour faire la sauvegarde vers la DB
            switch (entity)
            {
                case Feature f:
                    //repoFeature.Save();
                    //repoAttFeature.Save();
                    repository.Dispose();
                    //repoFeature.Dispose();
                    repoAttFeature.Dispose();

                    break;

                case SpecialAbility sa:
                    //repoSpecial.Save();
                    //repoAttSpecial.Save();

                    repoSpecial.Dispose();
                    repoAttSpecial.Dispose();
                    break;
                case Skill s:
                    //repoSkill.Save();
                    //repoAttSkill.Save();

                    repoSkill.Dispose();
                    repoAttSkill.Dispose();
                    break;
                case Resource r:
                    //repoResource.Dispose();
                    //repoAttResource.Dispose();
                    break;
                default:
                    break;
            }
            //repoCharacterize.Save();
            //repoAttFeature.Save();

            //repoCharacterize.Dispose();


            //if (switchToArray)
            //{
            //    Features = features.ToArray();
            //}
            return true;
        }

        private bool CheckSkill(ref Dictionary<string, int> dicCharacValue, ref Dictionary<string, string> dicSkillFeature)
        {
            string lineCharacterize = string.Empty;

            if (!ExtractSkills(ref lineCharacterize))
            {
                return false;
            }

            List<string> characterize = Standardize(new Skill(), Regex.Replace(lineCharacterize, @"\s+", " ").Split('|').ToList());

            List<string> skillsValue = SetSkillsFeature(characterize, ref dicSkillFeature);

            if (!CheckValue(skillsValue, ref dicCharacValue))
            {
                throw new CharacterException(string.Concat(_missed));
            }
            return true;
        }

        private List<string> SetSkillsFeature(List<string> characterize, ref Dictionary<string, string> dicSkillFeature)
        {
            List<string> vs = new List<string>();
            foreach (string c in characterize)
            {
                string skillValue = c.Remove(c.IndexOf("§"));
                string skill = Regex.Replace(skillValue, @"\d+", string.Empty).ToUpper().Trim();
                string feature = c.Substring(c.IndexOf("§") + 1).ToUpper().Trim();

                vs.Add(skillValue);
                dicSkillFeature.Add(skill, feature);
            }

            return vs;

        }

        /// <summary>
        /// Extrait les brevets ...
        /// </summary>
        private void ExtractPatents()
        {
            string patents = string.Empty;

            if (!ExtractDatas(new Patent(), ref patents))
            {
                return;
            }

            foreach (string p in patents.Split('|').ToList())
            {
                Patent patent = new Patent()
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
            // TODO : Mettre dans BdD les corporations 
            // Dans le cas Features toutes les valeurs sont requises
            if (t.GetType() == typeof(Feature))
            {
                return CheckFeatures(characterize, ref dico);
            }

            return CheckValue(characterize, ref dico);
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

            if (!CheckValue(items, ref dico))
            {
                _missed.Add(string.Format("{0} a renvoyé l'erreur {1}", key, message));
                return false;
            }

            return true;
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
                        
            _missed.Add(string.Concat("Des erreurs ont été trouvé : ", Environment.NewLine));

            foreach (string d in datas)
            {
                string name = null;
                int value = 0;

                if (!CheckFieldValue(d, ref message, ref name, ref value))
                {
                    _missed.Add(string.Concat(string.Format("- {0} ",message), Environment.NewLine));                    
                }

                // Verifie l'existence de doublon, si doublon alors la nouvelle valeur ecrase l'ancienne
                if (dico.Keys.Contains(name))
                {
                    dico.Remove(name);
                }
                dico.Add(name, value);
            }
            return (_missed.Count < 2);
        }
        /// <summary>
        /// Standardize all fields
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        private List<string> Standardize<T>(T t, List<string> datas)
        {
            List<string> listDatas = new List<string>();
            IDictionary<string, string> standard = new Dictionary<string, string>();

            listDatas.AddRange(datas);
            listDatas.Remove(string.Empty);

            string type = string.Empty;
            try
            {               
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
                string feature = string.Empty;
                string tmp = string.Empty;

                CheckFieldValue(l, ref message, ref key, ref val);

                if (key.Contains("§"))
                {
                    feature = key.Substring(key.IndexOf('§'));
                    key = key.Remove(key.IndexOf('§')).Trim();
                    tmp = l.Remove(l.IndexOf('§')).Trim();
                }
                else
                {
                    tmp = l;
                }


                if (standard.TryGetValue(key, out itemStandard))
                {
                    tmp = Regex.Replace(l, key, itemStandard, RegexOptions.IgnoreCase);
                    lstTemp.Add(tmp);
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(feature))
                {
                    tmp += feature;
                }

                lstTemp.Add(tmp);
            }

            return lstTemp;
        }
        /// <summary>
        /// Check if the associated field has an integer value
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
            
            output = output.ToUpper();
            string checkValue = Regex.Replace(output, @"[A-ZÉÈ_\.]", string.Empty).Trim();

            name = Regex.Replace(output, @"\d+", string.Empty).Trim();
            name = Regex.Replace(name, "[+-]", string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Le nom du champ n'est pas valide";
                return false;
            }

            if (checkValue.Contains(" "))
            {
                name += checkValue.Substring(0, checkValue.IndexOf(" "));
                checkValue = checkValue.Substring(checkValue.IndexOf(" "));
            }

            if (!int.TryParse(checkValue, out value))
            {
                message = string.Format("Le champ {0} n'est pas associé à une valuer entière",name);
                return false;
            }
            message = string.Format("OK : {0} = {1}",name,value);
            return true;
        }

        private bool ExtractSkills(ref string datas)
        {
            datas = string.Empty;
            bool isMatch = false;
            string feature = string.Empty;

            Regex match = new Regex(_dictionnaryStandards[typeof(Skill)], RegexOptions.IgnoreCase);

            List<char> Readfeatures = new List<char>() { '[', ']' };

            foreach (string c in _characterize)
            {
                if (match.IsMatch(c))
                {
                    isMatch = true;
                    continue;
                }

                if (isMatch)
                {
                    if (_fields.Exists(f => f == c))
                    {
                        break;
                    }

                    if (Readfeatures.Any(c.Contains))
                    {
                        feature = c.Replace("[", string.Empty).Replace("]", string.Empty);
                        continue;
                    }
                    // datas for skills is e.g. PERCEPTION 6§INT|SOCIAL 5§EMP| ...
                    if (!string.IsNullOrWhiteSpace(c))
                    {
                        datas += c.Trim() + "§" + feature + "|";
                    }
                }
            }

            if (string.IsNullOrEmpty(datas))
            {
                _missed.Add(string.Concat("Aucune Competences n'a été renseigné",
                                 Environment.NewLine,
                                 "Veuillez regarder un exemple",
                                 Environment.NewLine));
                return false;
            }
            return true;


            // Concerne les brevets ou la cyber (Ceci est optionnel) donc si ce champ est vide non retour d'erreur
            //int index = _characterize.FindIndex(c => c == _dictionnaryStandards[typeof(Patent)]);

            //if (index > 0)
            //{
            //    for (int i = index + 1; i < _characterize.Count; i++)
            //    {
            //        datas += _characterize[i] + "|";
            //    }
            //}

            //return true;
        }


        private bool ExtractDatas<T>(T t, ref string datas)
        {
            datas = string.Empty;
            bool isMatch = false;
            string requiredField = string.Empty;

            if (t.GetType() != typeof(Patent))
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
                    case Feature f:
                        requiredField = "Caracteristique";
                        break;
                    case Skill s:
                        requiredField = "Competences";
                        break;
                    default:
                        requiredField = "Champ optionnel";
                        break;
                }
                if (string.IsNullOrEmpty(datas) && (t.GetType() != typeof(Resource) || t.GetType() != typeof(SpecialAbility)))
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
            int index = _characterize.FindIndex(c => c == _dictionnaryStandards[typeof(Patent)]);

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
            {
                " o ",
                " oo",
                "^",
                "^^",
                "*",
                "**"
            };
            string output = input;
            // TODO : Getion du grade (cas particulier le rond) à ne pas confondre avec le o ou O
            // o G500   => grade
            // ooo IMF  => grade
            // freelance, agent immobilier => pas grade
            // *** Waterloo => grade = ***


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



        private void CreateEmployee()
        {
            //CorporationRepository repository = ne
        }

        private void CreateEmployee(string[] employee)
        {
            string name = employee[1].ToUpper().Trim();
            string stGrade = employee[0].ToLower().Trim();
            int qty = stGrade.Length;
            EnumCategory category;

            switch (stGrade.Substring(0, 1))
            {
                case "o":
                    category = EnumCategory.Circle;
                    break;
                case "^":
                    category = EnumCategory.Triangle;
                    break;
                case "*":
                    category = EnumCategory.Star;
                    break;
                default:
                    category = EnumCategory.Circle;
                    break;
            }

            DbCorporationRepository corpoRepository = new DbCorporationRepository();
            corpoRepository.Create(name);
            _idCorporation = corpoRepository.Id;
            //corpoRepository.Save();
            corpoRepository.Dispose();

            DbGradeRepository gradeRepository = new DbGradeRepository();

            _idGrade = gradeRepository.GetId(SetRank(category), qty);
            gradeRepository.Dispose();


            using (ILifetimeScope scope = _container.BeginLifetimeScope())
            {
                ICorporation corpo = scope.Resolve<ICorporation>();
                IGrade grade = scope.Resolve<IGrade>();

                //grade.Category = category;
                grade.Quantity = qty;
                grade.Category = SetRank(category);

                corpo.Name = name;
                //corpo.Grade = grade;

                Corporation = corpo;
            }
        }
        private string SetRank(EnumCategory category)
        {
            char r;
            char[] rk = { '\u25CF', '\u25BC', '\u2605' };
            switch (category)
            {
                case EnumCategory.Circle:
                    r = rk[0];
                    break;
                case EnumCategory.Triangle:
                    r = rk[1];
                    break;
                case EnumCategory.Star:
                    r = rk[2];
                    break;
                default:
                    r = rk[0];
                    break;
            }

            return r.ToString();
        }

        #endregion
    }
}
