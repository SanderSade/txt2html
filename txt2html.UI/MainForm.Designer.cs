namespace DukeLupus.txt2html.UI
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LbEntityList = new System.Windows.Forms.LinkLabel();
			this.ChCreateEntities = new System.Windows.Forms.CheckBox();
			this.LinkGithub = new System.Windows.Forms.LinkLabel();
			this.LinkHomepage = new System.Windows.Forms.LinkLabel();
			this.NumericMinimumLine = new System.Windows.Forms.NumericUpDown();
			this.ChJoinParagraphs = new System.Windows.Forms.CheckBox();
			this.LbCssFile = new System.Windows.Forms.LinkLabel();
			this.BtSelectCSS = new System.Windows.Forms.Button();
			this.ChIncludeCSS = new System.Windows.Forms.CheckBox();
			this.ChDetectUrls = new System.Windows.Forms.CheckBox();
			this.ChFixItalic = new System.Windows.Forms.CheckBox();
			this.ChFixBold = new System.Windows.Forms.CheckBox();
			this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
			this.BtSelectFiles = new System.Windows.Forms.Button();
			this.LbTitle = new System.Windows.Forms.Label();
			this.TxtTitle = new System.Windows.Forms.TextBox();
			this.CssFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.TxtFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericMinimumLine)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LbEntityList);
			this.groupBox1.Controls.Add(this.ChCreateEntities);
			this.groupBox1.Controls.Add(this.LinkGithub);
			this.groupBox1.Controls.Add(this.LinkHomepage);
			this.groupBox1.Controls.Add(this.NumericMinimumLine);
			this.groupBox1.Controls.Add(this.ChJoinParagraphs);
			this.groupBox1.Controls.Add(this.LbCssFile);
			this.groupBox1.Controls.Add(this.BtSelectCSS);
			this.groupBox1.Controls.Add(this.ChIncludeCSS);
			this.groupBox1.Controls.Add(this.ChDetectUrls);
			this.groupBox1.Controls.Add(this.ChFixItalic);
			this.groupBox1.Controls.Add(this.ChFixBold);
			this.groupBox1.Location = new System.Drawing.Point(12, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(527, 167);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Options";
			// 
			// LbEntityList
			// 
			this.LbEntityList.AccessibleDescription = "Edit entity list";
			this.LbEntityList.AutoSize = true;
			this.LbEntityList.Location = new System.Drawing.Point(139, 141);
			this.LbEntityList.Name = "LbEntityList";
			this.LbEntityList.Size = new System.Drawing.Size(68, 13);
			this.LbEntityList.TabIndex = 11;
			this.LbEntityList.TabStop = true;
			this.LbEntityList.Tag = "txt2html.ent";
			this.LbEntityList.Text = "Edit entity list";
			this.ToolTips.SetToolTip(this.LbEntityList, resources.GetString("LbEntityList.ToolTip"));
			this.LbEntityList.Click += new System.EventHandler(this.LbEntityList_Click);
			// 
			// ChCreateEntities
			// 
			this.ChCreateEntities.AccessibleDescription = "Replace characters with HTML entities.  ";
			this.ChCreateEntities.AutoSize = true;
			this.ChCreateEntities.Location = new System.Drawing.Point(7, 140);
			this.ChCreateEntities.Name = "ChCreateEntities";
			this.ChCreateEntities.Size = new System.Drawing.Size(126, 17);
			this.ChCreateEntities.TabIndex = 10;
			this.ChCreateEntities.Text = "Create HTML entities";
			this.ToolTips.SetToolTip(this.ChCreateEntities, resources.GetString("ChCreateEntities.ToolTip"));
			this.ChCreateEntities.UseVisualStyleBackColor = true;
			// 
			// LinkGithub
			// 
			this.LinkGithub.AccessibleDescription = "txt2html source code at GitHub";
			this.LinkGithub.AutoSize = true;
			this.LinkGithub.Location = new System.Drawing.Point(320, 45);
			this.LinkGithub.Name = "LinkGithub";
			this.LinkGithub.Size = new System.Drawing.Size(200, 13);
			this.LinkGithub.TabIndex = 9;
			this.LinkGithub.TabStop = true;
			this.LinkGithub.Tag = "https://github.com/SanderSade/txt2html";
			this.LinkGithub.Text = "https://github.com/SanderSade/txt2html";
			this.ToolTips.SetToolTip(this.LinkGithub, "txt2html source code at GitHub");
			this.LinkGithub.Click += new System.EventHandler(this.Label_Click);
			// 
			// LinkHomepage
			// 
			this.LinkHomepage.AccessibleDescription = "txt2html homepage";
			this.LinkHomepage.AutoSize = true;
			this.LinkHomepage.Location = new System.Drawing.Point(359, 21);
			this.LinkHomepage.Name = "LinkHomepage";
			this.LinkHomepage.Size = new System.Drawing.Size(161, 13);
			this.LinkHomepage.TabIndex = 8;
			this.LinkHomepage.TabStop = true;
			this.LinkHomepage.Tag = "http://dukelupus.com/#.txt2html";
			this.LinkHomepage.Text = "http://dukelupus.com/#.txt2html";
			this.ToolTips.SetToolTip(this.LinkHomepage, "txt2html homepage");
			this.LinkHomepage.Click += new System.EventHandler(this.Label_Click);
			// 
			// NumericMinimumLine
			// 
			this.NumericMinimumLine.AccessibleDescription = "Specify minimum line length for joining paragraphs";
			this.NumericMinimumLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NumericMinimumLine.Location = new System.Drawing.Point(214, 116);
			this.NumericMinimumLine.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.NumericMinimumLine.Name = "NumericMinimumLine";
			this.NumericMinimumLine.Size = new System.Drawing.Size(54, 20);
			this.NumericMinimumLine.TabIndex = 7;
			this.ToolTips.SetToolTip(this.NumericMinimumLine, "Specify minimum line length for joining paragraphs");
			this.NumericMinimumLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ChJoinParagraphs
			// 
			this.ChJoinParagraphs.AccessibleDescription = "Attempt to merge hard-coded line-breaks into coherent paragraphs. Lines shorter t" +
    "han <minimum line length> symbols which don\'t end with characters marking end of" +
    " line (\'.?!\\\") are joined";
			this.ChJoinParagraphs.AutoSize = true;
			this.ChJoinParagraphs.Location = new System.Drawing.Point(7, 116);
			this.ChJoinParagraphs.Name = "ChJoinParagraphs";
			this.ChJoinParagraphs.Size = new System.Drawing.Size(201, 17);
			this.ChJoinParagraphs.TabIndex = 6;
			this.ChJoinParagraphs.Text = "Join paragraphs, minimum line length:";
			this.ToolTips.SetToolTip(this.ChJoinParagraphs, "Attempt to merge hard-coded line-breaks into coherent paragraphs. \r\nLines shorter" +
        " than specified minimum line length,\r\nwhich don\'t end with characters marking en" +
        "d of line (\'.?!\\\") are joined");
			this.ChJoinParagraphs.UseVisualStyleBackColor = true;
			// 
			// LbCssFile
			// 
			this.LbCssFile.AccessibleDescription = "Custom CSS file";
			this.LbCssFile.AutoEllipsis = true;
			this.LbCssFile.Location = new System.Drawing.Point(173, 93);
			this.LbCssFile.Name = "LbCssFile";
			this.LbCssFile.Size = new System.Drawing.Size(347, 23);
			this.LbCssFile.TabIndex = 5;
			this.ToolTips.SetToolTip(this.LbCssFile, "Custom CSS file");
			this.LbCssFile.Click += new System.EventHandler(this.Label_Click);
			// 
			// BtSelectCSS
			// 
			this.BtSelectCSS.AccessibleDescription = "Select custom CSS file";
			this.BtSelectCSS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BtSelectCSS.Location = new System.Drawing.Point(95, 88);
			this.BtSelectCSS.Margin = new System.Windows.Forms.Padding(0);
			this.BtSelectCSS.Name = "BtSelectCSS";
			this.BtSelectCSS.Size = new System.Drawing.Size(75, 23);
			this.BtSelectCSS.TabIndex = 4;
			this.BtSelectCSS.Text = "Select file";
			this.ToolTips.SetToolTip(this.BtSelectCSS, "Select custom CSS file");
			this.BtSelectCSS.UseVisualStyleBackColor = true;
			this.BtSelectCSS.Click += new System.EventHandler(this.BtSelectCSS_Click);
			// 
			// ChIncludeCSS
			// 
			this.ChIncludeCSS.AccessibleDescription = "Include custom CSS file";
			this.ChIncludeCSS.AutoSize = true;
			this.ChIncludeCSS.Location = new System.Drawing.Point(7, 92);
			this.ChIncludeCSS.Name = "ChIncludeCSS";
			this.ChIncludeCSS.Size = new System.Drawing.Size(85, 17);
			this.ChIncludeCSS.TabIndex = 3;
			this.ChIncludeCSS.Text = "Include CSS";
			this.ToolTips.SetToolTip(this.ChIncludeCSS, "Include custom CSS file");
			this.ChIncludeCSS.UseVisualStyleBackColor = true;
			// 
			// ChDetectUrls
			// 
			this.ChDetectUrls.AccessibleDescription = "Detect URLs and make them clickable";
			this.ChDetectUrls.AutoSize = true;
			this.ChDetectUrls.Location = new System.Drawing.Point(7, 68);
			this.ChDetectUrls.Name = "ChDetectUrls";
			this.ChDetectUrls.Size = new System.Drawing.Size(88, 17);
			this.ChDetectUrls.TabIndex = 2;
			this.ChDetectUrls.Text = "Detect URLs";
			this.ToolTips.SetToolTip(this.ChDetectUrls, "Detect URLs and make them clickable");
			this.ChDetectUrls.UseVisualStyleBackColor = true;
			// 
			// ChFixItalic
			// 
			this.ChFixItalic.AccessibleDescription = "Fix _italic_ text";
			this.ChFixItalic.AutoSize = true;
			this.ChFixItalic.Location = new System.Drawing.Point(7, 44);
			this.ChFixItalic.Name = "ChFixItalic";
			this.ChFixItalic.Size = new System.Drawing.Size(75, 17);
			this.ChFixItalic.TabIndex = 1;
			this.ChFixItalic.Text = "Fix _italic_";
			this.ToolTips.SetToolTip(this.ChFixItalic, "Fix _italic_ text");
			this.ChFixItalic.UseVisualStyleBackColor = true;
			// 
			// ChFixBold
			// 
			this.ChFixBold.AccessibleDescription = "Fix *bold* text";
			this.ChFixBold.AutoSize = true;
			this.ChFixBold.Location = new System.Drawing.Point(7, 20);
			this.ChFixBold.Name = "ChFixBold";
			this.ChFixBold.Size = new System.Drawing.Size(70, 17);
			this.ChFixBold.TabIndex = 0;
			this.ChFixBold.Text = "Fix *bold*";
			this.ToolTips.SetToolTip(this.ChFixBold, "Fix *bold* text");
			this.ChFixBold.UseVisualStyleBackColor = true;
			// 
			// ToolTips
			// 
			this.ToolTips.AutomaticDelay = 400;
			this.ToolTips.BackColor = System.Drawing.Color.White;
			// 
			// BtSelectFiles
			// 
			this.BtSelectFiles.AccessibleDescription = "Select one or more .txt files";
			this.BtSelectFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtSelectFiles.Image = global::DukeLupus.txt2html.UI.Properties.Resources.directory_icon;
			this.BtSelectFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.BtSelectFiles.Location = new System.Drawing.Point(12, 190);
			this.BtSelectFiles.Name = "BtSelectFiles";
			this.BtSelectFiles.Size = new System.Drawing.Size(152, 32);
			this.BtSelectFiles.TabIndex = 1;
			this.BtSelectFiles.Text = "Select and convert";
			this.BtSelectFiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ToolTips.SetToolTip(this.BtSelectFiles, "Select one or more .txt files");
			this.BtSelectFiles.UseVisualStyleBackColor = true;
			this.BtSelectFiles.Click += new System.EventHandler(this.BtSelectFiles_Click);
			// 
			// LbTitle
			// 
			this.LbTitle.AccessibleDescription = "In case of multiple files, same title will be used for all!";
			this.LbTitle.AutoSize = true;
			this.LbTitle.Location = new System.Drawing.Point(170, 201);
			this.LbTitle.Name = "LbTitle";
			this.LbTitle.Size = new System.Drawing.Size(30, 13);
			this.LbTitle.TabIndex = 2;
			this.LbTitle.Text = "Title:";
			this.ToolTips.SetToolTip(this.LbTitle, "In case of multiple files, same title will be used for all!");
			// 
			// TxtTitle
			// 
			this.TxtTitle.AccessibleDescription = "In case of multiple files, same title will be used for all!";
			this.TxtTitle.Location = new System.Drawing.Point(199, 198);
			this.TxtTitle.Name = "TxtTitle";
			this.TxtTitle.Size = new System.Drawing.Size(340, 20);
			this.TxtTitle.TabIndex = 3;
			this.TxtTitle.Tag = "";
			this.ToolTips.SetToolTip(this.TxtTitle, "In case of multiple files, same title will be used for all!");
			// 
			// CssFileDialog
			// 
			this.CssFileDialog.Filter = "CSS files|*.css|All files|*.*";
			this.CssFileDialog.Title = "Select custom CSS file";
			// 
			// TxtFileDialog
			// 
			this.TxtFileDialog.Filter = "Text files|*.txt|All files|*.*";
			this.TxtFileDialog.Multiselect = true;
			this.TxtFileDialog.Title = "Select files for conversion";
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(551, 237);
			this.Controls.Add(this.TxtTitle);
			this.Controls.Add(this.LbTitle);
			this.Controls.Add(this.BtSelectFiles);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "txt2html v2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericMinimumLine)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox ChFixBold;
		private System.Windows.Forms.CheckBox ChFixItalic;
		private System.Windows.Forms.CheckBox ChDetectUrls;
		private System.Windows.Forms.CheckBox ChIncludeCSS;
		private System.Windows.Forms.Button BtSelectCSS;
		private System.Windows.Forms.LinkLabel LbCssFile;
		private System.Windows.Forms.ToolTip ToolTips;
		private System.Windows.Forms.OpenFileDialog CssFileDialog;
		private System.Windows.Forms.CheckBox ChJoinParagraphs;
		private System.Windows.Forms.NumericUpDown NumericMinimumLine;
		private System.Windows.Forms.LinkLabel LinkHomepage;
		private System.Windows.Forms.LinkLabel LinkGithub;
		private System.Windows.Forms.Button BtSelectFiles;
		private System.Windows.Forms.Label LbTitle;
		private System.Windows.Forms.TextBox TxtTitle;
		private System.Windows.Forms.OpenFileDialog TxtFileDialog;
		private System.Windows.Forms.CheckBox ChCreateEntities;
		private System.Windows.Forms.LinkLabel LbEntityList;
	}
}

