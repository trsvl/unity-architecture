using UnityEngine;

public interface ITroop : IEntity
{
    public string OpponentTag { get; }
    public Transform ClosestTarget { get; set; }
}