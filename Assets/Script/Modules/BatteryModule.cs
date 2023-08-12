using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryModule : Module
{
    public int maxEnergy = 1000;
    private int _currentEnergy;

    public int CurrentEnergy { get => _currentEnergy; set => _currentEnergy = value; }

    public override void DamagableModule(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void DestructionModule()
    {
        throw new System.NotImplementedException();
    }
}
