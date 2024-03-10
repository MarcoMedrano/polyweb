using System.Xml.Linq;

public class DownloadInfoService(HttpClient httpClient)
{
    const string x86Url = "https://polytranslator.s3.amazonaws.com/windows/x86/update.xml";
    const string x64Url = "https://polytranslator.s3.amazonaws.com/windows/x64/update.xml";

    public Task<DownloadInfo> GetX86DownloadInfoAsync() => GetDownloadInfoAsync(x86Url);
    public Task<DownloadInfo> GetX64DownloadInfoAsync() => GetDownloadInfoAsync(x64Url);

    private async Task<DownloadInfo> GetDownloadInfoAsync(string url)
    {
        string xml = await httpClient.GetStringAsync(url);
        var itemElement = XDocument.Parse(xml).Root;

        return new ()
        {
            Version = itemElement.Element("version").Value,
            Url = itemElement.Element("url").Value,
            Mandatory = bool.Parse(itemElement.Element("mandatory").Value)
        };
    }
}