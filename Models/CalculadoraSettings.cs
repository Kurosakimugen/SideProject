namespace WFHub.Models
{
    public enum EvaluationMode
    {
        Disabled,
        Maximum,
        Simulation
    }

    public enum WeaponSource
    {
        Test,
        Real
    }

    public enum BodyPart
    {
        Weakpoint,
        Normal,
        Special
    }

    public class CalculadoraSettings
    {
        public bool Stealth { get; set; } = false;
        public double Distance { get; set; } = 0;
        public int WeaponRank { get; set; } = 30;
        public Enemy Enemy { get; set; }
        public BodyPartMultiplier SelectedBodyPart { get; set; }

        public EvaluationMode CritMode { get; set; } = EvaluationMode.Disabled;
        public EvaluationMode StatusMode { get; set; } = EvaluationMode.Disabled;
        public EvaluationMode MultiMode { get; set; } = EvaluationMode.Disabled;
    }
}
