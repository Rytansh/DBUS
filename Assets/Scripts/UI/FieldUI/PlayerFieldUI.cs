using UnityEngine;

public class PlayerFieldUI : MonoBehaviour
{
    [SerializeField] private FieldSlotUI[] characterSlots;
    [SerializeField] private FieldSlotUI[] skillSlots;

    public void Initialise()
    {
        for (int i = 0; i < characterSlots.Length; i++) { characterSlots[i].Initialise(FieldSlotUI.FieldSlotType.Character, i); }
        for (int i = 0; i < skillSlots.Length; i++) { skillSlots[i].Initialise(FieldSlotUI.FieldSlotType.Skill, i); }
    }


    public FieldSlotUI[] GetCharacterSlots() { return characterSlots; }
    public FieldSlotUI[] GetSkillSlots() { return skillSlots; }
}
