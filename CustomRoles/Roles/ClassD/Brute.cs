namespace CustomRoles.Roles;

using CustomRoles.Abilities;
using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.ClassD)]
public class Brute : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 80;
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.ClassD;
    public StartTeam StartTeam { get; set; } = StartTeam.ClassD;

    public bool CooldownActive = false;
    public bool AbilityReady = false;
    
    public override uint Id { get; set; } = 11;

    public override RoleTypeId Role { get; set; } = RoleTypeId.ClassD;

    public override int MaxHealth { get; set; } = 120;

    public override string Name { get; set; } = "<color=#f8b200><b>D-0420 Brute</b></color>";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string Description { get; set; } =
        "The Class D that spawns with some stolen goods and armour from a weak cell guard earlier. Use these items to lead yourself and fellow Class D to victory!";

    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Player.InteractingDoor += InteractingWithGates;
        Exiled.Events.Handlers.Player.TogglingNoClip += NoClipActive;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Player.InteractingDoor -= InteractingWithGates;
        Exiled.Events.Handlers.Player.TogglingNoClip -= NoClipActive;
        base.UnsubscribeEvents();
    }
    public override string CustomInfo { get; set; } = "Brute D-0420";

    public override bool KeepInventoryOnSpawn { get; set; } = false;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };

    public override List<CustomAbility>? CustomAbilities { get; set; } = new() {};

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.Coin}",
        $"{ItemType.Coin}",
        $"{ItemType.ArmorLight}",
        $"{ItemType.KeycardJanitor}",
        $"{ItemType.Flashlight}",
    };

    public override Dictionary<AmmoType, ushort> Ammo { get; set; } = new()
    {
        {
            AmmoType.Nato9,
            30
        },
    };
    protected override void RoleAdded(Player player)
    {

        Timing.CallDelayed(1f, () =>
        {
            player.Scale = new Vector3(1f, 1.1f, 1f);
            Effect e = new Effect();
            e.Type = EffectType.DamageReduction;
            e.Intensity = 15;
            player.EnableEffect(e);

        });

    }
    
    public void NoClipActive(TogglingNoClipEventArgs ev)
    {
        if (!Check(ev.Player))
            return;
        if (CooldownActive)
        {
            ev.Player.ShowHint("<align=center>You can pry open a giant gate in less than 30 seconds.</align>", 5);
            return;
        }
        if (AbilityReady)
        {
            ev.Player.ShowHint("<align=center>You have deactivated the ability to open a giant gate, but you can reactivate it.</align>", 5);

            AbilityReady = false;
            return;
        }
        ev.Player.ShowHint("<align=center>You can now pry open a giant gate.</align>", 5);

        ev.IsAllowed = false;
        AbilityReady = true;
    }
    public void InteractingWithGates(InteractingDoorEventArgs ev)
    {
        
        if (ev.Door.IsGate && Check(ev.Player) && CooldownActive == false && AbilityReady == true)
        {
            Gate g = (Gate)ev.Door;
            if (g.Room.Type == RoomType.Hcz079)
                return;

            g.TryPry(ev.Player);
            CooldownActive = true;
            AbilityReady = false;
            
            Timing.CallDelayed(30f, () =>
            {
                CooldownActive = false;
            });
        }
    }
}