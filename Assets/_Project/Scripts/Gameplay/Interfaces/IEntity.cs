using UnityEngine;

public interface IEntity
{
    public Team Team { get; }
    public Rigidbody2D Rb { get; }
}