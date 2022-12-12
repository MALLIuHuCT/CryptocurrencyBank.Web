using CryptocurrencyBank.Desktop.CryptocurrencyBankApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddControllers(options => options.EnableEndpointRouting = false);
builder.Services.AddScoped<BalanceHttpClient>();
builder.Services.AddScoped<MoneyTransferHttpClient>();

builder.Services.AddHttpClient<BalanceHttpClient>(clien =>
{
    clien.BaseAddress = new Uri("http://localhost:5139/api/Balance/");
});

builder.Services.AddHttpClient<MoneyTransferHttpClient>(clien =>
{
    clien.BaseAddress = new Uri("http://localhost:5139/api/MoneyTransfer/");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMvc();

app.UseAuthorization();

app.MapControllers();

app.Run();
