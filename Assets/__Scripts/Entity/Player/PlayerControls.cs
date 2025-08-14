using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : NetworkBehaviour
{
    private ItemsUIControllerCore itemsUIController;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        itemsUIController = FindAnyObjectByType<ItemsUIControllerCore>(
            findObjectsInactive: FindObjectsInactive.Include);
        if (itemsUIController == null)
        {
            Debug.LogError($"{nameof(ItemsUIControllerCore)} not found in the scene");
        }
    }

    public void OnToggleInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            itemsUIController.ShowPlayersInventory();
            itemsUIController.ToggleUI();
        }
    }
}
