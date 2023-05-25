﻿using System.ComponentModel.DataAnnotations;

namespace pAspFinal.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public List<Utilisateur>? Utilisateurs { get; set; }//relation 1 à N
    }
}
