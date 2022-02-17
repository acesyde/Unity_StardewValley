using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] private GameObject closedChest;
    [SerializeField] private GameObject openedChest;
    [SerializeField] private bool opened;
    
    public override void Interact(Character character)
    {
        if (!opened)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }
    }
}
