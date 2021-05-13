using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class RentProcessor
    {
        public static int CreateRent(string firstName, string lastName, string email, string item)
        {
            RenterModel data = new RenterModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Item = item
            };

            string sql = @"insert into dbo.Rent (FirstName, LastName,Email,Item)
                            values (@FirstName, @LastName, @Email, @Item);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<RenterModel> LoadRenters()
        {
            string sql = @"select Id, FirstName, LastName, Email, Item
                            from dbo.Rent;";
            return SqlDataAccess.LoadData<RenterModel>(sql);
        }
    }
}
