using AhoCorasick;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace SearchFast
{
    public partial class Form1 : Form
    {
        /*public static void ApplicationDoEvents()
        {
            Application.DoEvents();
        }*/

        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SearchFast\";
        public static string file = folder + "config.cfg";
        private string notepadPlusPlusExe = null;

        Stopwatch swProgressTime = Stopwatch.StartNew();
        private void TimerProgressInfo_Tick(object sender, EventArgs e)
        {
            string sw = swProgressTime.Elapsed.ToString();
            labelProgressTime.Text = sw.Remove(sw.Length - 5, 5);
            //Application.DoEvents();
        }
        public Form1()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            toolStripStatusLabelVersion.Text = "ver. " + version.Remove(version.Length - 2);

            /* ustawienie paneli i okna */

            labelProgressInfoPre.Text = "";
            labelInfoFindingFile.Text = "";
            labelProgressTime.Text = "";

            //Form
            ClientSize = new System.Drawing.Size(515, 317);
            MaximumSize = new System.Drawing.Size(531, 356);
            MinimumSize = new System.Drawing.Size(531, 356);

            panelPreResult.Location = new System.Drawing.Point(12, 9);

            panelAskDeleteFile.Location = new System.Drawing.Point(12, 13);

            panelFindText.Location = new System.Drawing.Point(12, 48);

            /* koniec ustawien */


            if (File.Exists(file))
            {
                StreamReader cfginfo = new StreamReader(file);
                textBoxFindText1All.Text = cfginfo.ReadLine();
                textBoxFindText2.Text = cfginfo.ReadLine();
                textBoxFindText3.Text = cfginfo.ReadLine();
                textBoxFindText4.Text = cfginfo.ReadLine();
                textBoxFindText5.Text = cfginfo.ReadLine();
                textBoxFindText6.Text = cfginfo.ReadLine();
                textBoxFindText7.Text = cfginfo.ReadLine();
                textBoxDir.Text = cfginfo.ReadLine();
                textBoxExt.Text = cfginfo.ReadLine();
                textBoxCopy.Text = cfginfo.ReadLine();
                string checkBoxIgnoreCaseCheck = cfginfo.ReadLine();
                string checkBoxNewLineCheck = cfginfo.ReadLine();
                string checkBoxSubDirCheck = cfginfo.ReadLine();
                string radioButtonResultEditor1Check = cfginfo.ReadLine();
                textBoxResultFindText.Text = cfginfo.ReadLine();
                string radioButtonResultFindTextUpCheck = cfginfo.ReadLine();

                cfginfo.Close();

                if (checkBoxIgnoreCaseCheck == "True")
                    checkBoxIgnoreCase.Checked = true;
                if (checkBoxNewLineCheck == "True")
                    checkBoxNewLine.Checked = true;
                if (checkBoxSubDirCheck == "True")
                    checkBoxSubDir.Checked = true;
                if (radioButtonResultEditor1Check == "True")
                    radioButtonResultEditor1.Checked = true;
                if (radioButtonResultFindTextUpCheck == "True")
                    radioButtonResultFindTextUp.Checked = true;
            }

            /*System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            process.StartInfo = startInfo;
            process.Start();

            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd /c notepad++";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            AdjustFormScrollbars(true);
            */
            try
            {
                string notepadPlusPlusExe = GetRegistryValue(@"SOFTWARE\Notepad++", null).ToString() + @"\notepad++.exe";
            }
            catch
            {
                radioButtonResultEditor1.Checked = true;
                radioButtonResultEditor2.Enabled = false;
            }
           

        }
        public static RegistryKey GetRegistryKey()
        {
            return GetRegistryKey(null);
        }

        public static RegistryKey GetRegistryKey(string keyPath)
        {
            RegistryKey localMachineRegistry
                = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                          Environment.Is64BitOperatingSystem
                                              ? RegistryView.Registry64
                                              : RegistryView.Registry32);

            return string.IsNullOrEmpty(keyPath)
                ? localMachineRegistry
                : localMachineRegistry.OpenSubKey(keyPath);
        }

        public static object GetRegistryValue(string keyPath, string keyName)
        {
            RegistryKey registry = GetRegistryKey(keyPath);
            return registry.GetValue(keyName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_ConfigFile();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
            //Application.DoEvents();
        }
        private void Save_ConfigFile()
        {
            if (File.Exists(file))
                File.Delete(file);

            Directory.CreateDirectory(folder);

            StreamWriter cfginfo = new StreamWriter(file);
            cfginfo.WriteLine(textBoxFindText1All.Text);
            cfginfo.WriteLine(textBoxFindText2.Text);
            cfginfo.WriteLine(textBoxFindText3.Text);
            cfginfo.WriteLine(textBoxFindText4.Text);
            cfginfo.WriteLine(textBoxFindText5.Text);
            cfginfo.WriteLine(textBoxFindText6.Text);
            cfginfo.WriteLine(textBoxFindText7.Text);
            cfginfo.WriteLine(textBoxDir.Text);
            cfginfo.WriteLine(textBoxExt.Text);
            cfginfo.WriteLine(textBoxCopy.Text);
            cfginfo.WriteLine(checkBoxIgnoreCase.Checked);
            cfginfo.WriteLine(checkBoxNewLine.Checked);
            cfginfo.WriteLine(checkBoxSubDir.Checked);
            cfginfo.WriteLine(radioButtonResultEditor1.Checked);
            cfginfo.WriteLine(textBoxResultFindText.Text);
            cfginfo.WriteLine(radioButtonResultFindTextUp.Checked);

            cfginfo.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            panelFindText.Visible = false;
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
            swProgressTime.Restart();
            timerProgressInfo.Enabled = true;
            labelProgressTime.Text = "00:00:00.00";
            buttonStart.Enabled = false;
            buttonStart.Text = "Czekaj...";
            textBoxFindText1All.ReadOnly = true;
            textBoxFindText2.ReadOnly = true;
            textBoxFindText3.ReadOnly = true;
            textBoxFindText4.ReadOnly = true;
            textBoxFindText5.ReadOnly = true;
            textBoxFindText6.ReadOnly = true;
            textBoxFindText7.ReadOnly = true;
            textBoxDir.ReadOnly = true;
            textBoxExt.ReadOnly = true;
            textBoxCopy.ReadOnly = true;
            checkBoxIgnoreCase.AutoCheck = false;
            checkBoxNewLine.AutoCheck = false;
            checkBoxCopy.AutoCheck = false;
            checkBoxCopyExistDelete.AutoCheck = false;
            checkBoxDelete.AutoCheck = false;

            labelerror.Text = "";

            //richTextBox1.Clear();
            listViewResult.Items.Clear();

            Application.DoEvents();

            string findtxt = textBoxFindText1All.Text;
            if (textBoxFindText1All.Text == "" || textBoxDir.Text == "" || textBoxExt.Text == "")
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
                    if (checkBoxSubDir.Checked)
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
                        progressBar1Pre.Value = 0;
                        progressBar1.Value = 0;
                        progressBar1Pre.Maximum = filePaths.Length;
                        progressBar1.Maximum = filePaths.Length;

                        //for (int nr = 0; nr < filePaths.Length; nr++)
                        //{
                        //    progressBar1.Maximum = progressBar1.Maximum + 1;
                        //}
                        //listBoxResult.Enabled = false;

                        /* ustawienie paneli i okna */
                        //Form

                        progressBar1Pre.Visible = true;
                        progressBar1.Visible = true;

                        string filename;
                        for (int nr = 0; nr < filePaths.Length; nr++)
                        {
                            progressBar1Pre.Value = progressBar1Pre.Value + 1;
                            labelProgressInfoPre.Text = "Przeszukano: " + progressBar1Pre.Value + " / " + progressBar1Pre.Maximum;
                            labelProgressInfo.Text = labelProgressInfoPre.Text;
                            progressBar1.Value = progressBar1Pre.Value;

                            labelInfoFindingFile.Text = filePaths[nr];
                            Application.DoEvents();
                            //File.ReadLines(filePaths[nr])
                            //.SkipWhile (line => !line.Contains(textBox1.Text));
                            //.Skip(1) // optional
                            //.TakeWhile(line => !line.Contains("CustomerCh"));

                            List<List<string>> groups = new List<List<string>>();
                            //List<string> current = null;
                            bool isfound = false;

                            //////////////////////////////////////////
                            if (checkBoxAhoCorasick.Checked)
                            {
                                //Application.DoEvents();
                                // Construct the automaton
                                AhoCorasick.Trie trie = new AhoCorasick.Trie();
                                
                                // add words

                                findtxt = checkBoxNewLine.Checked ? textBoxFindText1All.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText1All.Text;
                                trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText2.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText2.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText3.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText3.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText4.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText4.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText5.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText5.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText6.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText6.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                findtxt = checkBoxNewLine.Checked ? textBoxFindText7.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText7.Text;
                                if (findtxt != "")
                                    trie.Add(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt);
                                //trie.Add("world");

                                // build search tree
                                trie.Build();
                                long length = new FileInfo(filePaths[nr]).Length;
                                //MessageBox.Show(length.ToString());
                                if (length > 50000000) // sprawdza rozmiar ... jesli wiekszy od X
                                {
                                    StreamReader reader = new StreamReader(filePaths[nr]);
                                    while (!reader.EndOfStream)
                                    {
                                        Application.DoEvents();
                                        string text = reader.ReadLine();
                                        foreach (string word in trie.Find(checkBoxIgnoreCase.Checked ? text.ToLower() : text))
                                            isfound = true;

                                    }
                                }
                                else
                                {
                                    string text = File.ReadAllText(filePaths[nr]);
                                    // find words
                                    foreach (string word in trie.Find(checkBoxIgnoreCase.Checked ? text.ToLower() : text))
                                        isfound = true;
                                }

                            }
                            else
                            {
                                //////////////////////////////////////////

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
                                    //Application.DoEvents();
                                    lineall += (checkBoxIgnoreCase.Checked ? lineread.ToLower() : lineread) + Environment.NewLine;
                                }

                                if (lineall.Contains(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt))
                                    isfound = true;
                            }

                            if (isfound == true)
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
                                            //richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal skopiowany ani usuniety." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "BŁĄD! Plik nie zostal skopiowany ani usuniety.");
                                            isok = false;
                                        }

                                        if (isok == true)
                                        {
                                            //richTextBox1.SelectedText = filename + " - Plik zostal poprawnie skopiowany i usuniety." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "Plik zostal poprawnie skopiowany i usuniety.");
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            File.Delete(Path.Combine(textBoxDir.Text, filename));
                                        }
                                        catch
                                        {
                                            //richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal usuniety." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "BŁĄD! Plik nie zostal usuniety.");
                                            isok = false;
                                        }

                                        if (isok == true)
                                        {
                                            //richTextBox1.SelectedText = filename + " - Plik zostal poprawnie usuniety." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "Plik zostal poprawnie usuniety.");
                                        }
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
                                            //richTextBox1.SelectedText = filename + " - BŁĄD! Plik nie zostal skopiowany." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "BŁĄD! Plik nie zostal skopiowany.");
                                            isok = false;
                                        }

                                        if (isok == true)
                                        {
                                            //richTextBox1.SelectedText = filename + " - Plik zostal poprawnie skopiowany." + Environment.NewLine;
                                            listBoxResult_ItemAdd(nr, filename, "Plik zostal poprawnie skopiowany.");
                                        }
                                    }
                                    else
                                    {
                                        //richTextBox1.SelectedText = filename + " - Brak operacji na pliku." + Environment.NewLine;
                                        listBoxResult_ItemAdd(nr, filename, "Brak operacji na pliku.");
                                    }
                                }
                            }

                        }
                        //if (richTextBox1.Text == "")
                        if (listViewResult.Items.Count <= 0)
                        {
                            labelerror.Text = "Brak wyników.";
                            labelerror.Visible = true;
                        }
                        else
                        {
                            progressBar1Pre.Visible = false;
                            progressBar1.Visible = false;

                            ClientSize = new System.Drawing.Size(950, 592);
                            MaximumSize = new System.Drawing.Size(966, 631);
                            MinimumSize = new System.Drawing.Size(966, 631);

                            panelPreResult.Visible = true;

                            //Application.DoEvents();

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

                            //listBoxResult.Enabled = true;
                        }
                    }
                }
            }
            if(panelPreResult.Visible == false)
                PrepareFormToHome();

            Save_ConfigFile(); // Save CFG

            //Application.DoEvents();

            /*textBoxText.ReadOnly = false;
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

            this.ClientSize = new System.Drawing.Size(515, 317);
            this.MaximumSize = new System.Drawing.Size(531, 356);
            this.MinimumSize = new System.Drawing.Size(531, 356);

            Application.DoEvents();*/
        }

        private void listBoxResult_ItemAdd(int nr, string strFile, string infoOperation)
        {
            string[] arr = new string[4];
            ListViewItem itm;
            //add items to ListView
            arr[0] = strFile;
            arr[1] = infoOperation;
            itm = new ListViewItem(arr);
            listViewResult.Items.Add(itm);

            if (nr % 10 == 1)
                Application.DoEvents();
        }

        private void buttonBackToHome_Click(object sender, EventArgs e)
        {
            PrepareFormToHome();
        }

        private void PrepareFormToHome()
        {
            timerProgressInfo.Enabled = false;
            labelProgressTime.Text = "";
            panelPreResult.Visible = false;
            listViewResult.Items.Clear();// richTextBox1.Clear();

            textBoxFindText1All.ReadOnly = false;
            textBoxFindText2.ReadOnly = false;
            textBoxFindText3.ReadOnly = false;
            textBoxFindText4.ReadOnly = false;
            textBoxFindText5.ReadOnly = false;
            textBoxFindText6.ReadOnly = false;
            textBoxFindText7.ReadOnly = false;
            textBoxDir.ReadOnly = false;
            textBoxExt.ReadOnly = false;
            textBoxCopy.ReadOnly = false;
            checkBoxIgnoreCase.AutoCheck = true;
            checkBoxNewLine.AutoCheck = true;
            checkBoxCopy.AutoCheck = true;
            checkBoxCopyExistDelete.AutoCheck = true;
            checkBoxDelete.AutoCheck = true;
            buttonStart.Text = "Szukaj";
            buttonStart.Enabled = true;
            progressBar1Pre.Visible = false;
            progressBar1.Visible = false;

            labelProgressInfoPre.Text = "";
            labelInfoFindingFile.Text = "";

            this.ClientSize = new System.Drawing.Size(515, 317);
            this.MaximumSize = new System.Drawing.Size(531, 356);
            this.MinimumSize = new System.Drawing.Size(531, 356);

            Application.DoEvents();
        }


        private void textBoxFindText_TextChanged(object sender, EventArgs e)
        {
            if (!checkBoxAhoCorasick.Checked)
                return;

                textBoxFindText1All.Text = "";

            textBoxFindText1_AutoFill(textBoxFindText2);
            textBoxFindText1_AutoFill(textBoxFindText3);
            textBoxFindText1_AutoFill(textBoxFindText4);
            textBoxFindText1_AutoFill(textBoxFindText5);
            textBoxFindText1_AutoFill(textBoxFindText6);
            textBoxFindText1_AutoFill(textBoxFindText7);
        }

        private void textBoxFindText1_AutoFill(TextBox textbox)
        {
            if (textbox.TextLength > 0)
            {
                if (textBoxFindText1All.TextLength > 0)
                    textBoxFindText1All.Text += ";" + textbox.Text;
                else
                    textBoxFindText1All.Text = textbox.Text;
            }
        }

        private void textBoxFindText1All_TextChanged(object sender, EventArgs e)
        {
            if (!checkBoxAhoCorasick.Checked)
                textBoxFindText2.Text = textBoxFindText1All.Text;
            if (textBoxFindText1All.TextLength > 0)
            {
                labelerror.Visible = false;
                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private void textBoxFindText1All_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (buttonStart.Enabled == true && panelPreResult.Visible == false)
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

        private void ListViewResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResult.SelectedItems.Count == 0)
                return;

            string curItem = textBoxDir.Text + "\\" + listViewResult.SelectedItems[0].Text.ToString();

            string text = File.ReadAllText(curItem);

            richTextBoxPreview.Text = text;
        }

        private void ButtonEditorOpen_Click(object sender, EventArgs e)
        {
            string curItem = textBoxDir.Text + "\\" + listViewResult.SelectedItems[0].Text.ToString();

            if (radioButtonResultEditor1.Checked == true)
            {
                LaunchCommandLineApp("Notepad", curItem);
            }
            else if (radioButtonResultEditor2.Checked == true)
            {
                LaunchCommandLineApp(notepadPlusPlusExe, curItem);
            }

        }

        static void LaunchCommandLineApp(string file, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = file;
            p.StartInfo.Arguments = "\"" + arguments + "\"";
            p.Start();
        }

        private void ButtonResultFindText_Click(object sender, EventArgs e)
        {

        }

        private void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void PictureBoxFindTextArrow_Click(object sender, EventArgs e)
        {
            FindTextArrow_Change();
        }

        private void CheckBoxAhoCorasick_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAhoCorasick.Checked)
            {
                textBoxFindText2.Text = textBoxFindText1All.Text;
                textBoxFindText_TextChanged(null, null);
                textBoxFindText1All.ReadOnly = true;
                panelFindText.Enabled = true;
            }
           else
            {
                textBoxFindText1All.Text = textBoxFindText2.Text;
                textBoxFindText1All.ReadOnly = false;
                panelFindText.Enabled = false;
            }
        }

        private void TextBoxFindText1All_Click(object sender, EventArgs e)
        {
            if (checkBoxAhoCorasick.Checked)
                FindTextArrow_Change();
        }

        private void FindTextArrow_Change()
        {
            if (panelFindText.Visible)
            {
                //buttonStart.Enabled = true;
                panelFindText.Visible = false;
                checkBoxAhoCorasick.ForeColor = System.Drawing.SystemColors.ControlText;
                pictureBoxFindTextArrow.Image = global::SearchFast.Properties.Resources.arrowDown;
            }
            else
            {
                //buttonStart.Enabled = false;
                panelFindText.Visible = true;
                checkBoxAhoCorasick.ForeColor = System.Drawing.Color.DarkRed;
                pictureBoxFindTextArrow.Image = global::SearchFast.Properties.Resources.arrowUp;
            }
        }

        private void FormAll_MouseHover(object sender, EventArgs e)
        {
            panelFindText.Visible = false;
            checkBoxAhoCorasick.ForeColor = System.Drawing.SystemColors.ControlText;
            pictureBoxFindTextArrow.Image = global::SearchFast.Properties.Resources.arrowDown;
        }
    }
}
