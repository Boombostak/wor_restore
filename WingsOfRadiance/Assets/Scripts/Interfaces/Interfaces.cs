using UnityEngine;
using System.Collections;

public interface IDestructible
{
    void DestroyThis();
}

public interface IDamageable
{
    void DamageThis(int damage_dealt);
}

public interface ISelfHealing
{
    void HealSelf(int hp_healed);
}