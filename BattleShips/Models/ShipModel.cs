using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

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

        public ImageSource ImageSource
        {
            get { return _imgSrc; }
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

        public ShipModel(String imageUrl)
        {
            ImageSourceConverter converter = new ImageSourceConverter();
            this._imgSrc = (ImageSource)converter.ConvertFromString(imageUrl);
        }
    }
}
