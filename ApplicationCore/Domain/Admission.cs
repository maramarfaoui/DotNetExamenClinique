using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Domain
{
    public class Admission
    {
        [DataType(DataType.DateTime)]
        public DateTime DateAdmission { get; set; }
        [DataType(DataType. MultilineText),Display(Name ="Motif de l'admission")]
        public string MotifAdmission { get; set; }
        public int NbJours { get; set; }
        [ForeignKey("Chambre")]
        public int ChambreFk { get; set; }

        public virtual Chambre chambre{ get; set; }
        [ForeignKey("Patient")]
        public string PatientFk { get; set; }
        public virtual Patient patient { get; set; }
    }
}
