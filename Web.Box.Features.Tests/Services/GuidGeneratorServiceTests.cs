using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Box.Features.Services;
using Web.Box.Models;

namespace Web.Box.Features.Tests.Services
{
    public class GuidGeneratorServiceTests
    {
        private readonly GuidGeneratorService _service;
        private readonly IGuidFormatterService _formatter;

        public GuidGeneratorServiceTests()
        {
            _formatter = Substitute.For<IGuidFormatterService>();
        }

        public static IEnumerable<object[]> ValidRequests()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new GuidGeneratorRequest
                    {
                        Format = GuidGenerationFormat.None,
                        Quantity = 2,
                    },

                    new List<GuidGeneratorResponse>
                    {
                        new GuidGeneratorResponse
                        {
                            Guid = Guid.Parse("f732ad11-ec41-4bf8-8bc6-52f417b96753"),
                            FormattedResponse = string.Empty,
                        },

                        new GuidGeneratorResponse
                        {
                            Guid = Guid.Parse("5bcffaad-d476-40fa-ab46-5fa934c8a65e"),
                            FormattedResponse = string.Empty,
                        },
                    }
                },
            };
        }

        [Theory]
        [MemberData(nameof(ValidRequests))]
        public void GenerateGuids_GivenValidRequest_ReturnsFormatedGuids(GuidGeneratorRequest request, List<GuidGeneratorResponse> expectedResponse)
        {

        }
    }
}
