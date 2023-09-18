namespace CustomRoles.Roles;

using CustomRoles.API;

using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;

using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.None)]
public class Template : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 0;

    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 9000;

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Test";

    public override string Description { get; set; } =
        "Test";

    public override string CustomInfo { get; set; } = "Test";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.AntiSCP207.ToString(),
    };

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
}