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

    public override uint Id { get; set; } = 19;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Facility Guard Supervisor";

    public override string Description { get; set; } =
        "<color=#2bad33><b>Supervisor</b></color>";
    public override string CustomInfo { get; set; } = "Facility Guard Supervisor";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#727472><b>Facility Guard:</b></color> <color=#2bad33><b>Gunslinger</b></color><br><i>There has been a containment breach at the site.</i><br><i>Provide combative support with all your fine weaponry.</i>\r\n[4:27 PM]\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
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