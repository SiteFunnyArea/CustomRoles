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
public class Bulldozer : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 0;

    public StartTeam StartTeam { get; set; } = StartTeam.Ntf;

    public override uint Id { get; set; } = 158;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfPrivate;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfPrivate;

    public override int MaxHealth { get; set; } = 100;
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Nine-Tailed Fox:</b></color> <color=#5fadfa><b>Bulldozer</b></color><br><i>You are a heavy boi with high explosives.</i><br><i>You spawn with a Impact Grenade and many grenades.</i>.\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Name { get; set; } = "Nine-Tailed Fox Bulldozer";

    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nine-Tailed Fox Bulldozer</b></color>\r\n";
    public override string CustomInfo { get; set; } = "Nine-Tailed Fox Bulldozer";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        RoleSpawnPoints = new List<RoleSpawnPoint>
        {
            new()
            {
                Role = RoleTypeId.NtfPrivate,
                Chance = 100,
            },
        },
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.GunShotgun.ToString(),
        ItemType.ArmorHeavy.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.Radio.ToString(),
        ItemType.KeycardMTFOperative.ToString(),
        ItemType.GrenadeHE.ToString(),
        ItemType.GrenadeHE.ToString(),
        "Impact Grenade",
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Ammo12Gauge,
            24
        },
        {
            AmmoType.Nato9,
            70
        },
    };

}