using Dalamud.Game.ClientState.Actors.Types;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Logging;
using Dalamud.Game;

namespace TankStanceSounds
{
    public class TankStanceDetector
    {
        private readonly Plugin plugin;

        public TankStanceDetector(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnActionUsed(uint actionId, Actor caster)
        {
            if (caster is PlayerCharacter player && player.ClassJob.GameData?.Role == 1) // Tank Role
            {
                string soundFile = actionId switch
                {
                    48 => "sounds/banjoeffect.wav", // Warrior Defiance
                    26 => "sounds/chorus.wav",     // Paladin Iron Will
                    3610 => "sounds/emo.wav",      // Dark Knight Grit
                    16142 => "sounds/sayhello.wav",// Gunbreaker Royal Guard
                    _ => null
                };

                if (soundFile != null)
                {
                    plugin.PlaySound(Path.Combine(plugin.PluginDirectory, soundFile));
                }
            }
        }
    }
}
