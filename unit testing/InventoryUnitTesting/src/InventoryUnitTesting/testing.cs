using System.Collections.Generic;
using Xunit;


namespace InventoryUnitTesting
{
    public class Testing
    {
        private readonly IList<Product> _productList;
        private readonly IList<Cart> _cartList;
        private readonly IList<Inventory> _inventoryList;

        Database database = new Database();

        Program program = new Program();

        #region Constructor
        public Testing()
        {
            
        }
        #endregion

        #region  AddInventory Testing        
        [Fact]
        public void WhenAProductIsAddedToInventory_PassingTest()
        {
            var newInventory = new Inventory()
            {
                Id = 6,
                ProductId = 1,
                Quantity = 3,
                CreationDateTime = System.DateTime.UtcNow
            };

            var inventory = program.AddInventory(newInventory);

            Assert.Equal(6, inventory.Count);

        }

        [Fact]
        public void WhenAProductIsAddedToInventory_FailingTest()
        {
            var newInventory = new Inventory()
            {
                Id = 6,
                ProductId = 1,
                Quantity = 3,
                CreationDateTime = System.DateTime.UtcNow
            };

            Assert.NotEqual(6, program.AddInventory(newInventory).Count);
        }
        #endregion

        #region UpdateInventory Testing
        [Fact]
        public void WhenAProductIsUpdatedInTheInventory_PassingTest()
        {
            var update = new Inventory
            {
                Id = 3,
                ProductId = 3,
                Quantity = 150,
                Price = 100, //Price raised
                CreationDateTime = System.DateTime.UtcNow
            };
            Assert.Equal(150, program.UpdateInventory(update).Price);
        }

        [Fact]
        public void WhenAProductIsUpdatedInTheInventory_FailingTest()
        {
            var update = new Inventory
            {
                Id = 3,
                ProductId = 3,
                Quantity = 150,
                Price = 100, //Price raised
                CreationDateTime = System.DateTime.UtcNow
            };
            Assert.NotEqual(150, program.UpdateInventory(update).Price);
        }
        #endregion

        #region DeleteInventory Testing

        [Fact]
        public void WhenInventoryIsDeleted_PassingTest()
        {
            var update = new Inventory
            {
                Id = 1,
                ProductId = 1
            };
            Assert.Equal(0, program.DeleteInventory(update).Count);
        }

        [Fact]
        public void WhenInventoryIsDeleted_FailingTest()
        {
            var update = new Inventory
            {
                Id = 1,
                ProductId = 1
            };
            Assert.NotEqual(0, program.DeleteInventory(update).Count);
        }
        #endregion

        #region Checkout Testing

        [Fact]
        public void WhenTheUserCheckOut_PassingTest()
        {
            var inventorySize = database.InventoryList.Count;

            List<Cart> cartList = new List<Cart>();

            var cart = new Cart()
            {
                Id = 1,
                ProductId = 1,
                OrderedQuantity = 5
            };

            cartList.Add(cart);

            cart = new Cart()
            {
                Id = 2,
                ProductId = 3,
                OrderedQuantity = 50
            };

            cartList.Add(cart);

            var inventoryList = program.CheckOutTheCartandUpdateInventory(cartList);

            foreach (var inventory in inventoryList){
                if (inventory.Id == 1)
                    Assert.Equal(95, inventory.Quantity);

                if (inventory.Id == 2)
                    Assert.Equal(100, inventory.Quantity);
            }
        }

        [Fact]
        public void WhenTheUserCheckOut_FailingTest()
        {
            var inventorySize = database.InventoryList.Count;

            List<Cart> cartList = new List<Cart>();

            var cart = new Cart()
            {
                Id = 1,
                ProductId = 1,
                OrderedQuantity = 5
            };

            cartList.Add(cart);

            cart = new Cart()
            {
                Id = 1,
                ProductId = 1,
                OrderedQuantity = 5
            };

            cartList.Add(cart);

            var inventoryList = program.CheckOutTheCartandUpdateInventory(cartList);

            foreach (var inventory in inventoryList)
            {
                if (inventory.Id == 1)
                    Assert.NotEqual(95, inventory.Quantity);

                if (inventory.Id == 2)
                    Assert.NotEqual(100, inventory.Quantity);
            }
        }

        #endregion
    }
}
