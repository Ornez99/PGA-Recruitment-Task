public class Item
{
    private ItemData data;

    public ItemData Data { get => data; }

    public Item(ItemData itemData)
    {
        data = itemData;
    }
}
