namespace CustomRoles.Roles;

using CustomRoles.API;

using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;

using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ClassD)]
public class Sprinter : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;

    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 2000;

    public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#f8b200><b>D-4830 Sprinter</b></color>";

    public override string Description { get; set; } =
        "The Class D that spawns with extra <color=#FFEA00>Movement Boost</color> and 50 whole cents! Make good use with this gift as a D-Boi.";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string CustomInfo { get; set; } = "Sprinter D-4830";
    
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;
    
    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.Coin.ToString(),
        ItemType.Coin.ToString(),
        ItemType.Flashlight.ToString(),

    };
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;

    protected override void RoleAdded(Player player)
    {
        base.RoleAdded(player);
        Timing.CallDelayed(1f, () =>
        {
            Effect e = new Effect();
            e.Type = Exiled.API.Enums.EffectType.MovementBoost;
            e.Intensity = 16;
            e.Duration = 0;
            e.IsEnabled = true;
            player.EnableEffect(e);


        });

    }

    protected override void RoleRemoved(Player player)
    {
    }
}