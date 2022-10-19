// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//CarTest();

//BrandTest();

//Core.Utilities.Result.IDataResult<List<User>> result = UserTest();

CustomerTest();

//RentalTest();

static void CarTest()
{
    //CarManager carManager = new CarManager(new EfCarDal());

    //foreach (var car in carManager.GetCarDetails())
    //{
    //    Console.WriteLine(car.BrandName + "/" + car.ModelYear + "/" + car.ColorName + "/" + car.DailyPrice);
    //}

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


    //foreach (var brand in brandManager.GetAll())
    //{
    //    Console.WriteLine(brand.Id + " " + brand.Name);
    //}
}

static Core.Utilities.Result.IDataResult<List<User>> UserTest()
{
    UserManager userManager = new UserManager(new EfUserDal());
    //User user1 = new User() { Id = 2, FirstName = "Ahmet", LastName = "Oz", Email = "a@aa.com", Password = "1234" };
    //userManager.Add(user1);
    User user2 = new User() { Id = 1, FirstName = "Elf", LastName = "Oz", Email = "a@aa.com", Password = "1234" };
    userManager.Update(user2);
    var result = userManager.GetAll();
    if (result.Success == true)
    {
        foreach (var user in result.Data)
        {
            Console.WriteLine(user.FirstName + "" + user.LastName);
        }
    }

    return result;
}

static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    //Rental rental2 = new Rental() { CarId = 2, Id = 5, CustomerId = 1, RentDate = Convert.ToDateTime("10.12.2022"), ReturnDate= Convert.ToDateTime("12.12.2022") };
    //rentalManager.Update(rental2);
    Rental rental1 = new Rental() { CarId = 2, Id = 6, CustomerId = 2, RentDate = Convert.ToDateTime("10.11.2022") };
    //rentalManager.Add(rental1);
    //Rental rental1 = new Rental() { CarId = 1, Id = 3, CustomerId = 2, RentDate = Convert.ToDateTime("10.11.2022") };
    var result = rentalManager.Add(rental1);
    if (result.Success == false)
    {
        Console.WriteLine(result.Message);
    }

    else
    {
        Console.WriteLine(result.Message);
    }
    var rresult = rentalManager.GetAll();
    if (rresult.Success == true)
    {
        foreach (var rental in rresult.Data)
        {
            Console.WriteLine(rental.Id + "/" + rental.CarId + "/" + rental.ReturnDate);
        }
    }
    Console.WriteLine(((rentalManager.GetByRentalId(1)).Data).CustomerId);
}

static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
    //Customer customer1 = new Customer() { Id = 1, CompanyName = "aa" };
    //customerManager.Add(customer1);
    var cresult = customerManager.GetAll();
    if (cresult.Success == true)
    {
        foreach (var customer in cresult.Data)
        {
            Console.WriteLine(customer.Id + "" + customer.CompanyName);
        }
    }
}