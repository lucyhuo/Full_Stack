using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        // foreign key 
        public int MovieId { get; set; }
        // Navigation property: help to get the related informaion for that particular table, like a join by INCLUDE
        public Movie Movie { get; set; }
    }
}
