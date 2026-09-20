using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Landoria.GentleDeath
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public sealed class GentleDeathPlugin : BaseUnityPlugin
    {
        private const string PluginGuid = "Landoria.GentleDeath";
        private const string PluginName = "Landoria.GentleDeath";
        private const string PluginVersion = "1.0.13";

        internal static ManualLogSource Log { get; private set; }


        private Harmony _harmony;

        private void Awake()
        {
            Log = Logger;
            Logger.LogInfo($"AssemblyVersion: {GetType().Assembly.GetName().Version}.");
            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();
            Log.LogInfo($"{PluginName} {PluginVersion} is loaded.");
        }

        private void OnDestroy()
        {
            Log?.LogInfo($"{PluginName} {PluginVersion} is unloaded.");
            _harmony?.UnpatchSelf();
            _harmony = null;
            Log = null;
        }
    }
}
