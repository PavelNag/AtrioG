using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesManager : MonoBehaviour
{
    private int _totalWeight;
    private int _totalUseEnergy;

    private BodyModule bodyModule;
    private BatteryModule batteryModule;

    private List<Module> otherModule = new List<Module>();
    private List<DriveModule> driveModule = new List<DriveModule>();

    public int TotalWeight { get => _totalWeight; set => _totalWeight = value; }
    public int TotalUseEnergy { get => _totalUseEnergy; set => _totalUseEnergy = value; }
    public BodyModule BodyModule { get => bodyModule; set => bodyModule = value; }
    public BatteryModule BatteryModule { get => batteryModule; set => batteryModule = value; }
    public List<DriveModule> DriveModule { get => driveModule; set => driveModule = value; }
    public List<Module> OtherModule { get => otherModule; set => otherModule = value; }

    private void Start()
    {
        RefrashAllModule();
        CalculateTotalWeight();
    }
    public void RefrashAllModule()
    {
        TotalWeight = 0;
        BodyModule = null;
        BatteryModule = null;
        DriveModule.Clear();
        OtherModule.Clear();
        //-----------------------------
        BodyModule = GetComponentInChildren<BodyModule>();
        BatteryModule = GetComponentInChildren<BatteryModule>();
        foreach (DriveModule module in GetComponentsInChildren<DriveModule>()) DriveModule.Add(module);
        foreach (Module module in GetComponentsInChildren<Module>()) if(!OtherModule.Contains(module)) OtherModule.Add(module);
    }

    private void CalculateTotalWeight()
    {
        foreach (Module module in GetComponentsInChildren<Module>()) _totalWeight += module.weight; 
    }
}
