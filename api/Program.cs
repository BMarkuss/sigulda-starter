using ApiDemoProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("All", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("All");

// GET
// Izgūt visas skolas kā sarakstu no datubāzes
app.MapGet("/registracijas", () =>
{
    RegistresanaRepository registresanaRepository = new RegistresanaRepository();

    List<Registracija> registracijas = registresanaRepository.GetAll();

    return registracijas;
});


// GET
// Izgūt visas skolas kā sarakstu no datubāzes
app.MapGet("/registracijas/{id}", (int id) =>
{
    RegistresanaRepository registresanaRepository = new RegistresanaRepository();

    Registracija registracija = registresanaRepository.FindById(id);

    return registracija;
});

// POST
// Pievienot jaunu skolu
app.MapPost("/registracijas", (Registracija registracija) =>
{
    RegistresanaRepository registracijasRepository = new RegistresanaRepository();

    registracijasRepository.Add(registracija);
});


// GET
// Izgūt visus sludinājumus kā sarakstu no datubāzes
app.MapGet("/registracijas", () =>
{
    RegistresanaRepository registresanaRepositaory = new RegistresanaRepository();

    List<Registracija> registracijas = registresanaRepositaory.GetAll();

    return registracijas;
});

app.MapPost("/sludinajumi", (Registracija registracija) =>
{
    RegistresanaRepository registracijasRepository = new RegistresanaRepository();

    registracijasRepository.Add(registracija);
});


app.MapPost("/post", () => "Hello from POST!");

// PUT
app.MapPut("/", () => "Hello from root PUT!");
app.MapPut("/put", () => "Hello from PUT!");

// DELETE
app.MapDelete("/", () => "Hello from root DELETE!");
app.MapDelete("/delete", () => "Hello from DELETE!");

app.Run();