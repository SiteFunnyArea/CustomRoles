namespace CustomRoles.Roles;

using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;

using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ClassD)]
public class Labrat : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 90;

    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 2002;

    public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#f8b200><b>D-9341 Labrat</b></color>";
    public CoroutineHandle effectGiveThing;
    public override string Description { get; set; } =
        "The Class D that has been through hell. You gain random effects due to the long last side effects of the tests you went through. You managed to sneak an injection away with you though.";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string CustomInfo { get; set; } = "Labrat D-9341";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.Painkillers.ToString(),
        "Injection-TP",
        ItemType.Coin.ToString(),
        ItemType.Flashlight.ToString(),

    };
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;

    protected override void RoleAdded(Player player)
    {
        //Timing.CallDelayed(2.5f, () => player.Scale = new Vector3(0.75f, 0.75f, 0.75f));
        //player.IsUsingStamina = false;
        effectGiveThing = Timing.RunCoroutine(EffectGiverThing(player));
    }

    protected override void RoleRemoved(Player player)
    {
        // player.IsUsingStamina = true;
        // player.Scale = Vector3.one;
        if (effectGiveThing.IsRunning)
            Timing.KillCoroutines(effectGiveThing);


    }

    public IEnumerator<float> EffectGiverThing(Player p)
    {
        while (true)
        {
            float duration = UnityEngine.Random.Range(24f, 47f);
            yield return Timing.WaitForSeconds(duration);
            float ran = UnityEngine.Random.Range(0f, 101f);

            if(ran <= 12.5f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Invisible, 7f);
            }else if (ran <= 25f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.SugarRush, 7f);
            }
            else if (ran <= 37.5f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Metal, 7f);
            }
            else if (ran <= 50f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Invigorated, 7f);
                
            }
            else if (ran <= 62.5f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.OrangeCandy, 7f);
            }
            else if (ran <= 75f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Scp207, 7f);
            }
            else if (ran <= 87.5f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.AntiScp207, 7f);
            }
            else if (ran <= 101f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.RainbowTaste, 7f);
            }
        }
    }
}