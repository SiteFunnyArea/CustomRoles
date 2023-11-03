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

[CustomRole(RoleTypeId.Scientist)]
public class ZoneManager : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.Scientist;
    public StartTeam StartTeam { get; set; } = StartTeam.Scientist;

    public override uint Id { get; set; } = 2502;

    public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;

    public override int MaxHealth { get; set; } = 110;

    public override string Name { get; set; } = "<color=#FAFF86><b>Scientist Weapons Researcher</b></color>";
    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>Crowd Control Napalm</color> grenade, <color=#FFEA00>Injection-R</color> and <color=#FFEA00>SCP-127</color>. This class specializes in combat and prioritizes in terminating hostile threats.";
    
    public override string CustomInfo { get; set; } = "Weapons Researcher";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        DynamicSpawnPoints = new List<DynamicSpawnPoint>()
        {
            new()
            {
                Location = SpawnLocationType.InsideNukeArmory,
                Chance = 100,
            }
        }
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override List<string> Inventory { get; set; } = new()
    {
        $"SCP 127",
        $"Injection-R",
        $"Crowd Control Napalm",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.KeycardGuard}",
        $"{ItemType.ArmorCombat}",

    };
    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {AmmoType.Nato9, 45},


    };
    protected override void RoleAdded(Player player)
    {

    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}