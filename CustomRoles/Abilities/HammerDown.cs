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
public class HammerDown : PassiveAbility
{
    public override string Name { get; set; } = "Hammer Down";

    public override string Description { get; set; } = "Deals extra damage.";

    [Description("The amount of damage that should be dealt with")]
    public float DamageIncrease { get; set; } = 1.5f;

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
            if (ev.Player.Role.Type.IsHuman() || ev.Player.Role.Type == RoleTypeId.Scp939) {
                ev.Amount = ev.Amount * DamageIncrease;
            }
        }
    }
}