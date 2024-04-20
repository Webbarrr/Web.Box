namespace Web.Box.Models
{
    public record GuidGeneratorResponse
    {
        public Guid Guid { get; init; }
        public string GuidWithCase { get; init; } = string.Empty;
        public string? FormattedResponse { get; init; }
    }
}