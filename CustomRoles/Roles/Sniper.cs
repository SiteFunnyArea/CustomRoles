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

[CustomRole(RoleTypeId.NtfPrivate)]
public class Sniper : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 40;

    public StartTeam StartTeam { get; set; } = StartTeam.Ntf;

    public override uint Id { get; set; } = 159;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfPrivate;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfPrivate;

    public override int MaxHealth { get; set; } = 100;
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Nine-Tailed Fox:</b></color> <color=#5fadfa><b>Sniper</b></color><br><i><aussie sounds grow stronger></i><br><i>You spawn with a sniper that blinds people.</i>.",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Name { get; set; } = "Nine-Tailed Fox Sniper";

    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nine-Tailed Fox Sniper</b></color>\r\n";
    public override string CustomInfo { get; set; } = "Nine-Tailed Fox Sniper";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = true;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.GunRevolver.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.Painkillers.ToString(),
        ItemType.Radio.ToString(),
        ItemType.ArmorCombat.ToString(),
        ItemType.KeycardMTFOperative.ToString(),
        "Counter-Insurgency Sniper Rifle",
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Ammo44Cal,
            24
        },
        {
            AmmoType.Nato556,
            40
        },
    };

}