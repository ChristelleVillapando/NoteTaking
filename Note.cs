using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTaking
{
    public class Note
    {
        public required String Title { get; set; }
        public required String Content {get; set; }
        public DateTime CreatedAt { get;}
        public Note(){

            CreatedAt = DateTime.Now;
        }
        
    }
}