﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerArgs;
using PowerArgs.Cli;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TextureBatchPacker
{
	class TextureBatchPackerArgs
	{
		[HelpHook, ArgShortcut("?"), ArgDescription("Shows this help.")]
		public bool Help { get; set; }

		[HelpHook, ArgShortcut("--help"), ArgDescription("Shows this help.")]
		public bool ShowHelp { get; set; }

		[HelpHook, ArgShortcut("--version"), ArgDescription("(--version) Print the version info.")]
		public bool ShowVersion { get; set; }

		[ArgDefaultValue("Editor"), ArgDescription("Packing mode - Editor, iOS, Android.")]
		public string Mode { get; set; }

		[ArgDefaultValue(0.5), ArgDescription("Scale factor.")]
		public float Scale { get; set; }

		[ArgDefaultValue(false), ArgDescription("Removes image file extensions from the sprite names - e.g. .png, .tga.")]
		public bool TrimSpriteNames { get; set; }

		[ArgRequired(PromptIfMissing = false), ArgExistingDirectory, ArgDescription("The input directory.")]
		public string InputDirectory { get; set; }

		[ArgRequired(PromptIfMissing = false), ArgExistingDirectory, ArgDescription("The output directory.")]
		public string OutputDirectory { get; set; }

		public void Main()
		{
			Console.WriteLine("Mode: {0}", Mode);
			Console.WriteLine("Scale: {0}", Scale);
			Console.WriteLine("TrimSpriteNames: {0}", TrimSpriteNames);
			Console.WriteLine("InputDirectory: {0}", InputDirectory);
			Console.WriteLine("OutputDirectory: {0}", OutputDirectory);
		}
	}

	class Program
	{
		static int Main(string[] args)
		{
			Console.WriteLine("{0} Ver. {1}", Application.ProductName, Application.ProductVersion);
			Console.WriteLine("Powered by Xin Zhang");
			Console.WriteLine("{0}\r\n", System.IO.File.GetLastWriteTime(Application.ExecutablePath));

			try
			{
				Process processTP = new Process();

				processTP.StartInfo.FileName = "TexturePacker.exe";
				processTP.StartInfo.Arguments = "--version";

				//将cmd的标准输入和输出全部重定向到.NET的程序里
				processTP.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常

				//processTP.StartInfo.RedirectStandardInput = true; //标准输入
				processTP.StartInfo.RedirectStandardOutput = true; //标准输出

				//不显示命令行窗口界面
				processTP.StartInfo.CreateNoWindow = true;
				processTP.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

				processTP.Start(); //启动进程
				Console.WriteLine(processTP.StandardOutput.ReadToEnd());
				processTP.WaitForExit();
				processTP.Dispose();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("TexturePacker not installed.");
#if DEBUG
				Console.ReadKey();
#endif
				return -1;
			}

			try
			{
				//string[] newArgs = { "-t", "True", "-i", "C:\\", "-o", "D:\\" };
				string[] newArgs = { "--help" };
				Args.InvokeMain<TextureBatchPackerArgs>(newArgs);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

#if DEBUG
			Console.ReadKey();
#endif

			return 0;
		}
	}
}
