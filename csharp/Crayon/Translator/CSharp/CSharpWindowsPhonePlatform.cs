﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crayon.Translator.CSharp
{
	class CSharpWindowsPhonePlatform : CSharpPlatform
	{
		public override string OutputFolderName { get { return "cswinphone"; } }

		public override void ApplyPlatformSpecificReplacements(Dictionary<string, string> replacements)
		{

		}

		public override void PlatformSpecificFiles(string projectId, List<string> compileTargets, Dictionary<string, FileOutput> files, Dictionary<string, string> replacements)
		{
		}
	}
}