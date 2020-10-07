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
using System.Threading;
using System.Timers;
using System.Windows.Forms;


/* CHANGELOG *
 * 
 * 1.2.6 @ 2013-2020 [27.03.2020] - poprawienie błędu nie wyświetlania znalezionego pliku oraz kilka innych mniej ważnych + dodanie kilku usprawnień oraz pomijanie błędów w przypadku braku dostępu do jakiegoś folderu.
 * 1.2.7 @ 2013-2020 [27.03.2020] - dodanie przycisku "Pokaz wyniki" oraz zmiana dzialania przycisku "Wróć" - teraz wraca do widoku głównego bez przerywania przeszukiwanie + przycisk "Otworz folder" otwiera explorer wraz z zaznaczonym plikiem docelowym + poprawienie bledu pojawianiem sie informacji "Brak wynikow" w momecie kiedy pliki zostaly znalezione ale wyszukiwanie trwalo za szybko aby zarejestrowac ich znalezienie
 * 
 */


namespace SearchFast
{
    public partial class Form1 : Form
    {
        /*public static void ApplicationDoEvents()
        {
            Application.DoEvents();
        }*/

        private static bool isSTOP = true;
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SearchFast\";
        private static string file = folder + "config.cfg";
        private static string notepadPlusPlusExe = null;

        Stopwatch swProgressTime = Stopwatch.StartNew();
        private int iTime = 0;
        private void TimerProgressInfo_Tick(object sender, EventArgs e)
        {
            string sw = swProgressTime.Elapsed.ToString();
            labelProgressTimePre.Text = sw.Remove(sw.Length - 5, 5);
            labelProgressTime.Text = sw.Remove(sw.Length - 5, 5);
            //Application.DoEvents();
            iTime++;
        }
        public Form1()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string[] verbetaArray = { "", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };
            string verbeta = verbetaArray[Int32.Parse(version.Remove(0, version.Length - 1))];

            toolStripStatusLabelVersion.Text = "ver. " + version.Remove(version.Length - 2) + verbeta;

            /* ustawienie paneli i okna */

            labelProgressInfoPre.Text = "";
            labelInfoFindingFilePre.Text = "";
            labelInfoFindingFile.Text = "";
            labelProgressTimePre.Text = "";
            labelProgressTime.Text = "";

            //Form
            ClientSize = new System.Drawing.Size(515, 317);
            MaximumSize = new System.Drawing.Size(531, 356);
            MinimumSize = new System.Drawing.Size(531, 356);

            panelPreResult.Location = new System.Drawing.Point(12, 9);

            panelAskDeleteFile.Location = new System.Drawing.Point(0, 13);

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
                string checkBoxIgnoreErrorsCheck = cfginfo.ReadLine();
                string checkBoxNewLineCheck = cfginfo.ReadLine();
                string checkBoxSubDirCheck = cfginfo.ReadLine();
                textBoxResultFindText.Text = cfginfo.ReadLine();
                string checkBoxResultFindTextIgnoreCaseCheck = cfginfo.ReadLine();
                string checkBoxResultFindTextFlashCheck = cfginfo.ReadLine();

                cfginfo.Close();

                if (checkBoxIgnoreCaseCheck == "True")
                    checkBoxIgnoreCase.Checked = true;
                if (checkBoxIgnoreErrorsCheck == "True")
                    checkBoxIgnoreErrors.Checked = true;
                if (checkBoxNewLineCheck == "True")
                    checkBoxNewLine.Checked = true;
                if (checkBoxSubDirCheck == "True")
                    checkBoxSubDir.Checked = true;
                if (checkBoxResultFindTextIgnoreCaseCheck == "True")
                    checkBoxResultFindTextIgnoreCase.Checked = true;
                if (checkBoxResultFindTextFlashCheck == "True")
                    checkBoxResultFindTextFlash.Checked = true;
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
                notepadPlusPlusExe = GetRegistryValue(@"SOFTWARE\Notepad++", null).ToString() + @"\notepad++.exe";
            }
            catch { }


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
            isSTOP = true;
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
            cfginfo.WriteLine(checkBoxIgnoreErrors.Checked);
            cfginfo.WriteLine(checkBoxNewLine.Checked);
            cfginfo.WriteLine(checkBoxSubDir.Checked);
            cfginfo.WriteLine(textBoxResultFindText.Text);
            cfginfo.WriteLine(checkBoxResultFindTextIgnoreCase.Checked);
            cfginfo.WriteLine(checkBoxResultFindTextFlash.Checked);

            cfginfo.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Text == "STOP")
            {
                isSTOP = true;
                PrepareFormToStart();
                return;
            }

            isSTOP = false;
            panelFindText.Visible = false;

            labelInfoFindingFile.Text = "Rozpoczynanie...";
            labelInfoFindingFilePre.Text = "Rozpoczynanie...";

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
            Save_ConfigFile(); // Save CFG

            //textBoxDir.Text
            //textBoxExt.Text
            //textBoxCopy.Text

            char[] invalidPathChars = Path.GetInvalidPathChars();

            foreach (char c in invalidPathChars)
            {
                string str = c.ToString();
                if (textBoxDir.Text.IndexOf(str) >= 0)
                {
                    MessageBox.Show("Niedozwolone znaki w polu \"Katalog do przeszukania\"");
                    return;
                }
                if (checkBoxCopy.Checked && textBoxCopy.Text.IndexOf(str) >= 0)
                {
                    MessageBox.Show("Niedozwolone znaki w polu \"Kopiuj znalezione pliki do\"");
                    return;
                }
            }

            char[] invalidFileChars = Path.GetInvalidFileNameChars();

            foreach (char c in invalidFileChars)
            {
                if (c != '*')
                {
                    string str = c.ToString();
                    if (textBoxExt.Text.IndexOf(str) >= 0)
                    {
                        MessageBox.Show("Niedozwolone znaki w polu \"Szukaj w plikach\"");
                        return;
                    }
                }
            }


            swProgressTime.Restart();
            timerProgressInfo.Enabled = true;
            labelProgressTimePre.Text = "00:00:00.00";
            labelProgressTime.Text = "00:00:00.00";
            buttonStart.Text = "STOP";
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
            checkBoxSubDir.AutoCheck = false;
            checkBoxIgnoreErrors.AutoCheck = false;
            checkBoxAhoCorasick.AutoCheck = false;

            checkBoxCopy.AutoCheck = false;
            checkBoxCopyExistDelete.AutoCheck = false;
            checkBoxDelete.AutoCheck = false;
            richTextBoxPreview.Clear();
            listViewResultViewPRE.Clear();

            labelerror.Text = "";

            //richTextBox1.Clear();
            listViewResultView.Items.Clear();

            Application.DoEvents();

            if (isSTOP)
                return;

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
                    string[] filePaths = { };

                    labelProgressInfoPre.Text = "Pobieranie listy plików...";
                    //progressBar1Pre.Visible = true;
                    // timerProgressGetDirList.Enabled = true;
                    Application.DoEvents();
                    if (isSTOP)
                        return;

                    if (checkBoxIgnoreErrors.Checked)
                    {

                        Thread thread1 = new Thread(() =>
                        {
                            try
                            {
                                if (checkBoxSubDir.Checked)
                                {

                                    IEnumerable<string> listFiles = GetFiles(textBoxDir.Text, textBoxExt.Text);
                                    //filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text, SearchOption.AllDirectories);
                                    foreach (string file in listFiles)
                                    {
                                        if (isSTOP)
                                            return;
                                        Array.Resize(ref filePaths, filePaths.Length + 1);

                                        filePaths[filePaths.Length - 1] = file;
                                    }
                                }
                                else
                                {
                                    if (isSTOP)
                                        return;
                                    filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                timerProgressInfo.Enabled = false;
                                MessageBox.Show("Bład przy pobieraniu listy plików:" + Environment.NewLine + ex.Message);

                                PrepareFormToStart();
                                Save_ConfigFile();
                                return;
                            }

                            if (isSTOP)
                                return;
                        });
                        thread1.Start();
                        while (thread1.IsAlive)
                            Application.DoEvents();
                        thread1.Join();
                    }
                    else
                    {
                        try
                        {
                            if (checkBoxSubDir.Checked)
                            {
                                filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text, SearchOption.AllDirectories);
                            }
                            else
                            {
                                filePaths = Directory.GetFiles(textBoxDir.Text, textBoxExt.Text);
                            }
                        }
                        catch (Exception ex)
                        {
                            timerProgressInfo.Enabled = false;
                            MessageBox.Show("Bład przy pobieraniu listy plików:" + Environment.NewLine + ex.Message);

                            PrepareFormToStart();
                            Save_ConfigFile();
                            return;
                        }
                    }

                    if (isSTOP)
                        return;

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

                        for (int nr = 0; nr < filePaths.Length; nr++)
                        {
                            if (isSTOP == true)
                                return;

                            string filename = filePaths[nr].Replace(textBoxDir.Text, "");
                            if (filename.Remove(1, filename.Length - 1) == @"\")
                                filename = filename.Remove(0, 1);

                            progressBar1Pre.Value = progressBar1Pre.Value + 1;
                            labelProgressInfoPre.Text = "Przeszukano: " + progressBar1Pre.Value + " / " + progressBar1Pre.Maximum;
                            labelProgressInfo.Text = labelProgressInfoPre.Text;
                            progressBar1.Value = progressBar1Pre.Value;

                            labelInfoFindingFilePre_ShowText(filename);
                            labelInfoFindingFile_ShowText(filePaths[nr]);

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
                                string findtxt = checkBoxNewLine.Checked ? textBoxFindText1All.Text.Replace(@"\n", Environment.NewLine) : textBoxFindText1All.Text;
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

                                try
                                {
                                    Thread thread2 = new Thread(() => {

                                        long length = new FileInfo(filePaths[nr]).Length;

                                        //MessageBox.Show(length.ToString());
                                        if (length > 50000000) // sprawdza rozmiar ... jesli wiekszy od X
                                        {
                                            StreamReader reader = new StreamReader(filePaths[nr]);
                                            while (!reader.EndOfStream)
                                            {
                                                if (isSTOP == true)
                                                    return;
                                                //Application.DoEvents();
                                                string text = reader.ReadLine();
                                                foreach (string word in trie.Find(checkBoxIgnoreCase.Checked ? text.ToLower() : text))
                                                {
                                                    isfound = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string text = File.ReadAllText(filePaths[nr]);
                                            // find words
                                            foreach (string word in trie.Find(checkBoxIgnoreCase.Checked ? text.ToLower() : text))
                                            {
                                                isfound = true;
                                                break;
                                            }
                                        }

                                        if (isSTOP)
                                            return;
                                    });
                                    thread2.Start();
                                    while (thread2.IsAlive)
                                        Application.DoEvents();
                                    thread2.Join();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bład pliku:" + Environment.NewLine + ex.Message);
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

                                /*string lineall = "";
                                int i = 0;
                                foreach (var lineread in File.ReadAllLines(filePaths[nr]))
                                {
                                    labelInfoFindingFileStep.Text = "(step:" +i + ")";
                                    Application.DoEvents();
                                    lineall += (checkBoxIgnoreCase.Checked ? lineread.ToLower() : lineread) + Environment.NewLine;
                                    i++;
                                }
                                string findtxt = textBoxFindText1All.Text;
                                if (lineall.Contains(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt))
                                    isfound = true;
                                    */

                                string lineall = String.Join(Environment.NewLine, File.ReadAllLines(filePaths[nr]));

                                if (checkBoxIgnoreCase.Checked)
                                    lineall = lineall.ToLower();

                                string findtxt = textBoxFindText1All.Text;
                                if (lineall.Contains(checkBoxIgnoreCase.Checked ? findtxt.ToLower() : findtxt))
                                    isfound = true;
                            }

                            if (isfound == true)
                            {
                                if (isSTOP == true)
                                    return;
                                /*filename = filePaths[nr].Replace(textBoxDir.Text, "");
                                if (filename.Remove(1, filename.Length - 1) == @"\")
                                    filename = filename.Remove(0, 1);*/

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

                                //labelFindedItemsCount.Text = "Znaleziono: " + listViewResultView.Items.Count;

                                if (!PrepareFormToResultList_FirstExecuted)
                                {
                                    PrepareFormToResultList_FirstExecuted = true;
                                    PrepareFormToResultList();
                                }
                            }
                        }
                        //if (richTextBox1.Text == "")
                        if (listViewResultView.Items.Count <= 0 && listViewResultViewPRE.Items.Count <= 0)
                        {
                            labelerror.Text = "Brak wyników.";
                            labelerror.Visible = true;
                        }
                        else
                        {
                            //PrepareFormToResultList(); // show result when finish

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
            if (labelerror.Visible == true)
                PrepareFormToStart();

            progressBar1.Visible = false;
            progressBar1Pre.Visible = false;
            timerProgressInfo.Enabled = false;


            listBoxResult_Show();

            labelInfoFindingFile.Text = "Przeszukiwanie zakończone.";
            labelInfoFindingFilePre.Text = "Przeszukiwanie zakończone.";

            //Save_ConfigFile(); // Save CFG

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

        private bool PrepareFormToResultList_FirstExecuted = false;

        private void labelInfoFindingFilePre_ShowText(string filename)
        {
            labelInfoFindingFilePre.Text = @".\" + filename;
            while (labelInfoFindingFilePre.Size.Width > 480)
                labelInfoFindingFilePre.Text = @"..." + labelInfoFindingFilePre.Text.Substring(10);
            Application.DoEvents();
        }
        private void labelInfoFindingFile_ShowText(string filePath)
        {
            labelInfoFindingFile.Text = filePath;
            while (labelInfoFindingFile.Size.Width > 900)
                labelInfoFindingFile.Text = @"..." + labelInfoFindingFile.Text.Substring(10);
            Application.DoEvents();
        }

        //private static int GetFilesProgressValue = 0;
        //private static int GetFilesProgressMax = 0;
        //private static string GetFilesProgressDir;

        /*private void timerProgressGetDirList_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show(GetFilesProgressValue + " / " + GetFilesProgressMax);
            
            //labelInfoFindingFilePre_ShowText(GetFilesProgressDir.Substring(textBoxDir.Text.Length));
            //progressBar1Pre.Maximum = GetFilesProgressMax;
            //progressBar1Pre.Value = GetFilesProgressValue;
            
        }*/

        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
            Stack<string> pending = new Stack<string>();
            pending.Push(root);
            while (pending.Count != 0)
            {
                /*
                    if (pending.Count > GetFilesProgressMax)
                    GetFilesProgressMax = pending.Count;
                GetFilesProgressValue = GetFilesProgressMax-pending.Count;
                */
                var path = pending.Pop();
                string[] next = null;
                try
                {
                    next = Directory.GetFiles(path, searchPattern);
                    //GetFilesProgressDir = Path.GetDirectoryName(next[0]);
                }
                catch { }
                if (next != null && next.Length != 0)
                    foreach (var file in next) yield return file;
                try
                {
                    next = Directory.GetDirectories(path);
                    foreach (var subdir in next) pending.Push(subdir);
                }
                catch { }
            }
        }

        private void buttonShowResultPanel_Click(object sender, EventArgs e)
        {
            panelPreResult.Visible = true;

            ClientSize = new System.Drawing.Size(950, 592);
            MaximumSize = new System.Drawing.Size(966, 631);
            MinimumSize = new System.Drawing.Size(966, 631);

            Application.DoEvents();
        }

        private void PrepareFormToResultList()
        {
            if (isSTOP == true)
                return;

            //progressBar1Pre.Visible = false;
            progressBar1.Visible = true;

            ClientSize = new System.Drawing.Size(950, 592);
            MaximumSize = new System.Drawing.Size(966, 631);
            MinimumSize = new System.Drawing.Size(966, 631);

            labelTextToSearch.Text = textBoxFindText1All.Text;
            panelPreResult.Visible = true;

            buttonShowResultPanel.Enabled = true;

            Application.DoEvents();
        }

        private int findedItemsCount = 0;
        private void listBoxResult_ItemAdd(int nr, string strFile, string infoOperation)
        {
            findedItemsCount++;
            labelFindedItemsCount.Text = "Znaleziono: " + findedItemsCount;
            /*string[] arr = new string[2];
            ListViewItem itm;
            //add items to ListView
            arr[0] = strFile;
            arr[1] = infoOperation;
            itm = new ListViewItem(arr);
            listViewResultViewPRE.Items.Add(itm);*/

            listViewResultViewPRE.Items.Add(new ListViewItem(new string[] { strFile, infoOperation }));

            if (iTime % 5 == 1)
            {
                //listViewResultView.BeginUpdate();

                listBoxResult_Show();
                //listViewResultView.EndUpdate();
                //Application.DoEvents();
            }
        }

        private void listBoxResult_Show()
        {
            int i = 1;
            foreach (ListViewItem item in listViewResultViewPRE.Items)
            {
                listViewResultView.Items.Add((ListViewItem)item.Clone());
                listViewResultViewPRE.Items.Remove(item);
                i++;
            }
        }

        private void buttonBackToHome_Click(object sender, EventArgs e)
        {
            //isSTOP = true;
            PrepareFormToHome();
            //panelPreResult.Visible = false;
        }

        private void PrepareFormToStart()
        {
            timerProgressInfo.Enabled = false;
            labelProgressTimePre.Text = "";
            labelProgressTime.Text = "";
            panelPreResult.Visible = false;
            listViewResultView.Items.Clear();// richTextBox1.Clear();

            if (checkBoxAhoCorasick.Checked)
                textBoxFindText1All.ReadOnly = true;
            else
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
            checkBoxSubDir.AutoCheck = true;
            checkBoxIgnoreErrors.AutoCheck = true;
            checkBoxAhoCorasick.AutoCheck = true;

            checkBoxCopy.AutoCheck = true;
            checkBoxCopyExistDelete.AutoCheck = true;
            checkBoxDelete.AutoCheck = true;

            buttonStart.Text = "Szukaj";
            //buttonStart.Enabled = true;
            progressBar1Pre.Visible = false;
            progressBar1.Visible = false;

            labelProgressInfoPre.Text = "";
            labelInfoFindingFilePre.Text = "";
            labelInfoFindingFile.Text = "";

            this.ClientSize = new System.Drawing.Size(515, 317);
            this.MaximumSize = new System.Drawing.Size(531, 356);
            this.MinimumSize = new System.Drawing.Size(531, 356);

            buttonResultEditorOpenNotepadWindows.Enabled = false;
            buttonResultEditorOpenNotepadPlusPlus.Enabled = false;

            buttonResultFindTextShowNextToUP.Enabled = false;
            buttonResultFindTextShowNextToDOWN.Enabled = false;

            buttonResultOpenExplorer.Enabled = false;

            PrepareFormToResultList_FirstExecuted = false;

            buttonShowResultPanel.Enabled = false;

            findedItemsCount = 0;

            Application.DoEvents();
        }

        private void PrepareFormToHome()
        {
            panelPreResult.Visible = false;

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

        private void listViewResultView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResultView.SelectedItems.Count == 0)
            {
                buttonResultEditorOpenNotepadWindows.Enabled = false;
                buttonResultEditorOpenNotepadPlusPlus.Enabled = false;
                buttonResultOpenExplorer.Enabled = false;
                return;
            }

            string curItem = textBoxDir.Text + "\\" + listViewResultView.SelectedItems[0].Text.ToString();

            string text = File.ReadAllText(curItem);

            richTextBoxPreview.Text = text;
            labelPreviewFileName.Text = Path.GetFileName(curItem);

            buttonResultEditorOpenNotepadWindows.Enabled = true;
            if (notepadPlusPlusExe != null)
                buttonResultEditorOpenNotepadPlusPlus.Enabled = true;
            buttonResultOpenExplorer.Enabled = true;

            ShowNext_indexStart = -1;
            FindTextFlash();
        }

        private void ButtonResultEditorOpenNotepadWindows_Click(object sender, EventArgs e)
        {
            LaunchCommandLineApp("Notepad", textBoxDir.Text + "\\" + listViewResultView.SelectedItems[0].Text);
        }

        private void ButtonResultEditorOpenNotepadPlusPlus_Click(object sender, EventArgs e)
        {
            LaunchCommandLineApp(notepadPlusPlusExe, textBoxDir.Text + "\\" + listViewResultView.SelectedItems[0].Text);
        }

        static void LaunchCommandLineApp(string file, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = file;
            p.StartInfo.Arguments = "\"" + arguments + "\"";
            p.Start();
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
            {
                FindTextArrow_Change();
                textBoxFindText2.Focus();
            }
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

        private void TextBoxResultFindText_TextChanged(object sender, EventArgs e)
        {
            if (textBoxResultFindText.TextLength > 0)
            {
                buttonResultFindTextShowNextToUP.Enabled = true;
                buttonResultFindTextShowNextToDOWN.Enabled = true;
            }
            else
            {
                buttonResultFindTextShowNextToUP.Enabled = false;
                buttonResultFindTextShowNextToDOWN.Enabled = false;
            }

            FindTextFlash();
        }

        private void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        private void CheckBoxResultFindTextFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxResultFindTextFlash.Checked)
                FindTextFlash();
            else
                richTextBoxPreview.Text = richTextBoxPreview.Text;
        }

        int FindText_CountFound = 0;
        private void FindTextFlash()
        {
            richTextBoxPreview.Text = richTextBoxPreview.Text;
            FindText_CountFound = 0;

            string findstr = textBoxResultFindText.Text;
            string richText = richTextBoxPreview.Text;

            if (richText.Length <= 0 || findstr.Length <= 0)
            {
                buttonResultFindTextShowNextToUP.Enabled = false;
                buttonResultFindTextShowNextToDOWN.Enabled = false;
                labelResultFindTextCountFound.Text = "Znaleziono: 0";
                return;
            }

            int indexStart = -1;

            
            while (true)
            {
                if(checkBoxResultFindTextIgnoreCase.Checked)
                    indexStart = richText.IndexOf(findstr, indexStart + 1, StringComparison.CurrentCultureIgnoreCase);
                else
                    indexStart = richText.IndexOf(findstr, indexStart + 1);

                if (indexStart < 0)
                    break;
                //richTextBoxPreview.Text = richText.Remove(indexStart, indexLenght);

                if (checkBoxResultFindTextFlash.Checked)
                {
                    richTextBoxPreview.Select(indexStart, findstr.Length);
                    //richTextBoxPreview.Clear();
                    //richTextBoxPreview.SelectionStart = indexStart;
                    richTextBoxPreview.SelectionColor = Color.Red;
                    richTextBoxPreview.SelectedText = richTextBoxPreview.SelectedText;
                }

                FindText_CountFound++;
            }

            labelResultFindTextCountFound.Text = "Znaleziono: " + FindText_CountFound.ToString();

            if (FindText_CountFound > 0)
            {
                buttonResultFindTextShowNextToUP.Enabled = true;
                buttonResultFindTextShowNextToDOWN.Enabled = true;
            }
            else
            {
                buttonResultFindTextShowNextToUP.Enabled = false;
                buttonResultFindTextShowNextToDOWN.Enabled = false;
            }
        }

        private int ShowNext_indexStart = -1;
        private void ButtonResultFindTextShowNextToUP_Click(object sender, EventArgs e)
        {
            string findstr = textBoxResultFindText.Text;
            string richText = richTextBoxPreview.Text;

            if (richText.Length <= 0 || findstr.Length <= 0)
                return;

            if (ShowNext_indexStart < 0)
                ShowNext_indexStart = richText.Length - findstr.Length + 1;

            if (ShowNext_indexStart == 0)
            {
                ShowNext_indexStart = -1;
                MessageBox.Show("Brak dalszych wyników.");
                return;
            }
            ///(findstr.Length == 2 ? 0 : 1)
            if (checkBoxResultFindTextIgnoreCase.Checked)
                ShowNext_indexStart = richText.LastIndexOf(findstr, ShowNext_indexStart + findstr.Length - 2, StringComparison.CurrentCultureIgnoreCase);
            else
                ShowNext_indexStart = richText.LastIndexOf(findstr, ShowNext_indexStart + findstr.Length - 2);

            if (ShowNext_indexStart < 0)
            {
                ShowNext_indexStart = -1;
                MessageBox.Show("Brak dalszych wyników.");
            }
            else
            {
            richTextBoxPreview.Select(ShowNext_indexStart, findstr.Length);
                richTextBoxPreview.Focus();
                //richTextBoxPreview.ScrollToCaret();
            }
        }

        
        private void ButtonResultFindTextShowNextToDOWN_Click(object sender, EventArgs e)
        {
            string findstr = textBoxResultFindText.Text;
            string richText = richTextBoxPreview.Text;

            if (richText.Length <= 0 || findstr.Length <= 0)
                return;

            if (checkBoxResultFindTextIgnoreCase.Checked)
                ShowNext_indexStart = richText.IndexOf(findstr, ShowNext_indexStart + 1, StringComparison.CurrentCultureIgnoreCase);
            else
                ShowNext_indexStart = richText.IndexOf(findstr, ShowNext_indexStart + 1);

            if (ShowNext_indexStart < 0)
            {
                ShowNext_indexStart = -1;
                MessageBox.Show("Brak dalszych wyników.");
            }
            else
            {
                richTextBoxPreview.Select(ShowNext_indexStart, findstr.Length);
                richTextBoxPreview.Focus();
                //richTextBoxPreview.ScrollToCaret();
            }
        }

        private void buttonResultOpenExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", string.Format("/select,\"{0}\"", (textBoxDir.Text + "\\" + listViewResultView.SelectedItems[0].Text).Replace(@"\\", @"\")));
        }
    }
}
