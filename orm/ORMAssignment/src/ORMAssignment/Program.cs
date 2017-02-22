using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMAssignment
{
    public class Program
    {

        const int PRODUCTTABLEID = 111;
        const int UPDATETABLEID = 222;

        /// <summary>
        /// Performs operation on database according to the Assignment
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            using(var db = new Model())
            {
                db.Database.Migrate();

                Program programObject = new Program();
                programObject.DriverProgram();


                /*
                 * Below commented out area is automated 
                 * operations. Some operation may fail if 
                 * the second operation is dependend
                 * on first operation. 
                 * 
                 */


                /* #region Add into product table

                 db.product.Add(new Product
                 {
                     Name = "Product1",
                     Description = "ProductDesc1",
                     HomePageURL = "www.product1.com"
                 });
                 var count = db.SaveChanges();

                 db.product.Add(new Product
                 {
                     Name = "Product2",
                     Description = "ProductDesc2",
                     HomePageURL = "www.product2.com"
                 });
                 count = db.SaveChanges();

                 db.product.Add(new Product
                 {
                     Name = "Product3",
                     Description = "ProductDesc3",
                     HomePageURL = "www.product3.com"
                 });
                 count = db.SaveChanges();
                 #endregion

                 #region Add into update table
                 db.update.Add(new Update
                 {
                     Name = "Update1",
                     Description = "UpdateDesc1",
                     ProductId = 10 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();

                 db.update.Add(new Update
                 {
                     Name = "Update2",
                     Description = "UpdateDesc2",
                     ProductId = 10 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();

                 db.update.Add(new Update
                 {
                     Name = "Update1",
                     Description = "UpdateDesc1",
                     ProductId = 11 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();

                 db.update.Add(new Update
                 {
                     Name = "Update2",
                     Description = "UpdateDesc2",
                     ProductId = 11 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();

                 db.update.Add(new Update
                 {
                     Name = "Update3",
                     Description = "UpdateDesc3",
                     ProductId = 11 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();
                 #endregion

                 #region Remove from Update Table

                 db.update.Remove(new Update
                 {
                     Id = 12 //Kindly change this ID according to the update Id generated
                 });
                 count = db.SaveChanges();

                 #endregion


                 #region Remove from Product Table

                 db.product.Remove(new Product
                 {
                     Id = 10 //Kindly change this ID according to the product Id generated
                 });
                 count = db.SaveChanges();

                 #endregion

                 #region Update table in Product Table

                 db.product.Update(new Product
                 {
                     Id = 10, //Kindly change this ID according to the product Id generated
                     Name = "ProductChanged",
                     Description = "New Description",
                     HomePageURL = "www.blabla.com"
                 });
                 count = db.SaveChanges();

                 #endregion

                 #region Update in Update Table

                 db.update.Update(new Update
                 {
                     Id = 10, //Kindly change this ID according to the update Id generated
                     Name = "Bla",
                     Description = "BlaBla",
                     ProductId = 11
                 });

                 #endregion

                 count = db.SaveChanges();*/

            }
        }

        /// <summary>
        /// Implementation of menu driven function
        /// </summary>
        public void DriverProgram()
        {
            string choice = "";
            do
            {
                Console.WriteLine("\nSelect a table for operation:");
                Console.WriteLine("1 for Product Table");
                Console.WriteLine("2 for Update Table");
                Console.WriteLine("Type 'EXIT' to exit this program");
                choice = Console.ReadLine();

                switch (choice.ElementAt(0))
                {
                    case '1': OperationOnTable(PRODUCTTABLEID);
                        break;
                    case '2': OperationOnTable(UPDATETABLEID);
                        break;
                    default: Console.WriteLine("Wrong input. Please try again.");
                        break;
                }



            } while (!choice.ToUpper().Equals("EXIT"));
        }

        /// <summary>
        /// Route specific task to specific function
        /// </summary>
        /// <param name="ID">Table ID </param>
        private void OperationOnTable(int ID)
        {
            Console.WriteLine("Select:");
            Console.WriteLine("1 to ADD a row");
            Console.WriteLine("2 to UPDATE a row");
            Console.WriteLine("3 to REMOVE a row");

            string choice = Console.ReadLine();

            switch (choice.ElementAt(0))
            {
                case '1':
                    AddToTable(ID);
                    break;
                case '2':
                    UpdateRow(ID);
                    break;
                case '3':
                    RemoveARow(ID);
                    break;
                default: Console.WriteLine("Wrong Input.");
                    break;
            }

        }

        /// <summary>
        /// Performs remove operation on a given table Id 
        /// </summary>
        /// <param name="ID">Table ID</param>
        private void RemoveARow(int ID)
        {
            int id = 0;
            try
            {
                Console.WriteLine("Enter ID (Required | Number): ");
                id = int.Parse(Console.ReadLine());




                if (ID == PRODUCTTABLEID)
                {
                    using (var db = new Model())
                    {
                        db.ProductTable.Remove(new Product
                        {
                            Id = id
                        });
                        
                        var count = db.SaveChanges();
                        Console.WriteLine(count + " changes done successfully");
                        
                       
                    }

                }
                else
                {
                    using (var db = new Model())
                    {
                        db.UpdateTable.Remove(new Update
                        {
                            Id = id
                        });
                        
                        var count = db.SaveChanges();
                        Console.WriteLine(count + " changes done successfully");
                      
                        
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error formating ID. Please provide a Valid ID.");
                TryAgainPrompt(ID, this.RemoveARow);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error occured while updating changes. Check if the Id exist or not.");
                TryAgainPrompt(ID, this.RemoveARow);
            }
        }

        /// <summary>
        /// Performs update operation on given table ID
        /// </summary>
        /// <param name="ID">Table ID</param>
        private void UpdateRow(int ID)
        {
            int id = 0;
            try
            {
                if (ID == PRODUCTTABLEID)
                {
                    Console.WriteLine("Enter Product Id (Required): ");
                    id = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Enter Update Id (Required): ");
                    id = int.Parse(Console.ReadLine());
                }
           
                Console.WriteLine("Enter Name (Required): ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Description (Required): ");
                string description = Console.ReadLine();

                if (ID == PRODUCTTABLEID)
                {
                    Console.WriteLine("Enter HomePageURL: ");
                    string url = Console.ReadLine();

                    using (var db = new Model())
                    {
                        db.ProductTable.Update(new Product
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            HomePageURL = url
                        });
                        var count = db.SaveChanges();
                        Console.WriteLine(count + " changes done successfully");
                    }

                }
                else
                {
                    using (var db = new Model())
                    {
                      
                        Console.WriteLine("Enter a Valid ProductID (Required | Number): ");
                        int productId = int.Parse(Console.ReadLine());
       
                        db.UpdateTable.Add(new Update
                        {
                            Id = id,
                            Name = name,
                            Description = description,
                            ProductId = id
                        });
                       
                        var count = db.SaveChanges();
                        Console.WriteLine(count + " changes done successfully");
                        
                        
                    
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error formating ID. Please provide a Valid ID.");
                TryAgainPrompt(ID, this.UpdateRow);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error occured while updating changes. Check if the Id exist or not.");
                TryAgainPrompt(ID, this.UpdateRow);
            }
        }

        /// <summary>
        /// Performs Add operation on given table ID
        /// </summary>
        /// <param name="ID">Table ID</param>
        private void AddToTable(int ID)
        {
            try
            {
                string name = "", description = "";
                do
                {
                    Console.WriteLine("Enter Name (Required): ");
                    name = Console.ReadLine();
                } while (name.Count() == 0);

                do
                {
                    Console.WriteLine("Enter Description (Required): ");
                    description = Console.ReadLine();
                } while (description.Count() == 0);

                if (ID == PRODUCTTABLEID)
                {
                    Console.WriteLine("Enter HomePageURL: ");
                    string url = Console.ReadLine();

                    using (var db = new Model())
                    {
                        db.ProductTable.Add(new Product
                        {
                            Name = name,
                            Description = description,
                            HomePageURL = url
                        });
                        var count = db.SaveChanges();

                        Console.WriteLine(count + " changes done successfully");
                    }

                }
                else
                {
                    using (var db = new Model())
                    {
                        int id = 0;
                      
                        Console.WriteLine("Enter a Valid ProductID (Required | Number): ");
                        id = int.Parse(Console.ReadLine());
                       
                        

                        db.UpdateTable.Add(new Update
                        {
                            Name = name,
                            Description = description,
                            ProductId = id
                        });

                        
                        var count = db.SaveChanges();
                        Console.WriteLine(count + " changes done successfully");
                       
                        
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error occured while updating changes. Check if the productId exist or not.");
                TryAgainPrompt(ID, this.AddToTable);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error formating ID. Please provide a Valid ID.");
                TryAgainPrompt(ID, this.AddToTable);
            }
        }

        private void TryAgainPrompt(int ID, Action<int> method)
        {
            Console.WriteLine("Try again? (Y/N)");
            char choice = Console.ReadLine().ElementAt(0);

            
            if (choice == 'Y' || choice == 'y')
                method.Invoke(ID);

            DriverProgram();
        }
    }
}
