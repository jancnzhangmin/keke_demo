using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace 防空
{
    class PublicClass
    {
        public static List<Point3D> Offset = new List<Point3D>();
        public static Point3D Offset_move = new Point3D();
        public  class Offset_Sin
        {
            public  Point3D offset = new Point3D();
            public  string uuid;
        }
        public static List<Offset_Sin> Offset_List = new List<Offset_Sin>();
    }
}
