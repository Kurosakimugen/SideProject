using WFHub.Models;
using static WFHub.Data.DamageTypes;

namespace WFHub.Data
{
    public class Weapons
    {
        public static Weapon Braton = new(
            Name: "Braton",
            WeaponClass: "Rifle",
            WeaponType: "Primary",

            Stats: new WeaponStats(
                Economy: new WeaponEconomy(
                    MagazineSize: 45,
                    AmmoMax: 540,
                    AmmoCost: 1
                ),

                Combat: new WeaponCombat(
                    BaseDamage: 24,
                    CritChance: 0.12,
                    CritMultiplier: 1.6,
                    FireRate: 8.75,
                    Multishot: 1,
                    StatusChance: 0.06
                ),

                Handling: new WeaponHandling(
                    ReloadTime: 2.0
                ),

                Falloff: new WeaponFalloff(
                    MinDistance: 0,
                    MaxDistance: 300
                )
            ),

            DamageProfile: new DamageProfile(
                new List<DamageEntry>
                {
                    new(Slash, 0.34),
                    new(Impact, 0.33),
                    new(Puncture, 0.33)
                }
            )
        );

        public static List<Weapon> All = new()
        {
            Braton
        };
    }
}
