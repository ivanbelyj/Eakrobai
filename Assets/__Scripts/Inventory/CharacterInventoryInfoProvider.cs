using UnityEngine;

// Пока что максимально простая реализация
// (в Raging Tomorrow сейчас используется вариант с сетевой синхронизацией)
public class CharacterInventoryInfoProvider : MonoBehaviour, IInventoryInfoProvider
{
    [SerializeField]
    private InventoryInfo inventoryInfo;
    public InventoryInfo InventoryInfo => inventoryInfo;

    public event IInventoryInfoProvider.InventoryInfoChangedEventHandler InventoryInfoChanged;
}
