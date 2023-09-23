namespace CustomRoles.Roles;

using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
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
public class FlashlightMan : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 15;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.None;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 6545;

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;

    public override int MaxHealth { get; set; } = 120;

    public override string Name { get; set; } = "Flashlight Man";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "holy shit, you're flashlight man.",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "yes";

    public override string CustomInfo { get; set; } = "Flashlight Man";

    public override bool KeepInventoryOnSpawn { get; set; } = true;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Flashlight}",
    };
    protected override void RoleAdded(Player player)
    {

    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}