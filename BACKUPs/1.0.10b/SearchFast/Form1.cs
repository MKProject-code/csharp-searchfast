﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SearchFast
{
    public partial class Form1 : Form
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SearchFast\";
        public static string file = folder + "config.cfg";

        public Form1()
        {
            InitializeComponent();

            if (File.Exists(file))
            {
                StreamReader cfginfo = new StreamReader(file);
                textBoxText.Text = cfginfo.ReadLine();
                textBoxDir.Text = cfginfo.ReadLine();
                textBoxExt.Text = cfginfo.ReadLine();
                textBoxCopy.Text = cfginfo.ReadLine();
                string checkBoxIgnoreCaseCheck = cfginfo.ReadLine();
                string checkBoxNewLineCheck = cfginfo.ReadLine();
                string checkBoxSubDirCheck = cfginfo.ReadLine();
                cfginfo.Close();

                if (checkBoxIgnoreCaseCheck == "True")
                    checkBoxIgnoreCase.Checked = true;
                if (checkBoxNewLineCheck == "True")
                    checkBoxIgnoreCase.Checked = true;
                if (checkBoxSubDirCheck == "True")
                    checkBoxSubDir.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxDelete.Checked)
            {
                labelAsk.Text = "Znalezione pliki zostaną usuniete!" + Environment.NewLine + "Czy na pewno chcesz kontynuować?";
                panelAskDeleteFile.Visible = true;
            }
            else if (checkBoxCopyExistDelete.Checked)
            {
                labelAsk.Text = "Kopiowane pliki zostaną nadpisane!" + Environment.NewLine + "Czy na pewno chcesz kontynuować?";
                panelAskDeleteFile.Visible = true;
            }
            else
            {
                searchfiles();
            }
        }

        private void buttonDeleteYes_Click(object sender, EventArgs e)
        {
            panelAskDeleteFile.Visible = false;
            searchfiles();
        }

        private void buttonDeleteNo_Click(object sender, EventArgs e)
        {
            panelAskDeleteFile.Visible = false;
        }

        private void searchfiles()
        {
            button1.Enabled = false;
            button1.Text = "Czekaj...";
            textBoxText.ReadOnly = true;
            textBoxDir.ReadOnly = true;
            textBoxExt.ReadOnly = true;
            textBoxCopy.ReadOnly = true;
            checkBoxIgnoreCase.AutoCheck = false;
            checkBoxNewLine.AutoCheck = false;
            checkBoxCopy.AutoCheck = false;
            checkBoxCopyExistDelete.AutoCheck = false;
            checkBoxDelete.AutoCheck = false;
            richTextBox1.Clear();
            progressBar1.Visible = true;
            Application.DoEvents();
            string findtxt = textBoxText.Text;
            if (textBoxText.Text == "" || textBoxDir.Text == "" || textBoxExt.Text == "")
            {
                labelerror.Text = "Żadne z pól nie może być puste.";
                labelerror.Visible = true;
            }
            else
            {
                if (!Directory.Exists(textBoxDir.Text))
                {
                    labelerror.Text = "Folder z plikami do przeszukania nie istnieje.";
                    labelerror.Visible = true;
                }
                else if (checkBoxCopy.Checked && !Directory.Exists(textBoxCopy.Text))
                {
                    labelerror.Text = "Folder, do którego mają się skopiować pliki nie istnieje.";
                    labelerror.Visible = true;
                }
                else
                {
                    string[] filePaths;
                    if(checkBoxSubDir.Checked)
                        filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text, SearchOption.AllDirectories);
                    else
                        filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text);
                    
                    if (filePaths.Length == 0)
                    {
                        labelerror.Text = "Brak plików.";
                        labelerror.Visible = true;
                    }
                    else
                    {
                        if (checkBoxNewLine.Checked == true)
                            findtxt = findtxt.Replace(@"\n", Environment.NewLine);

                        progressBar1.Value = 0;
                        progressBar1.Maximum = filePaths.Length;//0;

                        //for (int nr = 0; nr < filePaths.Length; nr++)
                        //{
                        //    progressBar1.Maximum = progressBar1.Maximum + 1;
                        //}

                        string filename;
                        for (int nr = 0; nr < filePaths.Length; nr++)
                        {
                            progressBar1.Value = progressBar1.Value + 1;
                            //File.ReadLines(filePaths[nr])
                            //.SkipWhile (line => !line.Contains(textBox1.Text));
                            //.Skip(1) // optional
                            //.TakeWhile(line => !line.Contains("CustomerCh"));
                            
                            List<List<string>> groups = new List<List<string>>();
                            List<string> current = null;
                            if (checkBoxIgnoreCase.Checked == true)
                            {
                                /*foreach (var linex in File.ReadAllLines(filePaths[nr]))
                                {
                                    var line = linex.ToLower();
                                    if (line.Contains(findtxt.ToLower()) && current == null)
                                        current = new List<string>();
                                    if (current != null)
                                        current.Add(line);
                                }*/
                                string lineall = "";
                                foreach (var lineread in File.ReadAllLines(filePaths[nr]))
                                {
                                    Application.DoEvents();
                                    var line = lineread.ToLower();
                                    lineall += line + Environment.NewLine;
                                }

                                if (lineall.Contains(findtxt.ToLower()) && current == null)
                                    current = new List<string>();
                                if (current != null)
                                    current.Add(lineall);
                            }
                            else
                            {
                                /*foreach (var line in File.ReadAllLines(filePaths[nr]))
                                {
                                    if (line.Contains(textBox1.Text) && current == null)
                                        current = new List<string>();
                                    if (current != null)
                                        current.Add(line);
                                }*/
                                string lineall = "";
                                foreach (var lineread in File.ReadAllLines(filePaths[nr]))
                                {
                                    Application.DoEvents();
                                    var line = lineread;
                                    lineall += line + Environment.NewLine;
                                }

                                if (lineall.Contains(findtxt) && current == null)
                                    current = new List<string>();
                                if (current != null)
                                    current.Add(lineall);

                            }

                            if (Convert.ToString(current) != "")
                            {
                                filename = filePaths[nr].Replace(textBoxDir.Text, "");
                                if (filename.Remove(1, filename.Length - 1) == @"\")
                                    filename = filename.Remove(0, 1);

                                bool isok = true;

                                if (checkBoxDelete.Checked)
                                {
                                    if (checkBoxCopy.Checked)
                                    {
                                        try
                                        {
                                            if (checkBoxCopyExistDelete.Checked)
                                            {
                                                if (File.Exists(Path.Combine(textBoxCopy.Text, filename)))
                                                    File.Delete(Path.Combine(textBoxCopy.Text, filename));
                                            }
                                            File.Move(Path.Combine(textBoxDir.Text, filename), Path.Combine(textBoxCopy.Text, filename));
                                        }
                                        catch
                                        {
                                            richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal skopiowany ani usuniety." + Environment.NewLine;
                                            isok = false;
                                        }

                                        if (isok == true)
                                            richTextBox1.SelectedText = filename + " - Plik zostal poprawnie skopiowany i usuniety." + Environment.NewLine;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            File.Delete(Path.Combine(textBoxDir.Text, filename));
                                        }
                                        catch
                                        {
                                            richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal usuniety." + Environment.NewLine;
                                            isok = false;
                                        }

                                        if (isok == true)
                                            richTextBox1.SelectedText = filename + " - Plik zostal poprawnie usuniety." + Environment.NewLine;
                                    }
                                }
                                else
                                {
                                    if (checkBoxCopy.Checked)
                                    {
                                        try
                                        {
                                            if (checkBoxCopyExistDelete.Checked)
                                            {
                                                if (File.Exists(Path.Combine(textBoxCopy.Text, filename)))
                                                    File.Delete(Path.Combine(textBoxCopy.Text, filename));
                                            }
                                            File.Copy(Path.Combine(textBoxDir.Text, filename), Path.Combine(textBoxCopy.Text, filename));
                                        }
                                        catch
                                        {
                                            richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal skopiowany." + Environment.NewLine;
                                            isok = false;
                                        }

                                        if (isok == true)
                                            richTextBox1.SelectedText = filename + " - Plik zostal poprawnie skopiowany." + Environment.NewLine;
                                    }
                                    else
                                    {
                                        richTextBox1.SelectedText = filename + " - Brak operacji na pliku." + Environment.NewLine;
                                    }
                                }
                            }

                        }
                        if (richTextBox1.Text == "")
                        {
                            labelerror.Text = "Brak wyników.";
                            labelerror.Visible = true;
                        }
                        else
                        {
                            /*if (File.Exists(file))
                                File.Delete(file);

                            Directory.CreateDirectory(folder);

                            StreamWriter cfginfo = new StreamWriter(file);
                            cfginfo.WriteLine(textBoxText.Text);
                            cfginfo.WriteLine(textBoxDir.Text);
                            cfginfo.WriteLine(textBoxExt.Text);
                            cfginfo.WriteLine(textBoxCopy.Text);
                            cfginfo.WriteLine(checkBoxIgnoreCase.Checked);
                            cfginfo.WriteLine(checkBoxNewLine.Checked);
                            cfginfo.WriteLine(checkBoxSubDir.Checked);
                            cfginfo.Close();*/

                            panel1.Visible = true;
                        }
                    }

                    if (File.Exists(file))
                        File.Delete(file);

                    Directory.CreateDirectory(folder);

                    StreamWriter cfginfo = new StreamWriter(file);
                    cfginfo.WriteLine(textBoxText.Text);
                    cfginfo.WriteLine(textBoxDir.Text);
                    cfginfo.WriteLine(textBoxExt.Text);
                    cfginfo.WriteLine(textBoxCopy.Text);
                    cfginfo.WriteLine(checkBoxIgnoreCase.Checked);
                    cfginfo.WriteLine(checkBoxNewLine.Checked);
                    cfginfo.WriteLine(checkBoxSubDir.Checked);
                    cfginfo.Close();
                }
            }
            textBoxText.ReadOnly = false;
            textBoxDir.ReadOnly = false;
            textBoxExt.ReadOnly = false;
            textBoxCopy.ReadOnly = false;
            checkBoxIgnoreCase.AutoCheck = true;
            checkBoxNewLine.AutoCheck = true;
            checkBoxCopy.AutoCheck = true;
            checkBoxCopyExistDelete.AutoCheck = true;
            checkBoxDelete.AutoCheck = true;
            button1.Text = "Szukaj";
            button1.Enabled = true;
            progressBar1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            richTextBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxText.TextLength > 0)
            {
                labelerror.Visible = false;
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (button1.Enabled == true && panel1.Visible == false)
                {
                    searchfiles();
                }
            }
        }

        private void checkBoxCopy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCopy.Checked)
            {
                textBoxCopy.Enabled = true;
                checkBoxCopyExistDelete.Enabled = true;
            }
            else
            {
                textBoxCopy.Enabled = false;
                checkBoxCopyExistDelete.Enabled = false;
            }
        }
    }
}
