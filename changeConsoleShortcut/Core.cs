using Il2CppScheduleOne.UI;
using HarmonyLib;
using MelonLoader;
using UnityEngine;
using ConsoleUI = Il2CppScheduleOne.UI.ConsoleUI;
[assembly: MelonInfo(typeof(changeConsoleShortcut.Core), "changeConsoleShortcut", "1.0.0", "Maxx", null)]
[assembly: MelonGame("TVGS", "Schedule I")]
namespace changeConsoleShortcut;


public class Core : MelonMod
{
    private KeyCode customConsoleKey = KeyCode.F1;
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg("Initialized.");
    }

    public override void OnUpdate()
    {
        // Ouvre la console avec F1
        if (Input.GetKeyDown(customConsoleKey))
        {
            ToggleConsoleManually();
        }
    }

   
    public void ToggleConsoleManually()
    {
        var console = UnityEngine.Object.FindObjectOfType<ConsoleUI>();
        if (console != null)
        {
            console.SetIsOpen(true);
            LoggerInstance.Msg("Console opened");
        }
        else
        {
            LoggerInstance.Warning("No instance of Console UI found");
        }
    }

    [HarmonyPatch(typeof(ConsoleUI), nameof(ConsoleUI.Update))]
    public class ConsoleUIPatch
    {
        static bool Prefix(ConsoleUI __instance)
        {
       
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                MelonLogger.Msg("Blocked original console key");
                return false;
            }
            return true; 
        }
    }

}
