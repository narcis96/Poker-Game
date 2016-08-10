using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int dificultate, numar_jucatori, Big, Small, ValB = 40, Ramasi, ValS = 20, Pot, Cerut, Primul, pas, steps;
        int[,] Carte = new int[10, 3];///Cartile jucatorilor
        int[] CarteJos = new int[10], Credit = new int[10], Next = new int[10], Prev = new int[10], facutraise = new int[10];
        Image[,] Img = new Image[16, 5];
        Button[] C = new Button[10];//Cele 5 carti de jos
        Button[,] B = new Button[10, 3];///Cele doua carti ale jucatorilor
        Button Yes = new Button(), No = new Button();
        Label[] Crd = new Label[10], Nume = new Label[10];///Creditul si numele fiecarui jucator
        TextBox[] Txt = new TextBox[10];///TextBox cu mutarile jucatorilor
        Random R = new Random();
        bool[] vizitat = new bool[200], joaca = new bool[10];
        bool Terminat;
        
        private int min(int a, int b)
        {
            if (a <= b)
                return a;
            return b;
        }
        private int max(int a, int b)
        {
            if (a >= b)
                return a;
            return b;
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            if (textBoxNume.Text.Length == 0)
            {
                MessageBox.Show("Nume Invalid! Numele trebuie sa contina cel putin un caracter");
                return;
            }
            Ok.Location = new Point(649, 562);
            Ok.Visible = false;
            Call.Visible = true; Raise.Visible = true;
            Check.Visible = true; numericUpRaise.Visible = true;
            buttoFold.Visible = true; buttonAllIn.Visible = true;
            if (pas == 1)///A fost jucata cel putin o mana 
            {
                Joc();
                return;
            }
            numericUpDown1.Visible = false;
            numericUpDownNumarJucatori.Visible = false;
            label1.Visible = false; labelPot.Visible = true;
            label2.Visible = false;
            numar_jucatori = (int)numericUpDownNumarJucatori.Value;
            dificultate = (int)numericUpDown1.Value;
            Joc_nou.Visible = true;
            Check.Enabled = false; textBoxNume.Visible = false;
            labelNume.Visible = false;
            Big = R.Next(1, numar_jucatori);
            Initializare();
            Joc();
        }

        private void Initializare()
        {
            Credit[0] = 2000000000;
            Ramasi = numar_jucatori;
            pas = 1;
            for (int i = 1; i < numar_jucatori; ++i)
            {
                Label L = new Label();
                L.Size = new Size(140, 23);
                L.Text = "Jucatorul " + (i + 1).ToString();
                L.Location = new Point(i * 140 - 100, 20);
                L.Font = new Font("Arial", (float)14.25);
                Nume[i + 1] = L;
                

                Crd[i + 1] = new Label();
                Crd[i + 1].Visible = true;
                Crd[i + 1].Size = new Size(115, 20);
                Crd[i + 1].Location = new Point(i * 140 - 101, 50);
                Crd[i + 1].Font = new Font("Arial", (float)14.25);
                Crd[i + 1].Text = "Credit:" + 2000.ToString();
                this.Controls.Add(Crd[i + 1]);
                Credit[i + 1] = 2000;

                for (int j = 1; j <= 2; ++j)
                {
                    B[i + 1, j] = new Button();
                    B[i + 1, j].Size = new Size(50, 95);
                    B[i + 1, j].Enabled = false;
                    B[i + 1, j].BackgroundImage = Image.FromFile("h1.jpg");
                    B[i + 1, j].BackgroundImageLayout = ImageLayout.Stretch;
                }
                B[i + 1, 1].Location = new Point(i * 140 - 95, 75);
                B[i + 1, 2].Location = new Point(i * 140 - 95 + 50, 75);
                this.Controls.Add(B[i + 1, 1]);
                this.Controls.Add(B[i + 1, 2]);

                Next[i] = i + 1;
                Prev[i] = i - 1;

                Txt[i + 1] = new TextBox();
                Txt[i + 1].Text = "       ";
                Txt[i + 1].Location = new Point(i * 140 - 95, 180);
                Txt[i + 1].Enabled = false;
                this.Controls.Add(Txt[i + 1]);

            }
            Prev[1] = numar_jucatori;
            Prev[numar_jucatori] = numar_jucatori - 1;
            Next[numar_jucatori] = 1;

            Small = Prev[Big];

            Label Lab = new Label();
            Lab.Size = new Size(110, 23);
            Lab.Text = textBoxNume.Text;
            Lab.Location = new Point(330, 380);
            Lab.Font = new Font("Arial", (float)14.25);
            Nume[1] = Lab;

            Credit[1] = 2000;
            Crd[1] = new Label();
            Crd[1].Visible = true;
            Crd[1].Size = new Size(210, 20);
            Crd[1].Location = new Point(330, 405);
            Crd[1].Font = new Font("Arial", (float)14.25);
            Crd[1].Text = "Credit:" + 2000.ToString();
            for (int i = 2; i <= 15; ++i)
            {
                if (i == 11)
                    continue;
                for (int j = 1; j <= 4; ++j)
                    Img[i, j] = Image.FromFile(i.ToString() + j.ToString() + ".png");
            }
            for (int i = 1; i <= 5; ++i)
            {
                C[i] = new Button();
                C[i].Location = new Point(i * 100 - 50, 235);
                C[i].Size = new Size(80, 130);
                C[i].Enabled = false;
                C[i].Visible = false;
                C[i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(C[i]);
            }
            for (int i = 1; i <= 2; ++i)
            {
                B[1, i] = new Button();
                B[1, i].Location = new Point(200 + i * 100, 440);
                B[1, i].Size = new Size(80, 130);
                B[1, i].Enabled = false;
                B[1, i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls.Add(B[1, i]);
            }
            for (int i = 1; i <= numar_jucatori; ++i)
            {
                this.Controls.Add(Nume[i]);
                this.Controls.Add(Crd[i]);
            }

            Yes = new Button();
            Yes.Text = "DA";
            Yes.Visible = false;
            Yes.Click += new EventHandler(Yes_Click);
            this.Controls.Add(Yes);

            No = new Button();
            No.Text = "NU";
            No.Visible = false;
            No.Click += new EventHandler(No_Click);
            this.Controls.Add(No);

        }

        public int GenereazaCarte()
        {
            int x = (R.Next(10, 48087) * R.Next(2, 14900) % 14) + 2;
            while (x == 11)
                x = (R.Next(10, 48087) * R.Next(2, 19090) % 14) + 2;
            int y = R.Next(1, 400) * R.Next(1, 100) % 4 + 1;
            if (vizitat[x * 10 + y] == true)
                return GenereazaCarte();
            vizitat[x * 10 + y] = true;
            return x * 10 + y;
        }
        private void PreFlop()
        {
            Pot = 0;
            Nume[1].Text = textBoxNume.Text;
            for (int i = 2; i <= numar_jucatori; ++i)
                Nume[i].Text = "Jucatorul " + i.ToString();
            Terminat = false;
            for (int i = 2; i <= 190; ++i)
                vizitat[i] = false;
            for (int i = 1; i <= 5; ++i)
                C[i].Visible = false;
            
            int v1 = min(Credit[Big], ValB);
            Credit[Big] -= v1;
            Pot += v1;
            int v2 = min(Credit[Small], ValS);
            Credit[Small] -= v2;
            Pot += v2;
            Ramasi = 0;

            numericUpRaise.Maximum = Credit[1];
            labelPot.Text = "Pot : " + Pot.ToString();
            
            for (int i = 1; i <= numar_jucatori; ++i)
            {
                joaca[i] = false;
                Nume[i].Visible = false;
                Crd[i].Visible = false;
                if (i > 1)
                    Txt[i].Visible = false;
                B[i, 1].Visible = B[i, 2].Visible = false;
                if (Credit[i] == 0)
                    continue;
                joaca[i] = true;
                Ramasi++;
                for (int j = 1; j <= 2; ++j)
                    Carte[i, j] = GenereazaCarte();
                B[i, 1].Visible = B[i, 2].Visible = true;
                Crd[i].Text = "Credit:" + Credit[i].ToString();
                if (i > 1)
                {
                    Txt[i].Visible = true;
                    Txt[i].Text = " ";
                    B[i, 1].BackgroundImage = Image.FromFile("h1.jpg");
                    B[i, 2].BackgroundImage = Image.FromFile("h1.jpg");
                }
            }
            B[1, 1].BackgroundImage = Img[Carte[1, 1] / 10, Carte[1, 1] % 10];
            B[1, 2].BackgroundImage = Img[Carte[1, 2] / 10, Carte[1, 2] % 10];
            Nume[Big].Text += " (B)";
            Nume[Small].Text += " (S)";
            if (numar_jucatori != 2)
            {
                int p = Small;
                do
                {
                    p = Prev[p];
                }
                while (Credit[p] == 0);
                Nume[p].Text += " (D)";
            }

            for (int i = 1; i <= numar_jucatori; ++i)
                if (Credit[i] > 0)
                {
                    Nume[i].Visible = true;
                    Crd[i].Visible = true;
                }
            Check.Enabled = false;
        }

        private void Pregatire()
        {
            do
            {
                Big = Next[Big];
            }
            while (Credit[Big] <= 0);
            do
            {
                Small = Next[Small];
            }
            while (Credit[Small] <= 0);
            if (Big == Small)
            {
                do
                {
                    Small = Prev[Small];
                }
                while (Credit[Small] <= 0);
            }
        }
        private int Risc(int jucator)
        {
            int[] nr = new int[16], culoare = new int[6];
            int pas = 0, Risc = 999999999;
            int sum = 0;
            for (int i = 1; i <= 15; ++i)
                nr[i] = 0;
            for (int i = 1; i <= 5; ++i)
                culoare[i] = 0;
            for (int i = 1; i <= 5; ++i)  
            {
                if (C[i].Visible == false)
                    break;
                pas = i;
                culoare[CarteJos[i] % 10]++;
                nr[CarteJos[i] / 10]++;
                if (CarteJos[i] / 10 == 15)
                    ++nr[1];
            }
            culoare[Carte[jucator, 1] % 10]++;
            nr[Carte[jucator, 1] / 10]++;
            if (Carte[jucator, 1] / 10 == 15)
                ++nr[1];

            culoare[Carte[jucator, 2] % 10]++;
            if (Carte[jucator, 2] / 10 == 15)
                ++nr[1];
            nr[Carte[jucator, 2] / 10]++;

            for (int i = 1; i <= 5; ++i)
            {
                if (culoare[i] >= 5)
                    Risc = min(Risc, 1);
                else
                if (culoare[i] == 4)
                {
                    if (pas == 3)
                    {
                        sum += 8;
                        Risc = min(Risc, 2);
                    }
                    else
                        if (pas == 4)
                        {
                            sum += 6;
                            Risc = min(Risc, 4);
                        }
                }
                else
                    if (culoare[i] == 3 && pas == 3)
                    {
                        sum += 1;
                        Risc = min(Risc, 6);
                    }
            }
            for (int i = 1; i <= 15; ++i)
                for (int j = 1; j <= 15; ++j)
                {
                    if (nr[i] == 3 && nr[j] == 2)
                        return 0;
                    if (nr[i] == 2 && nr[j] == 2)
                    {
                        if (pas == 3)
                        {
                            sum += 3;
                            Risc = min(Risc, 5);
                        }
                        if (pas == 4)
                        {
                            Risc = min(Risc, 6);
                            sum += 2;
                        }
                        else
                            Risc = min(Risc, 7);
                    }
                }
                   
            for (int i = 2; i <= 15; ++i)
            {
                if (nr[i] == 4)
                    return 0;
                else
                    if (nr[i] == 3)
                    {
                        if (pas == 3)
                            sum += 2;
                        else
                            if (pas == 4)
                                sum += 2;
                        Risc = min(Risc, 4);
                    }
                    else
                        if (nr[i] == 2)
                        {
                            if (i >= 10)
                            {
                                if (pas == 3)
                                    sum += 2;
                                else
                                    sum += 1;
                                Risc = min(Risc, 7);
                            }
                            else
                                Risc = min(Risc, 9);
                        }
           }
           for (int i = 1; i <= 10; ++i) 
           {
               int cnt = 0, k = 1;
               for (int j = i; k <= 5; ++j)
               {
                   if (j == 11)
                       continue;
                   ++k;
                   if (nr[j] > 0)
                       ++cnt;
               }
               if (cnt == 5)
                   Risc = min(Risc, 2);
               else
               {
                   if (cnt == 4)
                   {
                       if(pas == 3){
                           sum += 5;
                           Risc = min(Risc, 4);
                       }
                       if (pas == 4)
                       {
                           sum += 3;
                           Risc = min(Risc, 7);
                       }
                   }
                   if (cnt == 3 && pas == 3)
                   {
                       sum++;
                       Risc = min(Risc, 8);
                   }
               }
           }
           Risc -= sum / 9;
           if (Risc < 0)
               Risc = 0;
           return Risc;
        }
        private void DoAllIn(int jucator)
        {
            Check.Enabled = false;
            Pot += Credit[jucator];
            labelPot.Text = "Pot : " + Pot.ToString();
            Cerut = max(Cerut,Credit[jucator]);
            Credit[jucator] = 0;
            Crd[jucator].Text = "Credit:0";
            Txt[jucator].Text = "AllIn";
            Credit[jucator] = 0;
        }
        private void DoRaise(double risc,int jucator)
        {
            if (risc == 0)
                risc = 0.1;
            int c = Cerut;
            if (c == 0)
                c = dificultate;
            double y = (30*Credit[jucator] + 10*Pot)/(risc*c*Credit[jucator]);
            int x = Cerut + (int)y*ValS;
            if (x < Small)
                x = Small;
            if (x > Credit[jucator])
                x = Credit[jucator];
            if (x >= Credit[jucator])
            {
                DoAllIn(jucator);
                return;
            }
            Cerut = x;
            Credit[jucator] -= x;
            Pot += x;
            labelPot.Text = "Pot : " + Pot.ToString();
            Txt[jucator].Text = "Raise" + pas.ToString();
            Crd[jucator].Text = "Credit:" + Credit[jucator].ToString();
            Check.Enabled = false;
            Alege(2, 1);
            Continuare();
        }
        private void DoCall(int jucator)
        {
            if(Cerut >= Credit[jucator])
            {
                if(dificultate >= 2)
                    DoFold(jucator);
                else
                    DoAllIn(jucator);
                return;
            }
            Credit[jucator] -= Cerut;
            Pot += Cerut;
            labelPot.Text = "Pot:" + Pot.ToString();
            Txt[jucator].Text = "Call" + pas.ToString();
            Crd[jucator].Text = "Credit:" + Credit[jucator].ToString();
        }
        private void DoFold(int jucator)
        {
            Txt[jucator].Text = "Fold" + pas.ToString();
            Txt[jucator].Visible = false;
            B[jucator, 1].Visible = false;
            B[jucator, 2].Visible = false;
            joaca[jucator] = false; 
        }
        private void Alege(int Primul, int Ultimul)
        {
            if (Terminat == true)
                return;
            bool raise = false;
            for (int i = Primul; i != Ultimul; i = Next[i])
            {
                if (joaca[i] == false || Credit[i] == 0)
                    continue;
                double r = 0;
                if (Cerut > 0)
                    r = Cerut/Credit[i];
                if (r < 0.14 * (3 - dificultate + 1))
                    r = 1;
                else
                    if (r >= 1.0)
                         r += 2;
                int k =  (int)r;
                int R = Risc(i);
                if (R > 3)
                    R += k;
                //MessageBox.Show("Cerut =" + Cerut.ToString());
                if (R == 0)
                {
                    DoAllIn(i);
                    raise = true;
                    continue;
                }
                int C = 2;
                if (dificultate != 1)
                    C = 3;
                if (R <= C && facutraise[i] < 2)
                {
                    ++facutraise[i];
                    DoRaise(R, i);
                    raise = true;
                    continue;
                }
                if (Cerut > 0)
                {
                    if (Cerut * dificultate * 12 < Credit[i])
                    {
                        DoCall(i);
                    }
                    else
                    {
                        DoFold(i);
                    }
                    continue;
                }
                Txt[i].Text = "Check" + pas.ToString();
            }
            if (raise == false) 
                Cerut = 0;
            
        }

        private bool Update()
        {
            bool stop = true;
            for (int i = 2; i <= numar_jucatori; ++i)
                if (joaca[i] == true)
                    stop = false;
            if (stop == true)
                return true;
            bool ok = false;
            for (int i = 2; i <= numar_jucatori; ++i)
                if (facutraise[i] > 0)
                    ok = true;
            if (ok==false)
            {
                Cerut = 0;
                Check.Enabled = true;
                Call.Enabled = false;
            }
            else
            {
                Check.Enabled = false;
                Call.Enabled = true;
            }
            if (Credit[1] == 0)
                Check.Enabled = true;
            return false;
        }

        private void Arata(int Left, int Right)
        {
            if (Terminat == true)
                return;
            for (int i = Left; i <= Right; ++i)
            {
                CarteJos[i] = GenereazaCarte();
                C[i].BackgroundImage = Img[CarteJos[i] / 10, CarteJos[i] % 10];
                C[i].Visible = true;
            }
        }

        private void Inceput()
        {
            Check.Visible = false; Call.Visible = false;
            Raise.Visible = false; numericUpRaise.Visible = false;
            buttoFold.Visible = false; buttonAllIn.Visible = false;
            pas = 1;
            for (int i = 2; i <= numar_jucatori; ++i)
                if (joaca[i] == true)
                {
                    B[i, 1].BackgroundImage = Img[Carte[i, 1] / 10, Carte[i, 1] % 10];
                    B[i, 2].BackgroundImage = Img[Carte[i, 2] / 10, Carte[i, 2] % 10];
                }
            Castigator();
            Ok.Visible = true;
            pas = 1;
            Pregatire();
        }

        private bool Sfarsit()
        {
            if (Ramasi == 1 || Credit[1] <= 0)
            {
                for (int i = 1; i <= 5; ++i)
                    C[i].Visible = false;
                labelPot.Visible = false;
                Joc_nou.Visible = false;
                numericUpRaise.Visible = false; Raise.Visible = false;
                Check.Visible = false; Call.Visible = false;
                buttoFold.Visible = false; buttonAllIn.Visible = false;
                buttonAllIn.Enabled = true;
                for (int i = 1; i <= numar_jucatori; ++i)
                {
                    for (int j = 1; j <= 2; ++j)
                        B[i, j].Visible = false;
                    if (i > 1)
                        Txt[i].Visible = false;
                    Crd[i].Visible = false;
                    Nume[i].Visible = false;
                }
                Size S = this.Size;
                Label L = new Label();
                L.Location = new Point(S.Width / 2 - 50, S.Height / 2 - 50);
                L.Size = new Size(230, 80);
                L.Font = new Font("Arial", (float)14.25);
                if (Credit[1] == 0)
                    L.Text = "Ai pierdut! Mai incerci ? ";
                else
                    L.Text = "Ai castigat! Mai incerci ? ";
                this.Controls.Add(L);
                Yes.Location = new Point(S.Width / 2 - 50, S.Height / 2 - 20);
                No.Location = new Point(S.Width / 2 + 50, S.Height / 2 - 20);
                Yes.Visible = true;
                No.Visible = true;
                return true;
            }
            return false;
        }

        private void Joc()
        {
            for (int i = 1; i <= numar_jucatori; ++i)
                facutraise[i] = 0;
            if (Credit[1] > 0)
                Raise.Enabled = true;
            if (pas == 1)
            {
                buttonAllIn.Enabled = true;
                Call.Enabled = true;
                if (Sfarsit() == true)
                    return;
                PreFlop();
                ManaP();
            }
            else
                if (pas == 2)
                {
                    Arata(1, 3);
                    Cerut = 0;
                    Mana();
                }
                else
                    if (pas == 3)
                    {
                        Arata(4, 4);
                        Cerut = 0;
                        Mana();
                    }
                    else
                        if (pas == 4)
                        {
                            Arata(5, 5);
                            Cerut = 0;
                            Mana();
                        }
                        else
                            if (pas == 5)
                                Inceput();
        }

        private void ManaP()
        {
            Raise.Text = "Raise";
            Primul = Big;
            do
            {
                Primul = Next[Primul];
            }
            while (Credit[Primul] == 0);
            for (int i = 2; i <= numar_jucatori; ++i)
                Txt[i].Text = " ";
            Cerut = ValB;
            Alege(Primul, 1);
        }

        private void Mana()
        {
            Raise.Text = "Bet";
            Primul = Small;
            for (int i = 2; i <= numar_jucatori; ++i)
                Txt[i].Text = " ";
            Alege(Small, 1);
        }

        private void Continuare()
        {
            if (Update())
            {
                pas = 1;
                Joc();
                return;
            }
            if (Cerut > 0)
                Mana();
            else
            {
                ++pas;
                Joc();
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            Alege(2, Primul);
            Continuare();
        }

        private void Call_Click(object sender, EventArgs e)
        {
            Cerut = max(ValS,Cerut);
            int v = min(Cerut, Credit[1]);
            Credit[1] -= v;
            Crd[1].Text = "Credit:" + Credit[1].ToString();
            numericUpRaise.Maximum = Credit[1];

            if (Credit[1] == 0)
            {
                Raise.Enabled = false;
                numericUpRaise.Enabled = false;
                Call.Enabled = false;
            }

            Pot += v;
            labelPot.Text = "Pot : " + (Pot).ToString();

            Alege(2, Primul);
            Continuare();
        }

        private void Raise_Click(object sender, EventArgs e)
        {
            numericUpRaise.Value = min((int)numericUpRaise.Value, Credit[1]);
            if (Cerut + numericUpRaise.Value >= Credit[1])
            {
                buttonAllIn_Click(sender, e);
                return;
            }
            Credit[1] -= Cerut + (int)numericUpRaise.Value;
            numericUpRaise.Maximum = Credit[1];
            Crd[1].Text = "Credit:" + Credit[1].ToString();
            Pot += Cerut + (int)numericUpRaise.Value;
            labelPot.Text = "Pot : " + (Pot).ToString();
            Cerut = (int)numericUpRaise.Value;
            Alege(2, 1);
            Continuare();
        }

        private void buttoFold_Click(object sender, EventArgs e)
        {
            pas = 1;
            int minim = 0;
            for (int i = 2; i <= numar_jucatori; ++i)
                if (joaca[i] == true && Credit[i] < Credit[minim])
                    minim = i;
            Credit[minim] += Pot;
            Crd[minim].Text = "Credit: " + Credit[minim].ToString();
            Joc();
        }

        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            Pot += Credit[1];
            Cerut = max(Cerut, Credit[1]);
            labelPot.Text = "Pot:" + Pot.ToString();
            Credit[1] = 0;
            Crd[1].Text = "Credit:0";
            buttonAllIn.Enabled = false;
            for (int i = 2; i <= numar_jucatori; ++i)
            {
                B[i, 1].Visible = false;
                B[i, 2].Visible = false;
                Txt[i].Visible = false;
                joaca[i] = false;
            }
            pas = 5;
            Joc();
        }


        void Yes_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        void No_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Joc_nou_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void Castigator()
        {
            int[] nr = new int[20], culoare = new int[10], valoare = new int[10];
            for (int jucator = 1; jucator <= numar_jucatori; ++jucator)
            {
                valoare[jucator] = -99999;
                if (joaca[jucator] == true)
                {
                    for (int i = 1; i <= 15; ++i)
                        nr[i] = 0;
                    for (int i = 1; i <= 5; ++i)
                        culoare[i] = 0;
                    for (int i = 1; i <= 2; ++i)
                    {
                        try
                        {
                            culoare[Carte[jucator, i] % 10]++;
                            if (Carte[jucator, i] / 10 == 15)
                                ++nr[1];
                            nr[Carte[jucator, i] / 10]++;
                        }
                        catch
                        {
                            Console.WriteLine("Initializare");
                        }
                    }

                    for (int i = 1; i <= 5; ++i)
                    {
                        try
                        {
                            culoare[CarteJos[i] % 10]++;
                            nr[CarteJos[i] / 10]++;
                            if (CarteJos[i] / 10 == 15)
                                nr[1]++;
                        }
                        catch
                        {
                            Console.WriteLine("Initializare");
                        }
                    }
                    ///CHINATA LA CULOARE
                    try
                    {
                        for (int color = 1; color <= 4; ++color)
                            for (int i = 1; i <= 10; ++i)
                            {
                                int k = 0;
                                for (int j = i; k < 5; ++j)
                                {
                                    if (j == 11)
                                        continue;
                                    bool exista = false;
                                    for (int index = 1; index <= 5; ++index)
                                        if (CarteJos[index] / 10 == j && CarteJos[index] % 10 == color)
                                            exista = true;

                                    for (int index = 1; index <= 2; ++index)
                                        if (Carte[jucator, index] / 10 == j && Carte[jucator, index] % 10 == color)
                                            exista = true;
                                    if (exista == false)
                                        break;
                                    ++k;
                                }
                                if (k == 5)
                                    valoare[jucator] = 10 * 100 + i;
                            }
                    }
                    catch
                    {
                        Console.WriteLine("Chinta La culoare!");
                    }
                    if (valoare[jucator] != -99999)
                        continue;
                    ///CAREU
                    try
                    {
                        for (int i = 2; i <= 15; ++i)
                            if (nr[i] == 4)
                                valoare[jucator] = 9 * 100 + i;
                    }
                    catch
                    {
                        Console.WriteLine("Careu!\n");
                    }

                    if (valoare[jucator] != -99999)
                        continue;
                    //FULL
                    try
                    {
                        for (int i = 2; i <= 15; ++i)
                            for (int j = 2; j <= 15; ++j)
                                if (nr[i] == 3 && nr[j] == 2)
                                    valoare[jucator] = 6 * 100 + i * 16 + j;
                    }
                    catch
                    {
                        Console.WriteLine("FULL!\n");
                    }
                    if (valoare[jucator] != -99999)
                        continue;
                    ///CULOARE
                    try
                    {
                        for (int i = 1; i <= 4; ++i)
                            if (culoare[i] >= 5)
                                valoare[jucator] = 5 * 100;
                    }
                    catch
                    {
                        Console.WriteLine("CULOARE");
                    }


                    if (valoare[jucator] != -99999)
                        continue;
                    
                    ///CHINTA
                    try
                    {
                        for (int i = 1; i <= 10; ++i)
                        {
                            int cnt = 0, k = 1;
                            for (int j = i; k <= 5; ++j)
                            {
                                if (j == 11)
                                    continue;
                                ++k;
                                if (nr[j] > 0)
                                    ++cnt;
                            }
                            if (cnt == 5)
                                valoare[jucator] = 4 * 100 + i;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Chinta");
                    }
                    if (valoare[jucator] != -99999)
                        continue;
                
                    ///CUI
                    try
                    {
                        for (int i = 2; i <= 15; ++i)
                            if (nr[i] == 3)
                                valoare[jucator] = 3 * 100 + i;
                    }
                    catch
                    {
                        Console.WriteLine("CUI");
                    }
                    if (valoare[jucator] != -99999)
                        continue;

                    ///DOUA PERECHI
                    try
                    {
                        for (int i = 3; i <= 15; ++i)
                            for (int j = 2; j < i; ++j)
                                if (nr[i] == 2 && nr[j] == 2)
                                    valoare[jucator] = i * 16 + j;
                    }
                    catch
                    {
                        Console.WriteLine("doua perechi");
                    }
                    if (valoare[jucator] != -99999)
                        continue;

                    ///O PERECHE
                    try
                    {
                        for (int i = 2; i <= 15; ++i)
                            if (nr[i] == 2)
                                valoare[jucator] = -100 + i;
                    }
                    catch
                    {
                        Console.WriteLine("O PERECHE");
                    }
                    if (valoare[jucator] != -99999)
                        continue;

                    ///CARTE MARE
                    try
                    {
                        for (int i = 2; i <= 15; ++i)
                            if (nr[i] > 0)
                                valoare[jucator] = -200 + i;
                    }
                    catch
                    {
                        Console.WriteLine("carte mare");
                    }
                }
            }
            int maxx = -999999999, contor = 0;///valoare maxima si de cate ori apare aceasta
            for (int i = 1; i <= numar_jucatori; ++i)
                if (valoare[i] > maxx)
                {
                    maxx = valoare[i];
                    contor = 1;
                }
                else
                    if (valoare[i] == maxx)
                        ++contor;
            for (int i = 1; i <= numar_jucatori; ++i)
                if (valoare[i] == maxx)
                {
                    MessageBox.Show("Castigator : " + i.ToString());
                    Credit[i] += Pot / contor;
                    Crd[i].Text = "Credit:" + Credit[i].ToString();
                }
            ++steps;
            if (steps == 11) 
            {
                steps = 1;
                ValS += 20;
                ValB = 2*ValS;
                numericUpRaise.Increment = ValS;
                numericUpRaise.Value = ValS;
            }
        }
    }
}
