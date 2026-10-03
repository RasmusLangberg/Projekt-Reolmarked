using System;
using System.Collections.Generic;
using System.Text;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.data
{
    public interface IItemRepository
    {
        void add(Item item);
        void Delete(int itemId);
        List<Item> GetAll();
        void MarkAsSold(int itemId);
    }
}
