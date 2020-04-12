using Xunit;
using nats_client_metrics.Models;
using System;

namespace tests.Models
{
    public class ConnectionVariablesTests
    {
        [Fact]
        public void Test_NewConnectionVarsIsValid()
        {
            ConnectionVariables connvars = new ConnectionVariables();
            Assert.True(connvars != null);
            Assert.True(connvars.connections != null);
            Assert.True(connvars.connections.Count == 0);
        }
    
        [Fact]
        public void Test_ConnectionVarsWithDataIsValid()
        {
            ConnectionVariables connvars = new ConnectionVariables();

            ClientVariables clientvars = new ClientVariables();
            clientvars.uptime = "29m10s";
            clientvars.idle = "29m5s";
            clientvars.clientId = 1;
            clientvars.clientName = "my_client_name";
            clientvars.language = ".NET";
            clientvars.ipAddress = "10.10.10.111";
            clientvars.serverId = "KJGHKJGHJGFTOIUGLKHGJHKFGJKLHIUGYUT";
            clientvars.rtt = "2.74345s";
            clientvars.inMessages = 10;
            clientvars.outMessages = 14;
            clientvars.inBytes = 3434343;
            clientvars.outBytes = 1342132423;
            clientvars.subscriptions = 2;
            clientvars.pendingBytes = 0;

            connvars.connections.Add(clientvars);
            
            // test things out
            Assert.True(connvars != null);
            Assert.True(connvars.connections != null);
            Assert.True(connvars.connections.Count == 1);
        }
    }
}
