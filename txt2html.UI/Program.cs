using System;
using System.Windows.Forms;

namespace DukeLupus.txt2html.UI
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main(params string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
			Application.ThreadException +=
				(sender, eventArgs) =>
					CurrentDomainOnUnhandledException(sender, new UnhandledExceptionEventArgs(eventArgs.Exception, true));

			if (args?.Length > 0)
			{
				foreach (var arg in args)
				{
					MainForm.ConvertFile(arg);
				}

				Environment.Exit(0);
			}


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}


		private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs eventArgs)
		{
			MessageBox.Show(
				$"Error:\r\n{(eventArgs.ExceptionObject as Exception)?.Message}\r\n\r\nFull error message:\r\n{eventArgs.ExceptionObject}", "Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);

			Environment.Exit(99);
		}
	}
}