using System.Collections.Generic;

public class BodyModule : Module
{
    public override void DamagableModule(int damage)
    {
        if (strengthModule - damage > 0) strengthModule -= damage;
        else DestructionModule();
    }

    public override void DestructionModule()
    {
        print($"Основной модуль |{this.name}| разрушен!");
    }
}
