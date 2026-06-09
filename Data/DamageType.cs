using WFHub.Models;

namespace WFHub.Data
{
    public static class DamageTypes
    {
        public static readonly DamageType Impact = new("Impact");
        public static readonly DamageType Puncture = new("Puncture");
        public static readonly DamageType Slash = new("Slash");

        public static readonly DamageType Cold = new("Cold");
        public static readonly DamageType Heat = new("Heat");
        public static readonly DamageType Electricity = new("Electricity");
        public static readonly DamageType Toxin = new("Toxin");

        public static readonly DamageType Blast = new("Blast");
        public static readonly DamageType Corrosive = new("Corrosive");
        public static readonly DamageType Gas = new("Gas");
        public static readonly DamageType Magnetic = new("Magnetic");
        public static readonly DamageType Radiation = new("Radiation");
        public static readonly DamageType Viral = new("Viral");

        public static readonly DamageType VoidType = new("Void");
        public static readonly DamageType Tau = new("Tau");
        public static readonly DamageType TrueType = new("True");
    }
}
