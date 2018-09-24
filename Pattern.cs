using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> store = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
            
            store.Add("AB", 0);
            store.Add("BC", 0);
            store.Add("AC", 0);
            store.Add("BA", 0);
            store.Add("CB", 0);
            store.Add("CA", 0);
            
            //store.Add("AA", 0);
            //store.Add("BB", 0);
            //store.Add("CC", 0);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s = new string[50];

            string path = textBox1.Text;
            if (path == "")
            {
                MessageBox.Show("Please enter address");
                return;
            }
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    //sr.ReadLine();
                    int i = 0,j=0,k=1;
                    while ((i++)<8000)
                    {
                        string list = sr.ReadLine();
                        //string list1 = sr.ReadLine();
                        if (list == "")
                            break;
                        string[] con = list.Split(new char[] { ',' });
                        //string[] con1 = list1.Split(new char[] { ',' });
                        int tem = int.Parse(con[2]);
                        int id = int.Parse(con[3]);

                        if (id == k && k < 21)
                        {
                            s[j] = s[j]+retchar(tem).ToString();
                            continue;
                        }
                        else if (k < 20)
                        {
                            k++;
                            j++;
                            s[j] =s[j]+ retchar(tem).ToString();
                            continue;
                        }
                        
                    }
                }
                    
                    MessageBox.Show("S1= " + s[0] + Environment.NewLine + "S2= " + s[1] + Environment.NewLine + "S3= " + s[2] + Environment.NewLine + "S4= " + s[3] + Environment.NewLine + "S5= " + s[4] + Environment.NewLine + "S6= " + s[5] + Environment.NewLine + "S7= " + s[6] + Environment.NewLine + "S8= " + s[7] + Environment.NewLine + "S9= " + s[8] + Environment.NewLine + "S10= " + s[9] + Environment.NewLine);
                    MessageBox.Show("S11= " + s[10] + Environment.NewLine + "S12= " + s[11] + Environment.NewLine + "S13= " + s[12] + Environment.NewLine + "S14= " + s[13] + Environment.NewLine + "S15= " + s[14] + Environment.NewLine + "S16= " + s[15] + Environment.NewLine + "S17= " + s[16] + Environment.NewLine + "S18= " + s[17] + Environment.NewLine + "S19= " + s[18] + Environment.NewLine + "S20= " + s[19] + Environment.NewLine);

                

                while (true)
                {
                    int i, j;
                    int value;
                    float[] pw = { 1, 1, 1, 1, 1, 1 };
                    float min_thr = 0.1f,big;
                    float[][] prob = new float[20][];
                    for (int x = 0; x < 20; x++)
                        prob[x] = new float[6];

                    for (i = 0; i < 20; i++)
                    {
                    char[] ch=new char[600];
                                          
                        ch=s[i].ToCharArray();
                        for(j=0;j<ch.Length-1;j++)
                        {
                            char l, m;
                            l = ch[j];
                            m = ch[j + 1];

                            if(l==m)
                                continue;
                            else
                            {

                                if (store.ContainsKey(l.ToString() + m.ToString()))
                                    store[l.ToString() + m.ToString()]++;
                                else
                                    continue;
                                                                   
                            }
                        }
                        prob[i][0] = (float)store["AB"] / (ch.Length - 1);
                        prob[i][1] = (float)store["BC"] / (ch.Length - 1);
                        prob[i][2] = (float)store["AC"] / (ch.Length - 1);
                        prob[i][3] = (float)store["BA"] / (ch.Length - 1);
                        prob[i][4] = (float)store["CB"] / (ch.Length - 1);
                        prob[i][5] = (float)store["CA"] / (ch.Length - 1);

                        store["AB"] = 0;
                        store["BC"] = 0;
                        store["AC"] = 0;
                        store["BA"] = 0;
                        store["CB"] = 0;
                        store["CA"] = 0;

                       }

                    MessageBox.Show("In s1, The Probabilities are: " + Environment.NewLine + " AB=" + prob[0][0] + " BC=" + prob[0][1] + " AC=" + prob[0][2] + " BA=" + prob[0][3] + " CB=" + prob[0][4] + " CA=" + prob[0][5] + Environment.NewLine +
                        "In s2, The Probabilities are: " + Environment.NewLine + " AB=" + prob[1][0] + " BC=" + prob[1][1] + " AC=" + prob[1][2] + " BA=" + prob[1][3] + " CB=" + prob[1][4] + " CA=" + prob[1][5] + Environment.NewLine +
                        "In s3, The Probabilities are: " + Environment.NewLine + " AB=" + prob[2][0] + " BC=" + prob[2][1] + " AC=" + prob[2][2] + " BA=" + prob[2][3] + " CB=" + prob[2][4] + " CA=" + prob[2][5] + Environment.NewLine +
                        "In s4, The Probabilities are: " + Environment.NewLine + " AB=" + prob[3][0] + " BC=" + prob[3][1] + " AC=" + prob[3][2] + " BA=" + prob[3][3] + " CB=" + prob[3][4] + " CA=" + prob[3][5] + Environment.NewLine +
                        "In s5, The Probabilities are: " + Environment.NewLine + " AB=" + prob[4][0] + " BC=" + prob[4][1] + " AC=" + prob[4][2] + " BA=" + prob[4][3] + " CB=" + prob[4][4] + " CA=" + prob[4][5] + Environment.NewLine +
                        "In s6, The Probabilities are: " + Environment.NewLine + " AB=" + prob[5][0] + " BC=" + prob[5][1] + " AC=" + prob[5][2] + " BA=" + prob[5][3] + " CB=" + prob[5][4] + " CA=" + prob[5][5] + Environment.NewLine +
                        "In s7, The Probabilities are: " + Environment.NewLine + " AB=" + prob[6][0] + " BC=" + prob[6][1] + " AC=" + prob[6][2] + " BA=" + prob[6][3] + " CB=" + prob[6][4] + " CA=" + prob[6][5] + Environment.NewLine +
                        "In s8, The Probabilities are: " + Environment.NewLine + " AB=" + prob[7][0] + " BC=" + prob[7][1] + " AC=" + prob[7][2] + " BA=" + prob[7][3] + " CB=" + prob[7][4] + " CA=" + prob[7][5] + Environment.NewLine +
                        "In s9, The Probabilities are: " + Environment.NewLine + " AB=" + prob[8][0] + " BC=" + prob[8][1] + " AC=" + prob[8][2] + " BA=" + prob[8][3] + " CB=" + prob[8][4] + " CA=" + prob[8][5] + Environment.NewLine +
                        "In s10, The Probabilities are: " + Environment.NewLine + " AB=" + prob[9][0] + " BC=" + prob[9][1] + " AC=" + prob[9][2] + " BA=" + prob[9][3] + " CB=" + prob[9][4] + " CA=" + prob[9][5] + Environment.NewLine +
                        "In s11, The Probabilities are: " + Environment.NewLine + " AB=" + prob[10][0] + " BC=" + prob[10][1] + " AC=" + prob[10][2] + " BA=" + prob[10][3] + " CB=" + prob[10][4] + " CA=" + prob[10][5] + Environment.NewLine +
                        "In s12, The Probabilities are: " + Environment.NewLine + " AB=" + prob[11][0] + " BC=" + prob[11][1] + " AC=" + prob[11][2] + " BA=" + prob[11][3] + " CB=" + prob[11][4] + " CA=" + prob[11][5] + Environment.NewLine +
                        "In s13, The Probabilities are: " + Environment.NewLine + " AB=" + prob[12][0] + " BC=" + prob[12][1] + " AC=" + prob[12][2] + " BA=" + prob[12][3] + " CB=" + prob[12][4] + " CA=" + prob[12][5] + Environment.NewLine +
                        "In s14, The Probabilities are: " + Environment.NewLine + " AB=" + prob[13][0] + " BC=" + prob[13][1] + " AC=" + prob[13][2] + " BA=" + prob[13][3] + " CB=" + prob[13][4] + " CA=" + prob[13][5] + Environment.NewLine +
                        "In s15, The Probabilities are: " + Environment.NewLine + " AB=" + prob[14][0] + " BC=" + prob[14][1] + " AC=" + prob[14][2] + " BA=" + prob[14][3] + " CB=" + prob[14][4] + " CA=" + prob[14][5] + Environment.NewLine +
                        "In s16, The Probabilities are: " + Environment.NewLine + " AB=" + prob[15][0] + " BC=" + prob[15][1] + " AC=" + prob[15][2] + " BA=" + prob[15][3] + " CB=" + prob[15][4] + " CA=" + prob[15][5] + Environment.NewLine +
                        "In s17, The Probabilities are: " + Environment.NewLine + " AB=" + prob[16][0] + " BC=" + prob[16][1] + " AC=" + prob[16][2] + " BA=" + prob[16][3] + " CB=" + prob[16][4] + " CA=" + prob[16][5] + Environment.NewLine +
                        "In s18, The Probabilities are: " + Environment.NewLine + " AB=" + prob[17][0] + " BC=" + prob[17][1] + " AC=" + prob[17][2] + " BA=" + prob[17][3] + " CB=" + prob[17][4] + " CA=" + prob[17][5] + Environment.NewLine +
                        "In s19, The Probabilities are: " + Environment.NewLine + " AB=" + prob[18][0] + " BC=" + prob[18][1] + " AC=" + prob[18][2] + " BA=" + prob[18][3] + " CB=" + prob[18][4] + " CA=" + prob[18][5] + Environment.NewLine +
                        "In s20, The Probabilities are: " + Environment.NewLine + " AB=" + prob[19][0] + " BC=" + prob[19][1] + " AC=" + prob[19][2] + " BA=" + prob[19][3] + " CB=" + prob[19][4] + " CA=" + prob[19][5] + Environment.NewLine);

                    for (i = 0; i < 20; i++)
                        for (j = 0; j < 6; j++)
                            if (prob[i][j] < min_thr)
                                prob[i][j] = -1;


                    MessageBox.Show("In s1, The Probabilities are: " + Environment.NewLine + " AB=" + prob[0][0] + " BC=" + prob[0][1] + " AC=" + prob[0][2] + " BA=" + prob[0][3] + " CB=" + prob[0][4] + " CA=" + prob[0][5] + Environment.NewLine +
                        "In s2, The Probabilities are: " + Environment.NewLine + " AB=" + prob[1][0] + " BC=" + prob[1][1] + " AC=" + prob[1][2] + " BA=" + prob[1][3] + " CB=" + prob[1][4] + " CA=" + prob[1][5] + Environment.NewLine +
                        "In s3, The Probabilities are: " + Environment.NewLine + " AB=" + prob[2][0] + " BC=" + prob[2][1] + " AC=" + prob[2][2] + " BA=" + prob[2][3] + " CB=" + prob[2][4] + " CA=" + prob[2][5] + Environment.NewLine +
                        "In s4, The Probabilities are: " + Environment.NewLine + " AB=" + prob[3][0] + " BC=" + prob[3][1] + " AC=" + prob[3][2] + " BA=" + prob[3][3] + " CB=" + prob[3][4] + " CA=" + prob[3][5] + Environment.NewLine +
                        "In s5, The Probabilities are: " + Environment.NewLine + " AB=" + prob[4][0] + " BC=" + prob[4][1] + " AC=" + prob[4][2] + " BA=" + prob[4][3] + " CB=" + prob[4][4] + " CA=" + prob[4][5] + Environment.NewLine +
                        "In s6, The Probabilities are: " + Environment.NewLine + " AB=" + prob[5][0] + " BC=" + prob[5][1] + " AC=" + prob[5][2] + " BA=" + prob[5][3] + " CB=" + prob[5][4] + " CA=" + prob[5][5] + Environment.NewLine +
                        "In s7, The Probabilities are: " + Environment.NewLine + " AB=" + prob[6][0] + " BC=" + prob[6][1] + " AC=" + prob[6][2] + " BA=" + prob[6][3] + " CB=" + prob[6][4] + " CA=" + prob[6][5] + Environment.NewLine +
                        "In s8, The Probabilities are: " + Environment.NewLine + " AB=" + prob[7][0] + " BC=" + prob[7][1] + " AC=" + prob[7][2] + " BA=" + prob[7][3] + " CB=" + prob[7][4] + " CA=" + prob[7][5] + Environment.NewLine +
                        "In s9, The Probabilities are: " + Environment.NewLine + " AB=" + prob[8][0] + " BC=" + prob[8][1] + " AC=" + prob[8][2] + " BA=" + prob[8][3] + " CB=" + prob[8][4] + " CA=" + prob[8][5] + Environment.NewLine +
                        "In s10, The Probabilities are: " + Environment.NewLine + " AB=" + prob[9][0] + " BC=" + prob[9][1] + " AC=" + prob[9][2] + " BA=" + prob[9][3] + " CB=" + prob[9][4] + " CA=" + prob[9][5] + Environment.NewLine +
                        "In s11, The Probabilities are: " + Environment.NewLine + " AB=" + prob[10][0] + " BC=" + prob[10][1] + " AC=" + prob[10][2] + " BA=" + prob[10][3] + " CB=" + prob[10][4] + " CA=" + prob[10][5] + Environment.NewLine +
                        "In s12, The Probabilities are: " + Environment.NewLine + " AB=" + prob[11][0] + " BC=" + prob[11][1] + " AC=" + prob[11][2] + " BA=" + prob[11][3] + " CB=" + prob[11][4] + " CA=" + prob[11][5] + Environment.NewLine +
                        "In s13, The Probabilities are: " + Environment.NewLine + " AB=" + prob[12][0] + " BC=" + prob[12][1] + " AC=" + prob[12][2] + " BA=" + prob[12][3] + " CB=" + prob[12][4] + " CA=" + prob[12][5] + Environment.NewLine +
                        "In s14, The Probabilities are: " + Environment.NewLine + " AB=" + prob[13][0] + " BC=" + prob[13][1] + " AC=" + prob[13][2] + " BA=" + prob[13][3] + " CB=" + prob[13][4] + " CA=" + prob[13][5] + Environment.NewLine +
                        "In s15, The Probabilities are: " + Environment.NewLine + " AB=" + prob[14][0] + " BC=" + prob[14][1] + " AC=" + prob[14][2] + " BA=" + prob[14][3] + " CB=" + prob[14][4] + " CA=" + prob[14][5] + Environment.NewLine +
                        "In s16, The Probabilities are: " + Environment.NewLine + " AB=" + prob[15][0] + " BC=" + prob[15][1] + " AC=" + prob[15][2] + " BA=" + prob[15][3] + " CB=" + prob[15][4] + " CA=" + prob[15][5] + Environment.NewLine +
                        "In s17, The Probabilities are: " + Environment.NewLine + " AB=" + prob[16][0] + " BC=" + prob[16][1] + " AC=" + prob[16][2] + " BA=" + prob[16][3] + " CB=" + prob[16][4] + " CA=" + prob[16][5] + Environment.NewLine +
                        "In s18, The Probabilities are: " + Environment.NewLine + " AB=" + prob[17][0] + " BC=" + prob[17][1] + " AC=" + prob[17][2] + " BA=" + prob[17][3] + " CB=" + prob[17][4] + " CA=" + prob[17][5] + Environment.NewLine +
                        "In s19, The Probabilities are: " + Environment.NewLine + " AB=" + prob[18][0] + " BC=" + prob[18][1] + " AC=" + prob[18][2] + " BA=" + prob[18][3] + " CB=" + prob[18][4] + " CA=" + prob[18][5] + Environment.NewLine +
                        "In s20, The Probabilities are: " + Environment.NewLine + " AB=" + prob[19][0] + " BC=" + prob[19][1] + " AC=" + prob[19][2] + " BA=" + prob[19][3] + " CB=" + prob[19][4] + " CA=" + prob[19][5] + Environment.NewLine);

                    for (i = 0; i < 20; i++)
                    {
                        if (prob[i][0] != -1)
                            pw[0] = pw[0] * prob[i][0];
                        if (prob[i][1] != -1)
                            pw[1] = pw[1] * prob[i][1];
                        if (prob[i][2] != -1)
                            pw[2] = pw[2] * prob[i][2];
                        if (prob[i][3] != -1)
                            pw[3] = pw[3] * prob[i][3];
                        if (prob[i][4] != -1)
                            pw[4] = pw[4] * prob[i][4];
                        if (prob[i][5] != -1)
                            pw[5] = pw[5] * prob[i][5];
                    }

                    MessageBox.Show("POSSIBLE WORLDS:" + Environment.NewLine + " AB:" + pw[0] + Environment.NewLine + " BC:" + pw[1] + Environment.NewLine + " AC:" + pw[2] + Environment.NewLine + " BA:" + pw[3] + Environment.NewLine + " CB:" + pw[4] + Environment.NewLine + " CA:" + pw[5] + Environment.NewLine);

                    value = Biggest(pw);


                    if (value == 0)
                        MessageBox.Show("AB IS FREQUENT SEQUENTIAL PATTERN");
                    else if(value==1)
                        MessageBox.Show("BC IS FREQUENT SEQUENTIAL PATTERN");
                    else if (value == 2)
                        MessageBox.Show("AC IS FREQUENT SEQUENTIAL PATTERN");
                    else if (value == 3)
                        MessageBox.Show("BA IS FREQUENT SEQUENTIAL PATTERN");
                    else if (value == 4)
                        MessageBox.Show("CB IS FREQUENT SEQUENTIAL PATTERN");
                    else if (value == 5)
                        MessageBox.Show("CA IS FREQUENT SEQUENTIAL PATTERN");

                    break;
                }
                
           }


            
            catch (Exception ex)
            {
                MessageBox.Show(s+ex.ToString()+Environment.NewLine+ex.Message);
            }
        }
        public char retchar(int a)
        {
            if (a >= 55 && a <= 63)
                return 'A';
            if (a >= 64 && a < 72)
                return 'B';
            return 'C';
        }

        public int Biggest(float[] a)
        {
            float big;
            int i,value=0;
            big = a[0];
                    for (i = 0; i < 6; i++)
                    {
                        if (big > a[i])
                        {
                            big = a[i];
                            value=i;
                        }
                    }
                    return value;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.InitialDirectory="D:\\";
            ofd.Multiselect = false;
            ofd.Title = "choose a CSV file";
            ofd.ShowDialog();
            textBox1.Text = ofd.FileName;
        }

    }
}
