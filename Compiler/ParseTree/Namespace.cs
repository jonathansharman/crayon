﻿using System;
using System.Collections.Generic;

namespace Crayon.ParseTree
{
	// Despite being an "Executable", this isn't an executable thing.
	// It will get optimized away at resolution time.
	internal class Namespace : Executable
	{
		public Executable[] Code { get; set; }
		public string Name { get; set; }

		public Namespace(Token namespaceToken, string name, Executable owner)
			: base(namespaceToken, owner)
		{
			this.Name = name;
		}

		public void GetFlattenedCode(IList<Executable> executableOut, string[] imports, string libraryName)
		{
			foreach (Executable item in this.Code)
			{
				item.NamespacePrefixSearch = imports;
				item.LibraryName = libraryName;

				if (item is Namespace)
				{
					((Namespace)item).GetFlattenedCode(executableOut, imports, libraryName);
				}
				else
				{
					// already filtered at parse time to correct member types.
					executableOut.Add(item);
				}
			}
		}

		internal override IList<Executable> Resolve(Parser parser)
		{
			throw new ParserException(this.FirstToken, "Namespace declaration not allowed here. Namespaces may only exist in the root of a file or nested within other namespaces.");
		}

		internal override void GetAllVariableNames(Dictionary<string, bool> lookup)
		{
			throw new NotImplementedException();
		}

		internal override void AssignVariablesToIds(VariableIdAllocator varIds)
		{
			throw new NotImplementedException();
		}

		internal override void VariableUsagePass(Parser parser)
		{
			throw new NotImplementedException();
		}

		internal override void VariableIdAssignmentPass(Parser parser)
		{
			throw new NotImplementedException();
		}
	}
}
