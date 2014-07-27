using System.Windows;
using System.IO;
using System;

namespace SaySoundList
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var fbd = new System.Windows.Forms.FolderBrowserDialog();

			if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string path = fbd.SelectedPath;

				textBox1.Text = path;
				textBox2.Clear();
				textBox2.AppendText("\"Sound Combinations\"\n");
				textBox2.AppendText("{\n");

				string[] files = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
				Array.Sort(files);
				
				foreach (var file in files)
				{
					string ext = Path.GetFileNameWithoutExtension(file);
					string rep = file.Replace(path, "").Replace("\\", "/");

					textBox2.AppendText("\t\""+ ext +"\"\n");
					textBox2.AppendText("\t{\n");
					textBox2.AppendText("\t\t\"file\"\t\"misc" + rep + "\"\n");
					textBox2.AppendText("\t}\n");
				}

				textBox2.AppendText("}");
			}
		}
	}
}