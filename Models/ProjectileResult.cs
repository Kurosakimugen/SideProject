namespace WFHub.Models
{
    public class ProjectileResult
    {
        public double CritMultiplier { get; set; }

        public Dictionary<DamageType, int> StatusApplied { get; set; } = new();

        public double Damage {  get; set; }
    }
}
