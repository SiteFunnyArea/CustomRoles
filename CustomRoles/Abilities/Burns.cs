namespace CustomRoles.Abilities;

using System.ComponentModel;
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features.Attributes;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using PlayerRoles;

[CustomAbility]
public class Burns : PassiveAbility
{
    public override string Name { get; set; } = "Burns";

    public override string Description { get; set; } = "Deals Burned effect damage to all classes from any weapon.";

    [Description("The duration the Burned effect should last for (in %).")]
    public float Duration { get; set; } = 1.5f;

    protected override void SubscribeEvents()
    {
        Player.Hurting += OnHurting;
        base.SubscribeEvents();
    }

    protected override void UnsubscribeEvents()
    {
        Player.Hurting -= OnHurting;
        base.UnsubscribeEvents();
    }

    private void OnHurting(HurtingEventArgs ev)
    {
        if (Check(ev.Attacker))
        {
            if (ev.Player.Role.IsAlive) {
                ev.Player.EnableEffect(EffectType.Burned, 15);
            }
        }
    }
}