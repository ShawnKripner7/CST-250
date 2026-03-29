/*
 * Shawn Kripner
 * CST-250
 * 3/24/2026
 * Vehicle Class Library
 * Activity 1
 */

using System;
using System.Collections.Generic;
using System.Text;
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.DataAccessLayer;


namespace VehicleClassLibrary.Services.BusinessLogicLayer
{
    public class StoreLogic
    {
        // Class level variable for the StoreDAO
        private StoreDAO _storeDAO;

        /// <summary>
        /// Default constructor for StoreLogic
        /// </summary>
        public StoreLogic()
        {
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Get a list of vehicles in the shopping cart
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetShoppingCart()
        {
            return _storeDAO.GetShoppingCart();
        }

        /// <summary>
        /// Add a vehicle to the inventory
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            return _storeDAO.AddVehicleToInventory(vehicle);
        }

        /// <summary>
        /// Add a vehicle to the shopping cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int id)
        {
            return _storeDAO.AddVehicleToCart(id);
        }

        /// <summary>
        /// Write the inventory to the text file
        /// </summary>
        /// <returns></returns>
        public bool WriteInventory()
        {
            return _storeDAO.WriteInventory();
        }

        /// <summary>
        /// Read the inventory from the text file
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            return _storeDAO.ReadInventory();
        }

        /// <summary>
        /// Checkout the shopping cart
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            return _storeDAO.Checkout();
        }
    }
}
