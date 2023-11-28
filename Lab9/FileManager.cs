using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab9
{
    /// <summary>
    /// Класс FileManager для сериализации и десириализации 
    /// </summary>
    public class FileManager
    {

        /// <summary>
        ///  Запись объектов в файл в формате JSON
        ///  Идет порверка объекта на null и на то что название файла заканчивается на ".json"
        /// </summary>
        /// <param name="inentory">Объект для сохранения в файл</param>
        /// <param name="fileName">Название файла</param>
        /// <exception cref="Exception"></exception>
        public static void SerializationJSON(Inventory inentory, string fileName)
        {
            if (inentory is not null && fileName.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(inentory);
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream))
                    {
                        writer.Write(output);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Чтение данных из файла в объект 
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Inventory DeserializationJSON(string fileName)
        {
            if (fileName.EndsWith(".json"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string json = reader.ReadToEnd();
                        Inventory inentory = JsonSerializer.Deserialize<Inventory>(json);
                        return inentory;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }



        /// <summary>
        /// Запись объектов в файл в формате binary.
        /// Идет порверка объекта на null и на то что название файла заканчивается на ".bin"
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="fileName"></param>
        /// <exception cref="Exception"></exception>
        public static void SerializationBinary(Inventory inventory, string fileName)
        {
            if (inventory is not null && fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new(fileName, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter writer = new(fileStream, Encoding.Default))
                    {
                        foreach (Item part in inventory.InventoryList)
                        {
                            writer.Write(part.Name);
                            writer.Write(part.Id);
                            writer.Write(part.Quantity);
                            writer.Write(part.Durability);
                        }
                    }
                }
            }
            else
            {
                throw new Exception();
            }

        }

        /// <summary>
        /// Чтение данных из файла в объект 
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Inventory DeserializationBinary(string fileName)
        {
            if (fileName.EndsWith(".bin"))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        Inventory tempInventory = new Inventory();
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            Item part = new Item
                            {
                                Name = reader.ReadString(),
                                Id = reader.ReadString(),
                                Quantity = reader.ReadUInt32(),
                                Durability = reader.ReadUInt32()
                            };

                            tempInventory.AddItem(part);
                        }
                        return tempInventory;
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
