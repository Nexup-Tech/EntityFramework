using EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=db41759.public.databaseasp.net; Database=db41759; User Id=db41759; Password=Xa6?=7BqdT!4; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;")
    .Options;

using var context = new AppDbContext(options);



