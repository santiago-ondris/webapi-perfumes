// using MasterNet.Domain;
// using MasterNet.Persistence;
// using Microsoft.EntityFrameworkCore;

// using var context = new MasterNetDbContext();

// var perfumeNuevo = new Perfume
// {
//     Id = Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
//     Nombre = "Tuxedo",
//     Descripcion = "La sensualidad de la madera ambarina se combina con el luminosolirioetéreo para formar un dúo totalmente adictivo y embriagador.",
//     FechaPublicacion = new DateTime(2022, 1, 1),
//     MarcaId = DataSeed.Marca1Id
// };

// context.Add(perfumeNuevo);
// await context.SaveChangesAsync();

// var perfumes = await context.Perfumes!.ToListAsync();
// foreach(var perfume in perfumes)
// {
//     System.Console.WriteLine($"{perfume.Id}  {perfume.Nombre}");
// }