// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();

//BrandTest();





static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine(car.BrandName + "/" + car.ModelYear + "/" + car.ColorName + "/" + car.DailyPrice);
    }

    //Car car1 = new Car { CarId = 5, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 20, Description = "Max 20 days rental" };
    //carManager.Add(car1);

    //foreach (var car in carManager.GetAll())
    //{
    //    Console.WriteLine(car.Description + car.CarId);
    //}

    //foreach (var car in carManager.GetByBrandId(1))
    //{
    //    Console.WriteLine(car.Description + " " + car.CarId);
    //}
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    //var brand3 = new Brand() { Id = 9, Name = "Kia" };
    //brandManager.AddBrand(brand3);

    //Brand brand1 = new Brand() {Id=7,Name="GMC"};

    //brandManager.DeleteBrand(brand3);
    //var brand2 = new Brand() { Id = 5, Name = "GMC" };
    //brandManager.UpdateBrand(brand2);


    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.Id + " " + brand.Name);
    }
}