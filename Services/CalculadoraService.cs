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

        // Cálculo do dano das armas com base em habilidade de Warframe

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
                Console.WriteLine("Melhor caso possível de multishot");
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
                Console.WriteLine("Melhor caso possível de crit");
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
        public int Status_Amount (Weapon Arma, CalculadoraSettings Condicoes)
        {
            int resultado;

            if (Condicoes.StatusMode == EvaluationMode.Disabled)
            {
                Console.WriteLine("O Status está desativado");
                return 0;
            }

            // Verificação de % de status
            double statusChanceCheck = Math.Max(0, Arma.Stats.Combat.StatusChance);
            int amount_effects_secured = (int)Math.Floor(statusChanceCheck);
            // Separação da percentagem garantida para apenas ter a parte que pode variar com o RNG
            double overflow = statusChanceCheck - amount_effects_secured;

            if (Condicoes.StatusMode == EvaluationMode.Maximum)
            {
                // Formula quando não existe probabilidades
                Console.WriteLine("Melhor caso possível de status");
                resultado = amount_effects_secured + (overflow > 0 ? 1 : 0);
            }
            else
            {
                // Formula usando o RNG
                bool extra_Status = Random.Shared.NextDouble() < overflow;
                resultado = amount_effects_secured + (extra_Status ? 1 : 0);
            }
            return resultado;
        }

        public Dictionary<DamageType,int> Status_Applied (Weapon Arma, int Amount_Status)
        {
            if (Amount_Status <= 0)
            {
                return new Dictionary<DamageType, int>();
            }

            if (Arma.DamageProfile.Damages.Count == 1)
            {
                var tipo = Arma.DamageProfile.Damages[0].Type;

                return new Dictionary<DamageType, int>
                {
                    { tipo, Amount_Status }
                };
            }

            Dictionary<DamageType, int> resultado = new Dictionary<DamageType, int>();
            

            for (int i = 0; i < Amount_Status; i++)
            {
                double stack_random = 0;
                double number_RNG = Random.Shared.NextDouble();

                // iterar sobre todos os tipos de danos na arma e suas proporções de dano
                // Por enquanto assumir que os valores desta lista estão entre 0 e 1
                foreach (DamageEntry dmg in Arma.DamageProfile.Damages)
                {
                    // Obter o tipo de dano a ser avaliado
                    DamageType Tipo = dmg.Type;
                    double proportion = dmg.Value;
                    stack_random += proportion;
                    if (number_RNG < stack_random)
                    {
                        resultado.TryAdd(Tipo, 0);
                        resultado[Tipo]++;
                        break;
                    }

                }
            }
            

            return resultado;
        }

        // Extras

        // Cálculo de BodyPart Multiplier

        public double BodyPart_Multiplier (CalculadoraSettings Condicoes /* Rever onde vão estar guardados os mods*/)
        {
            if (Condicoes.SelectedBodyPart == null)
                return 1;

            double multiplier = Condicoes.SelectedBodyPart.Multiplier;

            if (Condicoes.SelectedBodyPart.Part == BodyPart.Weakpoint)
            {
                //multiplier *= (1 + Mods);
            }

            return multiplier;
        }

        // Cálculo do Bonus de Stealth (Apenas funciona quando é uma melee)

        public double StealthBonus (CalculadoraSettings Condicoes)
        {
            int WeaponRank = Condicoes.WeaponRank;
            double Bonus = 1 + (0.2 * WeaponRank);
            return Bonus;
        }

        // Cálculo de final de damage

        public DamageResult Damage_Per_Click(Weapon Arma, CalculadoraSettings Condicoes)
        {
            // Passo de verificação
            // Quantização
            Dictionary<DamageType, double> Quantized = Quantized_Damage(Arma);
            // Incialiazar o valor final
            DamageResult result = new();                        // Criar uma instância com o registo de todos os projeteis e o dano total
            double total = 0;
            double PartMultiplier = BodyPart_Multiplier(Condicoes);
            // Calcular o numero de projeteis
            int Projectiles = Projectiles_Per_Shot(Arma, Condicoes);
            // Por cada projectil calcular o seu crit e respetivo damage, a quantidade de status aplicada e quantos
            for (int i = 0; i < Projectiles; i++)
            {
                ProjectileResult projectile = new();            // Criar uma instância para guardar as informações sobre o projetil
                double projectileDamage = 0;

                double crit = Crit_Effect(Arma, Condicoes);
                // Guardar o valor do crit no registo
                projectile.CritMultiplier = crit;

                foreach (var dmg in Quantized)
                {
                    projectileDamage += dmg.Value * crit * PartMultiplier;
                }

                //Adicionar o valor total do projetil ao total
                total += projectileDamage;

                // Guardar o valor do dano total do projetil no registo
                projectile.Damage = projectileDamage;

                int status = Status_Amount(Arma, Condicoes);
                Dictionary<DamageType, int> applied = Status_Applied(Arma, status);
                // Guardar o status aplicados pelo projetil no registo
                projectile.StatusApplied = applied;

                // Guardar o registo do projetil no conjunto completo
                result.Projectiles.Add(projectile);
            }

            // Guardar o valor final do dano no conjunto completo
            result.TotalDamage = total;
            return result;
        }
    }
}