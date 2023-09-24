namespace CustomRoles.Roles;

using System.Collections.Generic;
using CustomRoles.Abilities;
using CustomRoles.API;

using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

using Player = Exiled.Events.Handlers.Player;

[CustomRole(RoleTypeId.NtfPrivate)]
public class Medic : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 0;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.NtfPrivate;

    public StartTeam StartTeam { get; set; } = StartTeam.Ntf;

    public override uint Id { get; set; } = 25;
    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override RoleTypeId Role { get; set; } = RoleTypeId.NtfPrivate;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "Nine-Tailed Fox Medic";

    public override string Description { get; set; } =
        "You have spawned as a custom class.<br><color=#71afff><b>Nine-Tailed Fox Medic</b></color><br><color=#ffed00><i>Do \".cmdbind [key] .special to use it.\"</i></color>";

    public override string CustomInfo { get; set; } = "Nine-Tailed Fox Medic";
    public override Broadcast Broadcast { get; set; } = new Broadcast()
    {
        Content = "<b>You have spawned as</b> <color=#7ec6fe><b>Nine-Tailed Fox:</b></color> <color=#5fadfa><b>Medic</b></color><br><i>Top tier medic gameplay.</i><br><i>You spawn with a medical gun and can toggle a healing mist.</i>.",
        Duration = 10,
        Show = true,
        Type = global::Broadcast.BroadcastFlags.Normal,
    };
    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.GunCrossvec}",
        "MG-119",
        $"{ItemType.Medkit}",
        $"{ItemType.Medkit}",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.ArmorCombat}",
        $"{ItemType.KeycardMTFOperative}",
    };

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

    public override List<CustomAbility>? CustomAbilities { get; set; } = new()
    {
        new HealingMist(),
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