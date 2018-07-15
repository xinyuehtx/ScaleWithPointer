using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var d = new Dictionary<int,int>();
            //d[0] = 0;
            //var myControl = new MyControl();
            _testDictionary = CreateDictionary();
            //CreateList();
        }

        private Dictionary<int, MyControl> _testDictionary;

        //private List<MyControl> _testList = new List<MyControl>();
        //private List<int> _intList = new List<int>();

        //private void CreateList()
        //{
        //    for (int i = 0; i < 1000000; i++)
        //    {
        //        _testList.Add(new MyControl());
        //        _intList.Add(i);
        //    }
        //}

        private Dictionary<int, MyControl> CreateDictionary()
        {
            var dictionary = new Dictionary<int, MyControl>();
            for (int i = 0; i < 1000000; i++)
            {
                dictionary.Add(i, new MyControl());
            }

            return dictionary;
        }

        private void MyGrid_OnKeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(e.Key);
            //Console.WriteLine($"---------------");
        }

        private int i = 0;
        private void MyGrid_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var position = e.GetPosition(TestGrid);
            Debug.WriteLine($"x:{position.X},Y:{position.Y}");
            
            var scale = 1 + e.Delta / (double)Math.Abs(e.Delta) * 0.1;
          
            var matrix = TestGrid.RenderTransform.Value;
            var matrix2 = TestGrid2.RenderTransform.Value;
            //var position = e.GetPosition(TestGrid);
            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            TestGrid.RenderTransform = new MatrixTransform(matrix);
            var position2 = position * matrix2;
            matrix2.ScaleAt(scale, scale, position2.X, position2.Y);
            TestGrid2.RenderTransform = new MatrixTransform(matrix2);
        }
    }

    class MyControl : UserControl
    {

    }
}
