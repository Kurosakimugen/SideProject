using WFHub.Models;
using static WFHub.Data.DamageTypes;

namespace WFHub.Data;

public static class ElementCombinations
{
    public static readonly List<CombinedElement> All =
    [
        new(Heat, Cold, Blast),
        new(Toxin, Electricity, Corrosive),
        new(Cold, Electricity, Magnetic),
        new(Heat, Toxin, Gas),
        new(Cold, Toxin, Viral),
        new(Heat, Electricity, Radiation)
    ];
}