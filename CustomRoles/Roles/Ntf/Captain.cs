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

[CustomRole(RoleTypeId.NtfCaptain)]
public class Captain : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 0;

    public StartTeam StartTeam { get; set; } = StartTeam.Ntf;

    public override uint Id { get; set; } = 156;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfCaptain;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfCaptain;
    public override int MaxHealth { get; set; } = 100;
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#bb0601><b>Nine Tailed Fox:</b></color> <color=#f8ce07><b>Captain</b></color><br><i>There has been a containment breach at the site.</i><br><i>Take control of the facility with your army. Use the radio for backup Delta-4 members.</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Name { get; set; } = "Nine-Tailed Fox Captain";
    
    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#f8ce07><b>Special Nine-Tailed Fox Captain</b></color>\r\n";

    public override string CustomInfo { get; set; } = "Nine-Tailed Fox Captain";

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
                Role = RoleTypeId.NtfCaptain,
                Chance = 100,
            },
        },
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.KeycardMTFCaptain.ToString(),
        ItemType.GunFRMG0.ToString(),
        ItemType.GunRevolver.ToString(),
        "Delta-4 Keycard",
        ItemType.ArmorHeavy.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.Radio.ToString(),
        ItemType.GrenadeHE.ToString(),
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato556,
            150
        },
        {
            AmmoType.Ammo44Cal,
            24
        },
    };

}