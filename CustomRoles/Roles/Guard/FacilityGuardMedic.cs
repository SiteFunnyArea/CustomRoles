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
public class FacilityGuardMedic : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 75;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.FacilityGuard;

    public StartTeam StartTeam { get; set; } = StartTeam.Guard;
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override uint Id { get; set; } = 2512;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 110;

    public override string Name { get; set; } = "<color=#727472><b>Facility Guard Medic</b></color>";

    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>Standard Medic Gun</color> that can heal zombies back to the <color=#005EBC>Foundation Team</color>. As well as some extra <color=#FFEA00>Medical Gear.</color>";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string CustomInfo { get; set; } = "Medic";

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.GunFSP9}",
        "Standard Medic Gun",
        $"{ItemType.Medkit}",
        $"{ItemType.Medkit}",
        $"Injection-HP",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.KeycardGuard}",
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
            AmmoType.Nato9,
            60
        },
    };
    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        //new HealingMist(),
    };

    protected override void SubscribeEvents()
    {
        Log.Debug($"{nameof(SubscribeEvents)}: Loading medic events..");
        Player.PickingUpItem += OnPickingUpItem;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Log.Debug($"{nameof(UnsubscribeEvents)}: Unloading medic events..");
        Player.PickingUpItem -= OnPickingUpItem;
        base.UnsubscribeEvents();
    }

    private void OnPickingUpItem(PickingUpItemEventArgs ev)
    {
        if (!Check(ev.Player))
            return;

        CustomItem? item = CustomItem.Get("MG-119");
        if (item == null)
            return;
        if (ev.Pickup.Type == item.Type)
        {
            ev.Player.ShowHint("You are not able to pick up this item, because it is of the same type as mediguns.");
            ev.IsAllowed = false;
        }
    }
}