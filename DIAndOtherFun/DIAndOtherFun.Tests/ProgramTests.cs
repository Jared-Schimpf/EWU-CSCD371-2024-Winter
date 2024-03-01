using DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace DIAndOtherFun.Tests;

public class ProgramTests
{
    [Fact]
    // WhatAmITesting_WhatIsTheScenario_WhatIsTheResult
    public void OutputService_WriteNextCharacter()
    {
        IServiceCollection services = new ServiceCollection();

        Program.ConfigureServices(services);

        // Arrange
        var characterProviderMock = new Mock<ICharacterProvider>();
        var writerMock = new Mock<IWriter>();

        // Registered the mocks in with the same key as the actual services
        // Last in wins
        services.AddSingleton<ICharacterProvider>(characterProviderMock.Object);
        services.Replace(new ServiceDescriptor(typeof(IWriter), writerMock.Object));

        // Set up the mock behavior
        characterProviderMock.Setup(cp => cp.GetCharacter()).Returns("Foo");

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        var things = serviceProvider.GetRequiredService<IEnumerable<IWriter>>();
        OutputService outputService = serviceProvider.GetRequiredService<OutputService>();

        // Act
        outputService.WriteOutNextCharacter();

        // Assert
        writerMock.Verify(w => w.Write("Foo"), Times.Once);
    }
}

// S.O.L.I.D. Principles
// Single Responsibility Principle
// Open/Closed Principle
// Liskov Substitution Principle
// Interface Segregation Principle *
// Dependency Inversion Principle *