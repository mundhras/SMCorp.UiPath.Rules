using System;
using System.Collections.Generic;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace SMCorp.UiPath.Rules
{
    internal static class CustomVariableLengthRule
    {
        internal static Rule<IActivityModel> Get()
        {
            var rule = new Rule<IActivityModel>(Strings.SMCORP_NMG_002_RuleName, Strings.SMCORP_NMG_002_RuleId, Inspect)
            {
                RecommendationMessage = Strings.SMCORP_NMG_002_Recommendation,
                DefaultErrorLevel = System.Diagnostics.TraceLevel.Warning,
                //Must contain "BusinessRule" to appear in StudioX, rules always appear in Studio
                ApplicableScopes = new List<string> { Strings.BusinessRule }
            };
            rule.Parameters.Add(Strings.VariableLengthAllowed, new Parameter());
            return rule;
        }

        private static InspectionResult Inspect(IActivityModel activityModel, Rule ruleInstance)
        {
            // get the valiue of the custome value
            var intlengthAllowed = Convert.ToInt32(ruleInstance.Parameters[Strings.VariableLengthAllowed]?.Value);

            var messageList = new List<string>();
            foreach (var activityModelVariable in activityModel.Variables)
            {
                if (activityModelVariable.DisplayName.Length > intlengthAllowed)
                {
                    messageList.Add($"The variable {activityModelVariable.DisplayName} has a length longer than {intlengthAllowed}.");
                }
            }
            if (messageList.Count > 0)
            {
                return new InspectionResult()
                {
                    ErrorLevel = ruleInstance.ErrorLevel,
                    HasErrors = true,
                    RecommendationMessage = ruleInstance.RecommendationMessage,
                    Messages = messageList
                };
            }
            else
            {
                return new InspectionResult() { HasErrors = false };
            }
        }
    }
}
