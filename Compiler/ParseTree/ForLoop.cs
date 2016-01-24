﻿using System.Collections.Generic;
using System.Linq;

namespace Crayon.ParseTree
{
	internal class ForLoop : Executable
	{
		public Executable[] Init { get; private set; }
		public Expression Condition { get; private set; }
		public Executable[] Step { get; private set; }
		public Executable[] Code { get; private set; }

		public ForLoop(Token forToken, IList<Executable> init, Expression condition, IList<Executable> step, IList<Executable> code, Executable owner)
			: base(forToken, owner)
		{
			this.Init = init.ToArray();
			this.Condition = condition ?? new BooleanConstant(forToken, true, owner);
			this.Step = step.ToArray();
			this.Code = code.ToArray();
		}

		internal override IList<Executable> Resolve(Parser parser)
		{
			this.Init = Resolve(parser, this.Init).ToArray();
			this.Condition = this.Condition.Resolve(parser);
			this.Step = Resolve(parser, this.Step).ToArray();
			this.Code = Resolve(parser, this.Code).ToArray();

			return Listify(this);
		}

		internal override void GetAllVariableNames(Dictionary<string, bool> lookup)
		{
			foreach (Executable init in this.Init)
			{
				init.GetAllVariableNames(lookup);
			}

			foreach (Executable step in this.Step)
			{
				step.GetAllVariableNames(lookup);
			}

			foreach (Executable line in this.Code)
			{
				line.GetAllVariableNames(lookup);
			}
		}

		internal override void AssignVariablesToIds(VariableIdAllocator varIds)
		{
			foreach (Executable ex in this.Init.Concat<Executable>(this.Step).Concat<Executable>(this.Code))
			{
				ex.AssignVariablesToIds(varIds);
			}
		}

		internal override void VariableUsagePass(Parser parser)
		{
			for (int i = 0; i < this.Init.Length; ++i)
			{
				this.Init[i].VariableUsagePass(parser);
			}

			if (this.Condition != null)
			{
				this.Condition.VariableUsagePass(parser);
			}

			for (int i = 0; i < this.Step.Length; ++i)
			{
				this.Step[i].VariableUsagePass(parser);
			}

			for (int i = 0; i < this.Code.Length; ++i)
			{
				this.Code[i].VariableUsagePass(parser);
			}
		}

		internal override void VariableIdAssignmentPass(Parser parser)
		{
			for (int i = 0; i < this.Init.Length; ++i)
			{
				this.Init[i].VariableIdAssignmentPass(parser);
			}

			if (this.Condition != null)
			{
				this.Condition.VariableIdAssignmentPass(parser);
			}

			for (int i = 0; i < this.Step.Length; ++i)
			{
				this.Step[i].VariableIdAssignmentPass(parser);
			}

			for (int i = 0; i < this.Code.Length; ++i)
			{
				this.Code[i].VariableIdAssignmentPass(parser);
			}
		}
	}
}
