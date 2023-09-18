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
public class Beta7MazHattersCombatant : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 75;

    public StartTeam StartTeam { get; set; } = StartTeam.Escape;

    public override uint Id { get; set; } = 152;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSpecialist;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Beta-7 Maz Hatters Combatant";

    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Combatant Operative:</b></color> <color=#6f34ff><b>Beta-7 Maz Hatters</b></color><br><i>We have some infections roaming about. You got the gear for it.</i><br><i>You are immune to most effects, deal extra damage to</i><color=#b71508><b>SCP 049-2</b></color><i>, and have a gas aura.</i>.",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Beta-7 Maz Hatters</b></color>\r\n";

    public override string CustomInfo { get; set; } = "Beta-7 Maz Hatters Combatant";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.GunCrossvec.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.SCP500.ToString(),
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
        new Beta7Ability(),
    };
}