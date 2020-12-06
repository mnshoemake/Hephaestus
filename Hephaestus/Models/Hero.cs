using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hephaestus.Models
{
    public class Hero
    {
        private int _HeroID;
        private string _Epithet;
        private string _Name;
        private string _Lineage;
        private bool _IsDemigod;
        private string _Pronouns;
        private string _God;
        private int _ArtsAndOrationDie;
        private int _BloodAndValorDie;
        private int _CraftAndReasonDie;
        private int _ResolveAndSpiritDie;
        private God _DivineFavorGod1;
        private God _DivineFavorGod2;
        private int _FavoreScore1;
        private int _FavorScore2;
        

        public Hero(int heroID, string epithet, string name)
        {
            this.HeroID = heroID;
            this.Epithet = epithet;
            this.Name = name;
        }

        public int HeroID { get => _HeroID; set => _HeroID = value; }
        public string Epithet { get => _Epithet; set => _Epithet = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Lineage { get => _Lineage; set => _Lineage = value; }
        public bool IsDemigod { get => _IsDemigod; set => _IsDemigod = value; }
        public string Pronouns { get => _Pronouns; set => _Pronouns = value; }
        public string God { get => _God; set => _God = value; }
        public int ArtsAndOrationDie { get => _ArtsAndOrationDie; set => _ArtsAndOrationDie = value; }
        public int BloodAndValorDie { get => _BloodAndValorDie; set => _BloodAndValorDie = value; }
        public int CraftAndReasonDie { get => _CraftAndReasonDie; set => _CraftAndReasonDie = value; }
        public int ResolveAndSpiritDie { get => _ResolveAndSpiritDie; set => _ResolveAndSpiritDie = value; }
        public God DivineFavorGod1 { get => _DivineFavorGod1; set => _DivineFavorGod1 = value; }
        public God DivineFavorGod2 { get => _DivineFavorGod2; set => _DivineFavorGod2 = value; }
        public int FavoreScore1 { get => _FavoreScore1; set => _FavoreScore1 = value; }
        public int FavorScore2 { get => _FavorScore2; set => _FavorScore2 = value; }
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
