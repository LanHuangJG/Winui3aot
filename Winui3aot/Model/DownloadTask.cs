namespace Winui3aot.Model
{
    public record DownloadTask(
        string Aid,
        string Url,
        long TaskCreateTime,
        string Title,
        string Pic,
        long VideoPubTime,
        long TaskFinishTime,
        double Progress,
        double DownloadSpeed,
        double TotalDownloadedBytes,
        bool IsSuccessful
);

}
