using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sander.txt2html.UI.Properties;

namespace Sander.txt2html.UI
{
	public partial class MainForm : Form
	{
		internal readonly UiArguments Settings;


		public MainForm()
		{
			InitializeComponent();
			Settings = GetSettings();
			LbCssFile.Tag = LbCssFile.Text = Settings.CssFile;
			ChDetectUrls.Checked = Settings.ConversionSettings.DetectUrls;
			ChFixBold.Checked = Settings.ConversionSettings.FixBold;
			ChFixItalic.Checked = Settings.ConversionSettings.FixItalic;
			ChIncludeCSS.Checked = Settings.UseCustomCss;
			ChJoinParagraphs.Checked = Settings.FixParagraphs;
			if (Settings.ConversionSettings.MinimumLineLength != null)
			{
				NumericMinimumLine.Value = (int)Settings.ConversionSettings.MinimumLineLength;
			}

			ChCreateEntities.Checked = Settings.ConversionSettings.CreateEntities;
		}


		private void BtSelectCSS_Click(object sender, EventArgs e)
		{
			if (CssFileDialog.ShowDialog() == DialogResult.OK)
			{
				LbCssFile.Text = CssFileDialog.FileName;
				LbCssFile.Tag = CssFileDialog.FileName;
				ChIncludeCSS.Checked = true;
			}
		}


		private void Label_Click(object sender, EventArgs e)
		{
			var link = (sender as Control)?.Tag as string;

			if (!string.IsNullOrWhiteSpace(link))
			{
				Process.Start(link);
			}
		}


		private static UiArguments GetSettings()
		{
			var settings = new UiArguments { ConversionSettings = new ConversionSettings() };
			settings.ConversionSettings.CreateEntities = Properties.Settings.Default.CreateEntities;
			settings.ConversionSettings.FixBold = Properties.Settings.Default.FixBold;
			settings.ConversionSettings.DetectUrls = Properties.Settings.Default.DetectUrls;
			settings.ConversionSettings.FixItalic = Properties.Settings.Default.FixItalic;
			settings.ConversionSettings.MinimumLineLength = Properties.Settings.Default.MinimumLineLength;

			settings.UseCustomCss = Properties.Settings.Default.UseCustomCss;
			settings.CssFile = Properties.Settings.Default.CssFile;
			settings.FixParagraphs = Properties.Settings.Default.FixParagraphs;

			return settings;
		}


		private void SaveSettings()
		{
			Properties.Settings.Default.CreateEntities = ChCreateEntities.Checked;
			Properties.Settings.Default.FixBold = ChFixBold.Checked;
			Properties.Settings.Default.CssFile = LbCssFile.Text;
			Properties.Settings.Default.DetectUrls = ChDetectUrls.Checked;
			Properties.Settings.Default.FixItalic = ChFixItalic.Checked;
			Properties.Settings.Default.FixParagraphs = ChJoinParagraphs.Checked;
			Properties.Settings.Default.MinimumLineLength = (uint)NumericMinimumLine.Value;
			Properties.Settings.Default.UseCustomCss = ChIncludeCSS.Checked;
			Properties.Settings.Default.Save();
		}


		private void AddLine(string htmlFile)
		{
			var labels = GetFileLabels();
			var linkLabels = labels as LinkLabel[] ?? labels.ToArray();
			var top = !linkLabels.Any()
				? BtSelectFiles.Bottom + 10
				: linkLabels.Last()
					.Bottom + 4;

			var label = new LinkLabel
			{
				Name = $"FileLabel_{linkLabels.Length}",
				Text = Path.GetFileName(htmlFile),
				Tag = htmlFile,
				Top = top,
				AutoSize = true,
				AutoEllipsis = true,
				Left = 30
			};

			ToolTips.SetToolTip(label, "Open converted file in the default browser");
			label.Click += Label_Click;
			Controls.Add(label);

			var directoryName = Path.GetDirectoryName(htmlFile);
			var button = new Button
			{
				TabStop = false,
				FlatStyle = FlatStyle.Flat,
				Image = Resources.directory_icon,
				Size = new Size(18, 18),
				ImageAlign = ContentAlignment.MiddleCenter,
				Top = label.Top - 2,
				Left = label.Left - 20,
				Tag = directoryName,
				Name = $"FolderButton_{linkLabels.Length}"
			};

			ToolTips.SetToolTip(button, $"Open folder containing the current file:\r\n{directoryName}");

			button.FlatAppearance.BorderSize = 0;
			button.Click += (sender, args) =>
			{
				Debug.Assert(sender != null, "sender != null");
				// ReSharper disable once AssignNullToNotNullAttribute
				Process.Start((sender as Control)?.Tag as string);
			};

			Controls.Add(button);
		}


		private IEnumerable<LinkLabel> GetFileLabels()
		{
			return Controls.OfType<LinkLabel>()
				.Where(x => x.Name.StartsWith("FileLabel"));
		}


		private void RemoveLabels()
		{
			foreach (var label in GetFileLabels())
			{
				label.Dispose();
			}

			foreach (var button in Controls.OfType<Button>()
				         .Where(x => x.Name.StartsWith("FolderButton"))
				         .ToList())
			{
				button.Dispose();
			}
		}


		private void LbEntityList_Click(object sender, EventArgs e)
		{
			var entityFile = GetEntityFile();
			if (!string.IsNullOrWhiteSpace(entityFile))
			{
				Process.Start("notepad.exe", entityFile);
			}
		}


		private string GetEntityFile()
		{
			var entityFile = Path.Combine(Environment.CurrentDirectory, "txt2html.ent");
			if (!File.Exists(entityFile))
			{
				MessageBox.Show(this, $"Entity file was not found! Expected file at:\r\n\r\n\t{entityFile}", "Entity file not found",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}

			return entityFile;
		}


		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}


		private void BtSelectFiles_Click(object sender, EventArgs e)
		{
			if (TxtFileDialog.ShowDialog() == DialogResult.OK && TxtFileDialog.FileNames?.Length > 0)
			{
				RunConversion(TxtFileDialog.FileNames);
			}
		}


		private void RunConversion(string[] filenames)
		{
			RemoveLabels();
			SaveSettings();

			DisableEnableContols(this, false);
			foreach (var fileName in filenames)
			{
				var outFile = ConvertFile(fileName, TxtTitle.Text);
				AddLine(outFile);
			}

			DisableEnableContols(this, true);
		}


		private void DisableEnableContols(Control control, bool enabled)
		{
			foreach (Control item in control.Controls)
			{
				item.Enabled = enabled;
				DisableEnableContols(item, enabled);
			}
		}


		internal static string ConvertFile(string fileName, string title = null)
		{
			//ensure everything is in sync
			var settings = GetSettings();
			if (settings.UseCustomCss)
			{
				if (!File.Exists(settings.CssFile))
				{
					throw new FileNotFoundException($"CSS file does not exist:\r\n{settings.CssFile}", settings.CssFile);
				}

				settings.ConversionSettings.Css = File.ReadAllText(settings.CssFile);
			}


			settings.ConversionSettings.MinimumLineLength = settings.FixParagraphs
				? settings.ConversionSettings.MinimumLineLength
				: null;

			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException($"Input file was not found:\r\n{fileName}", fileName);
			}

			var lines = File.ReadAllLines(fileName);
			settings.ConversionSettings.Title = title;

			var html = Converter.Convert(settings.ConversionSettings, lines);

			var outFile = Path.ChangeExtension(fileName, "html");
			File.WriteAllText(outFile, html, Encoding.UTF8);

			return outFile;
		}


		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			var dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
			RunConversion(dropFiles);
		}


		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}
	}
}
