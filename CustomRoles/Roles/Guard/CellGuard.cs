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
public class CellGuard : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 40;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.FacilityGuard;

    public StartTeam StartTeam { get; set; } = StartTeam.Guard;
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override uint Id { get; set; } = 2510;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#727472><b>Facility Guard Cell Guard</b></color>";

    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>Standard Stun Gun</color> and <color=#FFEA00>Standard Stun Baton</color> that can blind any hostiles and slow them down. Though it only deals <color=#FFEA00>5 Damage</color>, so do not use this for heavy combat.";

    public override string CustomInfo { get; set; } = "Cell Guard";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override List<string> Inventory { get; set; } = new()
    {
        "Standard Stun Baton",
        $"Standard Stun Gun",
        $"{ItemType.Medkit}",
        $"{ItemType.Painkillers}",
        $"{ItemType.KeycardZoneManager}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.Radio}",
    };
    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Ammo44Cal,
            6
        },
    };
    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
        RoleSpawnPoints = new List<RoleSpawnPoint>
        {
        },
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        //new HealingMist(),
    };

    protected override void RoleAdded(Exiled.API.Features.Player player)
    {
        player.Teleport(Room.Get(RoomType.LczCheckpointA));
    }
}