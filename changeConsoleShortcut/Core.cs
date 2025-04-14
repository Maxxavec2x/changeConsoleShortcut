using Il2CppScheduleOne.UI;
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
        // If user press F1
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
}
