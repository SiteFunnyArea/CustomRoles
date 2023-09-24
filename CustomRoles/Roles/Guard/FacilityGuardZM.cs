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
public class FacilityGuardZM : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 40;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.FacilityGuard;

    public StartTeam StartTeam { get; set; } = StartTeam.Guard;
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override uint Id { get; set; } = 20;

    public override RoleTypeId Role { get; set; } = RoleTypeId.FacilityGuard;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Facility Guard Zone Manager";

    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nine-Tailed Fox Medic</b></color><br><color=#ffed00><i>Do \".cmdbind [key] .special to use it.\"</i></color>";

    public override string CustomInfo { get; set; } = "Facility Guard Zone Manager";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "You have been spawned in as <color=#727472><b>Facility Guard:</b></color> <color=#2bad33><b>Zone Manager</b></color><br><i>There has been a containment breach at the site.</i><br><i>Keep the Class D Personnel controlled and help the researchers.</i>\r\n",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override List<string> Inventory { get; set; } = new()
    {
        "Stun Gun",
        $"{ItemType.Painkillers}",
        $"{ItemType.Coin}",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.KeycardZoneManager}",
    };
    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato9,
            60
        },
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