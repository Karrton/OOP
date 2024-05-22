using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warcraft
{
    partial class Game : System.Windows.Forms.Form
    {
        private Map map;
        private Random random;
        private TownHall hall;
        private Mine mine;
        List<Unit> unitList;
        private System.Windows.Forms.Timer timer;
        private Bitmap mapBitmap;
        Thread[] thread;

        public Game()
        {
            InitializeComponent();
            int width, height;
            width = 800;
            height = 800;
            int countUnit = 6;
            random = new Random();

            hall = new TownHall(new Point(), random.Next(3000, 5000));
            map = new Map(width, height);
            mine = new Mine(new Point(), random.Next(800, 2000));
            unitList = new List<Unit>();

            map.GenerateMap(800f);
            mapBitmap = map.CreateMapBitmap();
            mine.GenerateMines(5, random.Next(800, 2000), map.heightMap);
            hall.GenerateTownHall(map.heightMap, width, height, random.Next(3000, 5000), random);
            for (int i = 0; i < countUnit; i++)
                unitList.Add(new Unit(hall.Position, 5, 100));

            Thread[] threads = new Thread[countUnit];

            for (int i = 0; i < countUnit; i++)
            {
                int index = i;
                threads[i] = new Thread(() => Move(unitList[index], mine.GetMines(), hall, map.heightMap));
                threads[i].Start();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            e.Graphics.DrawImage(mapBitmap, new Point(0, 0));
            mine.Draw(g);
            hall.Draw(g);

            foreach (Unit unit in unitList)
            {
                unit.Draw(g);
            }
        }

        public void Move(Unit unit, List<Mine> mines, TownHall hall, float[,] heightMap)
        {
            while (mine.GetMines().Count != 0)
            {
                unit.CurrentMine = unit.GetRandomMine(mines);
                if (unit.currentCarryingWeight == 0)
                {
                    List<Point> pathToMine = unit.FindPathTo(unit.CurrentMine.Location, heightMap);
                    if (pathToMine != null && pathToMine.Count > 0)
                    {
                        // Перемещаемся к шахте
                        foreach (Point point in pathToMine)
                        {
                            unit.position = point;
                            BeginInvoke((Action)(() => Invalidate())); // Обновляем UI
                            Thread.Sleep(10); // Даем небольшую паузу
                        }

                        unit.IsInsideMine = true;

                        // Добываем золото, пока не наберем максимальную грузоподъемность
                        while (unit.currentCarryingWeight < unit.maxCarryingCapacity)
                        {
                            unit.currentCarryingWeight += unit.CurrentMine.MineGold(unit.ToMine(10, 30));
                            Thread.Sleep(100); // Даем небольшую паузу
                        }

                        unit.IsInsideMine = false;

                        // После добычи идем к базе
                        List<Point> pathToHall = unit.FindPathTo(hall.Position, heightMap);
                        if (pathToHall != null && pathToHall.Count > 0)
                        {
                            foreach (Point point in pathToHall)
                            {
                                unit.position = point;
                                BeginInvoke((Action)(() => Invalidate())); // Обновляем UI
                                Thread.Sleep(10); // Даем небольшую паузу
                            }
                            unit.currentCarryingWeight = 0;
                        }
                    }
                }
                else
                {
                    // Если есть груз, идем на базу
                    List<Point> pathToHall = unit.FindPathTo(hall.Position, heightMap);
                    if (pathToHall != null && pathToHall.Count > 0)
                    {
                        unit.IsInsideMine = true;
                        foreach (Point point in pathToHall)
                        {
                            unit.position = point;
                            BeginInvoke((Action)(() => Invalidate())); // Обновляем UI
                            Thread.Sleep(2000); // Даем небольшую паузу
                        }
                        unit.IsInsideMine = false;
                        unit.currentCarryingWeight = 0;
                    }
                }
            }
        }


        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Unit.DisposeUnitImage();
                Mine.DisposeMineImage();
                TownHall.DisposehallImage();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(816, 839);
            this.Text = "Warcraft";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.components = new System.ComponentModel.Container();
        }
        #endregion
    }
}
