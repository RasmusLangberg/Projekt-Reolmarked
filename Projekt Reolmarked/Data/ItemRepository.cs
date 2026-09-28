using Projekt_Reolmarked.data;
using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>();

        public void add(Item item)
        {
            _items.Add(item);
        }

        public List<Item> GetAll()
        {
            return _items;
        }
    }
}
