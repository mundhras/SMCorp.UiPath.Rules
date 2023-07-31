using System.Collections.Generic;
using System.Linq;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace SMCorp.UiPath.Rules
{
    internal static class VariableLengthRuleProcess
    {
        internal static Rule<IProjectModel> Get()
        {
            var rule = new Rule<IProjectModel>(Strings.SMCORP_NMG_003_RuleName, Strings.SMCORP_NMG_003_RuleId, Inspect)
            {
                RecommendationMessage = Strings.SMCORP_NMG_003_Recommendation,
                DefaultErrorLevel = System.Diagnostics.TraceLevel.Warning,
                //Must contain "BusinessRule" to appear in StudioX, rules always appear in Studio
                ApplicableScopes = new List<string> { Strings.BusinessRule }
            };
            return rule;
        }

        private static InspectionResult Inspect(IProjectModel project, Rule ruleInstance)
        {
            var messageList = new List<string>();

            //get the workflows in the project
            if (string.Compare(project.ProjectOutputType.Trim().ToLower(), "Process".ToLower(), true) == 0)
            {
                if (project.Workflows.Any())
                {
                    foreach (var workflow in project.Workflows)
                    {
                        if (workflow.Root != null)
                        {
                            foreach (var activityModelVariable in workflow.Root.Variables)
                            {
                                if (activityModelVariable.DisplayName.Length > 15)
                                {
                                    messageList.Add($"The variable {activityModelVariable.DisplayName} has a length longer than 15");
                                }
                            }
                            if (workflow.Root.Children.Any())
                            {
                                foreach (var activityModel in workflow.Root.Children)
                                {
                                    if (activityModel != null)
                                    {
                                        foreach (var activityModelVariable in activityModel.Variables)
                                        {
                                            if (activityModelVariable.DisplayName.Length > 15)
                                            {
                                                messageList.Add($"The variable {activityModelVariable.DisplayName} has a length longer than 15");
                                            }
                                        }
                                    }
                                }
                            }
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
