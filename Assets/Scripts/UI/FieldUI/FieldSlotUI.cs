using UnityEngine;

public class FieldSlotUI : MonoBehaviour
{
    private int index;
    private FieldSlotType slotType;
    private System.Action onClick;
    public enum FieldSlotType { Character, Skill }

    public void Initialise(FieldSlotType slotType, int index)
    {
        this.slotType = slotType;
        this.index = index;
        onClick = null;
    }

    public void EnableSlotClick(System.Action clickAction)
    {
        onClick = clickAction;
    }

    public void DisableSlotClick()
    {
        onClick = null;
    }

    private void OnMouseDown()
    {
        if (onClick != null)
        {
            onClick.Invoke();
        }
    }

    public FieldSlotType GetSlotType() => slotType;
    public int GetIndex() => index;
}

