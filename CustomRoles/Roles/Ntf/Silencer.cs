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
public class Silencer : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 100;

    public StartTeam StartTeam { get; set; } = StartTeam.Sergeant;

    public override uint Id { get; set; } = 26;
    public override void AddRole(Player player)
    {
        if (player.Role != Role)
        {
            return;
        }

        base.AddRole(player);
    }
    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSergeant;

    public override int MaxHealth { get; set; } = 100;
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Nine-Tailed Fox:</b></color> <color=#5fadfa><b>Silencer</b></color><br><i>Run around and stun people against their will.</i><br><i>You go a bit faster than most, and spawn with a Stun Gun.</i>.",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };

    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfSergeant;


    public override string Name { get; set; } = "Nine-Tailed Fox Silencer";

    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nine-Tailed Fox Silencer</b></color>";

    public override string CustomInfo { get; set; } = "Nine-Tailed Fox Silencer";

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
        ItemType.GunCrossvec.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.Medkit.ToString(),
        "TG-119",
        ItemType.Radio.ToString(),
        ItemType.KeycardMTFOperative.ToString(),
        ItemType.ArmorCombat.ToString(),
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato9,
            70
        },
        {
            AmmoType.Ammo12Gauge,
            24
        },
    };

    protected override void RoleAdded(Player player)
    {
        player.EnableEffect(Exiled.API.Enums.EffectType.MovementBoost);
        player.ChangeEffectIntensity(Exiled.API.Enums.EffectType.MovementBoost,8);
    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }
}