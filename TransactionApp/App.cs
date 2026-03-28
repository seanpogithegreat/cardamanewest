using System.Collections.Generic;
using TransactionModel;
using TransactionData;

namespace TransactionApp
{
    public class AppService
    {
        private readonly TransactionDBData dataService;

        public AppService()
        {
            dataService = new TransactionDBData();
        }

        public void AddLoad(string mobile, string network, decimal amount)
        {
            var load = new Load
            {
                MobileNumber = mobile,
                Network = network,
                Amount = amount
                // Id is usually 0 here; SQL handles the auto-increment
            };

            dataService.Add(load);
        }

        public List<Load> ViewLoads()
        {
            return dataService.GetAll();
        }

        public void UpdateLoad(int id, string mobile, string network, decimal amount)
        {
            // FIX: You were missing 'Amount = amount' inside the object initializer
            var load = new Load
            {
                Id = id, // Good practice to include the ID in the model
                MobileNumber = mobile,
                Network = network,
                Amount = amount
            };

            dataService.Update(id, load);
        }

        public void DeleteLoad(int id)
        {
            dataService.Delete(id);
        }
    }
}