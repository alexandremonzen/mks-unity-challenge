using System;

public interface IDamageable
{
    public event Action<int> OnTookDamage;
    public void TakeDamage(int damageValue);
    public int GetMaxHealth();
}