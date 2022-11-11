namespace Pathfinding
{
    public partial class Form1 : Form
    {
        public static int gridSize = 12;
        public static Panel[][] grid;
        public Point start;
        public Point end;


        public static bool Start;
        public static bool End;
        public static bool Obstacle;

        public Form1()
        {
            InitializeComponent();
            grid = createGrid();
            foreach (Panel[] p in grid)
            {
                foreach (Panel p1 in p)
                {

                    this.Controls.Add(p1);
                }
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public static Panel[][] createGrid()
        {
            Panel[][] grid = new Panel[12][];

            Point startLoc = new Point(325, 46);

            int change = 39;

            for (int x = 0; x < gridSize; x++)
            {
                grid[x] = new Panel[gridSize];
                for (int y = 0; y < gridSize; y++)
                {

                    Panel panel = new Panel
                    {
                        Name = $"{x} , {y}",
                        Size = new Size(33, 33),
                        Location = new Point((startLoc.X + (change * x)), (startLoc.Y + (change * y))),
                        BorderStyle = BorderStyle.FixedSingle,

                    };
                    panel.MouseClick += new MouseEventHandler(pressed);



                    grid[x][y] = panel;


                }
            }
            return grid;
        }
        public static void pressed(object sender, MouseEventArgs e)
        {
            Panel? panel = sender as Panel;
            if (Start)
            {
                panel.BackColor = Color.Green;
            }
            else if (End)
            {
                panel.BackColor = Color.Red;
            }
            else if (Obstacle)
            {
                panel.BackColor = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start = true;
            End = false;
            Obstacle = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start = false;
            End = true;
            Obstacle = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start = false;
            End = false;
            Obstacle = true;
        }

        private Panel[] getAdjacent(Panel[][] grid, Location coords)
        {
            Panel[] adjacent = new Panel[8];

            adjacent[0] = grid[coords.X - 1][coords.Y - 1];
            adjacent[1] = grid[coords.X - 1][coords.Y];
            adjacent[2] = grid[coords.X - 1][coords.Y + 1];
            adjacent[3] = grid[coords.X][coords.Y - 1];
            adjacent[4] = grid[coords.X][coords.Y + 1];
            adjacent[5] = grid[coords.X + 1][coords.Y - 1];
            adjacent[6] = grid[coords.X + 1][coords.Y];
            adjacent[7] = grid[coords.X + 1][coords.Y + 1];

            return adjacent;
        }

        private Location? getEnd(Panel[][] grid)
        {

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j].BackColor == Color.Red)
                    {
                        return new Location(i, j);
                    }
                }
            }
            return null;
        }
        private Location? getStart(Panel[][] grid)
        {

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j].BackColor == Color.Green)
                    {
                        return new Location(i, j);
                    }
                }
            }
            return null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Location start = getStart(grid);
            Location end = getEnd(grid);

            int XDistance = 0;
            int YDistance = 0;
            if (start.X > end.X)
            {
                XDistance = start.X - end.X;
                if (start.Y < end.Y)
                {
                    YDistance = end.Y - start.Y;
                    for (int i = XDistance; i > 0; i--)
                    {
                        if (grid[start.X - i][start.Y].BackColor == Color.Green || grid[start.X - i][start.Y].BackColor == Color.Red) continue;



                        grid[start.X - i ][start.Y].BackColor = Color.Blue;



                    }
                    for (int i = 0; i < YDistance; i++)
                    {
                        if (grid[start.X - XDistance][start.Y + i].BackColor == Color.Green || grid[start.X - XDistance][start.Y + i].BackColor == Color.Red) continue;


                        grid[start.X - XDistance][start.Y + i].BackColor = Color.Blue;

                    }
                }
                else
                {
                    YDistance = start.Y - end.Y;
                    for (int i = XDistance; i > 0; i--)
                    {
                        if (grid[start.X - i][start.Y].BackColor == Color.Green || grid[start.X - i][start.Y].BackColor == Color.Red) continue;



                        grid[start.X - i][start.Y].BackColor = Color.Blue;

                    }
                    for (int i = 0; i < YDistance; i++)
                    {
                        if (grid[start.X - XDistance][start.Y - i].BackColor == Color.Green || grid[start.X - XDistance][start.Y + i].BackColor == Color.Red) continue;


                        grid[start.X - XDistance][start.Y - i].BackColor = Color.Blue;

                    }
                }
            }
            else if (start.X < end.X)
            {
                XDistance = end.X - start.X;
                if (start.Y < end.Y)
                {
                    YDistance = end.Y - start.Y;
                    for (int i = 0; i < XDistance; i++)
                    {
                        if (grid[start.X + i][start.Y].BackColor == Color.Green || grid[start.X + i][start.Y].BackColor == Color.Red) continue;



                        grid[start.X + i][start.Y].BackColor = Color.Blue;



                    }
                    for (int i = 0; i < YDistance; i++)
                    {
                        if (grid[start.X + XDistance][start.Y + i].BackColor == Color.Green || grid[start.X + XDistance][start.Y + i].BackColor == Color.Red) continue;


                        grid[start.X + XDistance][start.Y + i].BackColor = Color.Blue;

                    }
                }
                else
                {
                    YDistance = start.Y - end.Y;
                    for (int i = 1; i < XDistance + 1; i++)
                    {
                        if (grid[start.X + i][start.Y].BackColor == Color.Green || grid[start.X + i][start.Y].BackColor == Color.Red) continue;


                        grid[start.X + i][start.Y].BackColor = Color.Blue;

                    }
                    for (int i = YDistance; i > 0; i--)
                    {
                        if (grid[start.X + XDistance][start.Y - i].BackColor == Color.Green || grid[start.X + XDistance][start.Y - i].BackColor == Color.Red) continue;
                        grid[start.X + XDistance][start.Y - i].BackColor = Color.Blue;

                    }
                }
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j].BackColor = Color.Transparent;

                }
            }
        }
        public class Location
        {
            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;
        }
    }
}