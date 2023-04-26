using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public class Clinique
    {
        public string Adresse { get; set; }
        public int Capacite { get; set; }
        
        public int CliniqueId { get; set; }
        public int NumTel { get; set; }
        public virtual ICollection<Chambre> Chambres { get; set; }
    }
}
