using NUnit.Framework;
using System.Threading.Tasks;
using DweetSharp;
using System.Threading;

#pragma warning disable RECS0063 // Warns when a culture-aware 'StartsWith' call is used by default.

namespace DweetSharpTests
{
    [TestFixture]
    public class LocksTests
    {
        [Test]
        public async Task FailLock()
        {
            Assert.False(await Dweet.Lock("someRandomThingJustForDweetSharp", "dweetLock", "masterKey"));
        }

        [Test]
        public async Task FailUnlock()
        {
            Assert.False(await Dweet.Unlock("someRandomThingJustForDweetSharp", "masterKey"));
        }

        [Test]
        public async Task FailRemoveLock()
        {
            Assert.False(await Dweet.RemoveLock("dweetLock", "masterKey"));
        }
    }

    [TestFixture]
    public class DweetTests
    {
        [Test]
        public async Task DweetForWithoutKey()
        {
            Thread.Sleep(1000); //make sure API is only called once every second for the same thing
            Assert.True(await Dweet.DweetFor("someRandomThingJustForDweetSharp", "{\"test\":123456789}"));
        }

        [Test]
        public async Task DweetQuietlyForWithoutKey()
        {
            Thread.Sleep(1000); //make sure API is only called once every second for the same thing
            Assert.True(await Dweet.DweetQuietlyFor("someRandomThingJustForDweetSharp", "{\"test\":123456789}"));
        }

        [Test]
        public async Task GetLatestDweetForWithoutKey()
        {
            Thread.Sleep(1000); //make sure API is only called once every second for the same thing
            Assert.True((await Dweet.GetLatestDweetFor("someRandomThingJustForDweetSharp")).StartsWith("{\"this\":\"succeeded\","));
        }
    }
}
