using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Lab9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("Axe", "12345", 23, 12);
            Item item3 = new Item("Shotgun", "12334567", 3, 4);
            Item item2 = new Item("Shovel", "945687893112", 1, 8);
            Item item4 = new Item("Rifle", "8567123", 15, 100);
            // Item item5 = new Item("Rifle", "8567123", 15,100);
            Inventory inventory1 = new Inventory();

            inventory1.AddItem(item1);
            inventory1.AddItem(item2);
            inventory1.AddItem(item3);
            inventory1.AddItem(item4);

            Console.WriteLine(inventory1);

            InventoryFilter filter = new InventoryFilter();
            InventorySorter sorter = new InventorySorter();


            //Стандартный делегат
            InventorySorter.ItemFilterDelegate filterDelegate = item => item.Durability >= 90;
            sorter.BubbleSort(inventory1.InventoryList, filterDelegate);

            Console.WriteLine("\nОтсортированный инвентарь:");
            Console.WriteLine(inventory1);

            //Стандартный делегат
            HashSet<Item> filteredInventory = filter.FilteredInventory(inventory1.InventoryList, InventoryFilter.FilterQuantityLower, 10);
            Console.WriteLine("Отфильтрованные предметы по количеству");
            foreach (Item item in filteredInventory)
            {
                Console.WriteLine(item);
            }

            InventoryFilter.FilterDelegate searchDurabilityLower = delegate (Item item, uint searchValue)
            {
                return item.Durability < searchValue;
            };

            //Использование анонимной функции
            HashSet<Item> filteredInventory1 = filter.FilteredInventory(inventory1.InventoryList, searchDurabilityLower, 10);
            Console.WriteLine("Отфильтрованные предметы по прочности");
            foreach (Item item in filteredInventory1)
            {
                Console.WriteLine(item);
            }

            //Использование лямбда-выражения
            HashSet<Item> filteredInventory2= filter.FilteredInventory(inventory1.InventoryList, (item, filterValue) => item.Quantity > filterValue, 3);
            Console.WriteLine("Отфильтрованные предметы по количеству");
            foreach (Item item in filteredInventory2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
