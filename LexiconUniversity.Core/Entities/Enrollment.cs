using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUniversity.Core.Entities
{
    public class Enrollment
    {
        public int Grade { get; set; }

        //Convention 1   Nullable FK     
        //public Student Student { get; set; }

        //Convention 3
        //public Student Student { get; set; }

        //Convention 4 add foreign key
       
        //Foreign Key
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        //Navigation property
        public Student Student {get; set;}
        public Course Course { get; set; }
    }
}
