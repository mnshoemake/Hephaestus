using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hephaestus.Models
{
    public class Hero
    {
        public Hero(string epithet, string name)
        {
  //          this.HeroId = heroId;
            this.Epithet = epithet;
            this.Name = name;
        }

//        public int HeroId { get; set; }
        [Required]
        public string Epithet { get; set; }
        [Required]
        public string Name { get; set; }
        public string Lineage { get; set; }
        [Display(Name = "Descended from a God?")]
        public bool IsDemigod { get; set; }
        public string Pronouns { get; set; }
        public string God { get; set; }
        public string Strength { get; set; }
        [Display(Name = "Arts & Oration")]
        public int ArtsAndOrationDie { get; set; }
        [Display(Name = "Blood & Valor")]
        public int BloodAndValorDie { get; set; }
        [Display(Name = "Craft & Reason")]
        public int CraftAndReasonDie { get; set; }
        [Display(Name = "Resolve & Spirit")]
        public int ResolveAndSpiritDie { get; set; }
        public God DivineFavorGod1 { get; set; }
        public God DivineFavorGod2 { get; set; }
        public int FavorScore1 { get; set; }
        public int FavorScore2 { get; set; }
        public string Notes { get; set; }
    }

    public enum Domain
    {
        ArtsAndOration = 1,
        BloodAndValor = 2,
        CraftAndReason = 3,
        ResolveAndSpirit = 4,
        Other = 5
    }

    public enum God
    {
        Zeus = 1,
        Aphrodite = 2,
        Demeter = 3,
        Hera = 4,
        Hermes = 5,
        Ares = 6,
        Poseidon = 7,
        Hephaistos = 8,
        Hekate = 9,
        Apollo = 10,
        Artemis = 11,
        Athena = 12,
        Other = 13
    }


}
