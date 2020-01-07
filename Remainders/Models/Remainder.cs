using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Remainders.Models
{
    public enum Priority
    {
        A, B, C, D, F
    }

    public class Remainder
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string TimeToWork { get; set; }
        public Priority Priority { get; set; }
    }
}
