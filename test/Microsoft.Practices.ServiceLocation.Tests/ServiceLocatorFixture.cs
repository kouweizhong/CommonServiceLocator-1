using System;
using Microsoft.Practices.ServiceLocation;
using ServiceLocation.Tests.Mocks;
using Xunit;

namespace ServiceLocation.Tests
{
    public class ServiceLocatorFixture
    {
        [Fact]
        public void TestInit()
        {
            ServiceLocator.SetLocatorProvider(null);
        }

        [Fact]
        public void ServiceLocatorIsLocationProviderSetReturnsTrueWhenSet()
        {
            ServiceLocator.SetLocatorProvider(() => new MockServiceLocator());

            Assert.True(ServiceLocator.IsLocationProviderSet);
        }

        [Fact]
        public void ServiceLocatorIsLocationProviderSetReturnsFalseWhenNotSet()
        {
            Assert.False(ServiceLocator.IsLocationProviderSet);
        }

        [Fact]
        public void ServiceLocatorCurrentThrowsWhenLocationProviderNotSet()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var currentServiceLocator = ServiceLocator.Current;
            });
        }
    }
}
