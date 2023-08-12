
public class DriveModule : Module
{
    public override void DamagableModule(int damage)
    {
        if (strengthModule - damage > 0) strengthModule -= damage;
        else DestructionModule();
    }

    public override void DestructionModule()
    {
        print($"Мудуль |{this.name}| разрушен!");
    }
}



