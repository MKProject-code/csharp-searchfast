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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.labelDir = new System.Windows.Forms.Label();
            this.labelExt = new System.Windows.Forms.Label();
            this.textBoxExt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.checkBoxNewLine = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxCopy = new System.Windows.Forms.TextBox();
            this.checkBoxCopy = new System.Windows.Forms.CheckBox();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.checkBoxCopyExistDelete = new System.Windows.Forms.CheckBox();
            this.labelerror = new System.Windows.Forms.Label();
            this.labelAsk = new System.Windows.Forms.Label();
            this.buttonDeleteYes = new System.Windows.Forms.Button();
            this.buttonDeleteNo = new System.Windows.Forms.Button();
            this.panelAskDeleteFile = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelPreResult = new System.Windows.Forms.Panel();
            this.richTextBoxPreview = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBoxResultInfoOperation = new System.Windows.Forms.ListBox();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.labelProgressInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxSubDir = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelAskDeleteFile.SuspendLayout();
            this.panelPreResult.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxText
            // 
            this.textBoxText.Location = new System.Drawing.Point(12, 29);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(490, 20);
            this.textBoxText.TabIndex = 0;
            this.textBoxText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(12, 68);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(490, 20);
            this.textBoxDir.TabIndex = 1;
            this.textBoxDir.Text = "C:\\Files";
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelText.Location = new System.Drawing.Point(30, 13);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(85, 15);
            this.labelText.TabIndex = 2;
            this.labelText.Text = "Szukany tekst:";
            // 
            // labelDir
            // 
            this.labelDir.AutoSize = true;
            this.labelDir.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDir.Location = new System.Drawing.Point(30, 52);
            this.labelDir.Name = "labelDir";
            this.labelDir.Size = new System.Drawing.Size(235, 15);
            this.labelDir.TabIndex = 3;
            this.labelDir.Text = "Folder w ktorym maja sie przeszukac pliki:";
            // 
            // labelExt
            // 
            this.labelExt.AutoSize = true;
            this.labelExt.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelExt.Location = new System.Drawing.Point(30, 91);
            this.labelExt.Name = "labelExt";
            this.labelExt.Size = new System.Drawing.Size(442, 15);
            this.labelExt.TabIndex = 5;
            this.labelExt.Text = "W jakim pliku ma szukac: ( moze byc   *.txt   lub   *.*   lub   nazwa.*   lub   *" +
    "zw*.* )";
            // 
            // textBoxExt
            // 
            this.textBoxExt.Location = new System.Drawing.Point(12, 107);
            this.textBoxExt.Name = "textBoxExt";
            this.textBoxExt.Size = new System.Drawing.Size(490, 20);
            this.textBoxExt.TabIndex = 4;
            this.textBoxExt.Text = "*.txt";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(12, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(490, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Szukaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(30, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Opcje:";
            // 
            // checkBoxIgnoreCase
            // 
            this.checkBoxIgnoreCase.AutoSize = true;
            this.checkBoxIgnoreCase.Location = new System.Drawing.Point(73, 170);
            this.checkBoxIgnoreCase.Name = "checkBoxIgnoreCase";
            this.checkBoxIgnoreCase.Size = new System.Drawing.Size(121, 17);
            this.checkBoxIgnoreCase.TabIndex = 12;
            this.checkBoxIgnoreCase.Text = "Ignoruj wielkość liter";
            this.checkBoxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxNewLine
            // 
            this.checkBoxNewLine.AutoSize = true;
            this.checkBoxNewLine.Location = new System.Drawing.Point(73, 187);
            this.checkBoxNewLine.Name = "checkBoxNewLine";
            this.checkBoxNewLine.Size = new System.Drawing.Size(143, 17);
            this.checkBoxNewLine.TabIndex = 13;
            this.checkBoxNewLine.Text = "Obsługa: \\n  (nowa linia)";
            this.checkBoxNewLine.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 509);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(929, 13);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
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
            this.checkBoxCopy.Location = new System.Drawing.Point(33, 129);
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
            this.checkBoxDelete.Location = new System.Drawing.Point(222, 173);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(280, 30);
            this.checkBoxDelete.TabIndex = 19;
            this.checkBoxDelete.Text = "Usuń znalezione pliki\r\n(jeśli ustawione kopiowanie to usunie po skopiowaniu)";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxCopyExistDelete
            // 
            this.checkBoxCopyExistDelete.AutoSize = true;
            this.checkBoxCopyExistDelete.Enabled = false;
            this.checkBoxCopyExistDelete.Location = new System.Drawing.Point(193, 129);
            this.checkBoxCopyExistDelete.Name = "checkBoxCopyExistDelete";
            this.checkBoxCopyExistDelete.Size = new System.Drawing.Size(85, 17);
            this.checkBoxCopyExistDelete.TabIndex = 21;
            this.checkBoxCopyExistDelete.Text = "Nadpisz pliki";
            this.checkBoxCopyExistDelete.UseVisualStyleBackColor = true;
            // 
            // labelerror
            // 
            this.labelerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelerror.Location = new System.Drawing.Point(12, 238);
            this.labelerror.Name = "labelerror";
            this.labelerror.Size = new System.Drawing.Size(490, 41);
            this.labelerror.TabIndex = 10;
            this.labelerror.Text = "Błąd.";
            this.labelerror.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelerror.Visible = false;
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
            this.panelAskDeleteFile.Location = new System.Drawing.Point(12, 13);
            this.panelAskDeleteFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.panelAskDeleteFile.Name = "panelAskDeleteFile";
            this.panelAskDeleteFile.Size = new System.Drawing.Size(490, 224);
            this.panelAskDeleteFile.TabIndex = 20;
            this.panelAskDeleteFile.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(9, 528);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(929, 39);
            this.button2.TabIndex = 8;
            this.button2.Text = "Wróć";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelPreResult
            // 
            this.panelPreResult.Controls.Add(this.richTextBoxPreview);
            this.panelPreResult.Controls.Add(this.button4);
            this.panelPreResult.Controls.Add(this.button3);
            this.panelPreResult.Controls.Add(this.listBoxResultInfoOperation);
            this.panelPreResult.Controls.Add(this.listBoxResult);
            this.panelPreResult.Controls.Add(this.labelProgressInfo);
            this.panelPreResult.Controls.Add(this.label1);
            this.panelPreResult.Location = new System.Drawing.Point(12, 9);
            this.panelPreResult.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panelPreResult.Name = "panelPreResult";
            this.panelPreResult.Size = new System.Drawing.Size(926, 481);
            this.panelPreResult.TabIndex = 9;
            this.panelPreResult.Visible = false;
            // 
            // richTextBoxPreview
            // 
            this.richTextBoxPreview.Location = new System.Drawing.Point(119, 335);
            this.richTextBoxPreview.Name = "richTextBoxPreview";
            this.richTextBoxPreview.Size = new System.Drawing.Size(802, 143);
            this.richTextBoxPreview.TabIndex = 27;
            this.richTextBoxPreview.Text = "";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 404);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 25);
            this.button4.TabIndex = 26;
            this.button4.Text = "Szukaj";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 25);
            this.button3.TabIndex = 25;
            this.button3.Text = "Otwórz w edytorze";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBoxResultInfoOperation
            // 
            this.listBoxResultInfoOperation.AllowDrop = true;
            this.listBoxResultInfoOperation.FormattingEnabled = true;
            this.listBoxResultInfoOperation.Location = new System.Drawing.Point(696, 20);
            this.listBoxResultInfoOperation.Margin = new System.Windows.Forms.Padding(0, 5, 4, 5);
            this.listBoxResultInfoOperation.Name = "listBoxResultInfoOperation";
            this.listBoxResultInfoOperation.Size = new System.Drawing.Size(225, 290);
            this.listBoxResultInfoOperation.TabIndex = 10;
            this.listBoxResultInfoOperation.SelectedIndexChanged += new System.EventHandler(this.ListBoxResult_SelectedIndexChanged);
            this.listBoxResultInfoOperation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxResult_MouseDoubleClick);
            // 
            // listBoxResult
            // 
            this.listBoxResult.AllowDrop = true;
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.Location = new System.Drawing.Point(5, 20);
            this.listBoxResult.Margin = new System.Windows.Forms.Padding(5);
            this.listBoxResult.MultiColumn = true;
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(916, 290);
            this.listBoxResult.TabIndex = 10;
            this.listBoxResult.SelectedIndexChanged += new System.EventHandler(this.ListBoxResult_SelectedIndexChanged);
            this.listBoxResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxResult_MouseDoubleClick);
            // 
            // labelProgressInfo
            // 
            this.labelProgressInfo.AutoSize = true;
            this.labelProgressInfo.Location = new System.Drawing.Point(778, 315);
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
            this.checkBoxSubDir.Location = new System.Drawing.Point(334, 50);
            this.checkBoxSubDir.Name = "checkBoxSubDir";
            this.checkBoxSubDir.Size = new System.Drawing.Size(168, 17);
            this.checkBoxSubDir.TabIndex = 22;
            this.checkBoxSubDir.Text = "Przeszukaj również podfoldery";
            this.checkBoxSubDir.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 570);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(950, 22);
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(733, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel2.Text = "ver. 1.0.10b";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(950, 592);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panelPreResult);
            this.Controls.Add(this.panelAskDeleteFile);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.textBoxExt);
            this.Controls.Add(this.textBoxCopy);
            this.Controls.Add(this.textBoxText);
            this.Controls.Add(this.checkBoxSubDir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelExt);
            this.Controls.Add(this.labelDir);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.checkBoxNewLine);
            this.Controls.Add(this.checkBoxIgnoreCase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelerror);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.checkBoxCopy);
            this.Controls.Add(this.checkBoxCopyExistDelete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SearchFast";
            this.panelAskDeleteFile.ResumeLayout(false);
            this.panelPreResult.ResumeLayout(false);
            this.panelPreResult.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.KeyPressEventHandler GetListBoxResult_KeyPress()
        {
            return this.ListBoxResult_KeyPress;
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelDir;
        private System.Windows.Forms.Label labelExt;
        private System.Windows.Forms.TextBox textBoxExt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIgnoreCase;
        private System.Windows.Forms.CheckBox checkBoxNewLine;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxCopy;
        private System.Windows.Forms.CheckBox checkBoxCopy;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.CheckBox checkBoxCopyExistDelete;
        private System.Windows.Forms.Label labelerror;
        private System.Windows.Forms.Label labelAsk;
        private System.Windows.Forms.Button buttonDeleteYes;
        private System.Windows.Forms.Button buttonDeleteNo;
        private System.Windows.Forms.Panel panelAskDeleteFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelPreResult;
        private System.Windows.Forms.CheckBox checkBoxSubDir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.Label labelProgressInfo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBoxPreview;
        private System.Windows.Forms.ListBox listBoxResultInfoOperation;
    }
}

