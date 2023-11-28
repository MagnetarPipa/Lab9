using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    /// <summary>
    /// Класс для управления предметами в инвентаре
    /// </summary>
    public class Inventory
    {
        HashSet<Item> inventoryList = new HashSet<Item>();

        public HashSet<Item> InventoryList
        {
            get => inventoryList;
            set => inventoryList = value;
        }

        /// <summary>
        ///  Добавление нового уникального предмета в HashSet
        /// </summary>
        /// <param name="newItem">Новый предмет для добавления в инвентарь,идет проверка на уникальность предмета.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void AddItem(Item newItem)
        {
            if (newItem is not null)
            {
                inventoryList.Add(newItem);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Ошибка в добавлении предмета");
            }
        }

        /// <summary>
        /// Удаление предмета из инвентаря
        /// </summary>
        /// <param name="itemToDelete">Предмет для удаления</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void DeleteItem(Item itemToDelete)
        {
            if (itemToDelete is not null && inventoryList.Contains(itemToDelete))
            {
                inventoryList.Remove(itemToDelete);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Таково предмета не существует");
            }
        }
       
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (Item part in inventoryList)
            {
                str.Append(part + "\n");
            }
            return str.ToString();
        }
    }
}
