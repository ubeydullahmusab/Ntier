using DL.Models;
using DL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class Service : IService
    {

        private readonly IRepository repository;
        public Service(IRepository repo)
        {
            repository = repo;
        }
        public void Add(Kisi kisi)
        {
            repository.Add(kisi); 
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public async Task<List<Kisi>> GetAll()
        {
            return await repository.GetAll();
        }

        public Kisi? GetById(int id)
        {
            return repository.Get(id);
        }

        public void Update(Kisi kisi)
        {
            repository.Update(kisi);
        }
    }
}
