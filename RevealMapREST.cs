using MelonLoader;
using System.Net;
using Wicker;

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
        public static void RevealMapHttp(HttpListenerResponse response)
        {
            Processing.RevealMap(response);
        }
    }
}
