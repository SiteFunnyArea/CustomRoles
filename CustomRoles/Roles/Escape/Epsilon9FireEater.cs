namespace CustomRoles.Roles;

using CustomRoles.Abilities;
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

[CustomRole(RoleTypeId.NtfSpecialist)]
public class Epsilon9FireEater : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 75;

    public StartTeam StartTeam { get; set; } = StartTeam.Escape;

    public override uint Id { get; set; } = 15;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfSpecialist;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSpecialist;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Epsilon-9 Fire Eaters Combatant";

    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Combatant Operative:</b></color> <color=#6f34ff><b>Epsilon-9 Fire Eaters</b></color><br><i>Hard to contain SCPs or Insurgency? Let's burn em down.</i><br><i>You deal Burned effect damage to whoever you damage.</i>.\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Epsilon-9 Fire Eaters</b></color>\r\n";

    public override string CustomInfo { get; set; } = "Epsilon-9 Fire Eaters Combatant";

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
                Role = RoleTypeId.NtfSpecialist,
                Chance = 100,
            },
        },
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.GunE11SR.ToString(),
        "Crowd Control Napalm",
        ItemType.Medkit.ToString(),
        ItemType.Flashlight.ToString(),
        ItemType.ArmorCombat.ToString(),
        ItemType.Radio.ToString(),
        ItemType.KeycardMTFOperative.ToString(),
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato556,
            90
        },
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        new Burns(),
    };
}