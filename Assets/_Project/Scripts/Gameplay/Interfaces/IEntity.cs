using UnityEngine;

public interface IEntity
{
    public Team Team { get; }
    public Rigidbody2D Rb { get; }
}

public interface IDamageable
{
    public void TakeDamage(float damage);
}

public interface IAttack
{
    public IDamageable ClosestDamageableTarget { get; set; }
}

public interface ITroop : IEntity
{
    public string OpponentTag { get; }
    public Transform ClosestTarget { get; set; }
}