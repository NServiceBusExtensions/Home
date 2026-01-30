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
            owner: "NServiceBusCommunity",
            repository: "Home",
            branch: "master");

        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/.editorconfig", "src/.editorconfig");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/license.txt", "license.txt");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/workflows/on-push-do-doco.yml", ".github/workflows/on-push-do-doco.yml");
        sync.AddSourceItem(TreeEntryTargetType.Blob, "src/RepoSync/Source/workflows/on-tag-do-release.yml", ".github/workflows/on-tag-do-release.yml");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Attachments", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.AuditFilter", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Bond", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.MessagePack", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.HandlerOrdering", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Hyperion", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "Newtonsoft.Json.Encryption", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Jil", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.MicrosoftLogging", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.MsgPack", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Native", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.ProtoBufGoogle", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.ProtoBufNet", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Validation", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Serilog", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Utf8Json", "master");
        //sync.AddTargetRepository("NServiceBusCommunity", "NServiceBus.Wire", "master");
        sync.AddTargetRepository("NServiceBusCommunity", "Verify.NServiceBus", "master");
        return sync.Sync(SyncOutput.MergePullRequest);
    }
}