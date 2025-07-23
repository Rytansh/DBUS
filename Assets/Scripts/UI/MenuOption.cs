using UnityEngine;
using System;

public class MenuOption
{
    public string label;
    public Action onSelect;

    public MenuOption(string label, Action onSelect)
    {
        this.label = label;
        this.onSelect = onSelect;
    }
}
