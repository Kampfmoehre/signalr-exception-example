using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Sockets;
using Microsoft.Extensions.Logging;
using SignalRExceptionExample.Model;

namespace SignalRExceptionExample.Client
{
    public class CalculateClient<TResult> : IDisposable
    {
        private HubConnection _connection;
        private readonly Uri _baseUrl;
        private readonly ILoggerFactory _loggerFactory;
        public CalculateClient(Uri baseUrl, ILoggerFactory loggerFactory)
        {
            _baseUrl = baseUrl;
            _loggerFactory = loggerFactory;
        }

        public async Task ConnectAsync()
        {
            var uri = new Uri(_baseUrl, "calculate");
            _connection = new HubConnection(uri, _loggerFactory);

            TransportType transportType = GetTransportTypeFromOS();
            Console.WriteLine($"Running on {RuntimeInformation.OSDescription} connection to {uri} using transport type {transportType}");
            await _connection.StartAsync(transportType);
        }

        public async Task<TResult> Calculate(IRootModel model)
        {
            return await _connection.Invoke<TResult>("Calculate", model);
        }

        public async Task<TResult> CalculateWithConverter(IRootModel model)
        {
            return await _connection.Invoke<TResult>("CalculateWithConverter", model);
        }

        public void Dispose()
        {
            DisposeAsync().Wait();
        }

        public async Task DisposeAsync()
        {
            if (_connection != null)
            {
                await _connection.DisposeAsync();
                _connection = null;
            }
        }

        private TransportType GetTransportTypeFromOS()
        {
            // When not on windows use web sockets
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return TransportType.WebSockets;

            const int versionOffset = 18;
            var versionStr = RuntimeInformation.OSDescription.Substring(versionOffset);
            if (!Version.TryParse(versionStr, out Version version))
                return TransportType.LongPolling;

            if (version.Major > 6 || (version.Major == 6 && version.Minor >= 2))
                return TransportType.WebSockets;

            return TransportType.LongPolling;
        }
    }
}