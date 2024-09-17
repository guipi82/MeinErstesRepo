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
using System.Speech;
using System.Speech.Synthesis;
using System.Media;
using System.Text.RegularExpressions;

namespace DialectTranslator
{
    public partial class Form1 : Form
    {
        int tabcomNr = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {






        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Fr_Ni1 = "Traduction\\dico1.txt"; 
            var Fr_Ni2 = "Traduction\\dico2.txt";
            var Fr_Ew1 = "Traduction\\Fr_Ew1.txt";
            var Fr_Ew2 = "Traduction\\Fr_Ew2.txt";

            int tabNr1 = tabControl1.SelectedIndex;
            int tabNr2 = tabControl2.SelectedIndex;

            string tabn1 = tabNr1.ToString();
            string tabn2 = tabNr2.ToString();

            string tabCombineNr = string.Concat(tabn1, tabn2);
            tabcomNr = Int32.Parse(tabCombineNr);

            switch (tabcomNr)
            {
                case (0):
                    traduction(Fr_Ni1, Fr_Ni2);
                    break;
                case (1):
                    traduction(Fr_Ew1, Fr_Ew2);
                    break;


                    //default:
                    //    Console.WriteLine($"Measured value is {measurement}.");
                    //    break;
            }

        }






        //SpeechSynthesizer reader = new SpeechSynthesizer();

        private void traduction(string PathName1, string PathName2 = "") 
        {
            try
            {
                //var pathlocation = "Traduction\\dico1.txt"; //C:\\Data\\disco.csv
                //var pathlocation1 = "Traduction\\dico2.txt";
                string value = "";
                string value1 = "";
                string value2 = "";
                bool TextOK1 = true;


                //string path = Path.Combine(pathlocation);

                FileInfo file = new FileInfo(PathName1);
                FileInfo file1 = new FileInfo(PathName2);

                if ((file.Exists) || (file1.Exists))
                {
                    var lines = File.ReadAllLines(PathName1);
                    var lines1 = File.ReadAllLines(PathName2);
                    string subs2 = textBox1.Text.TrimEnd(' ');

                    for (int c = 0; c < lines1.Length; c++)
                    {
                        string[] subs4 = lines1[c].Split(',');

                        if (subs2.Equals(subs4[0].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            switch (tabcomNr)
                            {
                                case (0):
                                    textBox2.Text = subs4[1].ToString();
                                    break;
                                case (1):
                                    textBox3.Text = subs4[1].ToString();
                                    break;
                                default:
                                    break;
                            }
                            TextOK1 = false;
                        }


                    }

                    if (TextOK1)
                    {
                        string subs5 = textBox1.Text.TrimEnd(' ');
                        string[] subs3 = subs5.Split(' ');
                        for (int i = 0; i < subs3.Length; i++)
                        {
                            for (int j = 0; j < lines.Length; j++)
                            {
                                string[] subs = lines[j].Split(',');

                                if (subs3[i].Equals(subs[0], StringComparison.OrdinalIgnoreCase))
                                {
                                    value += string.Concat(subs[0], " ");
                                    value1 += string.Concat(subs[1], " ");
                                    value2 = value.TrimEnd(' ');
                                    break;
                                }

                            }
                        }
                        switch (tabcomNr)
                        {
                            case (0):
                                textBox2.Text = value1.ToString();
                                break;
                            case (1):
                                textBox3.Text = value1.ToString();
                                break;
                            default:
                                break;
                        }
                        
                    }

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                MessageBox.Show("Please enter some text first!");
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabcomNr)
                {
                    case (0):
                        playsound("Soundaufnahmen\\Nihep",textBox2.Text);
                        break;
                    case (1):
                        playsound("Soundaufnahmen\\Ewondo",textBox3.Text);
                        break;
                    default:
                        break;
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void playsound(string soundPath, string textbox ) 
        {
            var folderloca = soundPath;
            var dir = new DirectoryInfo(folderloca);
            if (dir.Exists)
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                FileInfo[] files = dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    string[] subs = files[i].ToString().Split('.');  //trennen nach dem punkt
                    textbox = textbox.TrimEnd(' ');
                    if ((textbox != "") || (textBox1.Text != ""))
                    {
                        if (textbox.Equals(subs[0], StringComparison.OrdinalIgnoreCase))
                        {    
                            var soundloc = Path.Combine(soundPath, files[i].ToString());
                            SoundPlayer sound = new SoundPlayer(soundloc);
                            sound.PlaySync();                    

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter some text first!");
                        break;
                    }


                }


            }
        }
    }
}
