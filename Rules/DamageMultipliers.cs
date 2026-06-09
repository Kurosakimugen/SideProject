using WFHub.Models;
using static WFHub.Data.DamageTypes;
using static WFHub.Data.Factions;

namespace WFHub.Rules.Damage;

public static class DamageMultipliers
{
    public static readonly List<DamageMultiplierRule> All =
    [
        new(Impact, Grineer, 1.5),
        new(Impact, KuvaGrineer, 1.5),
        new(Impact, Scaldra, 1.5),
        new(Impact, Anarchs, 1.5),

        new(Puncture, Corpus, 1.5),
        new(Puncture, Orokin, 1.5),

        new(Slash, Infested, 1.5),
        new(Slash, Narmer, 1.5),

        new(Cold, Sentient, 1.5),
        new(Cold, Techrot, 0.5),

        new(Heat, KuvaGrineer, 0.5),
        new(Heat, Infested, 1.5),

        new(Electricity, CorpusAmalgam, 1.5),
        new(Electricity, Murmur, 1.5),
        new(Electricity, Anarchs, 1.5),

        new(Toxin, Narmer, 1.5),

        new(Blast, CorpusAmalgam, 0.5),
        new(Blast, InfestedDeimos, 1.5),

        new(Corrosive, Grineer, 1.5),
        new(Corrosive, KuvaGrineer, 1.5),
        new(Corrosive, Sentient, 0.5),
        new(Corrosive, Scaldra, 1.5),

        new(Gas, InfestedDeimos, 1.5),
        new(Gas, Scaldra, 0.5),
        new(Gas, Techrot, 1.5),

        new(Magnetic, Corpus, 1.5),
        new(Magnetic, CorpusAmalgam, 1.5),
        new(Magnetic, Narmer, 0.5),
        new(Magnetic, Techrot, 1.5),

        new(Radiation, Orokin, 0.5),
        new(Radiation, Sentient, 1.5),
        new(Radiation, Murmur, 1.5),

        new(Viral, InfestedDeimos, 0.5),
        new(Viral, Orokin, 1.5),
        new(Viral, Murmur, 0.5),

        new(VoidType, Zariman, 1.5)
    ];
}