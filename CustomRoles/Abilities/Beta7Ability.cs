namespace CustomRoles.Abilities;

using System.ComponentModel;
using System.Security.Policy;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features.Attributes;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;
using PlayerRoles;
using PluginAPI.Events;
using UnityEngine;

[CustomAbility]
public class Beta7Ability : PassiveAbility
{
    // Beta-7 Maz Hatters Combatant Ability: damage aura.
    public override string Name { get; set; } = "Beta 7 Ability";
    public override string Description { get; set; } = "Does Beta-7 things.";

    [Description("The amount of damage that should be dealt with (in %)")]
    public float DamageIncrease { get; set; } = 1.4f;
    [Description("The amount of damage that should be dealt with by 049-2 (in %)")]
    public float DamageIncrease0492 { get; set; } = 0.6f;

    protected override void SubscribeEvents()
    {
        Player.Hurting += OnHurting;
        Player.Dying += OnDying;
        Player.ReceivingEffect += ReceivingEffect;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Player.Hurting -= OnHurting;
        Player.Dying -= OnDying;
        Player.ReceivingEffect -= ReceivingEffect;
        base.UnsubscribeEvents();
    }

    private void ReceivingEffect(ReceivingEffectEventArgs ev)
    {
        if (Check(ev.Player))
        {
            if(ev.Effect.GetEffectType() == EffectType.AmnesiaVision || ev.Effect.GetEffectType() == EffectType.AmnesiaItems)
            {
                ev.Effect.IsEnabled = false;
            }
        }
    }
    private void OnHurting(HurtingEventArgs ev)
    {
        if(ev.DamageHandler.Type == DamageType.Scp0492)
        {
            if (Check(ev.Player))
            {
                if (ev.Attacker.Role.Type == RoleTypeId.Scp0492)
                {
                    ev.Amount = ev.Amount * DamageIncrease0492;
                }
            }
        }
        else if (ev.DamageHandler.Type.IsWeapon())
        {
            if (Check(ev.Attacker))
            {
                if (ev.Player.Role.Type == RoleTypeId.Scp0492)
                {
                    ev.Amount = ev.Amount * DamageIncrease;
                }
            }

        }
    }

    private void OnDying(DyingEventArgs ev)
    {
        if (ev.DamageHandler.Type.IsWeapon())
        {
            if (Check(ev.Attacker) && ev.Player.Role.Type == RoleTypeId.Scp0492)
            {
                ev.Attacker.AddAhp(10,75,0);
            }
        }
    }
}