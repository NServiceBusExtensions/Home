using System;
using System.Threading.Tasks;
using GitHubSync;
using Octokit;

class Program
{
    static Task Main()
    {
        var githubToken = Environment.GetEnvironmentVariable("Octokit_OAuthToken");

        var credentials = new Credentials(githubToken);
        var sync = new RepoSync(credentials, "NServiceBusExtensions", "Home", "master", Console.WriteLine);
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/.editorconfig", ".editorconfig");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/ISSUE_TEMPLATE/bug_report.md", ".github/ISSUE_TEMPLATE/bug_report.md");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/ISSUE_TEMPLATE/feature_request.md", ".github/ISSUE_TEMPLATE/feature_request.md");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/pull_request_template.md", ".github/pull_request_template.md");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Attachments", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.AuditFilter", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Bond", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.MessagePack", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.HandlerOrdering", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Hyperion", "master");
        sync.AddTarget("NServiceBusExtensions", "Newtonsoft.Json.Encryption", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Jil", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.MicrosoftLogging", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.MsgPack", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Native", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.ProtoBufGoogle", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.ProtoBufNet", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Validation", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Serilog", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Utf8Json", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.Wire", "master");
        sync.AddTarget("NServiceBusExtensions", "NServiceBus.ZeroFormatter", "master");
        return sync.Sync(SyncOutput.MergePullRequest);
    }
}