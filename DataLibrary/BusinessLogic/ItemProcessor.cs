using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class ItemProcessor
    {
        public static int CreateItem(string itemId, string itemName, int quantity, string imgUrl)
        {
            ItemMod data = new ItemMod
            {
                ItemId = itemId,
                ItemName = itemName,
                Quantity = quantity,
                ImgUrl = imgUrl
            };
            string sql = @"insert into dbo.Items (ItemId, ItemName, Quantity, ImgUrl)
                            values (@ItemId, @ItemName, @Quantity, @ImgUrl)";
            return ItemSqlDataAccess.SaveData(sql, data);
        }

        public static List<ItemMod> LoadItems()
        {
            string sql = @"select Id, ItemId,ItemName,Quantity,ImgUrl from dbo.Items;";
            return ItemSqlDataAccess.LoadData<ItemMod>(sql);
        }

        public static List<ItemMod> LoadSpecificItem(string specificity)
        {
            string spec = specificity;
            string sql = @"select Id, ItemId,ItemName,Quantity,ImgUrl from dbo.Items where ItemId = '" + spec + "'";
            return ItemSqlDataAccess.LoadData<ItemMod>(sql);

        }
    }
}
