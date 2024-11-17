using Dalamud.Game.Command;
using Dalamud.Plugin;
using System.IO;
using System.Media;

namespace TankStanceSounds
{
    public class Plugin : IDalamudPlugin
    {
        public string Name => "Tank Stance Sounds";

        private const string CommandName = "/tanksounds";
        private DalamudPluginInterface pluginInterface;
        private SoundPlayer soundPlayer;

        public void Initialize(DalamudPluginInterface pluginInterface)
        {
            this.pluginInterface = pluginInterface;
            this.pluginInterface.CommandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
            {
                HelpMessage = "Toggle tank stance sounds."
            });

            PluginLog.Log("Tank Stance Sounds plugin loaded.");
        }

        private void OnCommand(string command, string args)
        {
            PluginLog.Log("Command executed: " + args);
        }

        public void Dispose()
        {
            this.pluginInterface.CommandManager.RemoveHandler(CommandName);
            this.soundPlayer?.Dispose();
        }

        private void PlaySound(string soundFile)
        {
            if (File.Exists(soundFile))
            {
                soundPlayer = new SoundPlayer(soundFile);
                soundPlayer.Play();
            }
            else
            {
                PluginLog.LogError($"Sound file not found: {soundFile}");
            }
        }
    }
}
