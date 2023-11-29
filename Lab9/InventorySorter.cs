using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class InventorySorter
    {
        public delegate bool ItemFilterDelegate(Item item);

        /// <summary>
        /// Сортировка массива
        /// </summary>
        /// <param name="inventory">список предметов</param>
        /// <param name="compareDelegate">делегат</param>
        public void BubbleSort(HashSet<Item> inventory, ItemFilterDelegate compareDelegate)
        {

            if (inventory != null && compareDelegate != null)
            {
                Item[] itemsArray = new Item[inventory.Count];
                inventory.CopyTo(itemsArray);

                int n = itemsArray.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (compareDelegate(itemsArray[j]) && compareDelegate(itemsArray[j + 1]) && OrderByNameLeft(itemsArray[j], itemsArray[j + 1]))
                        {

                            Item temp = itemsArray[j];
                            itemsArray[j] = itemsArray[j + 1];
                            itemsArray[j + 1] = temp;
                        }
                    }
                }

                inventory.Clear();
                foreach (var item in itemsArray)
                {
                    inventory.Add(item);
                }
            }
            else
            {
                throw new ArgumentNullException("Значение не может быть null");
            }

        }

        private bool OrderByNameLeft(Item item1, Item item2)
        {
            return string.Compare(item1.Name, item2.Name, StringComparison.Ordinal) < 0;
        }
    }
}
