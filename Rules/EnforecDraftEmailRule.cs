using System.Collections.Generic;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace SMCorp.UiPath.Rules
{
    internal static class EnforecDraftEmailRule
    {
        internal static Rule<IActivityModel> Get()
        {
            var rule = new Rule<IActivityModel>(Strings.SMCORP_USG_001_RuleName, Strings.SMCORP_USG_001_RuleId, Inspect)
            {
                RecommendationMessage = Strings.SMCORP_USG_001_Recommendation,
                ErrorLevel = System.Diagnostics.TraceLevel.Warning,
                //Must contain "BusinessRule" to appear in StudioX, rules always appear in Studio
                ApplicableScopes = new List<string> { Strings.BusinessRule }
            };
            return rule;
        }

        private static InspectionResult Inspect(IActivityModel activityModel, Rule ruleInstance)
        {
            var messageList = new List<string>();

            if (activityModel.Type.ToString().Contains("SendMailX"))
            {
                foreach (var activityProperty in activityModel.Properties)
                {
                    if (activityProperty.DisplayName == "Save as draft")
                    {
                        if (activityProperty.DefinedExpression != "True")
                        {
                            messageList.Add($"Send email via automation is not supported please save to draft and review before sending email.");
                        }
                    }
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
