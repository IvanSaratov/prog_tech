using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes; // список объектов на рисунке
        private Shape selectedShape; // выбранный пользователем объект
        private Point lastMousePosition; // последняя позиция мыши
        public Form1()
        {
            InitializeComponent();
            InitializeShapes();
        }

        private void InitializeShapes()
        {
            shapes = new List<Shape>();

            // создаем различные объекты и добавляем их в список
            shapes.Add(new Line(100, 100, 200, 200, Color.Red, DashStyle.Solid));
            shapes.Add(new RectangleShape(300, 100, 200, 150, Color.Blue, DashStyle.Dash));
            shapes.Add(new Ellipse(500, 100, 150, 150, Color.Green, DashStyle.Dot));
            shapes.Add(new Polygon(new Point(700, 100), new Point(800, 200), new Point(900, 100), Color.Orange, DashStyle.DashDot));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // отрисовываем каждый объект на форме
            foreach (Shape shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // изменяем размер и поворачиваем объект, если он выбран
            if (selectedShape != null)
            {
                if (e.KeyCode == Keys.Up)
                {
                    selectedShape.Resize(1.1f);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    selectedShape.Resize(0.9f);
                }

                this.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // снимаем выбор с объекта
            selectedShape = null;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // перемещаем объект, если он выбран
            if (selectedShape != null)
            {
                int dx = e.X - lastMousePosition.X;
                int dy = e.Y - lastMousePosition.Y;
                selectedShape.Move(dx, dy);
                lastMousePosition = e.Location;
                this.Invalidate();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // проверяем, был ли щелчок мыши на объекте
            foreach (Shape shape in shapes)
            {
                if (shape.Contains(e.Location))
                {
                    selectedShape = shape;
                    lastMousePosition = e.Location;
                    break;
                }
            }
        }
    }

    public abstract class Shape
    {
        protected GraphicsPath path;
        protected Pen pen;
        protected Brush brush;

        public Shape(Color color, DashStyle dashStyle)
        {
            pen = new Pen(color, 2);
            pen.DashStyle = dashStyle;
            brush = new SolidBrush(color);
        }

        public abstract void Draw(Graphics g);
        public abstract bool Contains(Point point);
        public abstract void Move(int dx, int dy);
        public abstract void Resize(float factor);
    }

    public class Line : Shape
    {
        private Point startPoint;
        private Point endPoint;

        public Line(int startX, int startY, int endX, int endY, Color color, DashStyle dashStyle) : base(color, dashStyle)
        {
            startPoint = new Point(startX, startY);
            endPoint = new Point(endX, endY);
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(pen, startPoint, endPoint);
        }

        public override bool Contains(Point point)
        {
            return false; // линии не содержат точки
        }

        public override void Move(int dx, int dy)
        {
            startPoint.X += dx;
            startPoint.Y += dy;
            endPoint.X += dx;
            endPoint.Y += dy;
        }

        public override void Resize(float factor)
        {
            // линии не изменяют размер
        }
    }

    public class RectangleShape : Shape
    {
        private Rectangle rectangle;

        public RectangleShape(int x, int y, int width, int height, Color color, DashStyle dashStyle) : base(color, dashStyle)
        {
            rectangle = new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(pen, rectangle);
            g.FillRectangle(brush, rectangle);
        }

        public override bool Contains(Point point)
        {
            return rectangle.Contains(point);
        }

        public override void Move(int dx, int dy)
        {
            rectangle.X += dx;
            rectangle.Y += dy;
        }

        public override void Resize(float factor)
        {
            rectangle.Width = (int)(rectangle.Width * factor);
            rectangle.Height = (int)(rectangle.Height * factor);
        }
    }

    public class Ellipse : Shape
    {
        private Rectangle ellipse;

        public Ellipse(int x, int y, int width, int height, Color color, DashStyle dashStyle) : base(color, dashStyle)
        {
            ellipse = new Rectangle(x, y, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(pen, ellipse);
            g.FillEllipse(brush, ellipse);
        }

        public override bool Contains(Point point)
        {
            return ellipse.Contains(point);
        }

        public override void Move(int dx, int dy)
        {
            ellipse.X += dx;
            ellipse.Y += dy;
        }

        public override void Resize(float factor)
        {
            ellipse.Width = (int)(ellipse.Width * factor);
            ellipse.Height = (int)(ellipse.Height * factor);
        }
    }

    public class Polygon : Shape
    {
        private Point[] points;

        public Polygon(Point point1, Point point2, Point point3, Color color, DashStyle dashStyle) : base(color, dashStyle)
        {
            points = new Point[] { point1, point2, point3 };
        }

        public override void Draw(Graphics g)
        {
            g.DrawPolygon(pen, points);
            g.FillPolygon(brush, points);
        }

        public override bool Contains(Point point)
        {
            return false; // многоугольники не содержат точки
        }

        public override void Move(int dx, int dy)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X += dx;
                points[i].Y += dy;
            }
        }

        public override void Resize(float factor)
        {
            // многоугольники не изменяют размер
        }

        private bool IsPointInPolygon(Point point, Point[] polygon)
        {
            bool isInside = false;
            int count = polygon.Length;

            for (int i = 0, j = count - 1; i < count; j = i++)
            {
                if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                    (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
                {
                    isInside = !isInside;
                }
            }

            return isInside;
        }
    }
}
