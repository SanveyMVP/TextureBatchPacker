﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextureBatchPacker
{
	partial class TexturePackerCaller
	{
		private static int GetJpgQuality(ConvertionParameters parameters)
		{
			switch (parameters.TextureQuality)
			{
				case TEXTURE_QUALITY.HIGH:
					return 85;
				case TEXTURE_QUALITY.LOW:
					return 65;
				default:
					return 75;
			}
		}

		private static string GetTexturePackerArguments_JPG_888(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format jpg --jpg-quality {1} --dpi 72 --opt RGB888 --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {2} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{3}\"",
					plistFullPath,
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format jpg --jpg-quality {1} --dpi 72 --opt RGB888 --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {2} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{3}\"",
					plistFullPath,
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}

		private static string GetTexturePackerArguments_JPG_565(ConvertionParameters parameters)
		{
			string plistFullPath;
			string argument;

			plistFullPath = parameters.DstDir.FullName;

			if (!plistFullPath.EndsWith("\\"))
			{
				plistFullPath += "\\";
			}

			plistFullPath += parameters.SrcDir.Name;

			if (parameters.NoTrim)
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format jpg --jpg-quality {1} --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {2} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --disable-rotation --trim-mode None \"{3}\"",
					plistFullPath,
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}
			else
			{
				argument = string.Format(
					"--format cocos2d --data \"{0}\" --texture-format jpg --jpg-quality {1} --dpi 72 --opt RGB565 --dither-type FloydSteinberg --max-size 16384 --size-constraints AnySize --force-word-aligned --scale {2} --scale-mode Smooth --algorithm MaxRects --maxrects-heuristics Best --pack-mode Best --border-padding 0 --shape-padding 2 --inner-padding 0 --extrude 0 --enable-rotation --trim-mode Trim --trim-threshold 2 \"{3}\"",
					plistFullPath,
					GetJpgQuality(parameters),
					parameters.Scale,
					parameters.SrcDir.FullName);
			}

			return argument;
		}
	}
}
