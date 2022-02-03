using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem toolsystem;

    public ToolTip tooltip;

    public void Awake()
    {
        toolsystem = this;
    }

    public static void Show(string content, string header = "")
    {
        toolsystem.tooltip.SetText(content, header);
        toolsystem.tooltip.gameObject.SetActive(true);
    }
    public static void Hide()
    {
        toolsystem.tooltip.gameObject.SetActive(false);
    }
}
