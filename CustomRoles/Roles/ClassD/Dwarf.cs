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

[CustomRole(RoleTypeId.None)]
public class Dwarf : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 40;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.None;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 5;

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;

    public override int MaxHealth { get; set; } = 80;

    public override string Name { get; set; } = "Dwarf";

    public override string Description { get; set; } =
        "A normal player who has unlimited stamina, and is slightly smaller than normal.";

    public override string CustomInfo { get; set; } = "Dwarf";

    public override bool KeepInventoryOnSpawn { get; set; } = true;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};
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
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#EE7600><b>Class D Personnel:</b></color> <color=#2bad33><b>Dwarf</b></color><br><i>There has been a containment breach at the site.</i><br><i>You can get extra candy at the candy bowl. :p</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
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