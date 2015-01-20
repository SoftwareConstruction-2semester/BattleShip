using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class ShipModel
    {
        private int _left;
        private int _top;
        private int _length;
        private bool _hit;
        private int[] _hits;

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public bool Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }

        public int[] Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }
    }
}
