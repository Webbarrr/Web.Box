using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Web.Box.Features.Services;
using Web.Box.Models;
using Web.Box.WPF.Core;

namespace Web.Box.WPF.MVVM.ViewModels
{
    public class GuidGeneratorViewModel : ViewModel
    {
        private readonly IGuidGeneratorService _generatorService;

        private int _guidQty;
        public int GuidQty { get => _guidQty; set => SetProperty(ref _guidQty, value); }

        private bool _isUpper;
        public bool IsUpper { get => _isUpper; set => SetProperty(ref _isUpper, value); }

        private bool _isLower;
        public bool IsLower { get => _isLower; set => SetProperty(ref _isLower, value); }

        private string _guids;
        public string Guids { get => _guids; set => SetProperty(ref _guids, value); }

        private bool _public;
        public bool Public { get => _public; set => SetProperty(ref _public, value); }

        private bool _private;
        public bool Private { get => _private; set => SetProperty(ref _private, value); }

        private bool _privateReadonly;
        public bool PrivateReadonly { get => _privateReadonly; set => SetProperty(ref _privateReadonly, value); }


        public GuidGeneratorViewModel(IGuidGeneratorService generatorService)
        {
            _generatorService = generatorService;

            this.IsLower = true;
        }

        private ICommand _generateGuidCommand;
        public ICommand GenerateGuidCommand
        {
            get
            {
                if (_generateGuidCommand == null)
                {
                    _generateGuidCommand = new RelayCommand(
                        p => ExecuteGenerateGuidCommand(),
                        p => CanExecuteGenerateGuidCommand());
                }

                return _generateGuidCommand;
            }
        }
        
        private bool CanExecuteGenerateGuidCommand()
        {
            return GuidQty > 0;
        }

        private void ExecuteGenerateGuidCommand()
        {
            var request = new GuidGeneratorRequest
            {
                Quantity = _guidQty,
                Format = MapFormatting(),
                UpperCase = _isUpper,
            };

            var response = _generatorService.GenerateGuids(request);

            var builder = new StringBuilder();
            foreach (var item in response)
            {
                if (string.IsNullOrWhiteSpace(item.FormattedResponse))
                {
                    builder.Append(item.GuidWithCase);
                }
                else
                {
                    builder.Append(item.FormattedResponse);
                }

                builder.AppendLine();
            }

            Guids = builder.ToString();
        }

        private GuidGenerationFormat MapFormatting()
        {
            if (Private)
                return GuidGenerationFormat.Private;

            if (Public)
                return GuidGenerationFormat.Public;

            if (PrivateReadonly)
                return GuidGenerationFormat.PrivateReadonly;

            return GuidGenerationFormat.None;
        }

    }
}
