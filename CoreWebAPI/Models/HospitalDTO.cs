using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Models
{
    public class CreateHospitalDTO
    {
       
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hospital Name Is Too Long")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        public int CounrtyId { get; set; }
      //  public CountryDTO Country { get; set; }
    }

public class HospitalDTO :CreateHospitalDTO 
{
    public int Id { get; set; }
    public CountryDTO Country { get; set; }
    }

}
