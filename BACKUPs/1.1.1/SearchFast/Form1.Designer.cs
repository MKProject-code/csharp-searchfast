namespace SearchFast
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxFindText1All = new System.Windows.Forms.TextBox();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.labelFindText = new System.Windows.Forms.Label();
            this.labelDir = new System.Windows.Forms.Label();
            this.labelExt = new System.Windows.Forms.Label();
            this.textBoxExt = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.checkBoxNewLine = new System.Windows.Forms.CheckBox();
            this.textBoxCopy = new System.Windows.Forms.TextBox();
            this.checkBoxCopy = new System.Windows.Forms.CheckBox();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxCopyExistDelete = new System.Windows.Forms.CheckBox();
            this.labelerror = new System.Windows.Forms.Label();
            this.labelAsk = new System.Windows.Forms.Label();
            this.buttonDeleteYes = new System.Windows.Forms.Button();
            this.buttonDeleteNo = new System.Windows.Forms.Button();
            this.panelAskDeleteFile = new System.Windows.Forms.Panel();
            this.panelPreResult = new System.Windows.Forms.Panel();
            this.buttonBackToHome = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxResultFindText = new System.Windows.Forms.GroupBox();
            this.radioButtonResultFindTextUp = new System.Windows.Forms.RadioButton();
            this.radioButtonResultFindTextDown = new System.Windows.Forms.RadioButton();
            this.groupBoxResultEditor = new System.Windows.Forms.GroupBox();
            this.radioButtonResultEditor1 = new System.Windows.Forms.RadioButton();
            this.radioButtonResultEditor2 = new System.Windows.Forms.RadioButton();
            this.textBoxResultFindText = new System.Windows.Forms.TextBox();
            this.listViewResult = new System.Windows.Forms.ListView();
            this.columnHeaderFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxPreview = new System.Windows.Forms.RichTextBox();
            this.buttonResultFindText = new System.Windows.Forms.Button();
            this.buttonResultEditorOpen = new System.Windows.Forms.Button();
            this.labelProgressInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxSubDir = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1Pre = new System.Windows.Forms.ProgressBar();
            this.labelProgressInfoPre = new System.Windows.Forms.Label();
            this.labelInfoFindingFile = new System.Windows.Forms.Label();
            this.checkBoxAhoCorasick = new System.Windows.Forms.CheckBox();
            this.labelProgressTime = new System.Windows.Forms.Label();
            this.timerProgressInfo = new System.Windows.Forms.Timer(this.components);
            this.panelFindText = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFindTextOr3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFindTextOr2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFindTextOr1 = new System.Windows.Forms.Label();
            this.textBoxFindText7 = new System.Windows.Forms.TextBox();
            this.textBoxFindText4 = new System.Windows.Forms.TextBox();
            this.textBoxFindText6 = new System.Windows.Forms.TextBox();
            this.textBoxFindText3 = new System.Windows.Forms.TextBox();
            this.textBoxFindText5 = new System.Windows.Forms.TextBox();
            this.textBoxFindText2 = new System.Windows.Forms.TextBox();
            this.pictureBoxFindTextArrow = new System.Windows.Forms.PictureBox();
            this.panelAskDeleteFile.SuspendLayout();
            this.panelPreResult.SuspendLayout();
            this.groupBoxResultFindText.SuspendLayout();
            this.groupBoxResultEditor.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelFindText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFindTextArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFindText1All
            // 
            this.textBoxFindText1All.Location = new System.Drawing.Point(33, 29);
            this.textBoxFindText1All.Name = "textBoxFindText1All";
            this.textBoxFindText1All.ReadOnly = true;
            this.textBoxFindText1All.Size = new System.Drawing.Size(469, 20);
            this.textBoxFindText1All.TabIndex = 0;
            this.textBoxFindText1All.Click += new System.EventHandler(this.TextBoxFindText1All_Click);
            this.textBoxFindText1All.TextChanged += new System.EventHandler(this.textBoxFindText1All_TextChanged);
            this.textBoxFindText1All.DoubleClick += new System.EventHandler(this.TextBoxFindText1All_Click);
            this.textBoxFindText1All.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(12, 68);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(490, 20);
            this.textBoxDir.TabIndex = 1;
            this.textBoxDir.Text = "C:\\Files";
            // 
            // labelFindText
            // 
            this.labelFindText.AutoSize = true;
            this.labelFindText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFindText.Location = new System.Drawing.Point(30, 14);
            this.labelFindText.Name = "labelFindText";
            this.labelFindText.Size = new System.Drawing.Size(85, 15);
            this.labelFindText.TabIndex = 2;
            this.labelFindText.Text = "Szukany tekst:";
            this.labelFindText.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDir.Location = new System.Drawing.Point(9, 52);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(140, 15);
            this.labelDir.TabIndex = 3;
            this.labelDir.Text = "Katalog do przeszukania:";
            // 
            // labelExt
            // 
            this.labelExt.AutoSize = true;
            this.labelExt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelExt.Location = new System.Drawing.Point(9, 91);
            this.labelExt.Name = "labelExt";
            this.labelExt.Size = new System.Drawing.Size(401, 15);
            this.labelExt.TabIndex = 5;
            this.labelExt.Text = "Szukaj w plikach:  ( dopuszczalne: *.txt   lub   *.*   lub   plik.*   lub   *xx*." +
    "* )";
            // 
            // textBoxExt
            // 
            this.textBoxExt.Location = new System.Drawing.Point(12, 107);
            this.textBoxExt.Name = "textBoxExt";
            this.textBoxExt.Size = new System.Drawing.Size(490, 20);
            this.textBoxExt.TabIndex = 4;
            this.textBoxExt.Text = "*.txt";
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.Location = new System.Drawing.Point(247, 230);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(255, 28);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Szukaj";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Opcje:";
            this.label4.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // checkBoxIgnoreCase
            // 
            this.checkBoxIgnoreCase.AutoSize = true;
            this.checkBoxIgnoreCase.Location = new System.Drawing.Point(73, 172);
            this.checkBoxIgnoreCase.Name = "checkBoxIgnoreCase";
            this.checkBoxIgnoreCase.Size = new System.Drawing.Size(121, 17);
            this.checkBoxIgnoreCase.TabIndex = 12;
            this.checkBoxIgnoreCase.Text = "Ignoruj wielkość liter";
            this.checkBoxIgnoreCase.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreCase.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // checkBoxNewLine
            // 
            this.checkBoxNewLine.AutoSize = true;
            this.checkBoxNewLine.Location = new System.Drawing.Point(73, 195);
            this.checkBoxNewLine.Name = "checkBoxNewLine";
            this.checkBoxNewLine.Size = new System.Drawing.Size(143, 17);
            this.checkBoxNewLine.TabIndex = 13;
            this.checkBoxNewLine.Text = "Obsługa: \\n  (nowa linia)";
            this.checkBoxNewLine.UseVisualStyleBackColor = true;
            this.checkBoxNewLine.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // textBoxCopy
            // 
            this.textBoxCopy.Enabled = false;
            this.textBoxCopy.Location = new System.Drawing.Point(12, 146);
            this.textBoxCopy.Name = "textBoxCopy";
            this.textBoxCopy.Size = new System.Drawing.Size(490, 20);
            this.textBoxCopy.TabIndex = 15;
            this.textBoxCopy.Text = "C:\\Copy Files";
            // 
            // checkBoxCopy
            // 
            this.checkBoxCopy.AutoSize = true;
            this.checkBoxCopy.Location = new System.Drawing.Point(12, 129);
            this.checkBoxCopy.Name = "checkBoxCopy";
            this.checkBoxCopy.Size = new System.Drawing.Size(147, 17);
            this.checkBoxCopy.TabIndex = 18;
            this.checkBoxCopy.Text = "Kopiuj znalezione pliki do:";
            this.checkBoxCopy.UseVisualStyleBackColor = true;
            this.checkBoxCopy.CheckedChanged += new System.EventHandler(this.checkBoxCopy_CheckedChanged);
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(242, 172);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(242, 17);
            this.checkBoxDelete.TabIndex = 19;
            this.checkBoxDelete.Text = "Usuń znalezione pliki (usuwa po skopiowaniu)";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            this.checkBoxDelete.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // checkBoxCopyExistDelete
            // 
            this.checkBoxCopyExistDelete.AutoSize = true;
            this.checkBoxCopyExistDelete.Enabled = false;
            this.checkBoxCopyExistDelete.Location = new System.Drawing.Point(165, 129);
            this.checkBoxCopyExistDelete.Name = "checkBoxCopyExistDelete";
            this.checkBoxCopyExistDelete.Size = new System.Drawing.Size(85, 17);
            this.checkBoxCopyExistDelete.TabIndex = 21;
            this.checkBoxCopyExistDelete.Text = "Nadpisz pliki";
            this.checkBoxCopyExistDelete.UseVisualStyleBackColor = true;
            // 
            // labelerror
            // 
            this.labelerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelerror.Location = new System.Drawing.Point(12, 261);
            this.labelerror.Name = "labelerror";
            this.labelerror.Size = new System.Drawing.Size(490, 41);
            this.labelerror.TabIndex = 10;
            this.labelerror.Text = "Błąd.";
            this.labelerror.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelerror.Visible = false;
            this.labelerror.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // labelAsk
            // 
            this.labelAsk.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAsk.Location = new System.Drawing.Point(3, 39);
            this.labelAsk.Name = "labelAsk";
            this.labelAsk.Size = new System.Drawing.Size(484, 137);
            this.labelAsk.TabIndex = 2;
            this.labelAsk.Text = "Znalezione pliki zostaną usuniete!\r\nCzy na pewno chcesz kontynuować?";
            this.labelAsk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteYes
            // 
            this.buttonDeleteYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteYes.Location = new System.Drawing.Point(108, 148);
            this.buttonDeleteYes.Name = "buttonDeleteYes";
            this.buttonDeleteYes.Size = new System.Drawing.Size(130, 28);
            this.buttonDeleteYes.TabIndex = 1;
            this.buttonDeleteYes.Text = "TAK";
            this.buttonDeleteYes.UseVisualStyleBackColor = true;
            this.buttonDeleteYes.Click += new System.EventHandler(this.buttonDeleteYes_Click);
            // 
            // buttonDeleteNo
            // 
            this.buttonDeleteNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDeleteNo.Location = new System.Drawing.Point(244, 148);
            this.buttonDeleteNo.Name = "buttonDeleteNo";
            this.buttonDeleteNo.Size = new System.Drawing.Size(130, 28);
            this.buttonDeleteNo.TabIndex = 3;
            this.buttonDeleteNo.Text = "NIE";
            this.buttonDeleteNo.UseVisualStyleBackColor = true;
            this.buttonDeleteNo.Click += new System.EventHandler(this.buttonDeleteNo_Click);
            // 
            // panelAskDeleteFile
            // 
            this.panelAskDeleteFile.Controls.Add(this.buttonDeleteNo);
            this.panelAskDeleteFile.Controls.Add(this.buttonDeleteYes);
            this.panelAskDeleteFile.Controls.Add(this.labelAsk);
            this.panelAskDeleteFile.Location = new System.Drawing.Point(134, 417);
            this.panelAskDeleteFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.panelAskDeleteFile.Name = "panelAskDeleteFile";
            this.panelAskDeleteFile.Size = new System.Drawing.Size(490, 392);
            this.panelAskDeleteFile.TabIndex = 20;
            this.panelAskDeleteFile.Visible = false;
            // 
            // panelPreResult
            // 
            this.panelPreResult.Controls.Add(this.buttonBackToHome);
            this.panelPreResult.Controls.Add(this.progressBar1);
            this.panelPreResult.Controls.Add(this.groupBoxResultFindText);
            this.panelPreResult.Controls.Add(this.groupBoxResultEditor);
            this.panelPreResult.Controls.Add(this.textBoxResultFindText);
            this.panelPreResult.Controls.Add(this.listViewResult);
            this.panelPreResult.Controls.Add(this.richTextBoxPreview);
            this.panelPreResult.Controls.Add(this.buttonResultFindText);
            this.panelPreResult.Controls.Add(this.buttonResultEditorOpen);
            this.panelPreResult.Controls.Add(this.labelProgressInfo);
            this.panelPreResult.Controls.Add(this.label1);
            this.panelPreResult.Location = new System.Drawing.Point(818, 29);
            this.panelPreResult.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panelPreResult.Name = "panelPreResult";
            this.panelPreResult.Size = new System.Drawing.Size(926, 558);
            this.panelPreResult.TabIndex = 9;
            this.panelPreResult.Visible = false;
            // 
            // buttonBackToHome
            // 
            this.buttonBackToHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonBackToHome.Location = new System.Drawing.Point(3, 512);
            this.buttonBackToHome.Name = "buttonBackToHome";
            this.buttonBackToHome.Size = new System.Drawing.Size(920, 43);
            this.buttonBackToHome.TabIndex = 37;
            this.buttonBackToHome.Text = "Wróć";
            this.buttonBackToHome.UseVisualStyleBackColor = true;
            this.buttonBackToHome.Click += new System.EventHandler(this.buttonBackToHome_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 493);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(920, 13);
            this.progressBar1.TabIndex = 38;
            this.progressBar1.Visible = false;
            // 
            // groupBoxResultFindText
            // 
            this.groupBoxResultFindText.Controls.Add(this.radioButtonResultFindTextUp);
            this.groupBoxResultFindText.Controls.Add(this.radioButtonResultFindTextDown);
            this.groupBoxResultFindText.Location = new System.Drawing.Point(4, 419);
            this.groupBoxResultFindText.Name = "groupBoxResultFindText";
            this.groupBoxResultFindText.Size = new System.Drawing.Size(109, 68);
            this.groupBoxResultFindText.TabIndex = 36;
            this.groupBoxResultFindText.TabStop = false;
            this.groupBoxResultFindText.Text = "Kierunek";
            // 
            // radioButtonResultFindTextUp
            // 
            this.radioButtonResultFindTextUp.AutoSize = true;
            this.radioButtonResultFindTextUp.Location = new System.Drawing.Point(12, 19);
            this.radioButtonResultFindTextUp.Name = "radioButtonResultFindTextUp";
            this.radioButtonResultFindTextUp.Size = new System.Drawing.Size(60, 17);
            this.radioButtonResultFindTextUp.TabIndex = 31;
            this.radioButtonResultFindTextUp.Text = "W górę";
            this.radioButtonResultFindTextUp.UseVisualStyleBackColor = true;
            // 
            // radioButtonResultFindTextDown
            // 
            this.radioButtonResultFindTextDown.AutoSize = true;
            this.radioButtonResultFindTextDown.Checked = true;
            this.radioButtonResultFindTextDown.Location = new System.Drawing.Point(12, 42);
            this.radioButtonResultFindTextDown.Name = "radioButtonResultFindTextDown";
            this.radioButtonResultFindTextDown.Size = new System.Drawing.Size(55, 17);
            this.radioButtonResultFindTextDown.TabIndex = 31;
            this.radioButtonResultFindTextDown.TabStop = true;
            this.radioButtonResultFindTextDown.Text = "W dół";
            this.radioButtonResultFindTextDown.UseVisualStyleBackColor = true;
            // 
            // groupBoxResultEditor
            // 
            this.groupBoxResultEditor.Controls.Add(this.radioButtonResultEditor1);
            this.groupBoxResultEditor.Controls.Add(this.radioButtonResultEditor2);
            this.groupBoxResultEditor.Location = new System.Drawing.Point(4, 273);
            this.groupBoxResultEditor.Name = "groupBoxResultEditor";
            this.groupBoxResultEditor.Size = new System.Drawing.Size(109, 68);
            this.groupBoxResultEditor.TabIndex = 35;
            this.groupBoxResultEditor.TabStop = false;
            this.groupBoxResultEditor.Text = "Edytor";
            // 
            // radioButtonResultEditor1
            // 
            this.radioButtonResultEditor1.AutoSize = true;
            this.radioButtonResultEditor1.Location = new System.Drawing.Point(12, 19);
            this.radioButtonResultEditor1.Name = "radioButtonResultEditor1";
            this.radioButtonResultEditor1.Size = new System.Drawing.Size(65, 17);
            this.radioButtonResultEditor1.TabIndex = 31;
            this.radioButtonResultEditor1.Text = "Notatnik";
            this.radioButtonResultEditor1.UseVisualStyleBackColor = true;
            // 
            // radioButtonResultEditor2
            // 
            this.radioButtonResultEditor2.AutoSize = true;
            this.radioButtonResultEditor2.Checked = true;
            this.radioButtonResultEditor2.Location = new System.Drawing.Point(12, 42);
            this.radioButtonResultEditor2.Name = "radioButtonResultEditor2";
            this.radioButtonResultEditor2.Size = new System.Drawing.Size(78, 17);
            this.radioButtonResultEditor2.TabIndex = 31;
            this.radioButtonResultEditor2.TabStop = true;
            this.radioButtonResultEditor2.Text = "Notepad++";
            this.radioButtonResultEditor2.UseVisualStyleBackColor = true;
            // 
            // textBoxResultFindText
            // 
            this.textBoxResultFindText.Location = new System.Drawing.Point(3, 362);
            this.textBoxResultFindText.Name = "textBoxResultFindText";
            this.textBoxResultFindText.Size = new System.Drawing.Size(110, 20);
            this.textBoxResultFindText.TabIndex = 32;
            // 
            // listViewResult
            // 
            this.listViewResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFile,
            this.columnHeaderOperation});
            this.listViewResult.FullRowSelect = true;
            this.listViewResult.GridLines = true;
            this.listViewResult.HideSelection = false;
            this.listViewResult.Location = new System.Drawing.Point(3, 20);
            this.listViewResult.MultiSelect = false;
            this.listViewResult.Name = "listViewResult";
            this.listViewResult.Size = new System.Drawing.Size(920, 205);
            this.listViewResult.TabIndex = 28;
            this.listViewResult.UseCompatibleStateImageBehavior = false;
            this.listViewResult.View = System.Windows.Forms.View.Details;
            this.listViewResult.SelectedIndexChanged += new System.EventHandler(this.ListViewResult_SelectedIndexChanged);
            // 
            // columnHeaderFile
            // 
            this.columnHeaderFile.Text = "Plik";
            this.columnHeaderFile.Width = 700;
            // 
            // columnHeaderOperation
            // 
            this.columnHeaderOperation.Text = "Operacja";
            this.columnHeaderOperation.Width = 216;
            // 
            // richTextBoxPreview
            // 
            this.richTextBoxPreview.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxPreview.Location = new System.Drawing.Point(119, 244);
            this.richTextBoxPreview.Name = "richTextBoxPreview";
            this.richTextBoxPreview.ReadOnly = true;
            this.richTextBoxPreview.Size = new System.Drawing.Size(804, 243);
            this.richTextBoxPreview.TabIndex = 27;
            this.richTextBoxPreview.Text = "";
            // 
            // buttonResultFindText
            // 
            this.buttonResultFindText.Enabled = false;
            this.buttonResultFindText.Location = new System.Drawing.Point(3, 388);
            this.buttonResultFindText.Name = "buttonResultFindText";
            this.buttonResultFindText.Size = new System.Drawing.Size(110, 25);
            this.buttonResultFindText.TabIndex = 26;
            this.buttonResultFindText.Text = "Szukaj";
            this.buttonResultFindText.UseVisualStyleBackColor = true;
            this.buttonResultFindText.Click += new System.EventHandler(this.ButtonResultFindText_Click);
            // 
            // buttonResultEditorOpen
            // 
            this.buttonResultEditorOpen.Location = new System.Drawing.Point(3, 245);
            this.buttonResultEditorOpen.Name = "buttonResultEditorOpen";
            this.buttonResultEditorOpen.Size = new System.Drawing.Size(110, 25);
            this.buttonResultEditorOpen.TabIndex = 25;
            this.buttonResultEditorOpen.Text = "Otwórz w edytorze";
            this.buttonResultEditorOpen.UseVisualStyleBackColor = true;
            this.buttonResultEditorOpen.Click += new System.EventHandler(this.ButtonEditorOpen_Click);
            // 
            // labelProgressInfo
            // 
            this.labelProgressInfo.AutoSize = true;
            this.labelProgressInfo.Location = new System.Drawing.Point(780, 228);
            this.labelProgressInfo.Name = "labelProgressInfo";
            this.labelProgressInfo.Size = new System.Drawing.Size(88, 13);
            this.labelProgressInfo.TabIndex = 24;
            this.labelProgressInfo.Text = "labelProgressInfo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lista znalezionych plików, w których odnaleziono szukany tekst:\r\n";
            // 
            // checkBoxSubDir
            // 
            this.checkBoxSubDir.AutoSize = true;
            this.checkBoxSubDir.Location = new System.Drawing.Point(73, 218);
            this.checkBoxSubDir.Name = "checkBoxSubDir";
            this.checkBoxSubDir.Size = new System.Drawing.Size(168, 17);
            this.checkBoxSubDir.TabIndex = 22;
            this.checkBoxSubDir.Text = "Przeszukaj również podfoldery";
            this.checkBoxSubDir.UseVisualStyleBackColor = true;
            this.checkBoxSubDir.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 875);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1768, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(136, 17);
            this.toolStripStatusLabel1.Text = "Autor: Mateusz Klencner";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(1585, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabelVersion.Text = "ver...";
            // 
            // progressBar1Pre
            // 
            this.progressBar1Pre.Location = new System.Drawing.Point(247, 215);
            this.progressBar1Pre.Name = "progressBar1Pre";
            this.progressBar1Pre.Size = new System.Drawing.Size(255, 10);
            this.progressBar1Pre.TabIndex = 24;
            this.progressBar1Pre.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // labelProgressInfoPre
            // 
            this.labelProgressInfoPre.AutoSize = true;
            this.labelProgressInfoPre.Location = new System.Drawing.Point(314, 199);
            this.labelProgressInfoPre.Name = "labelProgressInfoPre";
            this.labelProgressInfoPre.Size = new System.Drawing.Size(104, 13);
            this.labelProgressInfoPre.TabIndex = 25;
            this.labelProgressInfoPre.Text = "labelProgressInfoPre";
            this.labelProgressInfoPre.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // labelInfoFindingFile
            // 
            this.labelInfoFindingFile.AutoEllipsis = true;
            this.labelInfoFindingFile.AutoSize = true;
            this.labelInfoFindingFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelInfoFindingFile.Location = new System.Drawing.Point(9, 280);
            this.labelInfoFindingFile.Name = "labelInfoFindingFile";
            this.labelInfoFindingFile.Size = new System.Drawing.Size(97, 13);
            this.labelInfoFindingFile.TabIndex = 26;
            this.labelInfoFindingFile.Text = "labelInfoFindingFile";
            this.labelInfoFindingFile.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // checkBoxAhoCorasick
            // 
            this.checkBoxAhoCorasick.AutoSize = true;
            this.checkBoxAhoCorasick.Checked = true;
            this.checkBoxAhoCorasick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAhoCorasick.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxAhoCorasick.Location = new System.Drawing.Point(12, 241);
            this.checkBoxAhoCorasick.Name = "checkBoxAhoCorasick";
            this.checkBoxAhoCorasick.Size = new System.Drawing.Size(214, 17);
            this.checkBoxAhoCorasick.TabIndex = 27;
            this.checkBoxAhoCorasick.Text = "Użyj algorytmu Aho-Corasick\'a (szybciej)";
            this.checkBoxAhoCorasick.UseVisualStyleBackColor = true;
            this.checkBoxAhoCorasick.CheckedChanged += new System.EventHandler(this.CheckBoxAhoCorasick_CheckedChanged);
            this.checkBoxAhoCorasick.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // labelProgressTime
            // 
            this.labelProgressTime.AutoSize = true;
            this.labelProgressTime.Location = new System.Drawing.Point(249, 199);
            this.labelProgressTime.Name = "labelProgressTime";
            this.labelProgressTime.Size = new System.Drawing.Size(31, 13);
            this.labelProgressTime.TabIndex = 25;
            this.labelProgressTime.Text = "--:--:--";
            this.labelProgressTime.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            // 
            // timerProgressInfo
            // 
            this.timerProgressInfo.Tick += new System.EventHandler(this.TimerProgressInfo_Tick);
            // 
            // panelFindText
            // 
            this.panelFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFindText.Controls.Add(this.label5);
            this.panelFindText.Controls.Add(this.labelFindTextOr3);
            this.panelFindText.Controls.Add(this.label3);
            this.panelFindText.Controls.Add(this.labelFindTextOr2);
            this.panelFindText.Controls.Add(this.label2);
            this.panelFindText.Controls.Add(this.labelFindTextOr1);
            this.panelFindText.Controls.Add(this.textBoxFindText7);
            this.panelFindText.Controls.Add(this.textBoxFindText4);
            this.panelFindText.Controls.Add(this.textBoxFindText6);
            this.panelFindText.Controls.Add(this.textBoxFindText3);
            this.panelFindText.Controls.Add(this.textBoxFindText5);
            this.panelFindText.Controls.Add(this.textBoxFindText2);
            this.panelFindText.Location = new System.Drawing.Point(164, 293);
            this.panelFindText.Name = "panelFindText";
            this.panelFindText.Size = new System.Drawing.Size(490, 121);
            this.panelFindText.TabIndex = 28;
            this.panelFindText.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "lub:";
            // 
            // labelFindTextOr3
            // 
            this.labelFindTextOr3.AutoSize = true;
            this.labelFindTextOr3.Location = new System.Drawing.Point(7, 79);
            this.labelFindTextOr3.Name = "labelFindTextOr3";
            this.labelFindTextOr3.Size = new System.Drawing.Size(24, 13);
            this.labelFindTextOr3.TabIndex = 1;
            this.labelFindTextOr3.Text = "lub:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "lub:";
            // 
            // labelFindTextOr2
            // 
            this.labelFindTextOr2.AutoSize = true;
            this.labelFindTextOr2.Location = new System.Drawing.Point(7, 41);
            this.labelFindTextOr2.Name = "labelFindTextOr2";
            this.labelFindTextOr2.Size = new System.Drawing.Size(24, 13);
            this.labelFindTextOr2.TabIndex = 1;
            this.labelFindTextOr2.Text = "lub:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "lub:";
            // 
            // labelFindTextOr1
            // 
            this.labelFindTextOr1.AutoSize = true;
            this.labelFindTextOr1.Location = new System.Drawing.Point(7, 2);
            this.labelFindTextOr1.Name = "labelFindTextOr1";
            this.labelFindTextOr1.Size = new System.Drawing.Size(77, 13);
            this.labelFindTextOr1.TabIndex = 1;
            this.labelFindTextOr1.Text = "Szukany tekst:";
            // 
            // textBoxFindText7
            // 
            this.textBoxFindText7.Location = new System.Drawing.Point(254, 95);
            this.textBoxFindText7.Name = "textBoxFindText7";
            this.textBoxFindText7.Size = new System.Drawing.Size(231, 20);
            this.textBoxFindText7.TabIndex = 0;
            this.textBoxFindText7.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxFindText4
            // 
            this.textBoxFindText4.Location = new System.Drawing.Point(3, 95);
            this.textBoxFindText4.Name = "textBoxFindText4";
            this.textBoxFindText4.Size = new System.Drawing.Size(232, 20);
            this.textBoxFindText4.TabIndex = 0;
            this.textBoxFindText4.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxFindText6
            // 
            this.textBoxFindText6.Location = new System.Drawing.Point(254, 56);
            this.textBoxFindText6.Name = "textBoxFindText6";
            this.textBoxFindText6.Size = new System.Drawing.Size(231, 20);
            this.textBoxFindText6.TabIndex = 0;
            this.textBoxFindText6.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxFindText3
            // 
            this.textBoxFindText3.Location = new System.Drawing.Point(3, 56);
            this.textBoxFindText3.Name = "textBoxFindText3";
            this.textBoxFindText3.Size = new System.Drawing.Size(232, 20);
            this.textBoxFindText3.TabIndex = 0;
            this.textBoxFindText3.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxFindText5
            // 
            this.textBoxFindText5.Location = new System.Drawing.Point(254, 17);
            this.textBoxFindText5.Name = "textBoxFindText5";
            this.textBoxFindText5.Size = new System.Drawing.Size(231, 20);
            this.textBoxFindText5.TabIndex = 0;
            this.textBoxFindText5.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // textBoxFindText2
            // 
            this.textBoxFindText2.Location = new System.Drawing.Point(3, 17);
            this.textBoxFindText2.Name = "textBoxFindText2";
            this.textBoxFindText2.Size = new System.Drawing.Size(232, 20);
            this.textBoxFindText2.TabIndex = 0;
            this.textBoxFindText2.TextChanged += new System.EventHandler(this.textBoxFindText_TextChanged);
            this.textBoxFindText2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxFindText1All_KeyDown);
            // 
            // pictureBoxFindTextArrow
            // 
            this.pictureBoxFindTextArrow.Image = global::SearchFast.Properties.Resources.arrowDown;
            this.pictureBoxFindTextArrow.Location = new System.Drawing.Point(12, 30);
            this.pictureBoxFindTextArrow.Name = "pictureBoxFindTextArrow";
            this.pictureBoxFindTextArrow.Size = new System.Drawing.Size(21, 19);
            this.pictureBoxFindTextArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFindTextArrow.TabIndex = 30;
            this.pictureBoxFindTextArrow.TabStop = false;
            this.pictureBoxFindTextArrow.Click += new System.EventHandler(this.PictureBoxFindTextArrow_Click);
            this.pictureBoxFindTextArrow.DoubleClick += new System.EventHandler(this.PictureBoxFindTextArrow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1768, 897);
            this.Controls.Add(this.panelFindText);
            this.Controls.Add(this.panelPreResult);
            this.Controls.Add(this.panelAskDeleteFile);
            this.Controls.Add(this.checkBoxAhoCorasick);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.textBoxFindText1All);
            this.Controls.Add(this.textBoxExt);
            this.Controls.Add(this.textBoxCopy);
            this.Controls.Add(this.checkBoxSubDir);
            this.Controls.Add(this.labelExt);
            this.Controls.Add(this.labelDir);
            this.Controls.Add(this.labelFindText);
            this.Controls.Add(this.checkBoxNewLine);
            this.Controls.Add(this.checkBoxIgnoreCase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.checkBoxCopy);
            this.Controls.Add(this.checkBoxCopyExistDelete);
            this.Controls.Add(this.labelInfoFindingFile);
            this.Controls.Add(this.labelerror);
            this.Controls.Add(this.labelProgressTime);
            this.Controls.Add(this.labelProgressInfoPre);
            this.Controls.Add(this.progressBar1Pre);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxFindTextArrow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SearchFast";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.MouseHover += new System.EventHandler(this.FormAll_MouseHover);
            this.panelAskDeleteFile.ResumeLayout(false);
            this.panelPreResult.ResumeLayout(false);
            this.panelPreResult.PerformLayout();
            this.groupBoxResultFindText.ResumeLayout(false);
            this.groupBoxResultFindText.PerformLayout();
            this.groupBoxResultEditor.ResumeLayout(false);
            this.groupBoxResultEditor.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelFindText.ResumeLayout(false);
            this.panelFindText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFindTextArrow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFindText1All;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label labelFindText;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Label labelExt;
        private System.Windows.Forms.TextBox textBoxExt;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCase;
        private System.Windows.Forms.CheckBox checkBoxNewLine;
        private System.Windows.Forms.TextBox textBoxCopy;
        private System.Windows.Forms.CheckBox checkBoxCopy;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.CheckBox checkBoxCopyExistDelete;
        private System.Windows.Forms.Label labelerror;
        private System.Windows.Forms.Label labelAsk;
        private System.Windows.Forms.Button buttonDeleteYes;
        private System.Windows.Forms.Button buttonDeleteNo;
        private System.Windows.Forms.Panel panelAskDeleteFile;
        private System.Windows.Forms.Panel panelPreResult;
        private System.Windows.Forms.CheckBox checkBoxSubDir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelProgressInfo;
        private System.Windows.Forms.Button buttonResultFindText;
        private System.Windows.Forms.Button buttonResultEditorOpen;
        private System.Windows.Forms.RichTextBox richTextBoxPreview;
        private System.Windows.Forms.ColumnHeader columnHeaderFile;
        private System.Windows.Forms.ColumnHeader columnHeaderOperation;
        private System.Windows.Forms.ListView listViewResult;
        private System.Windows.Forms.RadioButton radioButtonResultEditor2;
        private System.Windows.Forms.RadioButton radioButtonResultEditor1;
        private System.Windows.Forms.TextBox textBoxResultFindText;
        private System.Windows.Forms.GroupBox groupBoxResultEditor;
        private System.Windows.Forms.GroupBox groupBoxResultFindText;
        private System.Windows.Forms.RadioButton radioButtonResultFindTextUp;
        private System.Windows.Forms.RadioButton radioButtonResultFindTextDown;
        private System.Windows.Forms.Button buttonBackToHome;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar1Pre;
        private System.Windows.Forms.Label labelProgressInfoPre;
        private System.Windows.Forms.Label labelInfoFindingFile;
        private System.Windows.Forms.CheckBox checkBoxAhoCorasick;
        private System.Windows.Forms.Label labelProgressTime;
        private System.Windows.Forms.Timer timerProgressInfo;
        private System.Windows.Forms.Panel panelFindText;
        private System.Windows.Forms.Label labelFindTextOr3;
        private System.Windows.Forms.Label labelFindTextOr2;
        private System.Windows.Forms.Label labelFindTextOr1;
        private System.Windows.Forms.TextBox textBoxFindText4;
        private System.Windows.Forms.TextBox textBoxFindText3;
        private System.Windows.Forms.TextBox textBoxFindText2;
        private System.Windows.Forms.PictureBox pictureBoxFindTextArrow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFindText7;
        private System.Windows.Forms.TextBox textBoxFindText6;
        private System.Windows.Forms.TextBox textBoxFindText5;
    }
}

