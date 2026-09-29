using System;
using System.Collections.Generic;
using System.Text;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.data
{
    public interface IItemRepository
    {
        void add(Item item);
        List<Item> GetAll();
        void MarkAsSold(int itemId);
    }
}
