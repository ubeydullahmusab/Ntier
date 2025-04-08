using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Repository
{
    public interface IRepository 
    {
        Task<List<Kisi>> GetAll();
        Kisi? Get(decimal i);
        void Add(Kisi kisi);
        void Update(Kisi kisi);

        void Delete(decimal id);
    }
}
