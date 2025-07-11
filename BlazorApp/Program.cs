using BlazorApp.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.SmartComponents;
using Syncfusion.Blazor.AI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSyncfusionSmartComponents()
.ConfigureCredentials(new AIServiceCredentials { SelfHosted = true, Endpoint = new Uri("Your local endpoint"), DeploymentName = "your model name" })
.InjectOpenAIInference();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
