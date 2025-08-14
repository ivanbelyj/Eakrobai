using Mirror;
using UnityEngine;
using Zenject;

public class PlayerUIManager : NetworkBehaviour
{
    private ItemsUIControllerCore itemsUIController;

    [SerializeField, Required]
    private GameObject rootPlayerGameObject;

    [SerializeField, Required]
    private CharacterInventory characterInventory;

    [SerializeField, Required]
    private CharacterInventoryInfoProvider characterInventoryInfoProvider;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        SetupPlayerUI();
    }

    private void SetupPlayerUI()
    {
        SetupItemsUI();
    }

    private void SetupItemsUI()
    {
        itemsUIController = FindAnyObjectByType<ItemsUIControllerCore>();
        if (itemsUIController == null)
        {
            Debug.LogError($"{nameof(ItemsUIControllerCore)} not found in the scene");
        }

        itemsUIController.SetPlayer(
            rootPlayerGameObject,
            characterInventory,
            characterInventoryInfoProvider);

        itemsUIController.CloseUI();
    }
}
