using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Test.Models
{
    [Serializable]
    public class AreasModel
    {
        [Required]
        public string Comments { get; set; }
        public List<Area> Area { get; set; }
    }

    public class Area
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AreaName { get; set; }
        public bool Selected { get; set; }
    }
}
