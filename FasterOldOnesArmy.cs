using System.ComponentModel;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FasterOldOnesArmy
{
    public class FasterOldOnesArmySystem : ModSystem
    {
        public override void PostUpdateWorld()
        {
            if (DD2Event.TimeLeftBetweenWaves > 1)
            {
                DD2Event.TimeLeftBetweenWaves = 1;
            }

            if (ModContent.GetInstance<FasterOldOnesArmyConfig>().SpawnRate != 1)
            {
                DD2Event.LaneSpawnRate = 60 / ModContent.GetInstance<FasterOldOnesArmyConfig>().SpawnRate;
            }
        }
    }

    public class FasterOldOnesArmyConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(6)]
        [Range(1, 6)]
        [Slider]
        public int SpawnRate { get; set; }
    }
}
