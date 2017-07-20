using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15Puzzle
{
    class ids
    {
         public Stack<int[,]> s = new Stack<int[,]>();//a stack to hold the nodes
               public List<int[,]> visited = new List <int[,]>();//avoid checking nodes again
               public List<int[,]> way = new List<int[,]>();
               public Dictionary<int[,],int[,]> Steps = new Dictionary<int[,],int[,]>();//keeps parent nodes 
               public Dictionary<int[,], int> depth = new Dictionary<int[,], int>();
               public int[,] state = new int[4, 4];
               //public int[,] current = new int[4, 4];
               public int[,] root = new int[4, 4];
              // public int[,] start = new int[4, 4];
               public bool flag = false;
               public bool equal = false;
               public bool cutt_off = false;
               public int l = 0;//depth limiter
               public ids(int[,]start) {
                   s.Push(start);
                   visited.Add(start); 
                   Steps[start] = null;
                   depth[start] = 0;
               }
               public void equality(int[,]state, int[,] goal)
               {
                   int[] dstate = new int[16];
                   int[] dgoal = new int[16];
                   for (int w = 0; w < 4; w++)
                       for (int r = 0; r < 4; r++)
                       {
                           dstate[w * 4 + r] = state[w, r];
                           dgoal[w * 4 + r] = goal[w, r];
                       }
                   if (dstate.SequenceEqual(dgoal))
                       equal = true;

               }
        public  void seen_before(int[,]temp){
            int[,] temp1 = new int[4, 4];
            int[]dtemp1=new int[16];
            int[] dtemp = new int[16];
                    for (int k = 0; k < visited.Count; k++)
                    {
                        temp1 = (int[,])visited[k].Clone();
                        for (int w = 0; w < 4; w++)
                            for (int r = 0; r < 4; r++){
                                dtemp1[w * 4 + r] = temp1[w, r];
                                 dtemp[w * 4 + r] = temp[w, r];
                            }
                        if (dtemp1.SequenceEqual(dtemp))
                            flag = true;
                    }
        
        }
               public void expand(int a,int b) {
                   for (int i = 0; i < 4; i++)
                       for (int j = 0; j < 4; j++)
                           if (a == i && b == j && (b + 1) < 4)
                           {
                               int[,] state1 = (int[,])state.Clone();
                               state1[i, j] = state1[i, j + 1];
                               state1[i, j + 1] = 0;
                               flag = false;
                               seen_before(state1);
                               if (!flag)
                               {
                                   s.Push(state1);
                                   visited.Add(state1);
                                   Steps[state1] = state;
                                   depth[state1] = depth[state] + 1;
                                   break;
                               }//end inner for
                           }//end if in loop
                   // *****case2****
                   for (int i = 0; i < 4; i++)
                       for (int j = 0; j < 4; j++)
                           if (a == i && b == j && (b - 1) > -1)
                           {
                               int[,] state2 = (int[,])state.Clone();
                               state2[i, j] = state2[i, j - 1];
                               state2[i, j - 1] = 0;
                               flag = false;
                               seen_before(state2);
                               if (!flag)
                               {
                                   s.Push(state2);
                                   visited.Add(state2);
                                   Steps[state2] = state;
                                   depth[state2] = depth[state] + 1;
                                   break;
                               }//end inner for
                           }//end if in loop           
                   //************case3***************
                   for (int i = 0; i < 4; i++)
                       for (int j = 0; j < 4; j++)
                           if (a == i && b == j && (a + 1) < 4)
                           {
                               int[,] state3 = (int[,])state.Clone();
                               state3[i, j] = state3[i + 1, j];
                               state3[i + 1, j] = 0;
                               flag = false;
                               seen_before(state3);
                               if (!flag)
                               {
                                   s.Push(state3);
                                   visited.Add(state3);
                                   Steps[state3] = state;
                                   depth[state3] = depth[state] + 1;
                                   break;
                               }//end inner for
                           }//end if in loop
                   //******case4****
                   for (int i = 0; i < 4; i++)
                       for (int j = 0; j < 4; j++)
                           if (a == i && b == j && (a - 1) > -1)
                           {
                               int[,] state4 = (int[,])state.Clone();
                               state4[i, j] = state4[i - 1, j];
                               state4[i - 1, j] = 0;
                               flag = false;
                               seen_before(state4);
                               if (!flag)
                               {
                                   s.Push(state4);
                                   visited.Add(state4);
                                   Steps[state4] = state;
                                   depth[state4] = depth[state] + 1;
                                   break;
                               }//end inner for
                           }//end if in loop
               }
               public void depth_limit(int[,] goal) {
                   root=s.Peek();
                   while (!cutt_off)
                   {
                       check_up(goal);
                       if (s.Count == 0)
                       {
                           visited.Clear();
                           Steps.Clear();
                           depth.Clear();
                           s.Push(root);
                           visited.Add(root);
                           Steps[root] = null;
                           depth[root] = 0;
                       }
                          
                       l++;
                   }//end while
               }
               public void check_up(int[,] goal)
               {
                   while (s.Count > 0)
                   {
                       state = s.Pop();
                       int a = 0;
                       int b = 0;
                       for (int i = 0; i < 4; i++)
                           for (int j = 0; j < 4; j++)
                               if (state[i, j] == 0)//finding blank space location
                               {
                                   a = i;
                                   b = j;
                                   break;
                               }
                       equality(state, goal);
                       if (equal)
                       {
                           way.Add(state);
                           while (Steps[state] != null)
                               way.Add(state = Steps[state]);
                           cutt_off = true;
                           return;
                       }//end inner if
                       if (depth[state] == l)
                           continue;
                       else expand(a, b);
                   }//end 1st while
               }//end function check_up
    }//end class
}
