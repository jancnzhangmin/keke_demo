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

namespace 防空
{
    /// <summary>
    /// Sunshine2D.xaml 的交互逻辑
    /// </summary>
    public partial class Sunshine2D : UserControl
    {
        public Sunshine2D()
        {
            InitializeComponent();
        }

        Timer timer = new Timer();
        double scale = 1;


        public void set_sunshine(int line)
        {
            picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"sunshine\s" + line + ".png", UriKind.RelativeOrAbsolute));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //BitmapImage bitimg = new BitmapImage();
            //byte[] buffer = Guid.NewGuid().ToByteArray();
            //Int64 newguid = BitConverter.ToInt64(buffer, 0);
            //int intguid = int.Parse(newguid.ToString().Substring(0, 8));
            //Random rand = new Random(intguid);
            //int myrand = rand.Next(1, 8);
            //bitimg.BeginInit();
            //bitimg.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"sunshine\s" + myrand + ".png", UriKind.RelativeOrAbsolute);
            //bitimg.EndInit();
            //picturename.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"sunshine\s" + myrand + ".png", UriKind.RelativeOrAbsolute));
            ////double c = bitimg.Width;
            //picturename.Width = bitimg.Width;
            //picturename.Height = bitimg.Height;
            timer.Interval = 3000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            change_image();
            
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            Int64 newguid= BitConverter.ToInt64(buffer, 0);
            int intguid =int.Parse( newguid.ToString().Substring(0, 8));
            Random rand = new Random(intguid);
            scale = rand.Next(5, 20) / 10d;
            change_image();
            timer.Stop();
            timer.Interval = rand.Next(2000, 3000);
            timer.Start();
        }

        private void change_image()
        {
            Dispatcher.Invoke(new Action(delegate
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                Int64 newguid = BitConverter.ToInt64(buffer, 0);
                int intguid = int.Parse(newguid.ToString().Substring(0, 8));
                Random rand = new Random(intguid);


                DoubleAnimation opt = new DoubleAnimation();
                opt.To = (double)rand.Next(0,100)/100d;
                opt.Duration = TimeSpan.FromSeconds(rand.Next(1,5));
                picturename.BeginAnimation(Image.OpacityProperty, opt);

                DoubleAnimation wid = new DoubleAnimation();
                //wid.From = 600;
                wid.To = 600d * scale;
                wid.Duration = TimeSpan.FromSeconds(5);

                //wid.FillBehavior = FillBehavior.HoldEnd;
                //wid.RepeatBehavior = RepeatBehavior.Forever;
               
                DoubleAnimation hei = new DoubleAnimation();
                //hei.From = 30;
                hei.To = 30d * scale*5;
                hei.Duration = TimeSpan.FromSeconds(5);
                //hei.FillBehavior = FillBehavior.HoldEnd;
                //hei.RepeatBehavior = RepeatBehavior.Forever;
                
                //if (picturename.Opacity<0.005)
                //{
                    //picturename.BeginAnimation(Image.WidthProperty, wid);
                    //picturename.BeginAnimation(Image.HeightProperty, hei);


                    DoubleAnimation scanX = new DoubleAnimation();
                    scanX.To = scale;
                    scanX.Duration = TimeSpan.FromSeconds(5);
                    //scal.BeginAnimation(ScaleTransform.ScaleXProperty, scanX);

                    DoubleAnimation scanY = new DoubleAnimation();
                    scanY.To = scale;
                    scanY.Duration = TimeSpan.FromSeconds(5);
                    //scal.BeginAnimation(ScaleTransform.ScaleYProperty, scanY);

                //}

            }));
        }

    }
}
