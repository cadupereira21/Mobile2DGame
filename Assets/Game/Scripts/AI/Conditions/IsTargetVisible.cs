using BBUnity.Conditions;
using Pada1.BBCore;
using Pada1.BBCore.Framework;
using Pada1.BBCore.Tasks;
using UnityEngine;

[Condition("Game/Perception/IsTargetVisible")]
public class IsTargetVisible : GOCondition
{
    [InParam("Target")]
    private GameObject target;

    [InParam("AIVision")]
    private AIVision aiVision;

    [InParam("TargetMemoryDuration")]
    private float targetMemoryDuration;

    private float forgetTargetTime;

    public override bool Check()
    {
        bool isAvailable = IsAvailabe();
        if (aiVision.IsVisible(target) && isAvailable)
        {
            forgetTargetTime = Time.time + targetMemoryDuration;
            return true;
        }
        return Time.time < forgetTargetTime && isAvailable;
    }

    private bool IsAvailabe()
    {
        if (target == null)
        {
            return false;
        }

        // TODO: Não chamar GetComponent no Update
        IDamageable damageable = target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            //Caso nosso player não esteja morto, ele estará
            //disponível
            return !damageable.IsDead;
        }
        return true;
    }
}
