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
public class Spy : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 35;

    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public override uint Id { get; set; } = 2009;
    public bool Cooldown;
    public override RoleTypeId Role { get; set; } = RoleTypeId.ChaosConscript;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#28962b><b>Chaos Insurgent Spy</b></color>";
    public override string Description { get; set; } =
        "You spawn with a <color=#FFEA00>device that can change your appearance.</color> By hitting <color=#FFEA00>alt (no-clip key)</color>, you can pick what form you want to take, then <color=#FFEA00>drop it to take that form</color>. There is a cooldown on the item, use it wisely.";
    public override string CustomInfo { get; set; } = "Spy";

    public override bool KeepInventoryOnSpawn { get; set; } = false;
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;
    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    protected override void SubscribeEvents()
    {
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();
    }

    public override List<string> Inventory { get; set; } = new()
    {
        "Spy Device",
        ItemType.Flashlight.ToString(),
        ItemType.Coin.ToString(),
    };
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;

    protected override void RoleAdded(Player player)
    {
        player.Teleport(Room.Get(RoomType.LczClassDSpawn));
    }

    protected override void RoleRemoved(Player player)
    {

    }

    protected override void ShowMessage(Player player)
    {

        base.ShowMessage(player);
    }

    public void NoClip(TogglingNoClipEventArgs ev)
    {

    }
}