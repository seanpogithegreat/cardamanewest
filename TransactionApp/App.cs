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
                
            };

            dataService.Add(load);
        }

        public List<Load> ViewLoads()
        {
            return dataService.GetAll();
        }

        public void UpdateLoad(int id, string mobile, string network, decimal amount)
        {
            
            var load = new Load
            {
                Id = id, 
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