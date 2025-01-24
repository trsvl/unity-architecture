public interface IDamageable
{
    public Team Team { get; }
    public void TakeDamage(float damage);
}

public enum Team
{
    Player,
    Enemy
}