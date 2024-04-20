using Web.Box.Models;

namespace Web.Box.Features.Services
{
    public interface IGuidFormatterService
    {
        string FormatGuid(Guid guid, GuidGenerationFormat format, int iteration, bool? upperCase = null);
    }

    public class GuidFormatterService : IGuidFormatterService
    {
        public string FormatGuid(Guid guid, GuidGenerationFormat format, int iteration, bool? upperCase = null)
        {
            var formattedGuid = guid.ToString();
            if (upperCase.HasValue && upperCase.Value == true)
            {
                formattedGuid = formattedGuid.ToUpper();
            }

            switch (format)
            {
                case GuidGenerationFormat.Public:
                    return $"public Guid Property{iteration} = Guid.Parse(\"{formattedGuid}\");";
                case GuidGenerationFormat.Private:
                    return $"private Guid _property{iteration} =  Guid.Parse(\"{formattedGuid}\");";
                case GuidGenerationFormat.PrivateReadonly:
                    return $"private readonly Guid _property{iteration} =  Guid.Parse(\"{formattedGuid}\");";
                default:
                    return string.Empty;
            }
        }
    }
}
