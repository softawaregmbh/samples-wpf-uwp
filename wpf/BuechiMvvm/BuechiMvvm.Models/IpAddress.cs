using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuechiMvvm.Models
{
    public class IpAddress
    {
        public int Part1 { get; set; }

        public int Part2 { get; set; }

        public int Part3 { get; set; }

        public int Part4 { get; set; }

        public IpAddress(int p1, int p2, int p3, int p4)
        {
            this.Part1 = p1;
            this.Part2 = p2;
            this.Part3 = p3;
            this.Part4 = p4;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}.{3}",
                this.Part1,
                this.Part2,
                this.Part3,
                this.Part4);
        }
    }
}
