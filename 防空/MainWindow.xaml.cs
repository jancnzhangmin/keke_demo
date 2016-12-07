using System;
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
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Timers;

namespace 防空
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Timer timer = new Timer();
        Timer initTimer = new Timer();
        int initValue = 0;

        public static T FindChild<T>(DependencyObject parent, string childName)//查找控件
where T : DependencyObject
        {
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // 如果子控件不是需查找的控件类型 
                T childType = child as T;
                if (childType == null)
                {
                    // 在下一级控件中递归查找 
                    foundChild = FindChild<T>(child, childName);
                    // 找到控件就可以中断递归操作  
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // 如果控件名称符合参数条件 
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // 查找到了控件 
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        public static T GetParentObject<T>(DependencyObject obj) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T)
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        } 



        public static void follow(ViewportCtl view )//跟随动画
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            maingrid.Children.Add(main);
            //initTimer.Interval = 1000;
            //initTimer.Elapsed += new ElapsedEventHandler(initTimer_Elapsed);
            //initTimer.Start();
            //sunshine();

            //BitmapImage bitimg = new BitmapImage();
            //PublicClass.Offset.Add(new Point3D(-2.9, -1, -5));
            //PublicClass.Offset.Add(new Point3D(-4.5, 0, -10));
            //PublicClass.Offset.Add(new Point3D(-8.2, -0.2, -20));
            //PublicClass.Offset.Add(new Point3D(-7.8, -2.6, -20));
            //PublicClass.Offset.Add(new Point3D(-6.5, 0.8, -30));
            //PublicClass.Offset.Add(new Point3D(-4.4, -1.3, -20));
            //ViewportCtl view1 = new ViewportCtl();
            //Point3D p1 = new Point3D(0, 1, -0.01);
            //Point3D p2 = new Point3D(-1, -1, -0.01);
            //Point3D p3 = new Point3D(1, -1, -0.01);
            //Point3D p4 = new Point3D(0, 1, -0.01);

            //view1.Name = "view1";
            //view1.mesh.Positions.Clear();
            //view1.mesh.Positions.Add(p1);
            //view1.mesh.Positions.Add(p2);
            //view1.mesh.Positions.Add(p3);
            //view1.mesh.Positions.Add(p4);
            //view1.offset.OffsetX = -2.9;
            //view1.offset.OffsetY = -1;
            //view1.offset.OffsetZ = -5;
            //view1.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\02五次人防.jpg", UriKind.RelativeOrAbsolute));
            //bitimg.BeginInit();
            //bitimg.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\02五次人防.jpg", UriKind.RelativeOrAbsolute);
            //bitimg.EndInit();
            ////view1.rect.Width = bitimg.PixelWidth;
            ////view1.rect.Height = bitimg.PixelHeight;
            ////view1.picturename.Width = bitimg.PixelWidth;
            ////view1.picturename.Height = bitimg.PixelHeight;
            ////view1.IsManipulationEnabled = true;
            //view1.IsManipulationEnabled = true;
            //view1.ManipulationStarting += new EventHandler<ManipulationStartingEventArgs>(view_ManipulationStarting);
            //view1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(view_ManipulationDelta);
            //view1.MouseDown += new MouseButtonEventHandler(view1_MouseDown);
            ////view1.ImageManipulationStarting += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationStarting);
            ////view1.ImageManipulationDelta += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationDelta);
            ////view1.ImageManipulationCompleted += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationCompleted);
            //viewconter.Children.Add(view1.viewport);

            //ViewportCtl view2 = new ViewportCtl();
            //view2.Name = "view2";
            //p1 = new Point3D(-1, 1, -0.01);
            //p2 = new Point3D(0, -1, -0.01);
            //p3 = new Point3D(0, -1, -0.01);
            //p4 = new Point3D(1, 1, -0.01);
            //view2.mesh.Positions.Clear();
            //view2.mesh.Positions.Add(p1);
            //view2.mesh.Positions.Add(p2);
            //view2.mesh.Positions.Add(p3);
            //view2.mesh.Positions.Add(p4);
            //view2.offset.OffsetX = -4.5;
            //view2.offset.OffsetY = 0;
            //view2.offset.OffsetZ = -10;
            //view2.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\09IV战略导弹核潜艇.jpg", UriKind.RelativeOrAbsolute));
            //viewconter.Children.Add(view2.viewport);

            //ViewportCtl view3 = new ViewportCtl();
            //view3.Name = "view3";
            //p1 = new Point3D(0, 1, -0.01);
            //p2 = new Point3D(-1, -1, -0.01);
            //p3 = new Point3D(1, -1, -0.01);
            //p4 = new Point3D(0, 1, -0.01);
            //view3.mesh.Positions.Clear();
            //view3.mesh.Positions.Add(p1);
            //view3.mesh.Positions.Add(p2);
            //view3.mesh.Positions.Add(p3);
            //view3.mesh.Positions.Add(p4);
            //view3.offset.OffsetX = -8.2;
            //view3.offset.OffsetY = -0.2;
            //view3.offset.OffsetZ = -20;
            //view3.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\10月14日11时25分，中国在太原卫星发射中心用“长征二号丙”运载火箭，以”一箭双星“方式，成功将“实践九号”AB卫星发射升空并送入预定转移轨道。这是中国“长征”系列运载火箭第169次航天发射。.jpg", UriKind.RelativeOrAbsolute));
            //viewconter.Children.Add(view3.viewport);



            //ViewportCtl view4 = new ViewportCtl();
            //view4.Name = "view4";
            //p1 = new Point3D(-1, 1, -0.01);
            //p2 = new Point3D(0, -1, -0.01);
            //p3 = new Point3D(0, -1, -0.01);
            //p4 = new Point3D(1, 1, -0.01);
            //view4.mesh.Positions.Clear();
            //view4.mesh.Positions.Add(p1);
            //view4.mesh.Positions.Add(p2);
            //view4.mesh.Positions.Add(p3);
            //view4.mesh.Positions.Add(p4);
            //view4.offset.OffsetX = -7.8;
            //view4.offset.OffsetY = -2.6;
            //view4.offset.OffsetZ = -20;
            //view4.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\25_153085_7b996e5356a307b.jpg", UriKind.RelativeOrAbsolute));
            //viewconter.Children.Add(view4.viewport);

            //ViewportCtl view5 = new ViewportCtl();
            //view5.Name = "view5";
            //p1 = new Point3D(0, 1, -0.01);
            //p2 = new Point3D(-1, -1, -0.01);
            //p3 = new Point3D(1, -1, -0.01);
            //p4 = new Point3D(0, 1, -0.01);
            //view5.mesh.Positions.Clear();
            //view5.mesh.Positions.Add(p1);
            //view5.mesh.Positions.Add(p2);
            //view5.mesh.Positions.Add(p3);
            //view5.mesh.Positions.Add(p4);
            //view5.offset.OffsetX = -6.5;
            //view5.offset.OffsetY = 0.8;
            //view5.offset.OffsetZ = -30;
            //view5.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\051C驱逐舰首舰“沈阳”号.jpg", UriKind.RelativeOrAbsolute));
            //viewconter.Children.Add(view5.viewport);

            //ViewportCtl view6 = new ViewportCtl();
            //view6.Name = "view6";
            //p1 = new Point3D(-1, 1, -0.01);
            //p2 = new Point3D(0, -1, -0.01);
            //p3 = new Point3D(0, -1, -0.01);
            //p4 = new Point3D(1, 1, -0.01);
            //view6.mesh.Positions.Clear();
            //view6.mesh.Positions.Add(p1);
            //view6.mesh.Positions.Add(p2);
            //view6.mesh.Positions.Add(p3);
            //view6.mesh.Positions.Add(p4);
            //view6.offset.OffsetX = -4.4;
            //view6.offset.OffsetY = -1.3;
            //view6.offset.OffsetZ = -20;
            //view6.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\054A隐身护卫舰.jpg", UriKind.RelativeOrAbsolute));
            //viewconter.Children.Add(view6.viewport);

            //clouds();
            //timer.Interval = 3000;
            //timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            //timer.Start();

        }



        void view1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
            MessageBox.Show("asdf");
        }

        void view_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            MessageBox.Show("open");
            ViewportCtl view = sender as ViewportCtl;
            if (view != null)
            {
                MessageBox.Show("move");
                view.picturename.Margin = new Thickness(view.picturename.Margin.Left+e.DeltaManipulation.Translation.X, view.picturename.Margin.Top + e.DeltaManipulation.Translation.Y, 0, 0);
            }
        }

       



        void view_ImageManipulationCompleted(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            throw new NotImplementedException();
        }

        void view_ImageManipulationDelta(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            throw new NotImplementedException();
        }

        void view_ImageManipulationStarting(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            throw new NotImplementedException();
            //this.Close();


        }

        void view_viewmoveCompleted(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            throw new NotImplementedException();

        }



        private void move_cloud(Image img, float temrand, Thickness mar)
        {
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            ThicknessAnimation moveimg = new ThicknessAnimation();
            moveimg.To = new Thickness(-400, mar.Top, 0, 0);
            moveimg.Duration = TimeSpan.FromMinutes(rand.Next(1, 2) * (0.34f - temrand) * 30);
            img.BeginAnimation(Image.MarginProperty, moveimg);
        }

        private void opticy_cloud(Image img)
        {

        }


    }
}
