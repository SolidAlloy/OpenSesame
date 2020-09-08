﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Formatting.Rules;

namespace Microsoft.VisualStudio.LanguageServices.Implementation.Venus
{
    internal class ContainedDocumentPreserveFormattingRule : AbstractFormattingRule
    {
        public static readonly AbstractFormattingRule Instance = new ContainedDocumentPreserveFormattingRule();

        private static readonly AdjustSpacesOperation s_preserveSpace = FormattingOperations.CreateAdjustSpacesOperation(0, AdjustSpacesOption.PreserveSpaces);
        private static readonly AdjustNewLinesOperation s_preserveLine = FormattingOperations.CreateAdjustNewLinesOperation(0, AdjustNewLinesOption.PreserveLines);

        public override AdjustSpacesOperation GetAdjustSpacesOperation(SyntaxToken previousToken, SyntaxToken currentToken, AnalyzerConfigOptions options, in NextGetAdjustSpacesOperation nextOperation)
        {
            var operation = base.GetAdjustSpacesOperation(previousToken, currentToken, options, in nextOperation);
            if (operation != null)
            {
                return s_preserveSpace;
            }

            return operation;
        }

        public override AdjustNewLinesOperation GetAdjustNewLinesOperation(SyntaxToken previousToken, SyntaxToken currentToken, AnalyzerConfigOptions options, in NextGetAdjustNewLinesOperation nextOperation)
        {
            var operation = base.GetAdjustNewLinesOperation(previousToken, currentToken, options, in nextOperation);
            if (operation != null)
            {
                return s_preserveLine;
            }

            return operation;
        }
    }
}
