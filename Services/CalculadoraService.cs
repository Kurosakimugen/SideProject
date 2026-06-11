using System.Timers;
using WFHub.Models;

namespace WFHub.Services
{
    public class CalculadoraService
    {
        // Verificação se é incarnon ou não ou alguma outra coisa que possa alterar o possível base damage e verificção se existem mods que possam alterar os modifiers do base damagetypes

        // Quantização do dano
        public Dictionary<DamageType, double> Quantized_Damage(Weapon Arma/*,Mod Build*/)
        {
            Dictionary<DamageType, double> DmgScaled = new Dictionary<DamageType, double>();
            double baseDamage = Arma.Stats.Combat.BaseDamage;
            double scale = baseDamage / 32.0;

            foreach (DamageEntry dmg in Arma.DamageProfile.Damages)
            {
                double typeDamage = dmg.Value * baseDamage;
                // typeDamage = typeDamage * (1 + Mod.Value)
                double scaled = typeDamage / scale;
                double rounded = Math.Round(scaled);
                double quantized = rounded * scale;

                DmgScaled.Add(dmg.Type, quantized);
            }

            return DmgScaled;
        }

        // Cálculo do dano de mods elementais e quantizar 

        // Cálculo do dano base das armas com mods

        // Cálculo de multishot
        public int Projectiles_Per_Shot(Weapon Arma ,CalculadoraSettings Condicoes)
        {
            if (Condicoes.MultiMode == EvaluationMode.Disabled)
            {
                // Caso beca weird para considerar em shotguns visto terem multishot diferente de 1 como default
                Console.WriteLine("Multishot está desativado");
                return (int)Arma.Stats.Combat.Multishot;
            }

            //Atualizar o Multishot com base nos mods
            int baseProjectile = (int)Math.Floor(Arma.Stats.Combat.Multishot);
            double overflowProjectile = Arma.Stats.Combat.Multishot - Math.Floor(Arma.Stats.Combat.Multishot);

            if (Condicoes.MultiMode == EvaluationMode.Maximum)
            {
                Console.WriteLine("Melhor caso possível");
                return baseProjectile + (overflowProjectile > 0 ? 1 : 0 );
            }

            // RNG para saber se teve sucesso ou não
            bool extraProjectile = Random.Shared.NextDouble() < overflowProjectile;

            return baseProjectile + (extraProjectile ? 1 : 0);
        }

        // Cálculo de crit
        public double Crit_Effect(Weapon Arma, CalculadoraSettings Condicoes)
        {
            if (Condicoes.CritMode == EvaluationMode.Disabled)
            {
                Console.WriteLine("O crit está desativado");
                return 1;
            }

            // Verificação do crit não ser negativo
            double critChanceSafe = Math.Max(0, Arma.Stats.Combat.CritChance);
            int tier = (int)Math.Floor(critChanceSafe);
            int finaltier = tier;
            // Cálculo da probabilidade de avançar um tier
            double overflow = critChanceSafe - tier;


            if (Condicoes.CritMode == EvaluationMode.Maximum)
            {
                Console.WriteLine("Melhor caso possível");
                finaltier = tier + (overflow > 0 ? 1 : 0);

            }
            else
            {
                // RNG para saber se teve sucesso ou não
                bool extraTier = Random.Shared.NextDouble() < overflow;
                finaltier = tier + (extraTier ? 1 : 0);
            }

            double CritMultiplierFinal = 1 + finaltier * (Arma.Stats.Combat.CritMultiplier /* * ( 1 + Mods) */ - 1);
            return CritMultiplierFinal;
        }

        // Cálculo de status

        // Extras

        // Cálculo de final de damage

        public double Damage_Per_Click(Weapon Arma, CalculadoraSettings Condicoes)
        {
            // Passo de verificação
            // Quantização
            Dictionary<DamageType, double> Quantized = Quantized_Damage(Arma);
            // Incialiazar o valor final
            double total = 0;
            // Calcular o numero de projeteis
            int Projectiles = Projectiles_Per_Shot(Arma, Condicoes);
            // Por cada projectil calcular o seu crit e respetivo damage
            for (int i = 0; i < Projectiles; i++)
            {
                double crit = Crit_Effect(Arma, Condicoes);
                foreach (var dmg in Quantized)
                {
                    total += dmg.Value * crit;
                }
            }

            return total;
        }
    }
}