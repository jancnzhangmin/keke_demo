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
using System.Timers;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace 防空
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
        }
        Timer timer = new Timer();
        Timer initTimer = new Timer();
        int initValue = 0;
        Point oldpoint = new Point();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {





            //            <TextBlock  Text="人民防空知识" FontSize="90" Foreground="Red"  FontFamily="Arial Unicode MS" Margin="560,400,0,0" Opacity="1">
                
            //                        <TextBlock.Effect>
            //            <DropShadowEffect Color="White" Direction="0" BlurRadius="10" ShadowDepth="0"></DropShadowEffect>
            //        </TextBlock.Effect>
            //</TextBlock>
            //for(int i=0;i<1;i++)
            //{
            //    TextBlock txt = new TextBlock();
            //    txt.Text = "人民防空知识";
            //    txt.FontSize=90;
            //    txt.Foreground = Brushes.Red;
            //    txt.Margin = new Thickness(560, 400, 0, 0);
            //    txt.FontFamily = new FontFamily("华文中宋");
            //    //TextEffect eff = new TextEffect();
            //    //DropShadowBitmapEffect eff = new DropShadowBitmapEffect();
            //    DropShadowEffect eff = new DropShadowEffect();
            //    eff.Direction = 0;
            //    eff.ShadowDepth = 0;
            //    eff.Color = Colors.White;
            //    eff.BlurRadius=5;
            //    txt.Effect = eff;
            //    maincanvas.Children.Add(txt);
            //    //txt.FontFamily = FontFamily.FamilyNames.Add("Arial Unicode MS")

            //}


            flay();
            initTimer.Interval = 1000;
            initTimer.Elapsed += new ElapsedEventHandler(initTimer_Elapsed);
            initTimer.Start();
            sunshine();
            
            BitmapImage bitimg = new BitmapImage();
            PublicClass.Offset.Add(new Point3D(-2.9, -1, -5));
            PublicClass.Offset.Add(new Point3D(-4.5, 0, -10));
            PublicClass.Offset.Add(new Point3D(-8.2, -0.2, -20));
            PublicClass.Offset.Add(new Point3D(-7.8, -2.6, -20));
            PublicClass.Offset.Add(new Point3D(-6.5, 0.8, -30));
            PublicClass.Offset.Add(new Point3D(-4.4, -1.3, -20));


            PublicClass.Offset_Sin offset_sin1 = new PublicClass.Offset_Sin();
            offset_sin1.offset = new Point3D(-2.9, -1, -5);
            PublicClass.Offset_Sin offset_sin2 = new PublicClass.Offset_Sin();
            offset_sin2.offset = new Point3D(-4.5, 0, -10);
            PublicClass.Offset_Sin offset_sin3 = new PublicClass.Offset_Sin();
            offset_sin3.offset = new Point3D(-8.2, -0.2, -20);
            PublicClass.Offset_Sin offset_sin4 = new PublicClass.Offset_Sin();
            offset_sin4.offset = new Point3D(-7.8, -2.6, -20);
            PublicClass.Offset_Sin offset_sin5 = new PublicClass.Offset_Sin();
            offset_sin5.offset = new Point3D(-6.5, 0.8, -30);
            PublicClass.Offset_Sin offset_sin6 = new PublicClass.Offset_Sin();
            offset_sin6.offset = new Point3D(-4.4, -1.3, -20);
            //offset_sin1

            ViewportCtl view1 = new ViewportCtl();
            Point3D p1 = new Point3D(0, 1, -0.01);
            Point3D p2 = new Point3D(-1, -1, -0.01);
            Point3D p3 = new Point3D(1, -1, -0.01);
            Point3D p4 = new Point3D(0, 1, -0.01);

            view1.Name = "view1";
            view1.mesh.Positions.Clear();
            view1.mesh.Positions.Add(p1);
            view1.mesh.Positions.Add(p2);
            view1.mesh.Positions.Add(p3);
            view1.mesh.Positions.Add(p4);
            view1.offset.OffsetX = -2.9;
            view1.offset.OffsetY = -1;
            view1.offset.OffsetZ = -5;
            view1.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\99式主战坦克.jpg", UriKind.RelativeOrAbsolute));
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\99式主战坦克.jpg", UriKind.RelativeOrAbsolute);
            bitimg.EndInit();
            //view1.rect.Width = bitimg.PixelWidth;
            //view1.rect.Height = bitimg.PixelHeight;
            //view1.picturename.Width = bitimg.PixelWidth;
            //view1.picturename.Height = bitimg.PixelHeight;
            //view1.IsManipulationEnabled = true;
            view1.IsManipulationEnabled = true;
            view1.ManipulationStarting += new EventHandler<ManipulationStartingEventArgs>(view_ManipulationStarting);
            view1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(view_ManipulationDelta);
            view1.MouseDown += new MouseButtonEventHandler(view1_MouseDown);
            view1.PreviewMouseDown += new MouseButtonEventHandler(view_PreviewMouseDown);
            //view1.ImageManipulationStarting += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationStarting);
            //view1.ImageManipulationDelta += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationDelta);
            //view1.ImageManipulationCompleted += new RoutedPropertyChangedEventHandler<object>(view_ImageManipulationCompleted);
            offset_sin1.uuid = view1.guid;
            viewconter.Children.Add(view1.viewport);

            ViewportCtl view2 = new ViewportCtl();
            view2.Name = "view2";
            p1 = new Point3D(-1, 1, -0.01);
            p2 = new Point3D(0, -1, -0.01);
            p3 = new Point3D(0, -1, -0.01);
            p4 = new Point3D(1, 1, -0.01);
            view2.mesh.Positions.Clear();
            view2.mesh.Positions.Add(p1);
            view2.mesh.Positions.Add(p2);
            view2.mesh.Positions.Add(p3);
            view2.mesh.Positions.Add(p4);
            view2.offset.OffsetX = -4.5;
            view2.offset.OffsetY = 0;
            view2.offset.OffsetZ = -10;
            view2.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\09IV战略导弹核潜艇.jpg", UriKind.RelativeOrAbsolute));
            offset_sin2.uuid = view2.guid;
            viewconter.Children.Add(view2.viewport);

            ViewportCtl view3 = new ViewportCtl();
            view3.Name = "view3";
            p1 = new Point3D(0, 1, -0.01);
            p2 = new Point3D(-1, -1, -0.01);
            p3 = new Point3D(1, -1, -0.01);
            p4 = new Point3D(0, 1, -0.01);
            view3.mesh.Positions.Clear();
            view3.mesh.Positions.Add(p1);
            view3.mesh.Positions.Add(p2);
            view3.mesh.Positions.Add(p3);
            view3.mesh.Positions.Add(p4);
            view3.offset.OffsetX = -8.2;
            view3.offset.OffsetY = -0.2;
            view3.offset.OffsetZ = -20;
            view3.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\10月14日11时25分，中国在太原卫星发射中心用“长征二号丙”运载火箭，以”一箭双星“方式，成功将“实践九号”AB卫星发射升空并送入预定转移轨道。这是中国“长征”系列运载火箭第169次航天发射。.jpg", UriKind.RelativeOrAbsolute));
            offset_sin3.uuid = view3.guid;
            viewconter.Children.Add(view3.viewport);



            ViewportCtl view4 = new ViewportCtl();
            view4.Name = "view4";
            p1 = new Point3D(-1, 1, -0.01);
            p2 = new Point3D(0, -1, -0.01);
            p3 = new Point3D(0, -1, -0.01);
            p4 = new Point3D(1, 1, -0.01);
            view4.mesh.Positions.Clear();
            view4.mesh.Positions.Add(p1);
            view4.mesh.Positions.Add(p2);
            view4.mesh.Positions.Add(p3);
            view4.mesh.Positions.Add(p4);
            view4.offset.OffsetX = -7.8;
            view4.offset.OffsetY = -2.6;
            view4.offset.OffsetZ = -20;
            view4.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\25_153085_7b996e5356a307b.jpg", UriKind.RelativeOrAbsolute));
            offset_sin4.uuid = view4.guid;
            viewconter.Children.Add(view4.viewport);

            ViewportCtl view5 = new ViewportCtl();
            view5.Name = "view5";
            p1 = new Point3D(0, 1, -0.01);
            p2 = new Point3D(-1, -1, -0.01);
            p3 = new Point3D(1, -1, -0.01);
            p4 = new Point3D(0, 1, -0.01);
            view5.mesh.Positions.Clear();
            view5.mesh.Positions.Add(p1);
            view5.mesh.Positions.Add(p2);
            view5.mesh.Positions.Add(p3);
            view5.mesh.Positions.Add(p4);
            view5.offset.OffsetX = -6.5;
            view5.offset.OffsetY = 0.8;
            view5.offset.OffsetZ = -30;
            view5.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\051C驱逐舰首舰“沈阳”号.jpg", UriKind.RelativeOrAbsolute));
            offset_sin5.uuid = view5.guid;
            viewconter.Children.Add(view5.viewport);

            ViewportCtl view6 = new ViewportCtl();
            view6.Name = "view6";
            p1 = new Point3D(-1, 1, -0.01);
            p2 = new Point3D(0, -1, -0.01);
            p3 = new Point3D(0, -1, -0.01);
            p4 = new Point3D(1, 1, -0.01);
            view6.mesh.Positions.Clear();
            view6.mesh.Positions.Add(p1);
            view6.mesh.Positions.Add(p2);
            view6.mesh.Positions.Add(p3);
            view6.mesh.Positions.Add(p4);
            view6.offset.OffsetX = -4.4;
            view6.offset.OffsetY = -1.3;
            view6.offset.OffsetZ = -20;
            view6.picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\054A隐身护卫舰.jpg", UriKind.RelativeOrAbsolute));
            offset_sin6.uuid = view6.guid;
            viewconter.Children.Add(view6.viewport);

            PublicClass.Offset_List.Add(offset_sin1);
            PublicClass.Offset_List.Add(offset_sin2);
            PublicClass.Offset_List.Add(offset_sin3);
            PublicClass.Offset_List.Add(offset_sin4);
            PublicClass.Offset_List.Add(offset_sin5);
            PublicClass.Offset_List.Add(offset_sin6);

            clouds();
            timer.Interval = 3000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        void view_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("asdf");
        }

        void initTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            initValue++;
            init();
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
                view.picturename.Margin = new Thickness(view.picturename.Margin.Left + e.DeltaManipulation.Translation.X, view.picturename.Margin.Top + e.DeltaManipulation.Translation.Y, 0, 0);
            }
        }

        void view_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {

            e.ManipulationContainer = maincanvas;
            e.Mode = ManipulationModes.All;
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(new Action(delegate
            {
                for (int i = 0; i < maincanvas.Children.Count; i++)
                {
                    Image delimg = maincanvas.Children[i] as Image;
                    if (delimg != null)
                    {
                        if (delimg.Margin.Left < -399)
                        {
                            maincanvas.Children.Remove(delimg);
                            i--;
                        }
                    }
                }
                Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

                int temImageName = rand.Next(1, 50);
                BitmapImage temimg = new BitmapImage();
                temimg.BeginInit();
                temimg.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"clouds\c" + temImageName + ".png", UriKind.RelativeOrAbsolute);
                temimg.EndInit();
                double temwidth = temimg.PixelWidth;
                double temheight = temimg.PixelHeight;
                Image img = new Image();
                //img.BeginInit();
                img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"clouds\c" + temImageName + ".png", UriKind.RelativeOrAbsolute));
                float temrand = float.Parse(rand.Next(1, 5).ToString()) / 15f;
                img.Width = temwidth * temrand;
                img.Height = temheight * temrand;
                img.Margin = new Thickness(1920, rand.Next(500, 1000), 0, 0);
                img.SnapsToDevicePixels = true;
                move_cloud(img, temrand, img.Margin);
                maincanvas.Children.Add(img);
            }));

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

        private void clouds()
        {
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < 50; i++)
            {
                int temImageName = rand.Next(1, 50);
                BitmapImage temimg = new BitmapImage();
                temimg.BeginInit();
                temimg.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"clouds\c" + temImageName + ".png", UriKind.RelativeOrAbsolute);
                temimg.EndInit();
                double temwidth = temimg.PixelWidth;
                double temheight = temimg.PixelHeight;
                Image img = new Image();
                //img.BeginInit();
                img.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"clouds\c" + temImageName + ".png", UriKind.RelativeOrAbsolute));
                float temrand = float.Parse(rand.Next(1, 5).ToString()) / 15f;
                img.Width = temwidth * temrand;
                img.Height = temheight * temrand;
                img.Margin = new Thickness(rand.Next(0, 1920), rand.Next(500, 1000), 0, 0);
                img.SnapsToDevicePixels = true;
                move_cloud(img, temrand, img.Margin);
                maincanvas.Children.Add(img);

            }
        }

        private void init()
        {
            Dispatcher.Invoke(new Action(delegate
            {
                if (initValue > 5)
                {
                    DoubleAnimation rm = new DoubleAnimation();
                    rm.To = 1;
                    rm.Duration = TimeSpan.FromSeconds(5);
                    rm_img.BeginAnimation(TextBlock.OpacityProperty, rm);





                }
                if (initValue > 10)
                {
                    DoubleAnimation ddmt = new DoubleAnimation();
                    ddmt.To = 500;
                    ddmt.Duration = TimeSpan.FromSeconds(3);
                    dmt.BeginAnimation(StackPanel.WidthProperty, ddmt);
                    //initTimer.Stop();
                }



                if (initValue > 15)
                {
                    //Image imgflay = new Image();
                    foreach (var c in maincanvas.Children)
                    {
                        Image imgflay = c as Image;
                         if (imgflay != null)
                         {
                             if (imgflay.Name == "flay")
                             {
                                 //ScaleTransform scal = new ScaleTransform();
                                 //scal.ScaleX = 1;
                                 //scal.ScaleY = 1;

                                 //imgflay.RenderTransform = scal;


                                 //DoubleAnimation scaX = new DoubleAnimation();
                                 //scaX.To = 0.9;
                                 //scaX.Duration = TimeSpan.FromSeconds(1);
                                 //imgflay.BeginAnimation(ScaleTransform.ScaleXProperty, scaX);


                                 //DoubleAnimation win = new DoubleAnimation();
                                 //win.To = imgflay.ActualWidth * 0.9;
                                 //win.Duration = TimeSpan.FromSeconds(1);
                                 //imgflay.BeginAnimation(Image.WidthProperty, win);


                                 ThicknessAnimation anmation = new ThicknessAnimation();
                                 //imgflay.Margin = new Thickness(SystemParameters.WorkArea.Width + 200, 400, 0, 0);
                                 anmation.From = new Thickness(SystemParameters.WorkArea.Width - 650, 30, 0, 0);
                                 anmation.To = new Thickness(SystemParameters.WorkArea.Width - 650-3, 33, 0, 0);
                                 //imgflay.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\flay.png", UriKind.RelativeOrAbsolute));
                                 anmation.Duration = TimeSpan.FromSeconds(1);
                                 anmation.RepeatBehavior = RepeatBehavior.Forever;
                                 anmation.AutoReverse = true;
                                 //anmation.FillBehavior = FillBehavior.HoldEnd;
                                 imgflay.BeginAnimation(Image.MarginProperty, anmation);
                                 initTimer.Stop();
                             }
                         }
                    }
                   // initTimer.Stop();

                }


            }));
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

        private void sunshine()
        {


            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            //for (int i = 0; i < 360; )
            //{
            //    Sunshine shine = new Sunshine();
            //    shine.rotate.Angle = i;
            //    viewconter.Children.Add(shine.viewport);
            //    i += rand.Next(10, 30);
            //}
            for (int i = 0; i < 360; )
            {
                Sunshine2D shine = new Sunshine2D();
                shine.rotate.Angle = i;
                shine.SnapsToDevicePixels = true;

                //shine.Width = 600;
                //shine.Height = 60;
                shine.Margin = new Thickness(945, 180, 0, 0);
                maincanvas.Children.Add(shine);
                i += rand.Next(5, 20);
            }

        }

          private void flay()
        {



            Image imgflay = new Image();
            imgflay.Width = 450;
            imgflay.Height = 450;
            imgflay.Name = "flay";
            imgflay.SnapsToDevicePixels = true;
            imgflay.Margin = new Thickness(SystemParameters.WorkArea.Width+300, 400, 0, 0);
            imgflay.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\flay.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgfaly = new ThicknessAnimation();
            moveimgfaly.To = new Thickness(SystemParameters.WorkArea.Width-650, 30, 0, 0);
            moveimgfaly.Duration = TimeSpan.FromSeconds(15);
            imgflay.BeginAnimation(Image.MarginProperty, moveimgfaly);





            maincanvas.Children.Add(imgflay);



            //中间
            Image imgweiqi = new Image();
            imgweiqi.Opacity = 0.4;
            imgweiqi.SnapsToDevicePixels = true;
            imgweiqi.Margin = new Thickness(SystemParameters.WorkArea.Width+330, 550, 0, 0);//初始位置
            imgweiqi.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\weiqi.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgweiqi = new ThicknessAnimation();
            moveimgweiqi.To = new Thickness(SystemParameters.WorkArea.Width-550, 225, 0, 0);//到达位置
            moveimgweiqi.Duration = TimeSpan.FromSeconds(15);
            imgweiqi.BeginAnimation(Image.MarginProperty, moveimgweiqi);
            maincanvas.Children.Add(imgweiqi);

           // 最上
            Image imgweiqi1 = new Image();
            imgweiqi1.Opacity = 0.3;
            imgweiqi1.SnapsToDevicePixels = true;
            imgweiqi1.Margin = new Thickness(SystemParameters.WorkArea.Width + 390, 500, 0, 0);
            imgweiqi1.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\weiqi.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgweiqi1 = new ThicknessAnimation();
            moveimgweiqi1.To = new Thickness(SystemParameters.WorkArea.Width - 275, 230, 0, 0);
            moveimgweiqi1.Duration = TimeSpan.FromSeconds(15);
            imgweiqi1.BeginAnimation(Image.MarginProperty, moveimgweiqi1);
            maincanvas.Children.Add(imgweiqi1);

            //第二
            Image imgweiqi2 = new Image();
            imgweiqi2.Opacity = 0.25;
            imgweiqi2.SnapsToDevicePixels = true;
            imgweiqi2.Margin = new Thickness(SystemParameters.WorkArea.Width + 450, 520, 0, 0);
            imgweiqi2.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\weiqi.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgweiqi2 = new ThicknessAnimation();
            moveimgweiqi2.To = new Thickness(SystemParameters.WorkArea.Width - 395, 235, 0, 0);
            moveimgweiqi2.Duration = TimeSpan.FromSeconds(15);
            imgweiqi2.BeginAnimation(Image.MarginProperty, moveimgweiqi2);
            maincanvas.Children.Add(imgweiqi2);

            //第四
            Image imgweiqi3 = new Image();
            imgweiqi3.Opacity = 0.2;
            imgweiqi3.SnapsToDevicePixels = true;
            imgweiqi3.Margin = new Thickness(SystemParameters.WorkArea.Width + 350, 627, 0, 0);
            imgweiqi3.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\weiqi.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgweiqi3 = new ThicknessAnimation();
            moveimgweiqi3.To = new Thickness(SystemParameters.WorkArea.Width - 580, 278, 0, 0);
            moveimgweiqi3.Duration = TimeSpan.FromSeconds(15);
            imgweiqi3.BeginAnimation(Image.MarginProperty, moveimgweiqi3);
            maincanvas.Children.Add(imgweiqi3);


            //第五
            Image imgweiqi4 = new Image();
            imgweiqi4.Opacity = 0.2;
            imgweiqi4.SnapsToDevicePixels = true;
            imgweiqi4.Margin = new Thickness(SystemParameters.WorkArea.Width + 309, 679, 0, 0);
            imgweiqi4.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"images\weiqi.png", UriKind.RelativeOrAbsolute));
            ThicknessAnimation moveimgweiqi4 = new ThicknessAnimation();
            moveimgweiqi4.To = new Thickness(SystemParameters.WorkArea.Width - 565, 308, 0, 0);
            moveimgweiqi4.Duration = TimeSpan.FromSeconds(15);
            imgweiqi4.BeginAnimation(Image.MarginProperty, moveimgweiqi4);
            maincanvas.Children.Add(imgweiqi4);

        }

 
    }
}
