using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate; //a prefab that will be referred to when spawning buttons
    [SerializeField] private Transform buttonParent; //a parent that the buttons will spawn under

    private List<GameObject> activeButtons = new();

    public void Show(Vector3 screenPos, List<MenuOption> options)
    {
        Clear();

        this.transform.position = screenPos;
        this.gameObject.SetActive(true);

        foreach (MenuOption option in options)
        {
            GameObject spawnedButton = Instantiate(buttonTemplate, buttonParent);
            Button btn = spawnedButton.GetComponent<Button>();
            Text label = spawnedButton.GetComponentInChildren<Text>();

            label.text = option.label;
            btn.onClick.AddListener(() =>
            {
                option.onSelect?.Invoke();
                Hide();
            });

            activeButtons.Add(spawnedButton);
        }
    }

    public void Hide()
    {
        Clear();
        this.gameObject.SetActive(false);
    }

    private void Clear()
    {
        foreach (GameObject obj in activeButtons)
        {
            Destroy(obj);
        }
        activeButtons.Clear();
    }
}
