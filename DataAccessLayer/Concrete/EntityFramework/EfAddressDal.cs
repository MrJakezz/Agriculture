using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAddressDal : GenericRepository<Address>, IAddressDal
    {
        public string SelectMapInfo()
        {
            using var context = new AgricultureContext();

            return context.Addresses.Select(x => x.AddressMapInfo).FirstOrDefault();
        }
    }
}
