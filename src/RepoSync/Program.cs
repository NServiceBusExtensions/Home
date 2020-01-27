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
        var sync = new RepoSync(
            log: Console.WriteLine,
            defaultCredentials: credentials,
            syncMode: SyncMode.ExcludeAllByDefault);

        sync.AddSourceRepository(
            owner: "NServiceBusExtensions",
            repository: "Home",
            branch: "master");

        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/.editorconfig", "src/.editorconfig");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/license.txt", "license.txt");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/workflows/on-push-do-doco.yml", ".github/workflows/on-push-do-doco.yml");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/workflows/on-tag-do-release.yml", ".github/workflows/on-tag-do-release.yml");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Attachments", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.AuditFilter", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Bond", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.MessagePack", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.HandlerOrdering", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Hyperion", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "Newtonsoft.Json.Encryption", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Jil", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.MicrosoftLogging", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.MsgPack", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Native", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.ProtoBufGoogle", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.ProtoBufNet", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Validation", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Serilog", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Utf8Json", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "NServiceBus.Wire", "master");
        sync.AddTargetRepository("NServiceBusExtensions", "Verify.NServiceBus", "master");
        return sync.Sync(SyncOutput.MergePullRequest);
    }
}