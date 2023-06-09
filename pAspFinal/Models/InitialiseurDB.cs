﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
                Choix = new List<Choix>{ },
                Section = NomSection["Coté Employeur"],
                Type = NomType["Choisir X"]
            },            
            new Question
            {
                Titre = "test2",
                Commentaire = "test2",
                ParDefault = "test2",
                Choix = new List<Choix>{ },
                Section = NomSection["Coté Employées"],
                Type = NomType["Choisir 1"]
            },            
            new Question
            {
                Titre = "test3",
                Commentaire = "test3",
                ParDefault = "test3",
                Choix = new List<Choix>{ },
                Section = NomSection["Sécurité Physique"],
                Type = NomType["Choisir 1"]
            },            
            new Question
            {
                Titre = "test4 pour choisir liste",
                Commentaire = "le commentaire pour la question sur choisir liste",
                ParDefault = "test4",
                Choix = new List<Choix>{ },
                Section = NomSection["Sécurité informatique"],
                Type = NomType["Choisir liste"]
            }

        };





        private static Dictionary<string, Question> _TitreQuestion;
        public static Dictionary<string, Question> TitreQuestion
        {
            get
            {
                _TitreQuestion = new Dictionary<string, Question>();
                foreach (Question question in _Questions)
                {
                    _TitreQuestion.Add(question.Titre, question);
                }
                return _TitreQuestion;
            }
        }

        public static List<Choix> _Choix = new List<Choix>()
        {
            new Choix{Options="test0", Question = TitreQuestion["test"]},
            new Choix{Options = "Test1Q1", Question = TitreQuestion["test1"]},
            new Choix{Options = "Test2Q1", Question = TitreQuestion["test1"]},
            new Choix{Options = "Test3Q1", Question = TitreQuestion["test1"]},
            new Choix{Options = "Test1Q2", Question = TitreQuestion["test2"]},
            new Choix{Options = "Test2Q2", Question = TitreQuestion["test2"]},
            new Choix{Options = "Test3Q2", Question = TitreQuestion["test2"]},
            new Choix{Options = "Test4Q2", Question = TitreQuestion["test2"]},
            new Choix{Options = "Test1Q3", Question = TitreQuestion["test3"]},
            new Choix{Options = "Test2Q3", Question = TitreQuestion["test3"]},
            new Choix{Options = "Test3Q3", Question = TitreQuestion["test3"]},
            new Choix{Options = "Test4Q3", Question = TitreQuestion["test3"]},
            new Choix{Options = "Test5Q3", Question = TitreQuestion["test3"]},
            new Choix{Options = "Test1Q4", Question = TitreQuestion["test4"]},
            new Choix{Options = "Test2Q4", Question = TitreQuestion["test1"]}
        };

        public static List<Utilisateur> _Utilisateur = new List<Utilisateur>
        {
            new Utilisateur { Nom = "Administrateur1", Compagnie = "Admin"},
            new Utilisateur { Nom = "Utilisateur1", Compagnie = "Cegep Outaouiais"},
            new Utilisateur { Nom = "Anthony", Compagnie = "NET"},
            new Utilisateur { Nom = "Haspect", Compagnie = "ORG"}
        };

        public static List<Formulaire> _Formulaire = new List<Formulaire>
        {
            new Formulaire { Nom = "FormulaireAdmin", Questions = _Questions, Utilisateurs = _Utilisateur},
            new Formulaire { Nom = "FormulaireUtilisateur", Questions = _Questions, Utilisateurs = _Utilisateur}
        };
        
        public static Utilisateur utili = new Utilisateur
        {
            Compagnie = "SeedCompagnie",
            Email = "email@ceedcompagnie.com",
            EmailConfirmed = true,
            UserName = "email@seedcompagnie.com",

        };
        public static IdentityRole roleAdmin = new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "Admin",

        };


        public static async void Seed(IApplicationBuilder applicationBuilder)
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
            if (!pAspFinal_DbContext.Choixs.Any())
            {
                pAspFinal_DbContext.Choixs.AddRange(_Choix);
                pAspFinal_DbContext.SaveChanges();
            }

            if (!pAspFinal_DbContext.Roles.Any(r => r.Name == "Admin"))
            {
                pAspFinal_DbContext.Roles.Add(roleAdmin);
                pAspFinal_DbContext.SaveChanges();
            }
            if (!pAspFinal_DbContext.Utilisateurs.Any(u => u.UserName == utili.UserName))
            {
                var password = new PasswordHasher<Utilisateur>();
                var hashed = password.HashPassword(utili, "password");
                utili.PasswordHash = hashed;
                var userStore = new UserStore<Utilisateur>(pAspFinal_DbContext);
                await userStore.CreateAsync(utili);
                await userStore.AddToRoleAsync(utili, "admin");
            }




        }
    }
}
