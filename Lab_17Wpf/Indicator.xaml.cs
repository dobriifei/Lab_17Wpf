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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_17Wpf
{
    public partial class Indicator : System.Windows.Controls.UserControl
    {

        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;
        private static readonly RoutedEvent ColorChangedEvent;
        public Indicator()
        {
            InitializeComponent();
        }


        static Indicator()
        {
            // Регистрация свойств зависимости
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(Indicator),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(Indicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(Indicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(Indicator),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanget", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<Color>), typeof(Indicator));
        }

      
       public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Indicator indicator = (Indicator)sender;
            Color color = indicator.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            indicator.Color = color;
        }
        private static void OnColorChanged(DependencyObject sender,
           DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Indicator indicator = (Indicator)sender;
            indicator.Red = newColor.R;
            indicator.Green = newColor.G;
            indicator.Blue = newColor.B;
        }

    }
}



