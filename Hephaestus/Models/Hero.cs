using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Hephaestus.Models
{
    public class Hero
    {
        public Hero()
        {
            this.Epithet = "DefaultEpithet";
            this.EpithetDie = 6;
            this.Name = "DefaultName";
            this.NameDie = 6;
            this.Lineage = "";
            this.IsDemigod = true;
            this.Pronouns = "";
            this.HonoredGod = "";
            this.Strength = "DefaultStrength";
            this.ArtsAndOrationDie = 6;
            this.BloodAndValorDie = 6;
            this.CraftAndReasonDie = 6;
            this.ResolveAndSpiritDie = 6;
            this.FavorGodName1 = "";
            this.FavorGodName2 = "";
            this.FavorGodName3 = "";
            this.FavorGodName4 = "";
            this.FavorScore1 = 0;
            this.FavorScore2 = 0;
            this.FavorScore3 = 0;
            this.FavorScore4 = 0;
            this.Notes = "";
            this.UserId = 1;
        }

        public Hero(
            string epithet,
            int epithetDie,
            string name,
            int nameDie,
            string lineage,
            bool isDemigod,
            string pronouns,
            string honoredGod,
            string strength,
            int artsAndOrationDie,
            int bloodAndValorDie,
            int craftAndReasonDie,
            int resolveAndSpiritDie,
            string favorGodName1,
            string favorGodName2,
            string favorGodName3,
            string favorGodName4,
            int favorScore1,
            int favorScore2,
            int favorScore3,
            int favorScore4,
            string notes,
            int userId
        )
        {
            this.Epithet = epithet;
            this.EpithetDie = epithetDie;
            this.Name = name;
            this.NameDie = nameDie;
            this.Lineage = lineage;
            this.IsDemigod = isDemigod;
            this.Pronouns = pronouns;
            this.HonoredGod = honoredGod;
            this.Strength = strength;
            this.ArtsAndOrationDie = artsAndOrationDie;
            this.BloodAndValorDie = bloodAndValorDie;
            this.CraftAndReasonDie = craftAndReasonDie;
            this.ResolveAndSpiritDie = resolveAndSpiritDie;
            this.FavorGodName1 = favorGodName1;
            this.FavorGodName2 = favorGodName2;
            this.FavorGodName3 = favorGodName3;
            this.FavorGodName4 = favorGodName4;
            this.FavorScore1 = favorScore1;
            this.FavorScore2 = favorScore2;
            this.FavorScore3 = favorScore3;
            this.FavorScore4 = favorScore4;
            this.Notes = notes;
            this.UserId = 1;
        }
        public Hero(
            string epithet,
            int epithetDie,
            string name,
            int nameDie,
            string lineage,
            bool isDemigod,
            string pronouns,
            string honoredGod,
            string strength,
            int artsAndOrationDie,
            int bloodAndValorDie,
            int craftAndReasonDie,
            int resolveAndSpiritDie,
            string favorGodName1,
            string favorGodName2,
            string favorGodName3,
            string favorGodName4,
            int favorScore1,
            int favorScore2,
            int favorScore3,
            int favorScore4,
            string notes,
            int userId,
            int id
            )
        {
            this.Epithet = epithet;
            this.EpithetDie = epithetDie;
            this.Name = name;
            this.NameDie = nameDie;
            this.Lineage = lineage;
            this.IsDemigod = isDemigod;
            this.Pronouns = pronouns;
            this.HonoredGod = honoredGod;
            this.Strength = strength;
            this.ArtsAndOrationDie = artsAndOrationDie;
            this.BloodAndValorDie = bloodAndValorDie;
            this.CraftAndReasonDie = craftAndReasonDie;
            this.ResolveAndSpiritDie = resolveAndSpiritDie;
            this.FavorGodName1 = favorGodName1;
            this.FavorGodName2 = favorGodName2;
            this.FavorGodName3 = favorGodName3;
            this.FavorGodName4 = favorGodName4;
            this.FavorScore1 = favorScore1;
            this.FavorScore2 = favorScore2;
            this.FavorScore3 = favorScore3;
            this.FavorScore4 = favorScore4;
            this.Notes = notes;
            this.UserId = 1;
            this.Id = id;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Epithet { get; set; }
        public int EpithetDie { get; set; }
        [Required]
        public string Name { get; set; }
        public int NameDie { get; set; }
        public string Lineage { get; set; }
        [Display(Name = "Descended from a God?")]
        public bool IsDemigod { get; set; }
        public string Pronouns { get; set; }
        public string HonoredGod { get; set; }
        public string Strength { get; set; }
        [Display(Name = "Arts & Oration")]
        public int ArtsAndOrationDie { get; set; }
        [Display(Name = "Blood & Valor")]
        public int BloodAndValorDie { get; set; }
        [Display(Name = "Craft & Reason")]
        public int CraftAndReasonDie { get; set; }
        [Display(Name = "Resolve & Spirit")]
        public int ResolveAndSpiritDie { get; set; }
        public string FavorGodName1 { get; set; }
        public string FavorGodName2 { get; set; }
        public string FavorGodName3 { get; set; }
        public string FavorGodName4 { get; set; }
        public int FavorScore1 { get; set; }
        public int FavorScore2 { get; set; }
        public int FavorScore3 { get; set; }
        public int FavorScore4 { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        private int GetNextHeroId()
        {
            int lastHeroId = 0;

            //do sql stuff to get last used numgen

            return lastHeroId + 1;
        }
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