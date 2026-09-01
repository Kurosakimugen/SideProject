using WFHub.Models;
using static WFHub.Data.DamageTypes;

namespace WFHub.Data
{

    public enum WeaponStatsTarget
    {
        BaseDamage,
        CritChance,
        CritMultiplier,
        FireRate,
        Multishot,
        StatusChance,
        MagazineSize,
        AmmoMax,
        AmmoCost,
        ReloadTime,
        MinDistance,
        MaxDistance
    }

    public class Weapons
    {
        public static Weapon Braton = new(
            Name: "Braton",
            WeaponType: "Rifle",
            WeaponSlot: "Primary",

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

        public static Weapon Teste_Debug_Default = new(
            Name: "Debug",
            WeaponType: "Rifle",
            WeaponSlot: "Primary",

            Stats: new WeaponStats(
                Economy: new WeaponEconomy(
                    MagazineSize: 150,
                    AmmoMax: 1000,
                    AmmoCost: 3
                ),

                Combat: new WeaponCombat(
                    BaseDamage: 1000,
                    CritChance: 2.68,
                    CritMultiplier: 6.84,
                    FireRate: 14.6,
                    Multishot: 2.7,
                    StatusChance: 1.36
                ),

                Handling: new WeaponHandling(
                    ReloadTime: 1.5
                ),

                Falloff: new WeaponFalloff(
                    MinDistance: 0,
                    MaxDistance: 500
                )
            ),

            DamageProfile: new DamageProfile(
                new List<DamageEntry>
                {
                    new(Slash, 0.01),
                    new(Impact, 0.23),
                    new(Puncture, 0.03),
                    new(Heat,0.10),
                    new(Corrosive, 0.45),
                    new(Magnetic,0.18)
                }
            )
        );

        public static List<Weapon> All = new()
        {
            Braton,
            Teste_Debug_Default
        };
    }
}
