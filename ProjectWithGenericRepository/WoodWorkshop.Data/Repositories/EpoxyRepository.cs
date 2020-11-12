using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class EpoxyRepository
    {
        private readonly WoodWorkshopContext _ctx;
        public EpoxyRepository()
        {
            _ctx = new WoodWorkshopContext();
        }

        public Epoxy Create(Epoxy model)
        {
            _ctx.Epoxys.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public List<Epoxy> GetByType(string type)
        {
            return _ctx.Epoxys
                .Where(x => x.Type == type)
                .ToList();
        }
    }
}
