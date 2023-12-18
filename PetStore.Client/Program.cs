using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PetStore.Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IStateService, StateService>();
await builder.Build().RunAsync();
