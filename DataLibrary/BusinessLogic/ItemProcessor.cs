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
        public static int CreateItem(string itemId, string itemName, int quantity, string imgUrl, float price)
        {
            ItemMod data = new ItemMod
            {
                ItemId = itemId,
                ItemName = itemName,
                Quantity = quantity,
                ImgUrl = imgUrl,
                Price = price
            };
            string sql = @"insert into dbo.Items (ItemId, ItemName, Quantity, ImgUrl, Price)
                            values (@ItemId, @ItemName, @Quantity, @ImgUrl, @Price)";
            return ItemSqlDataAccess.SaveData(sql, data);
        }

        public static List<ItemMod> LoadItems()
        {
            string sql = @"select Id, ItemId,ItemName,Quantity,ImgUrl, Price from dbo.Items;";
            return ItemSqlDataAccess.LoadData<ItemMod>(sql);
        }

        public static List<ItemMod> LoadSpecificItem(string specificity)
        {
            string spec = specificity;
            string sql = @"select Id, ItemId,ItemName,Quantity,ImgUrl, Price from dbo.Items where ItemId = '" + spec + "'";
            return ItemSqlDataAccess.LoadData<ItemMod>(sql);

        }

        public static int UpdateSpecificItem(string itemId, string itemName, int quantity, string imgUrl, float price)
        {
            ItemMod data = new ItemMod
            {
                ItemId = itemId,
                ItemName = itemName,
                Quantity = quantity,
                ImgUrl = imgUrl,
                Price = price
            };

            string sql = "UPDATE dbo.Items Set ItemName = '"+itemName+"', Quantity = '"+quantity+"', ImgUrl = '"+imgUrl+ "', Price = '" + price + "' Where ItemId = '" + itemId+"';";
            return ItemSqlDataAccess.SaveData(sql, data);

        }
    } 
}
