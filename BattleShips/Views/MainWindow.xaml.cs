﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BattleShips.Views;

namespace BattleShips
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void panel_DragOver(object sender, DragEventArgs e)
        {

        }

        private void panel_Drop(object sender, DragEventArgs e)
        {
            // If an element in the panel has already handled the drop, 
            // the panel should not also handle it. 
            if (e.Handled == false)
            {
                Panel _panel = (Panel)sender;
                Ship _element = (Ship)e.Data.GetData("Object");

                // update statusbar with mouse position
                TextBlockStatusBar.Text = e.GetPosition(_panel).ToString();
                

                if (_panel != null && _element != null)
                {
                    // Get the panel that the element currently belongs to, 
                    // then remove it from that panel and add it the Children of 
                    // the panel that its been dropped on.
                
                    //remove margin
                    _element.Margin = new Thickness(0); 

                    Canvas.SetLeft(_element, (int)(e.GetPosition(_panel).X / 40) * 40);
                    Canvas.SetTop(_element, (int)(e.GetPosition(_panel).Y / 40) * 40);
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey &&
                            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                        {
                            UserControl userControl = new UserControl();_panel.Children.Add(userControl);

                            // Set position to match grid in canvas
                           
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            _panel.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }

            
        }

        

   }
}
