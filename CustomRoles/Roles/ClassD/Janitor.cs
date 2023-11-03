namespace CustomRoles.Roles;

using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Hazards;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ClassD)]
public class Janitor : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 90;

    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 2003;
    public bool Cooldown;
    public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#f8b200><b>D-Janitor</b></color>";
    public override string Description { get; set; } =
        "The Class D that has been through a bunch of hard work. A containment breach arises and the only thing you got is a janitor keycard. Good luck champ!";
    public override string CustomInfo { get; set; } = "Janitor";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;
    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.TogglingNoClip += NoClip;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.TogglingNoClip -= NoClip;
        base.UnsubscribeEvents();
    }

    public override List<string> Inventory { get; set; } = new()
    {
        ItemType.KeycardJanitor.ToString(),
        ItemType.Flashlight.ToString(),
        ItemType.Coin.ToString(),
        ItemType.Coin.ToString(),
        ItemType.Painkillers.ToString(),

    };
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;

    protected override void RoleAdded(Player player)
    {
        player.Teleport(Room.Get(RoomType.LczToilets));
        
    }

    protected override void RoleRemoved(Player player)
    {
        
    }

    public void NoClip(TogglingNoClipEventArgs ev)
    {
        if (!Check(ev.Player))
            return;
        if (Cooldown == true)
        {
            ev.Player.ShowHint("<align=center>Ability: Clean Up on Cooldown</align>", 5f);
            return;
        }
        ev.IsAllowed = false;
        Cooldown = true;
        ev.Player.ShowHint("<align=center>Ability: Cleaning Up</align>", 5f);
        RemoveTantrum(ev.Player.CurrentRoom);
        Timing.CallDelayed(30f, () =>
        {
            ev.Player.ShowHint("<align=center>Ability: Clean Up Ready</align>", 5f);
            Cooldown = false;
        });
    }

    public void RemoveTantrum(Room room)
    {
        foreach(TantrumHazard t in Hazard.List)
        {
            if(t.Room == room)
            {
                t.Destroy();
            }
        }
    }
}