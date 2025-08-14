using Mirror;
using UnityEngine;

// Скрипт для целей отладки / временных тестов
public class PlayerDebug : NetworkBehaviour
{
    [SerializeField, Required]
    private InterfaceField<IInventory> inventory;

    [SerializeField]
    private string itemStaticDataName;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        inventory.Value.TryToAdd(new ItemData()
        {
            ItemStaticDataName = itemStaticDataName
        }, 7);
    }
}
