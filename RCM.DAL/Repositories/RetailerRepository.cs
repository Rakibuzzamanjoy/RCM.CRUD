using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RCM.DAL.Context;
using RCM.DAL.Models;

namespace RCM.DAL.Repositories
{
    public interface IRetailerRepository
    {
        Task<RetailerInformation> CreateRetailerAsync(RetailerInformation retailerInformation);
        Task<List<RetailerInformation>> GetRetailerList();
        Task<RetailerInformation> ModifyRetailerInfo(RetailerInformation retailerInformation, int id);
        Task<RetailerInformation> RemoveRetailer(long id);
    }
    public class RetailerRepository : IRetailerRepository
    {
        private readonly ApplicationDbContext _context;
        public RetailerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RetailerInformation> CreateRetailerAsync(RetailerInformation retailerInformation)
        {
            var data = new RetailerInformation
            {
                RetailerID = retailerInformation.RetailerID,
                RetailerName = retailerInformation.RetailerName,
                RetailerPhone = retailerInformation.RetailerPhone,
                EntryDate = retailerInformation.EntryDate
            };
            _context.RetailerInformation.Add(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<List<RetailerInformation>> GetRetailerList()
        {
            var res = await _context.RetailerInformation.ToListAsync();
            return res;
        }

        public async Task<RetailerInformation> ModifyRetailerInfo(RetailerInformation retailerInformation, int id)
        {
            var res = await _context.RetailerInformation.FirstOrDefaultAsync(x => x.id == id);

            if(res != null)
            {
                res.RetailerName = retailerInformation.RetailerName;
                res.RetailerPhone = retailerInformation.RetailerPhone;
                res.EntryDate = retailerInformation.EntryDate;
            }
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<RetailerInformation> RemoveRetailer(long id)
        {
            var res = await _context.RetailerInformation.Where(x => x.id == id).FirstOrDefaultAsync();

            _context.RetailerInformation.Remove(res);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
