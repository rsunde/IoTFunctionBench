using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Collections.Generic;

namespace IoTFunctionBench
{
    public static class SystemInfo
    {
        [FunctionName("SystemInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("System Information and Benchmarking.");

            var result = new List<string>();

            Assembly assem = typeof(SystemInfo).Assembly;

            result.Add($"MachineName: {Environment.MachineName.ToString()}");
            result.Add();
            result.Add($"ProcessorCount: {Environment.ProcessorCount.ToString()}");
            result.Add($"Is64BitProcess: {Environment.Is64BitProcess.ToString()}");
            result.Add($"Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem.ToString()}");
            result.Add();
            result.Add($"OSVersion.Platform: {Environment.OSVersion.Platform.ToString()}");
            result.Add($"OSVersion.Version: {Environment.OSVersion.Version.ToString()}");
            result.Add();
            result.Add($"CLR Version: {Environment.Version.ToString()}");
            result.Add();
            result.Add($"Process WorkingSet: {Environment.WorkingSet.ToString()}");
            result.Add();
            result.Add($"UserDomainName: {Environment.UserDomainName.ToString()}");
            result.Add($"UserName: {Environment.UserName.ToString()}");
            result.Add();
            result.Add($"Assembly FullName: {assem.FullName.ToString()}");
            result.Add($"Assembly CodeBase: {assem.CodeBase.ToString()}");
            result.Add($"Assembly Location: {assem.Location.ToString()}");
            result.Add($"Assembly ManifestModule: {assem.ManifestModule.ToString()}");
            result.Add($"Assembly ImageRuntimeVersion: {assem.ImageRuntimeVersion.ToString()}");
            result.Add();
            result.Add(Extensions.Benchmark(100000000));
            result.Add(" 100,000,000 Takes ~ 11.5 seconds on MSI");
            result.Add(" 100,000,000 Takes ~ xx.x seconds on Lenovo");
            result.Add(" 100,000,000 Takes ~ xx.x seconds in Azure basic");

            return new OkObjectResult($"System information:{Environment.NewLine}{result.ToStringRows(" - ")}");
        }
    }
}
