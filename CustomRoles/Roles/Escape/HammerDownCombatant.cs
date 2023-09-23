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
public class HammerDownCombatant : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 75;

    public StartTeam StartTeam { get; set; } = StartTeam.Escape;

    public override uint Id { get; set; } = 150;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfSpecialist;

    public override int MaxHealth { get; set; } = 100;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfSpecialist;

    public override string Name { get; set; } = "Nu-7 Hammer Down Combatant";

    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Combatant Operative:</b></color> <color=#5fadfa><b>Nu-7 Hammer Down</b></color><br><i>The big guns has arrived to secure the facility.</i><br><i>You deal extra damage to Humans and </i><color=#b71508><b>SCP 939</b></color>.\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nu7 - Hammer Down</b></color>\r\n";

    public override string CustomInfo { get; set; } = "Nu-7 Hammer Down Combatant";

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
        ItemType.GunLogicer.ToString(),
        ItemType.GunShotgun.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.Medkit.ToString(),
        ItemType.ArmorHeavy.ToString(),
        ItemType.GrenadeHE.ToString(),
        ItemType.KeycardMTFOperative.ToString(),
        ItemType.Radio.ToString(),
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato762,
            150
        },
        {
            AmmoType.Ammo12Gauge,
            36
        },
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        new HammerDown(),
    };

    protected override void RoleAdded(Player player)
    {
        
        player.HumeShield = 75f;
        player.EnableEffect(Exiled.API.Enums.EffectType.Disabled);
    }

    protected override void RoleRemoved(Player player)
    {
        player.HumeShield = 0f;
        player.DisableAllEffects();
    }

}