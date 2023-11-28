using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{

    /// <summary>
    /// Класс Item содержащий свойства Item(предмета в инвентаре).
    /// </summary>
    public class Item
    {
        private string _name;
        private string _id;
        private uint _quantity;
        private uint _durability;
        private const byte MIN_ID_LENGHT = 5;
        private const byte MAX_ID_LENGHT = 20;
        private const byte MAX_DURABILITY = 100;

        /// <summary>
        /// Конструктор класса Item
        /// </summary>
        /// <param name="name">Название предмета</param>
        /// <param name="id">ID предмета</param>
        /// <param name="quantity">Количество</param>
        /// <param name="durability">Прочность</param>
        public Item(string name, string id, uint quantity, uint durability)
        {
            Name = name;
            Id = id;
            Quantity = quantity;
            Durability = durability;
        }

        public Item()
        {

        }

        /// <summary>
        /// Сеттер и геттер поля _name в котором хранится название предмета,
        /// возвращает Неправильное название, если пытаемся присвоить пустую строку.
        /// </summary>
        public string Name
        {
            get => _name;
            init
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value.Trim();
                }
                else
                {
                    throw new ArgumentNullException("Неправильное название");
                }
            }
        }

        /// <summary>
        /// Сеттер и геттер поля _name в котором хранится ID предмета,
        /// возвращает Неправильный id, если пытаемся присвоить пустую строку или будет неверна длина.
        /// </summary>
        public string Id
        {
            get => _id;
            set
            {
                // Идет проверка является указанная строка является строкой null или пустой строкой("")
                // и на то что длина ID не превышает 20 символов или не меньше 5. 
                if (!string.IsNullOrEmpty(value) && value.Length >= MIN_ID_LENGHT && value.Length <= MAX_ID_LENGHT)
                {
                    _id = (value.ToUpper()).Trim();
                }
                else
                {
                    throw new FormatException("Неправильный id");
                }
            }
        }

        /// <summary>
        /// Сеттер и геттер поля _quantity, в типе данных uint невозможно указать отрицательное значение или null.
        /// </summary>
        public uint Quantity { get => _quantity; set => _quantity = value; }

        /// <summary>
        /// Сеттер и геттер поля _durability, в типе данных uint невозможно указать отрицательное значение или null.
        /// Также идет проверка на то чтобы прочность не была выше 100.
        /// </summary>
        public uint Durability
        {
            get => _durability;
            set
            {
                if (value <= MAX_DURABILITY)
                {
                    _durability = value;
                }
                else
                {
                    throw new FormatException("Неправильная прочность");
                }
            }

        }

        public override string ToString()
        {
            return $"\nНазвание предмета: {Name}\n" + $"Id предмета: {Id}\n" + $"Количество: {Quantity}\n" + $"Прочность: {Durability}\n";

        }

    }
}
