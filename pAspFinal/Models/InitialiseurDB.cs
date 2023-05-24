using pAspFinal.Models;

namespace pAspFinal.Models
{
    public static class InitialiseurDB
    {
        public static List<Section> _Section = new List<Section>
        {
            new Section{Nom = "Sécurité informatique", Questions = new List < Question > { }},
            new Section{Nom = "Sécurité Physique", Questions = new List < Question > { }},
            new Section{Nom = "Coté Employées", Questions = new List<Question>{ }},
            new Section{Nom = "Coté Employeur", Questions = new List<Question>{ }}
        };
        private static Dictionary<string, Section> _NomSection;
        public static Dictionary<string, Section> NomSection
        {
            get
            {
                _NomSection = new Dictionary<string, Section>();
                foreach (Section section in _Section) 
                {
                    _NomSection.Add(section.Nom, section);
                }
                return _NomSection;
            }
        }

        public static List<Type> _Type = new List<Type>
        {
            new Type{Nom = "Choisir 1", Balise = "input", type = "radio", Questions = new List<Question>{ }},
            new Type{Nom = "Choisir X", Balise = "input", type = "checkbox", Questions = new List<Question>{ }},
            new Type{Nom = "Entrer", Balise = "input", type = "text", Questions = new List<Question>{ }},
            new Type{Nom = "Entre", Balise = "input", type = "range", Questions = new List<Question>{ }},
            new Type{Nom = "Combien", Balise = "input", type = "number", Questions = new List<Question>{ }},
            new Type{Nom = "Date", Balise = "input", type = "date", Questions = new List<Question>{ }},
            new Type{Nom = "Paragraphe", Balise = "textarea", Questions = new List<Question>{ }},
            new Type{Nom = "Choisir liste", Balise = "select", Questions = new List<Question>{ }}
        };

        private static Dictionary<string, Type> _NomType;
        public static Dictionary<string, Type> NomType
        {
            get
            {
                _NomType = new Dictionary<string, Type>();
                foreach (Type type in _Type)
                {
                    _NomType.Add(type.Nom, type);
                }
                return _NomType;
            }
        }
        public static List<Question> _Questions = new List<Question>
        {
            new Question
            {
                Titre = "test",
                Commentaire = "test",
                ParDefault = "test",
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Entrer"]
            },            
            new Question
            {
                Titre = "test1",
                Commentaire = "test1",
                ParDefault = "test1",
                Choix = new List<string> {"test1", "test2", "test3", "test4", "test5"},
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Choisir X"]
            },            
            new Question
            {
                Titre = "test2",
                Commentaire = "test2",
                ParDefault = "test2",
                Choix = new List<string> {"test1", "test2", "test3", "test4", "test5"},
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Choisir 1"]
            },            
            new Question
            {
                Titre = "test3",
                Commentaire = "test3",
                ParDefault = "test3",
                Choix = new List<string> {"test1", "test2", "test3", "test4", "test5"},
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Choisir 1"]
            },            
            new Question
            {
                Titre = "test3 pour choisir liste",
                Commentaire = "le commentaire pour la question sur choisir liste",
                ParDefault = "test3",
                Choix = new List<string> {"test1", "test2", "test3", "test4", "test5"},
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Choisir 1"]
            }

        };

        public static List<Role> _Roles = new List<Role>
        {
            new Role {Nom = "Admin"},
            new Role {Nom = "Utilisateur"},
            new Role {Nom = "temporaire"},
        };
        private static Dictionary<string, Role> _NomRoles;
        public static Dictionary<string, Role> NomRoles
        {
            get
            {
                _NomRoles = new Dictionary<string, Role>();
                foreach (Role roles in _Roles)
                {
                    _NomRoles.Add(roles.Nom, roles);
                }
                return _NomRoles;
            }
        }
        public static List<Utilisateur> _Utilisateur = new List<Utilisateur>
        {
            new Utilisateur { Nom = "Administrateur1", Compagnie = "Admin", Role = NomRoles["Admin"] },
            new Utilisateur { Nom = "Utilisateur1", Compagnie = "Cegep Outaouiais", Role = NomRoles["Utilisateur"] },
            new Utilisateur { Nom = "Anthony", Compagnie = "NET", Role = NomRoles["Utilisateur"] },
            new Utilisateur { Nom = "Haspect", Compagnie = "ORG", Role = NomRoles["Utilisateur"] }
        };

        public static List<Formulaire> _Formulaire = new List<Formulaire>
        {
            new Formulaire { Nom = "FormulaireAdmin", Questions = _Questions, Utilisateurs = _Utilisateur},
            new Formulaire { Nom = "FormulaireUtilisateur", Questions = _Questions, Utilisateurs = _Utilisateur}
        };

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            pAspFinal_dbContext pAspFinal_DbContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<pAspFinal_dbContext>();

            if (!pAspFinal_DbContext.Formulaires.Any())
            {
                pAspFinal_DbContext.Formulaires.AddRange(_Formulaire);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Utilisateurs.Any())
            {
                pAspFinal_DbContext.Utilisateurs.AddRange(_Utilisateur);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Roles.Any())
            {
                pAspFinal_DbContext.Roles.AddRange(NomRoles.Values);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Questions.Any())
            {
                pAspFinal_DbContext.Questions.AddRange(_Questions);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Sections.Any())
            {
                pAspFinal_DbContext.Sections.AddRange(NomSection.Values);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Types.Any())
            {
                pAspFinal_DbContext.Types.AddRange(NomType.Values);
                pAspFinal_DbContext.SaveChanges();
            }


        }
    }
}
