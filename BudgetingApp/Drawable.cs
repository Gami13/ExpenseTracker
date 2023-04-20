using System.Diagnostics;

namespace BudgetingApp
{
    public class Drawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF rect)
        {
            float CANVAS_HEIGHT = rect.Height;
            float CANVAS_WIDTH = rect.Width;
            canvas.DrawLine(5, 0, 5, CANVAS_HEIGHT - 5);
            canvas.DrawLine(5, CANVAS_HEIGHT - 5, CANVAS_WIDTH - 5, CANVAS_HEIGHT - 5);
            float MAX_COST = (float)Math.Round(Database.shoppingTrips.Max(x => x.Price) / 100, 2) * 100;
            float MAX_AGO = Database.shoppingTrips.Max(x => DateTime.Now.Subtract(x.Date).Days);
            float COST_UNIT = MAX_COST / 10;
            float HEIGHT_UNIT = (CANVAS_HEIGHT - 20) / 10;
            float TIME_UNIT = MAX_AGO / (float)Math.Round(CANVAS_WIDTH / (HEIGHT_UNIT * 2));
            float COST_SCALE = (CANVAS_HEIGHT - 10) / MAX_COST;
            float DAY_SCALE = (CANVAS_WIDTH - 10) / MAX_AGO;

            Debug.WriteLine($"SCALE COST:{COST_SCALE}, DAY: {DAY_SCALE}");

            //HORIZONTAL LINES
            canvas.StrokeColor = Colors.LightGray;
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 2, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 2);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 3, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 3);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 4, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 4);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 5, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 5);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 6, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 6);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 7, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 7);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 8, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 8);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 9, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 9);
            canvas.DrawLine(10, CANVAS_HEIGHT - HEIGHT_UNIT * 10, CANVAS_WIDTH - 5, CANVAS_HEIGHT - HEIGHT_UNIT * 10);


            //VERTICAL LINES
            canvas.DrawLine(HEIGHT_UNIT, CANVAS_HEIGHT - 5, HEIGHT_UNIT, -5);
            canvas.DrawLine(HEIGHT_UNIT * 3, CANVAS_HEIGHT - 5, HEIGHT_UNIT * 3, -5);
            canvas.DrawLine(HEIGHT_UNIT * 5, CANVAS_HEIGHT - 5, HEIGHT_UNIT * 5, -5);
            canvas.DrawLine(HEIGHT_UNIT * 7, CANVAS_HEIGHT - 5, HEIGHT_UNIT * 7, -5);
            canvas.DrawLine(HEIGHT_UNIT * 9, CANVAS_HEIGHT - 5, HEIGHT_UNIT * 9, -5);
            canvas.DrawLine(HEIGHT_UNIT * 11, CANVAS_HEIGHT - 5, HEIGHT_UNIT * 11, -5);


            canvas.StrokeColor = Colors.DarkGray;
            //Y AXIS DESCRIPTIOM
            canvas.DrawString(Math.Round(COST_UNIT).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((2 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 2 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((3 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 3 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((4 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 4 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((5 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 5 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((6 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 6 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((7 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 7 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((8 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 8 - 5, HorizontalAlignment.Left);
            canvas.DrawString(Math.Round((9 * COST_UNIT), 2).ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 9 - 5, HorizontalAlignment.Left);
            canvas.DrawString(MAX_COST.ToString(), 10, CANVAS_HEIGHT - HEIGHT_UNIT * 10 - 5, HorizontalAlignment.Left);
            //X AXIS DESCRIPTION

            canvas.DrawString($"-{MAX_AGO} days", HEIGHT_UNIT, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);
            canvas.DrawString($"-{Math.Round(MAX_AGO - TIME_UNIT)} days", HEIGHT_UNIT * 3, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);
            canvas.DrawString($"-{Math.Round(MAX_AGO - TIME_UNIT * 2)} days", HEIGHT_UNIT * 5, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);
            canvas.DrawString($"-{Math.Round(MAX_AGO - TIME_UNIT * 3)} days", HEIGHT_UNIT * 7, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);
            canvas.DrawString($"-{Math.Round(MAX_AGO - TIME_UNIT * 4)} days", HEIGHT_UNIT * 9, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);
            canvas.DrawString($"-{Math.Round(MAX_AGO - TIME_UNIT * 5)} days", HEIGHT_UNIT * 11, CANVAS_HEIGHT - 10, HorizontalAlignment.Justified);

            List<PointF> p = new List<PointF>();


            Database.shoppingTrips.ForEach(x =>
            {
                PointF point = new PointF(CANVAS_WIDTH - (DateTime.Now.Subtract(x.Date).Days * DAY_SCALE) + HEIGHT_UNIT - 8, CANVAS_HEIGHT - (float)x.Price * COST_SCALE);
                p.Add(point);
                Debug.WriteLine($"Point{point.ToString()}, Price: {x.Price}, Date: {x.Date}");
            });
            PathF path = new PathF();

            p.Sort(delegate (PointF a, PointF b)
            {
                return a.X.CompareTo(b.X);
            });

            path.MoveTo(p[0]);

            p.ForEach(x =>
            {
                Debug.WriteLine($"point {x.ToString()}");
            });

            canvas.StrokeSize = 4;
            canvas.StrokeColor = Colors.Red;

            for (int i = 0; i < p.Count - 1; i++) //properly draws points :D
            {
                float len = (float)Math.Sqrt((p[i + 1].X - p[i].X) * (p[i + 1].X - p[i].X) + (p[i + 1].Y - p[i].Y) * (p[i + 1].Y - p[i].Y));


                path.CurveTo(p[i], p[i], p[i + 1]);
                path.MoveTo(p[i + 1]);
                canvas.DrawCircle(p[i].X, p[i].Y, 3);
                canvas.DrawCircle(p[i + 1].X, p[i + 1].Y, 3);

            }



            path.MoveTo(p[p.Count - 1]);

            path.Close();



            canvas.DrawPath(path);
        }
    }
}
