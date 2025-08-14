using UnityEngine;

// В этом проекте пока что для инвентаря используется одна секция,
// но их может быть несколько (например, ещё wear section - что надето на персонажа)

// Минималистичная обертка под конкретный проект

/// <summary>
/// Компонент, предоставляющий доступ к секциям инвентаря персонажа.
/// </summary>
public class CharacterInventory : MonoBehaviour, IGridSectionInventory
{
    #region Inventory sections
    [Header("Set in inspector")]
    [SerializeField]
    private GridSection mainSection;

    public GridSection MainSection
    {
        get => mainSection;
        private set => mainSection = value;
    }

    GridSection IGridSectionInventory.GridSection => MainSection;
    #endregion

    public bool CanAdd(ItemData itemData, int count)
    {
        return MainSection.CanAddToSection(itemData, count);
    }

    public bool TryToAdd(ItemData itemData, int count)
    {
        return MainSection.TryToAddToSection(itemData, count);
    }

    public float TotalWeight => MainSection.TotalWeight;

    public bool Remove(ItemPlacementId placementId)
    {
        if (placementId.InventorySectionNetId == mainSection.netId)
        {
            return mainSection.RemoveFromSection(placementId.LocalId);
        }
        else
        {
            Debug.Log(
                "Предмет нельзя удалить из инвентаря персонажа, т.к. он находится в секции, " +
                "не относящейся к нему");
            return false;
        }
    }
}
