global using System.Runtime.CompilerServices;
global using Ardalis.SharedKernel;
global using Shouldly;
global using Mediator;
global using Microsoft.Extensions.Logging;
global using NSubstitute;
global using Xunit;
global using Vogen;

[assembly: VogenDefaults(
  staticAbstractsGeneration: StaticAbstractsGeneration.MostCommon | 
                             StaticAbstractsGeneration.InstanceMethodsAndProperties)]
