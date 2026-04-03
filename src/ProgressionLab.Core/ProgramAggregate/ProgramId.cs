using Vogen;

[assembly: VogenDefaults(
  staticAbstractsGeneration: StaticAbstractsGeneration.MostCommon | 
                             StaticAbstractsGeneration.InstanceMethodsAndProperties)]

namespace ProgressionLab.Core.ProgramAggregate;

[ValueObject<int>]
public readonly partial struct ProgramId
{
  
}
