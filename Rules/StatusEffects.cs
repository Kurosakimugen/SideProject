using WFHub.Models;

namespace WFHub.Data.Status;

public static class StatusEffects
{
    public static readonly Effect Stagger = new(
        "Stagger",
        "Causes enemy stagger"
    );

    public static readonly Effect MercyThreshold = new(
        "Parazon Mercy Threshold",
        "Allows Parazon Mercy interaction"
    );


    public static readonly Effect DamageReduction = new(
        "Enemy Damage Reduced",
        "Reduces enemy damage output"
    );

    public static readonly Effect CriticalChanceIncrease = new(
        "Increase Crit Chance",
        "Increases critical chance"
    );


    public static readonly Effect Bleed = new(
        "Bleed",
        "Deals damage over time and ignores armor"
    );

    public static readonly Effect ArmorIgnore = new(
        "Ignore Armor",
        "Damage bypasses armor"
    );


    public static readonly Effect Slow = new(
        "Slow",
        "Reduces enemy movement speed or freezes them if enough stacks are applied"
    );

    public static readonly Effect CriticalDamageIncrease = new(
        "Increase Crit Damage",
        "Increases critical damage"
    );


    public static readonly Effect Burn = new(
        "Burn",
        "Deals heat damage over time"
    );

    public static readonly Effect Panic = new(
        "Panic",
        "Causes enemies to panic"
    );

    public static readonly Effect ArmorReduction = new(
        "Armor Reduction",
        "Reduces enemy armor"
    );


    public static readonly Effect TeslaChain = new(
        "Tesla Chain",
        "Chains electricity between enemies"
    );

    public static readonly Effect Stun = new(
        "Stun",
        "Prevents enemy actions temporarily"
    );


    public static readonly Effect Poison = new(
        "Poison",
        "Deals toxin damage"
    );

    public static readonly Effect ShieldIgnore = new(
        "Ignore Shield",
        "Bypasses enemy shields"
    );


    public static readonly Effect Explosions = new(
        "Multiple Explosions",
        "Creates additional explosions"
    );


    public static readonly Effect GasCloud = new(
        "Gas Cloud",
        "Creates a toxic gas cloud"
    );


    public static readonly Effect ShieldAmplification = new(
        "Shield Amplification",
        "Amplifies damage against shields, overguard and nullifier bubbles"
    );

    public static readonly Effect OverguardAmplification = new(
        "Shield Amplification",
        "Amplifies damage against overguard"
    );

    public static readonly Effect ShieldRegenNegation = new(
        "Negate Shield Regen",
        "Prevents shield regeneration"
    );


    public static readonly Effect FriendlyFire = new(
        "Friendly Fire",
        "Causes enemies to attack allies"
    );


    public static readonly Effect HealthAmplification = new(
        "Health Damage Amplification",
        "Amplifies damage dealt to health"
    );


    public static readonly Effect BulletAttraction = new(
        "Bullet Attraction",
        "Creates bullet attraction effect"
    );


    public static readonly Effect StatusVulnerability = new(
        "Status Vulnerability",
        "Increases vulnerability to status effects"
    );
}