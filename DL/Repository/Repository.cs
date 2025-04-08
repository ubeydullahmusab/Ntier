using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repository
{
    public class Repository : IRepository
    {
        private readonly MusabContext db;
        public Repository(MusabContext context)
        {
            db = context;
        }
        public void Add(Kisi kisi)
        {
            db.Add(kisi);
            db.SaveChanges();
        }

        public void Delete(decimal id)
        {
            var data = db.Kisis.Find(id);
            if (data != null)
            {
                db.Kisis.Remove(data);
                db.SaveChanges();
            }
        }

        public Kisi? Get(decimal i)
        {
            return db.Kisis.Find(i);
        }

        public async Task<List<Kisi>> GetAll()
        {
            return await db.Kisis.ToListAsync();
        }

        public void Update(Kisi kisi)
        {
            var existingKisi = db.Kisis.Find(kisi.Id);

            if (existingKisi != null)
            {
                // Entity'nin durumunu Unchanged yaparak EF Core'un eski nesneyi izlemesini sağlarız
                db.Entry(existingKisi).State = EntityState.Detached;

                // Yeni nesneyi ekle
                db.Kisis.Update(kisi);
                db.SaveChanges();
            }
        }
    }
}
