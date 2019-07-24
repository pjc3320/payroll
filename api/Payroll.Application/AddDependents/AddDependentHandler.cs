using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.AddDependents
{
    public class AddDependentHandler : IRequestHandler<AddDependent, Dependent>
    {
        private readonly IDependentRepository _dependentRepository;
        private readonly IMapper _mapper;

        public AddDependentHandler(IDependentRepository dependentRepository, IMapper mapper)
        {
            _dependentRepository = dependentRepository;
            _mapper = mapper;
        }

        public async Task<Dependent> Handle(AddDependent request, CancellationToken cancellationToken)
        {
            var dependent = _mapper.Map<Dependent>(request);
            dependent.Id = Guid.NewGuid();

            await _dependentRepository.Upsert(dependent);

            return dependent;
        }
    }
}
