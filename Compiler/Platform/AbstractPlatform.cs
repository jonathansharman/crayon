﻿using Common;
using Pastel;
using System;
using System.Collections.Generic;

namespace Platform
{
    public abstract class AbstractPlatform
    {
        public AbstractPlatform(Language language)
        {
            this.Language = language;
        }

        public IPlatformProvider PlatformProvider { get; set; }

        public Language Language { get; private set; }
        public abstract string Name { get; }
        public abstract string InheritsFrom { get; }

        public abstract IDictionary<string, object> GetConstantFlags();
        public abstract string NL { get; }
        protected int TranslationIndentionCount { get; set; }

        private string[] inheritanceChain = null;
        public IList<string> InheritanceChain
        {
            get
            {
                if (this.inheritanceChain == null)
                {
                    List<string> chainBuilder = new List<string>();
                    AbstractPlatform walker = this;
                    while (walker != null)
                    {
                        chainBuilder.Add(walker.Name);
                        walker = walker.ParentPlatform;
                    }
                    this.inheritanceChain = chainBuilder.ToArray();
                }
                return this.inheritanceChain;
            }
        }

        private Dictionary<string, object> flattenedCached = null;
        public Dictionary<string, object> GetFlattenedConstantFlags()
        {
            if (this.flattenedCached == null)
            {
                this.flattenedCached = this.InheritsFrom != null
                    ? new Dictionary<string, object>(this.PlatformProvider.GetPlatform(this.InheritsFrom).GetFlattenedConstantFlags())
                    : new Dictionary<string, object>();

                IDictionary<string, object> thisPlatform = this.GetConstantFlags();
                foreach (string key in thisPlatform.Keys)
                {
                    this.flattenedCached[key] = thisPlatform[key];
                }
            }

            return new Dictionary<string, object>(this.flattenedCached);
        }

        public void CopyResourceAsBinary(Dictionary<string, FileOutput> output, string outputPath, string resourcePath)
        {
            output[outputPath] = new FileOutput()
            {
                Type = FileOutputType.Binary,
                BinaryContent = this.LoadBinaryResource(resourcePath),
            };
        }

        public byte[] LoadBinaryResource(string resourcePath)
        {
            byte[] bytes = Util.ReadAssemblyFileBytes(this.GetType().Assembly, resourcePath);
            if (bytes == null)
            {
                AbstractPlatform parent = this.ParentPlatform;
                if (parent == null)
                {
                    return null;
                }
                return parent.LoadBinaryResource(resourcePath);
            }
            return bytes;
        }

        public void CopyResourceAsText(Dictionary<string, FileOutput> output, string outputPath, string resourcePath, Dictionary<string, string> replacements)
        {
            output[outputPath] = new FileOutput()
            {
                Type = FileOutputType.Text,
                TextContent = this.LoadTextResource(resourcePath, replacements),
            };
        }

        public string LoadTextResource(string resourcePath, Dictionary<string, string> replacements)
        {
            string content = Util.ReadAssemblyFileText(this.GetType().Assembly, resourcePath, true);
            if (content == null)
            {
                AbstractPlatform parent = this.ParentPlatform;
                if (parent == null)
                {
                    throw new Exception("Resource not found: '" + resourcePath + "'");
                }
                return parent.LoadTextResource(resourcePath, replacements);
            }

            return this.ApplyReplacements(content, replacements);
        }

        protected string ApplyReplacements(string text, Dictionary<string, string> replacements)
        {
            if (text.Contains("%%%"))
            {
                string[] segments = Util.StringSplit(text, "%%%");
                for (int i = 1; i < segments.Length; i += 2)
                {
                    string replacement;
                    if (replacements.TryGetValue(segments[i], out replacement))
                    {
                        segments[i] = replacement;
                    }
                    else
                    {
                        segments[i] = "%%%" + segments[i] + "%%%";
                    }
                }
                text = string.Join("", segments);
            }
            return text;
        }

        private bool parentPlatformSet = false;
        private AbstractPlatform parentPlatform = null;
        public AbstractPlatform ParentPlatform
        {
            get
            {
                if (!this.parentPlatformSet)
                {
                    this.parentPlatformSet = true;
                    this.parentPlatform = this.PlatformProvider.GetPlatform(this.InheritsFrom);
                }
                return this.parentPlatform;
            }
        }

        public abstract void ExportStandaloneVm(
            Dictionary<string, FileOutput> output,
            TemplateStorage templates,
            IList<LibraryForExport> everyLibrary);

        public abstract void ExportProject(
            Dictionary<string, FileOutput> output,
            TemplateStorage templates,
            IList<LibraryForExport> libraries,
            ResourceDatabase resourceDatabase,
            Options options);

        public static string IndentCodeWithTabs(string code, int tabCount)
        {
            return IndentCodeImpl(code, Util.MultiplyString("\t", tabCount));
        }

        public static string IndentCodeWithSpaces(string code, int spaceCount)
        {
            return IndentCodeImpl(code, Util.MultiplyString(" ", spaceCount));
        }

        private static string IndentCodeImpl(string code, string tabSequence)
        {
            string newline = code.Contains("\r\n") ? "\r\n" : "\n";
            string[] lines = code.Split('\n');
            for (int i = 0; i < lines.Length; ++i)
            {
                lines[i] = tabSequence + lines[i].TrimEnd();
            }
            return string.Join(newline, lines);
        }

        public abstract Dictionary<string, string> GenerateReplacementDictionary(Options options, ResourceDatabase resDb);

        protected static Dictionary<string, string> GenerateGeneralReplacementsDictionary(Options options)
        {
            return new Dictionary<string, string>()
            {
                { "PROJECT_ID", options.GetString(ExportOptionKey.PROJECT_ID) },
                { "PROJECT_NAME", options.GetString(ExportOptionKey.DEFAULT_TITLE, "Untitled App") },
                { "DEFAULT_TITLE", options.GetString(ExportOptionKey.DEFAULT_TITLE, "Untitled App") },
                { "PROJECT_DESCRIPTION", options.GetStringOrEmpty(ExportOptionKey.DESCRIPTION) },
                { "PROJECT_VERSION", options.GetStringOrEmpty(ExportOptionKey.VERSION) },
                { "DEFAULT_WINDOW_WIDTH", options.GetInteger(ExportOptionKey.WINDOW_WIDTH, 800).ToString() },
                { "DEFAULT_WINDOW_HEIGHT", options.GetInteger(ExportOptionKey.WINDOW_HEIGHT, 600).ToString() },
            };
        }

        public virtual void GleanInformationFromPreviouslyExportedProject(
            Options options,
            string outputDirectory)
        { }
    }
}
