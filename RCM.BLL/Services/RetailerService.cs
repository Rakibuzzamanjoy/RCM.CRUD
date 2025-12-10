using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCM.DAL.Models;
using RCM.DAL.Repositories;

namespace RCM.BLL.Services
{
    public interface IRetailerService
    {
        Task<RetailerInformation> CreateRetailerAsync(RetailerInformation retailerInformation);
        Task<List<RetailerInformation>> GetRetailerList();
        Task<RetailerInformation> ModifyRetailerInfo(RetailerInformation retailerInformation, int id);
        Task<RetailerInformation> RemoveRetailer(long id);
    }
    public class RetailerService : IRetailerService
    {
        private readonly IRetailerRepository _retailerRepository;
        public RetailerService(IRetailerRepository retailerRepository)
        {
            _retailerRepository = retailerRepository;
        }

        public async Task<RetailerInformation> CreateRetailerAsync(RetailerInformation retailerInformation)
        {
            return await _retailerRepository.CreateRetailerAsync(retailerInformation);
        }
        public async Task<List<RetailerInformation>> GetRetailerList()
        {
            var res = await _retailerRepository.GetRetailerList();
            return res;
        }

        public async Task<RetailerInformation> ModifyRetailerInfo(RetailerInformation retailerInformation, int id)
        {
            var res = await _retailerRepository.ModifyRetailerInfo(retailerInformation, id);
            return res;
        }

        public async Task<RetailerInformation> RemoveRetailer(long id)
        {
            var res = await _retailerRepository.RemoveRetailer(id);
            return res;
        }
    }
}
