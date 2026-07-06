namespace WFHub.Models
{
    public class DamageResult
    {
        public double TotalDamage { get; set; }

        public List<ProjectileResult> Projectiles { get; set; } = new();
    }
}
