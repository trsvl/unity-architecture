using UnityEngine;

public interface IDamageable
{
    public Collider2D Collider { get; }
    public void TakeDamage(float damage);
}