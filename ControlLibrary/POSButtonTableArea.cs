﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlLibrary
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlLibrary"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlLibrary;assembly=ControlLibrary"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:POSButtonTableArea/>
    ///
    /// </summary>
    public class POSButtonTableArea : Button
    {
        public Data.KHU _Khu { get; set; }

        public ImageSource ImageCheck
        {
            get { return (ImageSource)GetValue(ImageCheckProperty); }
            set { SetValue(ImageCheckProperty, value);}
        }
        public static readonly DependencyProperty ImageCheckProperty =
            DependencyProperty.Register("ImageCheck", typeof(ImageSource), typeof(POSButtonTableArea), new PropertyMetadata(null));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty);}
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(ImageSource), typeof(POSButtonTableArea), new PropertyMetadata(null));

        static POSButtonTableArea()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(POSButtonTableArea), new FrameworkPropertyMetadata(typeof(POSButtonTableArea)));
        }
        public void SetTableClicked(bool isClick)
        {
            if (isClick)
            {
                this.ImageCheck = new BitmapImage(new Uri(@"/SystemImages;component/Images/Accep.png", UriKind.Relative));
                this.Foreground = Brushes.Red;
            }
            else
            {
                this.ImageCheck = null;
                this.Foreground = Brushes.Black;
            }
        }
    }
}