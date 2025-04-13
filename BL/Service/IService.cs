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
<<<<<<< HEAD
        void Update(Kisi kisi); 
=======
        void Update(Kisi kisi);
>>>>>>> 593e67366a53dc4b88d3c2570fe7d6da20ceee32
        void Delete(int id);
    }
}
