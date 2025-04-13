using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public interface IService
    {
        Task<List<Kisi>> GetAll();
        Kisi? GetById(int id);
        void Add(Kisi kisi);
        void Update(Kisi kisi); 
        void Delete(int id);
    }
}
