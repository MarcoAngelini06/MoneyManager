using Money_Tracker.MVVM.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Money_Tracker.Services
{
    public class DatabaseService
    {
        private string connectionString = "server=127.0.0.1;uid=root;pwd=Ma019rco#;database=modeydb";

        // Retrieve all movements
        public List<Movement> GetAllMovements()
        {
            var movements = new List<Movement>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Movement";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            movements.Add(new Movement
                            {
                                movementId = reader.GetInt32("movementID"),
                                date = reader.GetDateTime("date"),
                                movementValue = reader.GetDouble("movement"),
                                type = reader.GetInt32("type"),
                                month = reader.GetInt32("month"),
                                description = reader.GetString("description")
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }

            return movements;
        }
        public List<Month> GetAllMonths()
        {
            var months = new List<Month>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM month";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            months.Add(new Month
                            {
                                monthID = !reader.IsDBNull(reader.GetOrdinal("monthID")) ? reader.GetInt32(reader.GetOrdinal("monthID")) : 0,
                                subscription = !reader.IsDBNull(reader.GetOrdinal("subscription")) ? reader.GetInt32(reader.GetOrdinal("subscription")) : 0,
                                name = !reader.IsDBNull(reader.GetOrdinal("name")) ? reader.GetString(reader.GetOrdinal("name")) : string.Empty,
                                income = !reader.IsDBNull(reader.GetOrdinal("income")) ? reader.GetDouble(reader.GetOrdinal("income")) : 0.0,
                                expenses = !reader.IsDBNull(reader.GetOrdinal("expenses")) ? reader.GetDouble(reader.GetOrdinal("expenses")) : 0.0,
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
            }

            return months;
        }
        // Insert a new movement
        public bool InsertMovement(Movement movement)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Movement (date, movement, type, month, description) 
                                     VALUES (@date, @movement, @type, @month, @description)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@date", movement.date);
                        command.Parameters.AddWithValue("@movement", movement.movementValue);
                        command.Parameters.AddWithValue("@type", movement.type);
                        command.Parameters.AddWithValue("@month", movement.month);
                        command.Parameters.AddWithValue("@description", movement.description);

                        return command.ExecuteNonQuery() > 0; // Returns true if rows are affected
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Database Error: {ex.Message}");
                return false;
            }
        }
    }
}
