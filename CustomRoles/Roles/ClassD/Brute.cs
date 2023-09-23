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
public class Brute : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 60;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.None;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 645;

    public override RoleTypeId Role { get; set; } = RoleTypeId.None;

    public override int MaxHealth { get; set; } = 120;

    public override string Name { get; set; } = "Brute";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#EE7600><b>Class D Personnel:</b></color> <color=#2bad33><b>Brute</b></color><br><i>There has been a containment breach at the site.</i><br><i>Lead the D-Boi army out of the facility!</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "<color=#2bad33><b>Brute</b></color>";

    public override string CustomInfo { get; set; } = "Brute";

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
        "Makeshit COM-10",
        $"{ItemType.Coin}",
        $"{ItemType.Coin}",
        $"{ItemType.Coin}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.KeycardJanitor}",
        $"{ItemType.Painkillers}",

    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato9,
            30
        },
    };
    protected override void RoleAdded(Player player)
    {
        Effect e = new Effect();
        e.Type = Exiled.API.Enums.EffectType.DamageReduction;
        e.Intensity = 2;
        player.EnableEffect(e);
    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}