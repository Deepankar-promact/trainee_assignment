using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMAssignment
{
    public class Program
    {
        /// <summary>
        /// Performs operation on database according to the Assignment
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            using(var db = new Model())
            {
                db.Database.Migrate();

                #region Add into product table

                db.product.Add(new Product
                {
                    Name = "Product1",
                    Description = "ProductDesc1",
                    HomePageURL = "www.product1.com"
                });

                db.product.Add(new Product
                {
                    Name = "Product2",
                    Description = "ProductDesc2",
                    HomePageURL = "www.product2.com"
                });

                db.product.Add(new Product
                {
                    Name = "Product3",
                    Description = "ProductDesc3",
                    HomePageURL = "www.product3.com"
                });
                #endregion

                #region Add into update table
                db.update.Add(new Update
                {
                    Name = "Update1",
                    Description = "UpdateDesc1",
                    ProductId = 10
                });

                db.update.Add(new Update
                {
                    Name = "Update2",
                    Description = "UpdateDesc2",
                    ProductId = 10
                });

                db.update.Add(new Update
                {
                    Name = "Update1",
                    Description = "UpdateDesc1",
                    ProductId = 11
                });

                db.update.Add(new Update
                {
                    Name = "Update2",
                    Description = "UpdateDesc2",
                    ProductId = 11
                });

                db.update.Add(new Update
                {
                    Name = "Update3",
                    Description = "UpdateDesc3",
                    ProductId = 11
                });
                #endregion

                #region Remove from Update Table

                db.update.Remove(new Update
                {
                    Id = 12
                });

                #endregion


                #region Remove from Product Table

                db.product.Remove(new Product
                {
                    Id = 10
                });

                #endregion
                
                #region Update table in Product Table

                db.product.Update(new Product
                {
                    Id = 10,
                    Name = "ProductChanged",
                    Description = "New Description",
                    HomePageURL = "www.blabla.com"
                });

                #endregion

                #region Update in Update Table

                db.update.Update(new Update
                {
                    Id = 10,
                    Name = "Bla",
                    Description = "BlaBla",
                    ProductId = 11
                });

                #endregion

                var count = db.SaveChanges();

            }
        }
    }
}
