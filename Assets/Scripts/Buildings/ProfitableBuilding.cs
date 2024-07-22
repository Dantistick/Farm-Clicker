using UnityEngine;

abstract class ProfitableBuilding : MonoBehaviour
{
    [SerializeField] protected OtherBuilding _otherBuilding;

    public abstract void ReceiveProfit();
}