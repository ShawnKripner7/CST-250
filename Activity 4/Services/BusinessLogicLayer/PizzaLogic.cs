/*
 * Shawn Kripner
 * CST-250
 * 4/16/2025
 * Pizza Maker
 * Activity 4
 */

using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMakerClassLibrary.Services.BusinessLogicLayer
{
    public class PizzaLogic
    {
        // Declare class level variables
        private PizzaDAO _pizzaDAO;

        /// <summary>
        /// Default constructor for PizzaLogic
        /// </summary>
        public PizzaLogic()
        {
            // Initialize the pizza DAO object
            _pizzaDAO = new PizzaDAO();
        }

        /// <summary>
        /// Add a new pizza to the current order
        /// </summary>
        /// <param name="newPizza"></param>
        /// <returns></returns>
        public (bool isValidPizza, int pizzasInOrder) AddPizzaToOrder(PizzaModel newPizza)
        {
            // Declare and initialize
            int pizzas = -1;

            // Check if the pizza is valid
            if (!string.IsNullOrWhiteSpace(newPizza.ClientName) &&
                !string.IsNullOrWhiteSpace(newPizza.Crust) &&
                newPizza.Crust != "Unknown" &&
                newPizza.Ingredients.Count > 0 &&
                newPizza.SauceQty > 0 &&
                newPizza.CheeseQty > 0)
            {
                // Call the DAO AddPizzaToOrder
                pizzas = _pizzaDAO.AddPizzaToOrder(newPizza);

                // Return the pizzas variable
                return (true, pizzas);
            }

            // Return false and -1 if the pizza is invalid
            return (false, pizzas);
        }

        /// <summary>
        /// Get the list of pizzas in the current order
        /// </summary>
        /// <returns></returns>
        public List<PizzaModel> GetPizzaOrder()
        {
            // Get and return GetPizzaOrder from the DAO
            return _pizzaDAO.GetPizzaOrder();
        }

        /// <summary>
        /// Write the pizza order to a text file
        /// </summary>
        /// <returns></returns>
        public bool WriteOrderToFile()
        {
            // Get and return WriteOrderToFile from the DAO
            return _pizzaDAO.WriteOrderToFile();
        }

    }
}
