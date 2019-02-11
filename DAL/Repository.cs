using DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public Advert GetById(int id) => context.Adverts.FirstOrDefault(a => a.Id == id);

        public void Add(Advert advert)
        {
            context.Adverts.Add(advert);
            context.SaveChanges();
        }

        public void Update(Advert advert)
        {
            context.Entry(advert).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Advert advert)
        {
            context.Entry(advert).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
