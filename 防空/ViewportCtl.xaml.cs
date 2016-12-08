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
using System.Timers;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace 防空
{
    /// <summary>
    /// ViewportCtl.xaml 的交互逻辑
    /// </summary>
    public partial class ViewportCtl : UserControl
    {
        public ViewportCtl()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();
        Timer roatetimer = new Timer();
        int RoateValue = 0;
        public string guid = System.Guid.NewGuid().ToString();

        int time_step = 0;
        Point oldpoint = new Point();

        public static readonly RoutedEvent viewmoveCompletedEvent = EventManager.RegisterRoutedEvent("viewmoveCompleted", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(ViewportCtl));
        public event RoutedPropertyChangedEventHandler<object> viewmoveCompleted
        {
            add { AddHandler(viewmoveCompletedEvent, value); }
            remove { RemoveHandler(viewmoveCompletedEvent, value); }
        }
        public static readonly RoutedEvent RoateEvent =EventManager.RegisterRoutedEvent("Roate",RoutingStrategy.Bubble,typeof(RoutedPropertyChangedEventHandler<object>),typeof(ViewportCtl));

        public static readonly RoutedEvent ImageManipulationCompletedEvent = EventManager.RegisterRoutedEvent("ImageManipulationCompleted", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(ViewportCtl));
        public event RoutedPropertyChangedEventHandler<object> ImageManipulationCompleted
        {
            add { AddHandler(ImageManipulationCompletedEvent, value); }
            remove { RemoveHandler(ImageManipulationCompletedEvent, value); }
        }
        public static readonly RoutedEvent ImageManipulationDeltaEvent = EventManager.RegisterRoutedEvent("ImageManipulationDelta", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(ViewportCtl));
        public event RoutedPropertyChangedEventHandler<object> ImageManipulationDelta
        {
            add { AddHandler(ImageManipulationDeltaEvent, value); }
            remove { RemoveHandler(ImageManipulationDeltaEvent, value); }
        }       
        public static readonly RoutedEvent ImageManipulationStartingEvent = EventManager.RegisterRoutedEvent("ImageManipulationStarting", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<object>), typeof(ViewportCtl));
        public event RoutedPropertyChangedEventHandler<object> ImageManipulationStarting
        {
            add { AddHandler(ImageManipulationStartingEvent, value); }
            remove { RemoveHandler(ImageManipulationStartingEvent, value); }
        }



        private void viewmove_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(this, e);
            args.RoutedEvent = ViewportCtl.viewmoveCompletedEvent;
            
            args.Source = e.OriginalSource;
            
            this.RaiseEvent(args);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            byte[] buffer = Guid.NewGuid().ToByteArray();
            Int64 newguid = BitConverter.ToInt64(buffer, 0);
            int intguid = int.Parse(newguid.ToString().Substring(0, 8));
            Random rand = new Random(intguid);
            
            if (RoateValue > 0)
            {
                RoateValue = -rand.Next(5);
            }
            else
            {
                RoateValue = rand.Next(5);
            }


            Dispatcher.Invoke(new Action(delegate
            {
                DoubleAnimation roate = new DoubleAnimation();
                
                //roate.RepeatBehavior = RepeatBehavior.Forever;
                //roate.FillBehavior = FillBehavior.HoldEnd;
                //roatetimer.Start();
                time_step++;
                if (time_step % 1 == 0)
                {
                    roate.From = 0;
                    roate.To = RoateValue;
                    roate.Duration = TimeSpan.FromSeconds(0.5);
                }
                 if(time_step%5 == 0)
                {
                    roate.From = 0;
                    roate.To = -360;
                    roate.Duration = TimeSpan.FromSeconds(0.5);
                    //sunshine();
                }
                 if (time_step > 10)
                {
                    time_step = 0;
                    sunshine();
                    
                }
                
                rotate.BeginAnimation(AxisAngleRotation3D.AngleProperty, roate);
            }));



            timer.Interval = rand.Next(1000, 2000);

            //follow_move();
        }


        private void follow_move()
        {
            Dispatcher.Invoke(new Action(delegate
            {
                for (int i = 0; i < PublicClass.Offset_List.Count; i++)
                {
                    if (PublicClass.Offset_List[i].uuid == guid && (PublicClass.Offset_List[i].offset.X != offset.OffsetX || PublicClass.Offset_List[i].offset.Y != offset.OffsetY))
                    {

                        DoubleAnimation offX = new DoubleAnimation();
                        offX.To = PublicClass.Offset_List[i].offset.X;
                        offX.Duration = TimeSpan.FromSeconds(1);
                        offset.BeginAnimation(TranslateTransform3D.OffsetXProperty, offX);
                        DoubleAnimation offY = new DoubleAnimation();
                        offY.To = PublicClass.Offset_List[i].offset.Y;
                        offY.Duration = TimeSpan.FromSeconds(1);
                        offset.BeginAnimation(TranslateTransform3D.OffsetYProperty, offY);
                        DoubleAnimation roate = new DoubleAnimation();
                        roate.From = 0;
                        roate.To = -360;
                        roate.Duration = TimeSpan.FromSeconds(1);
                        rotate.BeginAnimation(AxisAngleRotation3D.AngleProperty, roate);
                    }
                }
            }));
        }


        private void sunshine()
        {
            DoubleAnimation an1 = new DoubleAnimation();
            an1.From = -1;
            an1.To = 2;
            an1.Duration = TimeSpan.FromSeconds(10);
            s1.BeginAnimation(GradientStop.OffsetProperty, an1);

            DoubleAnimation an2 = new DoubleAnimation();
            an2.From = -0.5;
            an2.To = 2.5;
            an2.Duration = TimeSpan.FromSeconds(10);
            s2.BeginAnimation(GradientStop.OffsetProperty, an2);

            DoubleAnimation an3 = new DoubleAnimation();
            an3.From = 0;
            an3.To = 3;
            an3.Duration = TimeSpan.FromSeconds(10);
            s3.BeginAnimation(GradientStop.OffsetProperty, an3);

            //DoubleAnimation an4 = new DoubleAnimation();
            //an4.From = -0.7;
            //an4.To = 2.3;
            //an4.Duration = TimeSpan.FromSeconds(10);
            //s4.BeginAnimation(GradientStop.OffsetProperty, an4);

            //DoubleAnimation an5 = new DoubleAnimation();
            //an5.From = -0.5;
            //an5.To = 2.5;
            //an5.Duration = TimeSpan.FromSeconds(10);
            //s5.BeginAnimation(GradientStop.OffsetProperty, an5);

            //DoubleAnimation an6 = new DoubleAnimation();
            //an6.From = -0.3;
            //an6.To = 2.7;
            //an6.Duration = TimeSpan.FromSeconds(10);
            //s6.BeginAnimation(GradientStop.OffsetProperty, an6);
            
        }


        private void picturename_Initialized(object sender, EventArgs e)
        {
            
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            byte[] buffer = Guid.NewGuid().ToByteArray();
            Int64 newguid = BitConverter.ToInt64(buffer, 0);
            int intguid = int.Parse(newguid.ToString().Substring(0, 8));
            Random rand = new Random(intguid);

            timer.Interval = rand.Next(500,5000);
            RoateValue = rand.Next(-5, 5);
            timer.Start();

            roatetimer.Elapsed += new ElapsedEventHandler(roatetimer_Elapsed);
            roatetimer.Interval = rand.Next(4000, 6000);
            //roatetimer.Start();
        }

        void roatetimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            Int64 newguid = BitConverter.ToInt64(buffer, 0);
            int intguid = int.Parse(newguid.ToString().Substring(0, 8));
            Random rand = new Random(intguid);
            //roatetimer.Interval = rand.Next(4000, 6000);
            Dispatcher.Invoke(new Action(delegate
            {
                DoubleAnimation roate = new DoubleAnimation();
                roate.Duration = TimeSpan.FromSeconds(1);
                //roate.RepeatBehavior = RepeatBehavior.Forever;
                //roate.FillBehavior = FillBehavior.HoldEnd;
                //roatetimer.Start();
                    roate.To = -360;
                rotate.BeginAnimation(AxisAngleRotation3D.AngleProperty, roate);
            }));
        }

        private void picturename_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            //RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(this, e);
            //args.RoutedEvent = ViewportCtl.ImageManipulationCompletedEvent;
            //this.RaiseEvent(args);
            //MainWindow.follow(this);
            //TranslateTransform3D tem_offset = (TranslateTransform3D)sender;
            for (int i = 0; i < PublicClass.Offset_List.Count; i++)
            {
                if (PublicClass.Offset_List[i].offset.X != offset.OffsetX || PublicClass.Offset_List[i].offset.Y != offset.OffsetY)
                {
                    double xishu = 0.16d * Math.Pow(PublicClass.Offset_List[i].offset.Z, 2) + 10.2d * PublicClass.Offset_List[i].offset.Z + 232d;
                    PublicClass.Offset_List[i].offset.X += PublicClass.Offset_move.X / xishu;
                    PublicClass.Offset_List[i].offset.Y -= PublicClass.Offset_move.Y / xishu;
                }
            }

           

        }

        private void picturename_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            //picturename.Margin = new Thickness(picturename.Margin.Left + e.DeltaManipulation.Translation.X, picturename.Margin.Top + e.DeltaManipulation.Translation.Y, 0, 0);
            double xishu = 0.16d * Math.Pow(offset.OffsetZ, 2) + 10.2d * offset.OffsetZ + 232d;
            offset.OffsetX += e.DeltaManipulation.Translation.X / xishu;
            offset.OffsetY -= e.DeltaManipulation.Translation.Y / xishu;

            PublicClass.Offset_move.X += e.DeltaManipulation.Translation.X;
            PublicClass.Offset_move.Y += e.DeltaManipulation.Translation.Y;
            //RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(this, e);
            //args.RoutedEvent = ViewportCtl.ImageManipulationDeltaEvent;
            //this.RaiseEvent(args);
        }

        private void picturename_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            PublicClass.Offset_move.X = 0;
            PublicClass.Offset_move.Y = 0;
            //MainWindow mainwindow = MainWindow.FindChild<MainWindow>(Application.Current.MainWindow, "mainwindow");
            Viewport3D v3d = MainWindow.FindChild<Viewport3D>(Application.Current.MainWindow, "viewconter");
            //MessageBox.Show("begin");
            //if (mainwindow != null)
            //{
            //    MessageBox.Show("movestart");
                //e.ManipulationContainer;
            e.ManipulationContainer = v3d;
                e.Mode = ManipulationModes.All;
            
            //}
            //RoutedPropertyChangedEventArgs<object> args = new RoutedPropertyChangedEventArgs<object>(this, e);
            //args.RoutedEvent = ViewportCtl.ImageManipulationStartingEvent;
            //this.RaiseEvent(args);

        }

        private void picturename_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Viewport3D maincanvas = MainWindow.GetParentObject<Viewport3D>(this);
            //MainWindow main = MainWindow.FindChild<MainWindow>(Application.Current.MainWindow, "mainwindow");
            
            //int v;
        }

        private void picturename_PreviewTouchDown(object sender, TouchEventArgs e)
        {
           
        }

        private void picturename_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Viewport3D v3d = MainWindow.FindChild<Viewport3D>(Application.Current.MainWindow, "viewconter");
            {
                if (v3d != null)
                {
                    oldpoint = e.GetPosition(v3d);
                }
            }
        }

        private void picturename_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Viewport3D v3d = MainWindow.FindChild<Viewport3D>(Application.Current.MainWindow, "viewconter");
                double xishu = 0.16d * Math.Pow(offset.OffsetZ, 2) + 10.2d * offset.OffsetZ + 232d;
                offset.OffsetX += (e.GetPosition(v3d).X-oldpoint.X) / xishu/50d;
                offset.OffsetY -= (e.GetPosition(v3d).Y-oldpoint.Y) / xishu/50d;

                PublicClass.Offset_move.X += e.GetPosition(v3d).X;
                PublicClass.Offset_move.Y += e.GetPosition(v3d).Y;


                //offset.OffsetX+=e.GetPosition()


            }
        }

        private void picturename_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(this.Name.ToString() + ",offx=" + offset.OffsetX + ",offy=" + offset.OffsetY);
        }




    }
}
