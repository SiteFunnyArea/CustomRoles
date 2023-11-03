namespace CustomRoles.Roles;

using CustomRoles.API;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Scp330;
using MEC;
using PlayerRoles;
using System.Collections.Generic;
using UnityEngine;

[CustomRole(RoleTypeId.Scientist)]
public class Candyman : CustomRole, ICustomRole
{
    public int Chance { get; set; } = 90;

    public StartTeam StartTeam { get; set; } = StartTeam.Scientist;

    public override uint Id { get; set; } = 2557;

    public override RoleTypeId Role { get; set; } = RoleTypeId.Scientist;

    public override int MaxHealth { get; set; } = 100;

    public override string Name { get; set; } = "<color=#FAFF86><b>Scientist Candyman</b></color>";
    public CoroutineHandle effectGiveThing;
    public override string Description { get; set; } =
        "You spawn with <color=#FFEA00>2 random candies</color>, <color=#FFEA00>Infinite Sprint</color>, and can take three candies from <color=#FFEA00>SCP 330</color> bowl.";
    public override bool DisplayCustomItemMessages { get; set; } = false;

    public override string CustomInfo { get; set; } = "Candyman";

    public override bool KeepInventoryOnSpawn { get; set; } = true;

    public override bool KeepRoleOnDeath { get; set; } = false;

    public override bool RemovalKillsPlayer { get; set; } = false;

    public override SpawnProperties SpawnProperties { get; set; } = new()
    {
        Limit = 1,
    };
    protected override void SubscribeEvents()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 += OnCandyAdded;
        base.SubscribeEvents();
    }
    protected override void UnsubscribeEvents()
    {
        Exiled.Events.Handlers.Scp330.InteractingScp330 -= OnCandyAdded;
        base.SubscribeEvents();
    }

    public override List<string> Inventory { get; set; } = new()
    {
        $"{ItemType.KeycardZoneManager}",
        $"{ItemType.Medkit}",
        $"{ItemType.Radio}",
        $"{ItemType.Flashlight}",
        $"{ItemType.Coin}",
        $"{ItemType.SCP2176}",


    };
    public void OnCandyAdded(InteractingScp330EventArgs ev)
    {
        if (Check(ev.Player))
        {
            if (ev.UsageCount <= 3)
            {
                ev.ShouldSever = false;
            }
            else if (ev.UsageCount > 3)
            {
                ev.ShouldSever = true;
            }
        }
    }
    public RoleTypeId RoleToBe { get; set; } = RoleTypeId.Scientist;

    protected override void RoleAdded(Player player)
    {
        effectGiveThing = Timing.RunCoroutine(EffectGiverThing(player));

            player.AddItem(ItemType.SCP330);
            for(int i = 0; i < 2; i++)
            {
                float ran = UnityEngine.Random.Range(1, 14);
                if(ran == 1)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Rainbow);

                }else if (ran == 2)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Yellow);

                }else if (ran == 3)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Purple);

                }else if (ran == 4)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Red);

                }
                else if (ran == 5)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Green);

                }
                else if (ran == 6)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Blue);

                }
                else if (ran == 7)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Pink);

                }
                else if (ran == 8)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Orange);

                }
                else if (ran == 9)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.White);

                }
                else if (ran == 10)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Gray);

                }
                else if (ran == 11)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Black);

                }
                else if (ran == 12)
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Brown);

                }
                else
                {
                    player.TryAddCandy(InventorySystem.Items.Usables.Scp330.CandyKindID.Evil);

                }
            }
        player.IsUsingStamina = false;
    }

    protected override void RoleRemoved(Player player)
    {
         player.IsUsingStamina = true;
         player.Scale = Vector3.one;
        if (effectGiveThing.IsRunning)
            Timing.KillCoroutines(effectGiveThing);


    }

    public IEnumerator<float> EffectGiverThing(Player p)
    {
        while (true)
        {
            float duration = UnityEngine.Random.Range(26f, 36f);
            yield return Timing.WaitForSeconds(duration);
            float ran = UnityEngine.Random.Range(0f, 101f);

            if(ran <= 16.66666667f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.SugarRush, 5f);
            }else if (ran <= 33.33333334f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.SugarHigh, 5f);
            }
            else if (ran <= 50.00000001f)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.OrangeCandy, 5f);
            }
            else if (ran <= 66.66666668)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Ghostly, 5f);
                
            }
            else if (ran <= 83.33333335)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Metal, 5f);
            }
            else if (ran <= 100)
            {
                p.EnableEffect(Exiled.API.Enums.EffectType.Spicy, 5f);
            }
        }
    }
}