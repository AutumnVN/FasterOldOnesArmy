using System.ComponentModel;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace FasterOldOnesArmy
{
    public class FasterOldOnesArmySystem : ModSystem
    {
        private int originalLaneSpawnRate = 60;
        public override void PostUpdateWorld()
        {
            if (DD2Event.TimeLeftBetweenWaves > 1)
            {
                DD2Event.TimeLeftBetweenWaves = 1;
            }

            if (DD2Event.LaneSpawnRate > 30)
            {
                originalLaneSpawnRate = DD2Event.LaneSpawnRate;
            }

            int spawnRate = ModContent.GetInstance<FasterOldOnesArmyConfig>().SpawnRate;

            if (!NPC.AnyNPCs(564) && !NPC.AnyNPCs(565) && !NPC.AnyNPCs(576) && !NPC.AnyNPCs(577) && !NPC.AnyNPCs(551) && spawnRate != 1)
            {
                DD2Event.LaneSpawnRate = 60 / spawnRate;
            }
            else
            {
                DD2Event.LaneSpawnRate = originalLaneSpawnRate;
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
