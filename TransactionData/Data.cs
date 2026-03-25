using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TransactionModel;

namespace TransactionData
{
    public class DataService
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TransactionData.json");

        public List<Load> Loads = new List<Load>();

        public void LoadTransactions()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Loads = JsonSerializer.Deserialize<List<Load>>(json) ?? new List<Load>();
            }
        }

        public void SaveTransactions()
        {
            Console.WriteLine("Saving to: " + filePath);

            string json = JsonSerializer.Serialize(Loads, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public void Add(string mobileNumber, string network, decimal amount)
        {
            var load = new Load
            {
                MobileNumber = mobileNumber,
                Network = network,
                Amount = amount
            };

            Loads.Add(load);
            SaveTransactions();
        }

        public List<Load> GetAll()
        {
            return Loads;
        }

        public void Update(int index, Load load)
        {
            if (index >= 0 && index < Loads.Count)
            {
                Loads[index] = load;
                SaveTransactions();
            }
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < Loads.Count)
            {
                Loads.RemoveAt(index);
                SaveTransactions();
            }
        }
    }
}