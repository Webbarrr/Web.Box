using Web.Box.Models;

namespace Web.Box.Features.Services
{
    public interface IGuidGeneratorService
    {
        IEnumerable<GuidGeneratorResponse> GenerateGuids(GuidGeneratorRequest request);
    }

    public class GuidGeneratorService : IGuidGeneratorService
    {
        private readonly IGuidFormatterService _formatterService;

        public GuidGeneratorService(IGuidFormatterService formatterService)
        {
            _formatterService = formatterService;
        }

        public IEnumerable<GuidGeneratorResponse> GenerateGuids(GuidGeneratorRequest request)
        {
            var guids = new HashSet<Guid>();
            var response = new List<GuidGeneratorResponse>();

            for (int i = 0; i < request.Quantity; i++)
            {
                Guid guid;
                do
                {
                    guid = CreateGuid();
                } while (!guids.Add(guid)); // Add returns false if the guid is already in the set, so repeat until a unique one is generated

                response.Add(new GuidGeneratorResponse
                {
                    Guid = guid,
                    GuidWithCase = request.UpperCase ? guid.ToString().ToUpper() : guid.ToString(),
                    FormattedResponse = _formatterService.FormatGuid(guid, request.Format, i, request.UpperCase),
                });
            }

            return response;
        }

        internal Guid CreateGuid() => Guid.NewGuid();
    }
}