using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BattleShips.Models
{
    public class ShipModel
    {
        private int _left;
        private int _top;
        private int _length;
        private bool _hit;
        private int[] _hits;
        private ImageSource _imgSrc;

        public ImageSource ImgSrc
        {
            get { return _imgSrc; }
            set { _imgSrc = value; }
        }

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

        public Thickness ImgMargin
        {
            get { return new Thickness(Left, Top, 0, 0); }
            set
            {
                Left = (int) value.Left;
                Top = (int) value.Top;
            }
        }
    }
}
