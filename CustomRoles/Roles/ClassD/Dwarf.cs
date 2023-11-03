namespace CustomRoles.Roles;

using CustomRoles.Abilities;
using CustomRoles.API;

using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ClassD)]
public class Dwarf : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 90;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 10;

    public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    public override int MaxHealth { get; set; } = 80;

    public override string Name { get; set; } = "<color=#f8b200><b>D-0343 Dwarf</b></color>";

    public override string Description { get; set; } =
        "The Class D that is the youngest of em all. You are smaller and not as strong as the others, though you can take extra candy from <color=#FFEA00>SCP 330</color>, and have <color=#FFEA00>Infinite Sprint</color>!";

    public override string CustomInfo { get; set; } = "Dwarf D-0343";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    protected override void RoleAdded(Player player)
    {
        Timing.CallDelayed(2.5f, () => player.Scale = new Vector3(0.75f, 0.75f, 0.75f));
        player.IsUsingStamina = false;
    }

    protected override void RoleRemoved(Player player)
    {
        player.IsUsingStamina = true;
        player.Scale = Vector3.one;
    }

    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 += OnCandyAdded;
        base.SubscribeEvents();
    }
    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 -= OnCandyAdded;
        base.SubscribeEvents();
    }
    public void OnCandyAdded(InteractingScp330EventArgs ev)
    {
        if (Check(ev.Player))
        {
            if(ev.UsageCount <= 3)
            {
                ev.ShouldSever = false;
            }else if(ev.UsageCount > 3)
            {
                ev.ShouldSever = true;
            }
        }
    }
}