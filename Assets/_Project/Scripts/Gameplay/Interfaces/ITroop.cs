using UnityEngine;

public interface ITroop
{
    public Team Team { get; }
    public string OpponentTag { get; }
    public Rigidbody2D Rb { get; }
    public Transform ClosestTarget { get; set; }
}

public interface IDamageable
{
    public void TakeDamage(float damage);
}

public interface IAttack
{
    public IDamageable ClosestDamageableTarget { get; set; }
}

public interface IMove
{
    public float MoveSpeed { get; set; }
}

public interface IChase
{
    public void DoChase();
}