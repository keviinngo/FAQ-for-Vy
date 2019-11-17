using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuellAngular.Models
{
    public class question
    {
        public int id { get; set; }
        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public string sporsmal { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,30}$")]
        public string svar { get; set; }
        
        public int ratingOpp { get; set; }
        
        public int ratingNed { get; set; }
    }

    public class bruker
    {
        public int id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [RegularExpression("^[a-zøæåA-ZØÆÅ. \\-]{2,30}$")]
        public string fornavn { get; set; }

        [Required]
        [RegularExpression("^[a-zæøåA-ZÆØÅ. \\-]{2,30}$")]
        public string etternavn { get; set; }

        [Required]
        public string adresse { get; set; }

        [Required]
        public string brukersporsmal { get; set; }

    }
}
