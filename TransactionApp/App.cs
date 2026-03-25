using System.Collections.Generic;
using TransactionModel;
using TransactionData;

namespace TransactionApp
{
    public class AppService
    {
        private readonly DataService dataService;


        public AppService()
        {
            dataService = new DataService();
            dataService.LoadTransactions();
        }

        public void AddLoad(string mobile, string network, decimal amount)
        {
            var load = new Load
            {
                MobileNumber = mobile,
                Network = network,
                Amount = amount
            };

            dataService.Add(mobile, network, amount);
        }

        public List<Load> ViewLoads()
        {
            return dataService.GetAll();
        }

        public void UpdateLoad(int index, string mobile, string network, decimal amount)
        {
            var load = new Load
            {
                MobileNumber = mobile,
                Network = network,
                Amount = amount
            };

            dataService.Update(index, load);
        }

        public void DeleteLoad(int index)
        {
            dataService.Delete(index);
        }
    }
}