using WFHub.Data;
using WFHub.Models;

namespace WFHub.Services
{
    public class WeaponsService
    {
        // Função generica para atualizar os dados sobre certa arma
        public Weapon ApplyModification ( Weapon arma, WeaponStatsTarget alvo, double value)
        {
            switch (alvo)
            {
                // Stats
                case WeaponStatsTarget.BaseDamage:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                BaseDamage = arma.Stats.Combat.BaseDamage + value
                            }
                        }
                    };
                case WeaponStatsTarget.CritChance:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                CritChance = arma.Stats.Combat.CritChance + value
                            }
                        }
                    };
                case WeaponStatsTarget.CritMultiplier:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                CritMultiplier = arma.Stats.Combat.CritMultiplier + value
                            }
                        }
                    };
                case WeaponStatsTarget.FireRate:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                FireRate = arma.Stats.Combat.FireRate + value
                            }
                        }
                    };
                case WeaponStatsTarget.Multishot:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                Multishot = arma.Stats.Combat.Multishot + value
                            }
                        }
                    };
                case WeaponStatsTarget.StatusChance:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Combat = arma.Stats.Combat with
                            {
                                StatusChance = arma.Stats.Combat.StatusChance + value
                            }
                        }
                    };

                // Economy
                case WeaponStatsTarget.MagazineSize:
                    if (value % 1 != 0)
                    {
                        throw new ArgumentException("Requires a Integer value.");
                    }

                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Economy = arma.Stats.Economy with
                            {
                                MagazineSize = arma.Stats.Economy.MagazineSize + (int)value
                            }
                        }
                    };
                case WeaponStatsTarget.AmmoMax:
                    if (value % 1 != 0)
                    {
                        throw new ArgumentException("Requires a Integer value.");
                    }

                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Economy = arma.Stats.Economy with
                            {
                                AmmoMax = arma.Stats.Economy.AmmoMax + (int)value
                            }
                        }
                    };
                case WeaponStatsTarget.AmmoCost:
                    if (value % 1 != 0)
                    {
                        throw new ArgumentException("Requires a Integer value.");
                    }

                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Economy = arma.Stats.Economy with
                            {
                                AmmoCost = arma.Stats.Economy.AmmoCost + (int)value
                            }
                        }
                    };

                // Handling
                case WeaponStatsTarget.ReloadTime:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Handling = arma.Stats.Handling with
                            {
                                ReloadTime = arma.Stats.Handling.ReloadTime + value
                            }
                        }
                    };

                // Fallof
                case WeaponStatsTarget.MinDistance:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Falloff = arma.Stats.Falloff with
                            {
                                MinDistance = arma.Stats.Falloff.MinDistance + value
                            }
                        }
                    };
                case WeaponStatsTarget.MaxDistance:
                    return arma with
                    {
                        Stats = arma.Stats with
                        {
                            Falloff = arma.Stats.Falloff with
                            {
                                MaxDistance = arma.Stats.Falloff.MaxDistance + value
                            }
                        }
                    };
            }
            return arma;
        }
    }
}
