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
public class ContainmentEngineer : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.Scientist;
    public StartTeam StartTeam { get; set; } = StartTeam.Scientist;

    public override uint Id { get; set; } = 2500;

    public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;

    public override int MaxHealth { get; set; } = 110;

    public override string Name { get; set; } = "<color=#FAFF86><b>Scientist Containment Engineer</b></color>";
    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>SCP 268-TP</color> and <color=#FFEA00>SCP 127-HP</color>. These modified SCP specialize in both situations of combat and quick escape. \r\n>";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string CustomInfo { get; set; } = "Containment Engineer";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        RoleSpawnPoints = new List<RoleSpawnPoint>()
        {
            new(){
                Chance = 100,
                Role = RoleTypeId.Scientist,
            }
        }
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.KeycardContainmentEngineer}",
        $"SCP 268-TP",
        $"SCP 127-HP",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.Coin}",

    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {AmmoType.Nato9, 25},


    };

    protected override void RoleAdded(Player player)
    {
        
    }

    protected override void RoleRemoved(Player player)
    {
        player.DisableAllEffects();
    }

}