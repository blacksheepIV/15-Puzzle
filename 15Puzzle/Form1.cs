using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15Puzzle
{
    public partial class Form1 : Form
    {
        int[,] Puzzle = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };//intialization of puzzle before scrambling
        int[,] state = new int[4, 4];
        int[,] goal = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };//what should the solved puzzle look like
 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "15-Puzzle";
            MessageBox.Show("Please Enter your Desired puzzle manually then hit \"Have Puzzle Your Way\"or let the program create a puzzle for you", "Tip", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp = 0;
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x1 = (r.Next(16)) / 4;
                int y1 = (r.Next(16)) % 4;
                int x2 = (r.Next(16)) / 4;
                int y2 = (r.Next(16)) % 4;
                temp = Puzzle[x1, y1];
                Puzzle[x1, y1] = Puzzle[x2, y2];
                Puzzle[x2, y2] = temp;
            }
            textBox1.Text = Convert.ToString(Puzzle[0, 0]);
            textBox2.Text = Convert.ToString(Puzzle[0, 1]);
            textBox3.Text = Convert.ToString(Puzzle[0, 2]);
            textBox4.Text = Convert.ToString(Puzzle[0, 3]);
            textBox5.Text = Convert.ToString(Puzzle[1, 0]);
            textBox8.Text = Convert.ToString(Puzzle[1, 1]);
            textBox11.Text = Convert.ToString(Puzzle[1, 2]);
            textBox12.Text = Convert.ToString(Puzzle[1, 3]);
            textBox6.Text = Convert.ToString(Puzzle[2, 0]);
            textBox9.Text = Convert.ToString(Puzzle[2, 1]);
            textBox13.Text = Convert.ToString(Puzzle[2, 2]);
            textBox14.Text = Convert.ToString(Puzzle[2, 3]);
            textBox7.Text = Convert.ToString(Puzzle[3, 0]);
            textBox10.Text = Convert.ToString(Puzzle[3, 1]);
            textBox15.Text = Convert.ToString(Puzzle[3, 2]);
            textBox16.Text = Convert.ToString(Puzzle[3, 3]);
            button3.Enabled = true;//enabling Solve button
            button2.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            rbBFS.Enabled = true;
            rbDLS.Enabled = true;
            rbIDS.Enabled = true;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Puzzle[0, 0] = Convert.ToInt32(textBox1.Text);
            Puzzle[0, 1] = Convert.ToInt32(textBox2.Text);
            Puzzle[0, 2] = Convert.ToInt32(textBox3.Text);
            Puzzle[0, 3] = Convert.ToInt32(textBox4.Text);
            Puzzle[1, 0] = Convert.ToInt32(textBox5.Text);
            Puzzle[1, 1] = Convert.ToInt32(textBox8.Text);
            Puzzle[1, 2] = Convert.ToInt32(textBox11.Text);
            Puzzle[1, 3] = Convert.ToInt32(textBox12.Text);
            Puzzle[2, 0] = Convert.ToInt32(textBox6.Text);
            Puzzle[2, 1] = Convert.ToInt32(textBox9.Text);
            Puzzle[2, 2] = Convert.ToInt32(textBox13.Text);
            Puzzle[2, 3] = Convert.ToInt32(textBox14.Text);
            Puzzle[3, 0] = Convert.ToInt32(textBox7.Text);
            Puzzle[3, 1] = Convert.ToInt32(textBox10.Text);
            Puzzle[3, 2] = Convert.ToInt32(textBox15.Text);
            Puzzle[3, 3] = Convert.ToInt32(textBox16.Text);
            button3.Enabled = true;//enabling solve button
            button1.Enabled = false;
            rbBFS.Enabled = true;
            rbDLS.Enabled = true;
            rbIDS.Enabled = true;
        }

        private void rbBFS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] dPuzzle = new int[16];
            int[] dgoal = new int[16];
            for (int w = 0; w < 4; w++)
                for (int r = 0; r < 4; r++)
                {
                    dPuzzle[w * 4 + r] = Puzzle[w, r];
                    dgoal[w * 4 + r] = goal[w, r];
                }
            if (dPuzzle.SequenceEqual(dgoal))
            {
                MessageBox.Show("Puzzle is already solved!!");
                this.Close();
            }
            if (rbBFS.Checked)
            {
                MessageBox.Show("You are about to solve 15Puzzle with BFS,this may take some time,be patient", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bfs test = new bfs(Puzzle);
                test.check_up(goal);
                state = test.way[0];
                textBox17.Text = Convert.ToString(state[0, 0]);
                textBox18.Text = Convert.ToString(state[0, 1]);
                textBox19.Text = Convert.ToString(state[0, 2]);
                textBox20.Text = Convert.ToString(state[0, 3]);
                textBox21.Text = Convert.ToString(state[1, 0]);
                textBox22.Text = Convert.ToString(state[1, 1]);
                textBox23.Text = Convert.ToString(state[1, 2]);
                textBox24.Text = Convert.ToString(state[1, 3]);
                textBox25.Text = Convert.ToString(state[2, 0]);
                textBox26.Text = Convert.ToString(state[2, 1]);
                textBox27.Text = Convert.ToString(state[2, 2]);
                textBox28.Text = Convert.ToString(state[2, 3]);
                textBox29.Text = Convert.ToString(state[3, 0]);
                textBox30.Text = Convert.ToString(state[3, 1]);
                textBox31.Text = Convert.ToString(state[3, 2]);
                textBox32.Text = Convert.ToString(state[3, 3]);
                for (int k = test.way.Count - 1; k >= 0; k--)
                {
                    state = test.way[k];
                    for (int j = 0; j < 4; j++)
                        for (int l = 0; l < 4; l++)
                        {
                            richTextBox1.AppendText(Convert.ToString(state[j, l]));
                            richTextBox1.AppendText(" ");
                            if ((l / 3) == 1)
                                richTextBox1.AppendText(Environment.NewLine);
                        }
                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.AppendText("**********");
                    richTextBox1.AppendText(Environment.NewLine);
                }
                button4.Enabled = true;
                }//end bfs-if
            //*********************************************************************8
                if (rbDLS.Checked)
                {
                    MessageBox.Show("You are about to solve 15Puzzle with DFS,this may take some time,be patient", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dls test1 = new dls(Puzzle,10);
                    test1.check_up(goal);
                    if (test1.way.Count == 0)
                        MessageBox.Show("No resault found in the specified depth");
                    else
                    {
                        state = test1.way[0];
                        textBox17.Text = Convert.ToString(state[0, 0]);
                        textBox18.Text = Convert.ToString(state[0, 1]);
                        textBox19.Text = Convert.ToString(state[0, 2]);
                        textBox20.Text = Convert.ToString(state[0, 3]);
                        textBox21.Text = Convert.ToString(state[1, 0]);
                        textBox22.Text = Convert.ToString(state[1, 1]);
                        textBox23.Text = Convert.ToString(state[1, 2]);
                        textBox24.Text = Convert.ToString(state[1, 3]);
                        textBox25.Text = Convert.ToString(state[2, 0]);
                        textBox26.Text = Convert.ToString(state[2, 1]);
                        textBox27.Text = Convert.ToString(state[2, 2]);
                        textBox28.Text = Convert.ToString(state[2, 3]);
                        textBox29.Text = Convert.ToString(state[3, 0]);
                        textBox30.Text = Convert.ToString(state[3, 1]);
                        textBox31.Text = Convert.ToString(state[3, 2]);
                        textBox32.Text = Convert.ToString(state[3, 3]);
                        for (int k = test1.way.Count - 1; k >= 0; k--)
                        {
                            state = test1.way[k];
                            for (int j = 0; j < 4; j++)
                                for (int l = 0; l < 4; l++)
                                {
                                    richTextBox1.AppendText(Convert.ToString(state[j, l]));
                                    richTextBox1.AppendText(" ");
                                    if ((l / 3) == 1)
                                        richTextBox1.AppendText(Environment.NewLine);
                                }//end if
                            richTextBox1.AppendText(Environment.NewLine);
                            richTextBox1.AppendText("**********");
                            richTextBox1.AppendText(Environment.NewLine);
                        }//end for richtext

                    }//end else
                    button4.Enabled = true;
                }//end if dls
            //********************************************************************
                if (rbIDS.Checked) {
                     MessageBox.Show("You are about to solve 15Puzzle with IDS,this may take some time,be patient", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ids test2 = new ids(Puzzle);
                test2.depth_limit(goal);
                state = test2.way[0];
                textBox17.Text = Convert.ToString(state[0, 0]);
                textBox18.Text = Convert.ToString(state[0, 1]);
                textBox19.Text = Convert.ToString(state[0, 2]);
                textBox20.Text = Convert.ToString(state[0, 3]);
                textBox21.Text = Convert.ToString(state[1, 0]);
                textBox22.Text = Convert.ToString(state[1, 1]);
                textBox23.Text = Convert.ToString(state[1, 2]);
                textBox24.Text = Convert.ToString(state[1, 3]);
                textBox25.Text = Convert.ToString(state[2, 0]);
                textBox26.Text = Convert.ToString(state[2, 1]);
                textBox27.Text = Convert.ToString(state[2, 2]);
                textBox28.Text = Convert.ToString(state[2, 3]);
                textBox29.Text = Convert.ToString(state[3, 0]);
                textBox30.Text = Convert.ToString(state[3, 1]);
                textBox31.Text = Convert.ToString(state[3, 2]);
                textBox32.Text = Convert.ToString(state[3, 3]);
                for (int k = test2.way.Count - 1; k >= 0; k--)
                {
                    state = test2.way[k];
                    for (int j = 0; j < 4; j++)
                        for (int l = 0; l < 4; l++)
                        {
                            richTextBox1.AppendText(Convert.ToString(state[j, l]));
                            richTextBox1.AppendText(" ");
                            if ((l / 3) == 1)
                                richTextBox1.AppendText(Environment.NewLine);
                        }
                    richTextBox1.AppendText(Environment.NewLine);
                    richTextBox1.AppendText("**********");
                    richTextBox1.AppendText(Environment.NewLine);
                }//end for
                }//end if ids
                button4.Enabled = true;
            }//end button
        

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void rbDFS_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox17.Text = string.Empty;
            textBox18.Text = string.Empty;
            textBox19.Text = string.Empty;
            textBox20.Text = string.Empty;
            textBox21.Text = string.Empty;
            textBox22.Text = string.Empty;
            textBox23.Text = string.Empty;
            textBox24.Text = string.Empty;
            textBox25.Text = string.Empty;
            textBox26.Text = string.Empty;
            textBox27.Text = string.Empty;
            textBox28.Text = string.Empty;
            textBox29.Text = string.Empty;
            textBox30.Text = string.Empty;
            textBox31.Text = string.Empty;
            textBox32.Text = string.Empty;
            richTextBox1.Clear();
        }
    }
}
