using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Repository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Advert> GetAll() => context.Adverts;
        public Advert GetById(int id) => context.Adverts.FirstOrDefault(a => a.ID == id);
    }
}
