using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectBooks.Data;
using ProjectBooks.Data.Entities;
using ProjectBooks.Models.ViewModel;
using ProjectBooks.Repository;


namespace ProjectBooks.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IRepository<Author> _author;
        private readonly IRepository<Book> _book;
        private readonly AppDbContext _app;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthorController(IRepository<Author> author, IRepository<Book> book, AppDbContext app, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            _author = author;
            _book = book;
            _app = app;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Author> author = _author.GetAll();
            var LoggedIn = HttpContext.Session.GetString("IsLoggedIn");
            if (LoggedIn == "true")
            {
                var username = HttpContext.Session.GetString("Username");
                // User is logged in, you can use the username or other stored data

                ViewBag.Username = username;
            }
            return View(author);
        }
        //public async Task<IActionResult> AuthorWithBook(Author a1)
        //{
        //    Author a = _author.GetByID(a=> a.ID ==a1.ID);
        //    List<Book> book = _app.books.Where(i => i.AuthorID == a1.ID).ToList();
        //    var vm = new AuthorBookVM
        //    {
        //        author = a,
        //        books = book
        //    };
        //    return View(vm);
        //}
       
        public async Task<IActionResult> AuthorBook(Author a1)
        {

            List<Book> book = _app.books.Where(i => i.AuthorID == a1.ID).ToList();

            return View(book);
        }

        public async Task<IActionResult> UpdateBook(Book book)
        {

            Book book1 = _book.GetByID(i => i.ID == book.ID);

            return View(book1);
        }

        public async Task<IActionResult> UpdateBookbtn(Book book)
        {

            _book.Update(book);
            int save = _app.SaveChanges();
            return RedirectToAction(nameof(AuthorBook));
        }

        public async Task<IActionResult> DeleteBook(int id)
        {

            Book book1 = _book.GetByID(i => i.ID == id);

            return View(book1);
        }

        public async Task<IActionResult> DeleteBookBtn(int id)
        {
            Book book = _book.GetByID(i => i.ID == id);
            if (book != null)
            {
                _book.Delete(book);
                int save = _app.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateBook(Author author)
        {
            Author a = _author.GetByID(x => x.ID == author.ID);
            var vm = new AuthorBookVM
            {
                author = a,

            };
            return View(vm);
        }
        public async Task<IActionResult> CreateBookBtn(AuthorBookVM vm)
        {
            var newbook = new Book
            {
                AuthorID = vm.author.ID,
                Name = vm.books.Name,
                Description = vm.books.Description

            };
            _book.Add(newbook);
            int save = _app.SaveChanges();
            return RedirectToAction(nameof(Index));


        }


        public async Task<IActionResult> RegistrUser()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrUser(UserVM vm)
        {

            if (vm.Password == vm.CheckPassword)
            {
                var AddToTableIdentityUser = new IdentityUser()
                {
                    UserName = vm.UserName,
                    Email = vm.Email,
                    PhoneNumber = vm.Phone

                };
                var AddToTableUser = new User()
                {

                    UserName = vm.UserName,
                    Email = vm.Email,
                    Password = vm.Password,
                    CheckPassword = vm.CheckPassword,
                    Phone = vm.Phone,
                    Address = vm.Address,

                };
                var result = await _userManager.CreateAsync(AddToTableIdentityUser, vm.Password);

                if (result.Succeeded)
                {
                    var SignInResult = await _signInManager.PasswordSignInAsync(AddToTableIdentityUser, vm.Password, false, false); // user authentication 
                    if (SignInResult.Succeeded)
                    {

                        if (vm.userRole == "Customer")
                        { 
                            _app.users.Add(AddToTableUser);
                            int Save1 = _app.SaveChanges();

                            var findUserID = _app.users.Find(AddToTableUser.Id);

                                var AddToTablCustomer = new Customer()
                                {
                                    UserID = findUserID.Id
                                };
                                _app.customers.Add(AddToTablCustomer);
                            int Save2 = _app.SaveChanges();
                         
                        }

                        else
                        {
                            _app.users.Add(AddToTableUser);
                            int Save = _app.SaveChanges();
                        }
                        return RedirectToAction(nameof(LoginUser));
                    }
                }

                return RedirectToAction(nameof(LoginUser));
            }


            return View();
        }


        public async Task<IActionResult> LoginUser()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> LoginUser(UserVM vm)
        {

            var SignInResult = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password,true, false); //authentication 

            if(SignInResult.Succeeded)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");

                HttpContext.Session.SetString("Username", vm.UserName);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        //public async Task<IActionResult> EditAuthorBook(Book book)
        //{

        //    Author author1 = _author.GetByID(x => x.ID == book.AuthorID);
        //    Book book1 = _book.GetByID(i => i.ID == book.ID);
        //    var vm1 = new AuthorBookVM
        //    {
        //        author = author1,
        //        books = book1
        //    };
        //    return View(vm1);
        //}

        //[HttpPost]
        //public async Task<IActionResult> EditAuthorBookPost(Book book)
        //{

        //     _book.Update(book);
        //    int save = _app.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}

//SqlException: Cannot insert the value NULL into column 'Name', table 'Project1.dbo.Author'; column does not allow nulls. INSERT fails.

