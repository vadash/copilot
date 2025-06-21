using System.Linq;
using ExileCore.PoEMemory.Components;

namespace CoPilot;

internal class Summons
{
    public static float GetLowestMinionHpp()
    {
        float hpp = 100;
        foreach (var obj in CoPilot.Instance.localPlayer.GetComponent<Actor>().DeployedObjects
                     .Where(x => x?.Entity?.GetComponent<Life>() != null))
            if (obj.Entity.GetComponent<Life>().HPPercentage < hpp)
                hpp = obj.Entity.GetComponent<Life>().HPPercentage;
        return hpp;
    }

    public static float GetAnimatedGuardianHpp()
    {
        float hpp = 100;
        foreach (var obj in CoPilot.Instance.localPlayer.GetComponent<Actor>().DeployedObjects
                     .Where(x => x?.Entity?.GetComponent<Life>() != null && x.Entity.Path.Contains("Corpse")))
            if (obj.Entity.GetComponent<Life>().HPPercentage < hpp)
                hpp = obj.Entity.GetComponent<Life>().HPPercentage;
        return hpp;
    }
}