using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStudentManagement.Models
{
    class Student
    {
        public string Vorname { get; set; }
        public string Nachname  { get; set; }
        public int Alter { get; set; }
        public string Studiengang { get; set; }
        public bool Bezahlt { get; set; }

    }
}
