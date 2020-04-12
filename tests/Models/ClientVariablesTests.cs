using Xunit;
using nats_client_metrics.Models;
using System;

namespace tests.Models
{
    public class ClientVariablesTests
    {
        [Fact]
        public void Test_NewClientVariablesIsValid()
        {
            ClientVariables clientvars = new ClientVariables();
            Assert.True(clientvars != null);
            Assert.True(clientvars.clientId == 0);
            Assert.True(clientvars.uptimeDays == 0);
            Assert.True(clientvars.uptimeHours == 0);
            Assert.True(clientvars.uptimeMinutes == 0);
            Assert.True(clientvars.uptimeSeconds == 0);
            Assert.True(clientvars.idleDays == 0);
            Assert.True(clientvars.idleHours == 0);
            Assert.True(clientvars.idleMinutes == 0);
            Assert.True(clientvars.idleSeconds == 0);
            Assert.True(clientvars.inMessages == 0);
            Assert.True(clientvars.outMessages == 0);
            Assert.True(clientvars.inBytes == 0);
            Assert.True(clientvars.outBytes == 0);
            Assert.True(clientvars.subscriptions == 0);
            Assert.True(clientvars.pendingBytes == 0);
            Assert.True(clientvars.roundTripTime == 0);
        }
    
        [Fact]
        public void Test_ClientVariablesWithDataIsValid()
        {
            ClientVariables clientvars = new ClientVariables();
            clientvars.uptime = "29m10s";
            clientvars.idle = "29m5s";
            clientvars.clientId = 1;
            clientvars.clientName = "my_client_name";
            clientvars.language = ".NET";
            clientvars.ipAddress = "10.10.10.111";
            clientvars.serverId = "KJGHKJGHJGFTOIUGLKHGJHKFGJKLHIUGYUT";
            clientvars.rtt = "2.743s";
            clientvars.inMessages = 10;
            clientvars.outMessages = 14;
            clientvars.inBytes = 3434343;
            clientvars.outBytes = 1342132423;
            clientvars.subscriptions = 2;
            clientvars.pendingBytes = 0;

            Assert.True(clientvars != null);
            Assert.True(clientvars.clientId == 1);
            Assert.True(clientvars.uptimeDays == 0);
            Assert.True(clientvars.uptimeHours == 0);
            Assert.True(clientvars.uptimeMinutes == 29);
            Assert.True(clientvars.uptimeSeconds == 10);
            Assert.True(clientvars.idleDays == 0);
            Assert.True(clientvars.idleHours == 0);
            Assert.True(clientvars.idleMinutes == 29);
            Assert.True(clientvars.idleSeconds == 5);
            Assert.True(clientvars.inMessages == 10);
            Assert.True(clientvars.outMessages == 14);
            Assert.True(clientvars.inBytes == 3434343);
            Assert.True(clientvars.outBytes == 1342132423);
            Assert.True(clientvars.subscriptions == 2);
            Assert.True(clientvars.pendingBytes == 0);
            Assert.True(clientvars.roundTripTime == Convert.ToDecimal(2.743));
        }
    }
}
