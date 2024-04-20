namespace Web.Box.Models
{
    public record GuidGeneratorRequest
    {
        /// <summary>
        /// Number of guids to generate
        /// </summary>
        public int Quantity { get; init; }

        /// <summary>
        /// The request format
        /// </summary>
        public GuidGenerationFormat Format { get; init; }

        /// <summary>
        /// Should it be uppercase?
        /// </summary>
        public bool UpperCase { get; init; } = false;
    }
}