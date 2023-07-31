using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer;
using UiPath.Studio.Activities.Api;
using SMCorp.UiPath.Rules.Counters;

namespace SMCorp.UiPath.Rules
{
    public class RuleRegistration : IRegisterAnalyzerConfiguration
    {
        //Registers the rules with Workflow Analyzer
        public void Initialize(IAnalyzerConfigurationService workflowAnalyzerConfigService)
        {
            if (!workflowAnalyzerConfigService.HasFeature("WorkflowAnalyzerV4"))
                return;

            workflowAnalyzerConfigService.AddRule(VariableLengthRule.Get());
            workflowAnalyzerConfigService.AddRule(VariableLengthRuleProcess.Get());
            workflowAnalyzerConfigService.AddRule(CustomVariableLengthRule.Get());
            workflowAnalyzerConfigService.AddCounter(NumberOfActivitiesInFile.Get());
            workflowAnalyzerConfigService.AddRule(EnforecDraftEmailRule.Get());

        }
    }
}
