using Il2Cpp;
using MelonLoader;
using WickerREST;

namespace RevealMapREST
{
    public static class BuildInfo
    {
        public const string Name = "RevealMapREST";
        public const string Description = "Map Revealer for Farthest Frontier using REST";
        public const string Author = "Skrip";
        public const string Version = "1.0.0";
        public const string DownloadLink = "";
    }

    public static class ActiveConfig
    {
        public static bool isRevealed = false;
        public static bool isPlaying = false;
    }

    public class RevealMapREST : MelonMod
    {

        public bool IsPlaying { get => ActiveConfig.isPlaying; set => ActiveConfig.isPlaying = value; }
        public bool IsRevealed { get => ActiveConfig.isRevealed; set => ActiveConfig.isRevealed = value; }

        public override void OnInitializeMelon()
        {
            HarmonyInstance.PatchAll();
        }

        [CommandHandler("revealMap")]
        public static void RevealMapHttp()
        {
            Processing.RevealMap();
        }

        [CommandHandler("ExampleCommand")]
        public static void ExampleCommandHttp(string Input1, string Input2 = "Default value")
        {
            WickerNetwork.Instance.LogResponse($"Returning back: {Input1} {Input2}");
        }

        [GameVariable("GameFullyInitialized")]
        public static string GetGmeFullyInitialized()
        {
            return GameManager.gameFullyInitialized.ToString();
        }
    }
}
