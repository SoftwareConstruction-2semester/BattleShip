using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleShips.Views
{
    /// <summary>
    /// Interaction logic for Missile.xaml
    /// </summary>
    public partial class Missile : UserControl
    {
        private bool _hit;
        private ImageSource _imgSrc;

        public bool Hit
        {
            get; set ;
            
        }

        public ImageSource ImgSrc
        {
            get { return _imgSrc; }
        }

        public Missile()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
