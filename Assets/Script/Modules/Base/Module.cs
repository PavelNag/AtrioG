using UnityEngine;

public abstract class Module : MonoBehaviour
{
    public int strengthModule = 100;
    public int weight = 1;
    public int useEnergy = 1;

    public abstract void DamagableModule(int damage);
    public abstract void DestructionModule();
}
