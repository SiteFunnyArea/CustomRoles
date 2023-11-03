namespace CustomRoles.Roles;

using System.Collections.Generic;
using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

using Player = Exiled.Events.Handlers.Player;

[CustomRole(RoleTypeId.FacilityGuard)]
public class FacilityGuardSupervisor : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 100;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.FacilityGuard;

    public StartTeam StartTeam { get; set; } = StartTeam.Guard;
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override uint Id { get; set; } = 2513;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 120;

    public override string Name { get; set; } = "<color=#727472><b>Facility Guard Supervisor</b></color>";

    public override string Description { get; set; } =
        "You spawn with <color=#FFEA00>extra weapons</color> and <color=#FFEA00>extra HP</color>. Lead your Facility Guard team to victory and wait for <color=#960018>RRT</color> or <color=#005EBC>MTF</color>.";
    public override string CustomInfo { get; set; } = "Supervisor";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.GunE11SR}",
        $"{ItemType.ArmorCombat}",
        $"{ItemType.Medkit}",
        $"{ItemType.KeycardMTFPrivate}",
        $"{ItemType.GrenadeFlash}",
        $"{ItemType.Radio}",
        $"{ItemType.GunCOM15}",

    };

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        RoleSpawnPoints = new List<RoleSpawnPoint>
        {
            new()
            {
                Role = RoleTypeId.FacilityGuard,
                Chance = 100,
            },
        },
    };
    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato556,
            45
        },
    };
    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        //new HealingMist(),
    };
}