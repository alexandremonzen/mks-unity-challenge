using System;

public interface IDamageable
{
    public event Action<int> OnTookDamage;
    public void TakeDamage(int damageValue, Team teamSide);
    public int GetMaxHealth();
    public Team GetTeamSide();
}