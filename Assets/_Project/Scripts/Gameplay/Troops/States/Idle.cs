using _Project.Scripts.Gameplay.Troops.Base;

namespace _Project.Scripts.Gameplay.Troops
{
    public class Idle : TroopStateNode
    {
        public Idle(IAnimationListener animationListener, TroopBase troop) : base(
            animationListener, troop)
        {
        }
    }
}