namespace WFHub.Models
{
    public record DamageType(string Damage);

    public record Faction(string FactionName);

    public record Mod(string ModName);

    public record DamageMultiplierRule(DamageType DamageType, Faction Faction, double Multiplier);

    public record Effect (string EffectName, string Description);

    public record DamageEffect(DamageType DamageType, Effect Effect);

    public record CombinedElement(DamageType Element1, DamageType Element2, DamageType Result)
    {
        public bool Matches(DamageType a, DamageType b) =>
            (Element1 == a && Element2 == b) ||
            (Element1 == b && Element2 == a);
    };

    public record DamageEntry(DamageType Type,double Value);

    public record DamageProfile(IReadOnlyList<DamageEntry> Damages);

    public record WeaponEconomy(
        int MagazineSize,
        int AmmoMax,
        int AmmoCost
    );

    public record WeaponCombat(
        double BaseDamage,
        double CritChance,
        double CritMultiplier,
        double FireRate,
        double Multishot,
        double StatusChance
    );

    public record WeaponHandling(double ReloadTime);

    public record WeaponFalloff(
        double MinDistance,
        double MaxDistance
    );

    public record WeaponStats(
        WeaponEconomy Economy,
        WeaponCombat Combat,
        WeaponHandling Handling,
        WeaponFalloff Falloff
        );

    public record Weapon(
        string Name,
        string WeaponType,
        string WeaponSlot,
        WeaponStats Stats,
        DamageProfile DamageProfile
    );

    public record Enemy(string Name, Faction Faction, int Armor, int Health, int Shields, bool Damage_Attenuation, List<BodyPartMultiplier> PartMultiplier );

    public record BodyPartMultiplier(string Name, double Multiplier, BodyPart Part);
}

