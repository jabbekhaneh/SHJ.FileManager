using SHJ.FileManager;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conntection= "data source =.; initial catalog =dbFileManager; integrated security = True; MultipleActiveResultSets=True";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/////////////////////////////////
builder.Services.AddFileManager(option =>
{
    option.DatabaseName = "dbFileManager";
    option.ConnectionString = conntection;
});
/////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/////////////////////////////
app.UseStaticFiles();
app.UseFileManager();
/////////////////////////////
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
