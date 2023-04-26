using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public enum TypeChambre
    {
        Simple,
        Double
    }
    public class Chambre
    {
        [ForeignKey("Clinique")]
        
        public int CliniqueFk { get; set; }
        [Key]
        public int NumeroChambre { get; set;}
        public float Prix { get; set; }
        public TypeChambre typeChambre { get; set; }

       //ou bien [ForeignKey("CliniqueFk")]
        public virtual Clinique Clinique { get; set; }
        public virtual ICollection<Admission> admissions { get; set; }
    }
}
