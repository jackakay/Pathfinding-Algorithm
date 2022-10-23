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
            foreach(Panel[] p in grid)
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
            }else if (End )
            {
                panel.BackColor= Color.Red;
            }else if (Obstacle)
            {
                panel.BackColor = Color.Black;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Start = true;
            End = false;
            Obstacle= false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Start=false;
            End=true;
            Obstacle = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Start = false;
            End = false;
            Obstacle = true;
        }
    }
}