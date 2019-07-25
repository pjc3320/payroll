using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Payroll.Application.Models;

namespace Payroll.Application.UpsertDependents
{
    public class UpsertDependentHandler : IRequestHandler<UpsertDependent, Dependent>
    {
        private readonly IDependentRepository _dependentRepository;
        private readonly IMapper _mapper;

        public UpsertDependentHandler(IDependentRepository dependentRepository, IMapper mapper)
        {
            _dependentRepository = dependentRepository ?? throw new ArgumentNullException(nameof(dependentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Dependent> Handle(UpsertDependent request, CancellationToken cancellationToken)
        {
            var dependent = _mapper.Map<Dependent>(request);
            dependent.Id = Guid.NewGuid();

            await _dependentRepository.Upsert(dependent);

            return dependent;
        }
    }
}
