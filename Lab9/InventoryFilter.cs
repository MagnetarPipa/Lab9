using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class InventoryFilter
    {
        public delegate bool FilterDelegate(Item item, uint filterValue);

        /// <summary>
        ///  Фильтрация по значению 
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="filterDelegate">Делегат</param>
        /// <param name="filterValue">Значение по которому происходит фильтрация</param>
        /// <returns></returns>
        public HashSet<Item> FilteredInventory(HashSet<Item> inventory, FilterDelegate filterDelegate, uint filterValue)
        {
            HashSet<Item> filteredItems = new HashSet<Item>();

            foreach (Item item in inventory)
            {
                if (filterDelegate(item, filterValue))
                {
                    filteredItems.Add(item);
                }
            }

            return filteredItems;
        }

        public static bool FilterQuantityLower(Item item, uint value)
        {
            return item.Quantity < value;
        }
        public static bool FilterQuantityHigher(Item item, uint value)
        {
            return item.Quantity > value;
        }

    }
}
