using WFHub.Models;

namespace WFHub.Data
{
    public class Enemys
    {
        public static Enemy Dummy = new(
            Name: "Dummy", 
            Faction: Factions.Grineer,
            Armor: 2700,
            Health: 1500000,
            Shields: 30000,
            Damage_Attenuation: false,
            PartMultiplier: new List<BodyPartMultiplier>
            {
                new (Name: "Default", Multiplier: 1, BodyPart.Normal),
                new (Name: "Head", Multiplier: 3, BodyPart.Weakpoint),
                new (Name: "Other", Multiplier: 0.5, BodyPart.Special)
            }
            );

        public static List<Enemy> All = new()
        {
            Dummy
        };

    }
}
