using FluentValidation;
using FluentValidation.AspNetCore;
using RowerPower.Models;
using RowerPower.Repo;
using RowerPower.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<VehicleDatabase>();

builder.Services.AddScoped<IRepository<VehicleModel>, VehicleRepository>();
builder.Services.AddScoped<IRepository<VehicleTypeModel>, VehicleTypeRepository>();
builder.Services.AddScoped<IRepository<VehicleRentalSpotModel>, RentalSpotRepository>();
//builder.Services.AddScoped<IRepository<VehicleReservationModel>, VehicleReservationRepository>();
builder.Services.AddScoped<IRepository<UserModel>, UserRepository>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<VehicleValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<VehicleTypeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RentalSpotValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var dbContext = scope.ServiceProvider.GetService<VehicleDatabase>();
    if (dbContext is null) {
        return;
    }

    List<VehicleTypeModel> vehicleTypeList = new List<VehicleTypeModel>() {
        new(){
            VehicleTypeId = 1,
            VehicleTypeName = "Wyczynowy"
        },
        new(){
            VehicleTypeId = 2,
            VehicleTypeName = "Miejski"
        },
        new(){
            VehicleTypeId = 3,
            VehicleTypeName = "Górski"
        }
    };

    foreach (var vt in vehicleTypeList) {
        VehicleTypeModel vehicleType = new VehicleTypeModel() {
            VehicleTypeId = vt.VehicleTypeId,
            VehicleTypeName = vt.VehicleTypeName
        };
        dbContext.VehicleTypes.Add(vehicleType);
    }

    dbContext.SaveChanges();

    List<VehicleDetailViewModel> vehicleList = new List<VehicleDetailViewModel>() {
        new(){
            Id = 1,
            Name = "BMX P.20",
            Type = vehicleTypeList[0],
            Producer = "Specialized",
            Price = 1949M,
            Height = 0.8F,
            Weight = 10F,
            Color = "Satin Royal Blue",
            Description = "Bardzo ³adny kolor."
        },
        new(){
            Id = 2,
            Name = "Crossway 40",
            Type = vehicleTypeList[1],
            Producer = "Merida",
            Price = 3199M,
            Height = 1.1F,
            Weight = 14F,
            Color = "White",
            Description = "Super rower!"
        },
        new(){
            Id = 3,
            Name = "Prowler Master",
            Type = vehicleTypeList[2],
            Producer = "KTM",
            Price = 23429.99M,
            Height = 1.2F,
            Weight = 14.2F,
            Color = "Silver",
            Description = "Rower trzy."
        }
    };

    dbContext.SaveChanges();

    foreach (var v in vehicleList) {

        v.Type = dbContext.VehicleTypes.Find(v.Type.VehicleTypeId);

        VehicleModel vehicle = new VehicleModel() {
            VehicleId = v.Id,
            Name = v.Name,
            Type = v.Type,
            Producer = v.Producer,
            Price = v.Price,
            Height = v.Height,
            Weight = v.Weight,
            Color = v.Color,
            Description = v.Description
        };
        dbContext.Vehicles.Add(vehicle);
    }

    dbContext.SaveChanges();

    List<VehicleRentalSpotModel> rentalSpotList = new List<VehicleRentalSpotModel>() {
        new(){
            LocaleId = 1,
            LocaleName = "Wydzia³ w Sosnowcu",
            LocaleAddress = "Krakowska 17"
        },
        new(){
            LocaleId = 2,
            LocaleName = "Wydzia³ w Kêtach",
            LocaleAddress = "Koœciuszki 24"
        },
        new(){
            LocaleId = 3,
            LocaleName = "Wydzia³ w Bielsku-Bia³ej",
            LocaleAddress = "Czo³gistów 69"
        }
    };

    foreach (var rs in rentalSpotList) {
        VehicleRentalSpotModel rentalSpot = new VehicleRentalSpotModel() {
            LocaleId = rs.LocaleId,
            LocaleName = rs.LocaleName,
            LocaleAddress = rs.LocaleAddress
        };
        dbContext.RentalSpots.Add(rentalSpot);
    }

    dbContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
