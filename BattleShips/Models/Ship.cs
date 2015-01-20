using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    class Ship
    {
        public int Left { get; set; }

        public int Top { get; set; }
        public int Length { get; set; }

        public bool Hit { get; set; }

        public int[] Hits { get; set; }

    }
}
