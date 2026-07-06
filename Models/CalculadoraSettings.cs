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

    public class CalculadoraSettings
    {
        public bool Headshot { get; set; } = false;
        public bool Stealth { get; set; } = false;
        public double Distance { get; set; } = 0;

        public EvaluationMode CritMode { get; set; } = EvaluationMode.Disabled;
        public EvaluationMode StatusMode { get; set; } = EvaluationMode.Disabled;
        public EvaluationMode MultiMode { get; set; } = EvaluationMode.Disabled;
    }
}
