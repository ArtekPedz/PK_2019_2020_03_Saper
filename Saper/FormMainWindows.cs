using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class FormMainWindows : Form
    {
        private const int fieldSize = 30;
        private SapperLogic myGame;
        public FormMainWindows()
        {
            InitializeComponent();
            prostaToolStripMenuItem_Click(null, null);
        }
        private void prostaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGame = new SapperLogic(8, 8, 10);
            generateView();
        }

        private void srdnioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGame = new SapperLogic(12, 10, 25);
            generateView();
        }

        private void trudnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myGame = new SapperLogic(20, 15, 50);
            generateView();
        }

        private void generateView()
        {
            panelButtons.Controls.Clear();

            for (int x = 0; x < myGame.BoardWidth; x++)
            {
                for (int y = 0; y < myGame.BoardHeight; y++)
                {
                    Button b = new Button();
                    b.Size = new Size(fieldSize, fieldSize);
                    b.Location = new Point(fieldSize * x, fieldSize * y);
                    b.Click += button_Click;
                    panelButtons.Controls.Add(b);
                    b.Tag = new Point(x, y);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(myGame.State == SapperLogic.GameState.InProgress)
            {
                if(sender is Button)
                {
                    Button b = sender as Button;
                    if(b.Tag is Point)
                    {
                        Point p = (Point)b.Tag;

                        myGame.Uncover(p);
                        refreshView();

                        if(myGame.State == SapperLogic.GameState.Win)
                        {
                            MessageBox.Show("Nie najgorzej stary :)");
                        }
                        if (myGame.State == SapperLogic.GameState.Loss)
                        {
                            MessageBox.Show("Sorry bro, przegrałeś");
                        }
                    }
                }
            }
        }

        private void refreshView()
        {
            foreach(Button b in panelButtons.Controls)
            {
                SapperLogic.Field f = myGame.GetField((Point)b.Tag);
                if(f.Covered == false)
                {
                    if(f.FieldType == SapperLogic.FieldTypeEnum.Bomb)
                    {
                        b.BackColor = Color.Red;
                        b.Text = "@";
                    }
                    else
                    {
                        b.BackColor = Color.White;

                        if(f.FieldType == SapperLogic.FieldTypeEnum.BombCount)
                        {
                            b.Text = f.BombCount.ToString();
                        }
                    }
                }
            }
        }

        private void FormMainWindows_Load(object sender, EventArgs e)
        {

        }
    }

    class SapperLogic
    {
        internal enum FieldTypeEnum
        {
            Bomb,
            BombCount,
            Empty
        }
        internal enum GameState
        {
            InProgress,
            Win,
            Loss
        }
        internal class Field
        {
            private FieldTypeEnum fieldType;
            private int bombCount;
            private bool covered;

            public FieldTypeEnum FieldType { get { return fieldType; } }
            public int BombCount { get { return bombCount; } }
            public bool Covered { get { return covered; } set { covered = value; } }

            internal Field(FieldTypeEnum fieldType, int bombCount = 0)
            {
                this.covered = true;
                this.fieldType = fieldType;
                this.bombCount = bombCount;
            }
        }

        readonly Random generator = new Random();
        private Field[,] board;
        private int fieldsToUncover;
        private GameState state;

        public int BoardWidth
        {
            get { return (int)board.GetLongLength(0); }
        }
        public int BoardHeight
        {
            get { return (int)board.GetLongLength(0); }
        }
        public GameState State
        {
            get { return state; }
        }

        public SapperLogic(int width, int height, int bombCount)
        {
            this.fieldsToUncover = (width * height) - bombCount;
            this.board = new Field[width, height];

            do
            {
                int x = generator.Next(BoardWidth);
                int y = generator.Next(BoardHeight);
                if(board[x,y] == null)
                {
                    board[x, y] = new Field(FieldTypeEnum.Bomb);
                    bombCount--;
                }
            } while (bombCount > 0);

            for (int x = 0; x < BoardWidth; x++)
            {
                for(int y = 0; y < BoardHeight; y++)
                {
                    if(board[x,y] == null)
                    {
                        int localBombCount = 0;
                        for (int xx = x-1; xx<=x+1; xx++)
                        {
                            for(int yy = y-1; yy<=y+1; yy++)
                            {
                                if(xx>=0 && xx<BoardWidth && yy>=0 && yy<BoardHeight && board[xx,yy]!=null && board[xx,yy].FieldType == FieldTypeEnum.Bomb)
                                {
                                    localBombCount++;
                                }
                            }
                        }
                        if (localBombCount > 0) board[x, y] = new Field(FieldTypeEnum.BombCount, localBombCount);
                        else  board[x, y] = new Field(FieldTypeEnum.Empty);

                    }
                }
            }
        }

        internal Field GetField(Point p)
        {
            return board[p.X, p.Y];
        }

        internal void Uncover(Point p)
        {
            Field f = board[p.X, p.Y];
            if(f.Covered)
            {
                if(f.FieldType == FieldTypeEnum.Bomb)
                {
                    state = GameState.Loss;
                    for(int x=0; x<BoardWidth; x++)
                    {
                        for(int y=0; y<BoardHeight; y++)
                        {
                            board[x, y].Covered = false;
                        }
                    }
                }
                else if (f.FieldType == FieldTypeEnum.BombCount)
                {
                    f.Covered = false;
                    fieldsToUncover--;
                }
                else
                {
                    f.Covered = false;
                    fieldsToUncover--;
                    for(int xx = p.X-1; xx<=p.X+1; xx++)
                    {
                        for(int yy = p.Y-1; yy<=p.Y+1; yy++)
                        {
                            if(xx >= 0 && xx < BoardWidth && yy >= 0 && yy<BoardHeight)
                            {
                                Uncover(new Point(xx, yy));
                            }
                        }
                    }
                }

                if(fieldsToUncover == 0)
                {
                    state = GameState.Win;
                }
            }
        }

    }
    
}
