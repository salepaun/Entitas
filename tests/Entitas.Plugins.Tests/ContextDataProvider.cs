﻿using FluentAssertions;
using Xunit;

namespace Entitas.Plugins.Tests
{
    public class ContextDataProvider
    {
        [Fact]
        public void CreatesDataForEachContext()
        {
            var contexts = "Entitas.Plugins.Contexts = Input, GameState";
            var provider = new Plugins.ContextDataProvider();
            provider.Configure(new TestPreferences(contexts));

            var data = (ContextData[])provider.GetData();
            data.Length.Should().Be(2);
            data[0].Name.Should().Be("Input");
            data[1].Name.Should().Be("GameState");
        }
    }
}