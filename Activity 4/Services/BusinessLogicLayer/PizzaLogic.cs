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

            // Call the DAO AddPizzaToOrder
            pizzas = _pizzaDAO.AddPizzaToOrder(newPizza);

            // Return the pizzas variable
            return (true, pizzas);
        }

    }
}
