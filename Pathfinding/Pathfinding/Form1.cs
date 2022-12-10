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
                        MessageBox.Show("X : " + i.ToString() + " Y : " + j.ToString());
                        return new Location(i, j);
                    }
                }
            }
            return null;
        }
        private Location[] getDiagonalTiles(Location cell)
        {
            //Will return an array of the diagonal adjacent cells to the input cell. Will be given as an array of locations. 
            /*
             * [0][][3]
             * [][][]
             * [1][][2]
            */
            Location[] diagonalCells = new Location[4];
            diagonalCells[0] = new Location(cell.X - 1, cell.Y - 1);
            diagonalCells[1] = new Location(cell.X - 1, cell.Y + 1);
            diagonalCells[2] = new Location(cell.X + 1, cell.Y + 1);
            diagonalCells[3] = new Location(cell.X + 1, cell.Y - 1);
            return diagonalCells;
        }

        private void colourDiagonalPath(Location[] path)
        {
            for(int i = 0; i < path.Length - 1; i++)
            {
                grid[path[i].X][path[i].Y].BackColor = Color.Purple;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Location start = getStart(grid);
            Location end = getEnd(grid);
            Location[] diagonalPath = new Location[12];
            int count = 0;
            int countn = 0;
            Location lastPoint = start;
            bool solved = false;

            int XDistance = 0;
            int YDistance = 0;
            if (start.X > end.X)
            {
                XDistance = start.X - end.X;
                if (start.Y < end.Y)
                {
                    //MessageBox.Show("End is diagonal down left from start");
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
                    for(int i = XDistance; i > 0; i--)
                    {
                        
                        MessageBox.Show("new row");
                        lastPoint = start;
                        lastPoint.X = start.X - countn;
                        // for some reason doesnt work?
                        countn++;
                        
                        for(int j = 0; j < YDistance; j++)
                        {
                            Location diagonalTile = getDiagonalTiles(lastPoint)[1];
                            if (diagonalTile.X < 0 || diagonalTile.X > 13 || diagonalTile.Y < 0 || diagonalTile.Y > 13) continue; 
                            diagonalPath[count] = diagonalTile;
                            //errors here
                            richTextBox1.AppendText(lastPoint.X.ToString() + " " + lastPoint.Y.ToString() + "\n");
                            lastPoint = diagonalTile;
                            //MessageBox.Show(lastPoint.X.ToString() + " " + lastPoint.Y.ToString());
                            
                            if(grid[lastPoint.X][lastPoint.Y].BackColor == Color.Red)
                            {
                                MessageBox.Show("Found path");
                                colourDiagonalPath(diagonalPath);
                            }
                            else
                            {
                                grid[lastPoint.X][lastPoint.Y].BackColor = Color.Magenta;
                            }
                           
                            count++;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("End is diagonal up left from start");
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
                MessageBox.Show("End is diagonal down right from start");
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
                    MessageBox.Show("End is diagonal up right from start");
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}