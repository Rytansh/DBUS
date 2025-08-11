using UnityEngine;

public class AttackSystem
{
    public AttackTargetingSystem attackTargetingSystem;
    public AttackSystem()
    {
        attackTargetingSystem = new AttackTargetingSystem();
        attackTargetingSystem.OnTargetSelected += AttackTarget;
    }

    void AttackTarget(RuntimeCard attacker, RuntimeCard target)
    {
        Debug.Log(attacker.full_data.name + " attacks " + target.full_data.name + "!");
    }
}
