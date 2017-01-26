﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Zmeika
{
    public partial class Form1 : Form
    {
        public enum Direction
        {
            up,
            down,
            left,
            right,
            none
        };
        Direction dir;
        Direction next_dir = Direction.none;
        int game_points;
        public static List<List<Point>> list;
        Random rnd = new Random();
        Panel food;
        Snake snake;
        Point prev_loc;
        int num_speed;
        DateTime key_down_time;
        bool key_down = false;
        int time_to_fast = 200;
        //bool is_fast = false;
        int min_speed = 1;
        int max_speed = 10;

        public Form1()
        {
            InitializeComponent();
            list = new List<List<Point>>();
            for (int i = 0; i * 10 < zona.Width; i++)
            {
                list.Add(new List<Point>());
                for (int j = 0; j * 10 < zona.Height; j++)
                {
                    list[i].Add(new Point(i * 10, j * 10));
                }
            }
            butstart1.PerformClick();
            //masarray = new Point[list.Count, list[0].Count];
            //for (int i = 0; i < masarray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < masarray.GetLength(1); j++)
            //    {
            //        masarray[i, j] = list[i][j];
            //    }
            //}
        }

        Panel CreateFood(int foodsize)
        {
            Panel food = new Panel();
            int x = rnd.Next(0, zona.Width - foodsize);
            int y = rnd.Next(0, zona.Height - foodsize);
            Point foodlocation = new Point(x - x % foodsize, y - y % foodsize);
            //Point foodlocation = masarray[rnd.Next(masarray.GetLength(0) - 1), rnd.Next(masarray.GetLength(1) - 1)];
            food.Location = foodlocation;
            food.Size = new Size(foodsize, foodsize);
            food.BackColor = Color.Red;
            food.BorderStyle = BorderStyle.FixedSingle;
            return food;
        }
        void GameOver()
        {
            timer.Stop();
            MessageBox.Show("Game Over\nYour points are " + game_points.ToString());
        }
        bool IsEatFood()
        {
            if (snake.segments[0].Location == food.Location)
                return true;
            return false;
        }
        void Slowly()
        {
            snake.Speed -= 2;
        }
        void Faster()
        {
            snake.Speed += 2;
        }

        private void butstart_Click(object sender, EventArgs e)
        {
            zona.Controls.Clear();
            game_points = 0;
            //timer.Stop();
            //if (snake != null)
            //{
            //    for (int i = 0; i < snake.segments.Count; i++)
            //    {
            //        zona.Controls.Remove(snake.segments[i]);
            //    }
            //}
            //zona.Controls.Remove(food);
            dir = Direction.none;
            snake = new Snake(zona, timer);
            prev_loc = snake.segments[0].Location;

            food = CreateFood(Snake.segsize);
            zona.Controls.Add(food);
            butstart1.KeyDown -= new KeyEventHandler(Form1_KeyDown);
            butstart1.KeyUp -= new KeyEventHandler(Form1_KeyUp);
            butstart1.KeyDown += new KeyEventHandler(Form1_KeyDown);
            butstart1.KeyUp += new KeyEventHandler(Form1_KeyUp);
            butstart1.Focus();
            //KeyDown -= new KeyEventHandler(Form1_KeyDown);
            //KeyUp -= new KeyEventHandler(Form1_KeyUp);
            //KeyDown += new KeyEventHandler(Form1_KeyDown);
            //KeyUp += new KeyEventHandler(Form1_KeyUp);

            //bool v = Focus();
            //bool v1 = textBox1.CanFocus;
            //v = textBox1.Focused;

            //this.Focus();
            //v1 = this.CanFocus;
            //v = this.Focused;

            snake.Speed = Convert.ToInt32(tbSpeed.Text) - 1;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            //if (key_down)
            //{
            //    if ((DateTime.Now - key_down_time).Milliseconds > time_to_fast)
            //    {
            //        Faster();
            //        is_fast = true;
            //        key_down = false;
            //    }
            //}
            if (!snake.is_fast && key_down)
            {
                if ((DateTime.Now - key_down_time).Milliseconds > time_to_fast)
                {
                    try { snake.Faster(); }
                    catch { }
                    //Faster();
                    //is_fast = true;
                    //key_down = false;
                }
            }
            if (IsEatFood())
            {
                zona.Controls.Add(snake.CreateSeg(1000, 1000, Snake.segsize, Color.LightGreen));
                zona.Controls.Remove(food);
                food = CreateFood(Snake.segsize);
                zona.Controls.Add(food);
                game_points += 100;
            }
            if (dir != Direction.none)
            {
                snake.Moove(dir);
            }

            if (snake.IsEatMyself() || snake.IsMooveOutOfZona())
            {
                GameOver();
                return;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!key_down)
            {
                Point p = new Point(snake.segments[0].Location.X - prev_loc.X, snake.segments[0].Location.Y - prev_loc.Y);
                Direction prev_dir = Direction.none;
                if (p.X > 0)
                    prev_dir = Direction.right;
                else if (p.X < 0)
                    prev_dir = Direction.left;
                else if (p.Y > 0)
                    prev_dir = Direction.down;
                else if (p.Y < 0)
                    prev_dir = Direction.up;


                if (e.KeyCode == Keys.A && prev_dir != Direction.right)
                {
                    dir = Direction.left;
                }
                else if (e.KeyCode == Keys.D && prev_dir != Direction.left)
                {
                    dir = Direction.right;
                }
                else if (e.KeyCode == Keys.W && prev_dir != Direction.down)
                {
                    dir = Direction.up;
                }
                else if (e.KeyCode == Keys.S && prev_dir != Direction.up)
                {
                    dir = Direction.down;
                }
                else
                    return;
                key_down = true;
                prev_loc = snake.segments[0].Location;
            }


            key_down_time = DateTime.Now;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (is_fast)
            //    Slowly();
            if (snake.is_fast)
                try { snake.Slowly(); }
                catch { }
            key_down = false;
            //is_fast = false;
        }
        private void butPlus_Click(object sender, EventArgs e)
        {
            //int new_speed = Convert.ToInt32(tbSpeed.Text) + 1;
            //int new_speed = snake.Speed + 1;
            //if (new_speed < max_speed + 1 && new_speed >= min_speed + 1)
            try
            {
                if (snake.Speed < max_speed)
                {
                    snake.Speed += 1;
                    tbSpeed.Text = snake.Speed.ToString();
                }
            }
            catch { }
            //if (snake.Speed < max_speed)
            //{
            //    snake.Speed += 1;
            //    tbSpeed.Text = snake.Speed.ToString();
            //}
        }
        private void butMinus_Click(object sender, EventArgs e)
        {
            //int new_speed = Convert.ToInt32(tbSpeed.Text) - 1;
            //if (new_speed > min_speed - 1)
            //{
            //    tbSpeed.Text = new_speed.ToString();
            //    snake.Speed = new_speed - 1;
            //}
            //if (snake.Speed > min_speed)
            //{
            //    snake.Speed -= 1;
            //    tbSpeed.Text = snake.Speed.ToString();
            //}

            try
            {
                if (snake.Speed > min_speed)
                {
                    snake.Speed -= 1;
                    tbSpeed.Text = snake.Speed.ToString();
                }
            }
            catch { }

        }
    }




    class Snake
    {
        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                t.Interval = speed_arr[speed];
            }
        }
        public static int segsize = 10;
        public List<Panel> segments;

        private PictureBox zona;
        private Timer t;
        private int speed;
        private int[] speed_arr = new int[] { 300, 250, 200, 150, 130, 110, 80, 60, 40, 30, 20, 10 };
        public bool is_fast;

        public Snake(PictureBox zona_, Timer t_)
        {
            zona = zona_;
            t = t_;
            segments = new List<Panel>();
            int x = zona.Width / 2 - (zona.Width / 2) % segsize;
            int y = zona.Height / 2 - (zona.Height / 2) % segsize;
            Panel seg = CreateSeg(x, y, segsize, Color.Green);
            zona.Controls.Add(segments[0]);
        }

        public void Faster()
        {
            Speed += 2;
            is_fast = true;
        }
        public void Slowly()
        {
            Speed -= 2;
            is_fast = false;
        }
        public Panel CreateSeg(int x, int y, int size, Color color)
        {
            Panel p = new Panel();
            p.BackColor = color;
            p.BorderStyle = BorderStyle.FixedSingle;
            //if (x == 0 && y == 0)
            //    p.Location = new Point(Ptmp.X + 10, Ptmp.Y);
            //else
            p.Location = new Point(x, y);
            p.Size = new Size(size, size);
            segments.Add(p);
            return p;
        }
        public void Moove(Form1.Direction d)
        {
            Point Ptmp = new Point();
            if (d == Form1.Direction.left)
            {
                Ptmp = segments[0].Location;
                segments[0].Location = new Point(segments[0].Location.X - 10, segments[0].Location.Y);
                ZsuvSegments(Ptmp);
            }
            else if (d == Form1.Direction.right)
            {
                Ptmp = segments[0].Location;
                segments[0].Location = new Point(segments[0].Location.X + 10, segments[0].Location.Y);
                ZsuvSegments(Ptmp);
            }
            else if (d == Form1.Direction.up)
            {
                Ptmp = segments[0].Location;
                segments[0].Location = new Point(segments[0].Location.X, segments[0].Location.Y - 10);
                ZsuvSegments(Ptmp);
            }
            else if (d == Form1.Direction.down)
            {
                Ptmp = segments[0].Location;
                segments[0].Location = new Point(segments[0].Location.X, segments[0].Location.Y + 10);
                ZsuvSegments(Ptmp);
            }
        }
        public void ZsuvSegments(Point Ptmp)
        {
            Point Ptmp0 = new Point();
            for (int i = 1; i < segments.Count; i++)
            {
                Ptmp0 = segments[i].Location;
                segments[i].Location = Ptmp;
                Ptmp = Ptmp0;
            }
        }
        public bool IsEatMyself()
        {
            for (int i = 1; i < segments.Count; i++)
                if (segments[0].Location == segments[i].Location)
                    return true;
            return false;
        }
        public bool IsMooveOutOfZona()
        {
            if (segments[0].Location.X < 0 || segments[0].Location.Y < 0 || segments[0].Location.X + segsize > zona.Width || segments[0].Location.Y + segsize > zona.Height)
                return true;
            return false;
        }

    }
}
