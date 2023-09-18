namespace CustomRoles.Abilities;

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.CustomRoles.API.Features;
using MEC;

[CustomAbility]
public class HealingMist : PassiveAbility
{
    private readonly List<CoroutineHandle> coroutines = new ();

    public override string Name { get; set; } = "Healing Mist";

    public override string Description { get; set; } =
        "Activates a short-term spray of chemicals which will heal and protect allies.";

    public float Seconds { get; set; } = 10;

    [Description("The amount healed every second the ability is active.")]
    public float HealAmount { get; set; } = 6;

    protected override void AbilityAdded(Player player)
    {
        ActivateMist(player);
        base.AbilityAdded(player);
    }

    protected override void UnsubscribeEvents()
    {
        foreach (CoroutineHandle handle in coroutines)
            Timing.KillCoroutines(handle);
        base.UnsubscribeEvents();
    }

    private void ActivateMist(Player ply)
    {
        foreach (Player player in Player.List)
        {
            if (player.Role.Side == ply.Role.Side && player != ply)
                coroutines.Add(Timing.RunCoroutine(DoMist(ply, player)));
        }
    }

    private IEnumerator<float> DoMist(Player activator, Player player)
    {
        for (;;)
        {
            if (player.Health + HealAmount >= player.MaxHealth ||
                (player.Position - activator.Position).sqrMagnitude > 144f || !Check(activator))
                continue;

            player.Health += HealAmount;

            yield return Timing.WaitForSeconds(Seconds);

            if (!Check(activator))
            {
                foreach (CoroutineHandle handle in coroutines)
                    Timing.KillCoroutines(handle);
            }
        }
    }
}