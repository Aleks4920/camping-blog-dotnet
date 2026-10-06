using campingBlog.Controllers;
using campingBlog.Data;
using campingBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CampingBlogTests
{
    [TestClass]
    public class PostsControllerTests
    {
        private ApplicationDbContext context;
        private PostsController controller;



        [TestMethod]
        public void IndexLoadView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (ViewResult)controller.Index().Result;

            // Assert

            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void IndexReturnsAllPosts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (ViewResult)controller.Index().Result;
            var model = (List<Post>)result.Model;

            // Assert
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void DetailsReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (NotFoundResult)controller.Details(1).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        //test if the details returns not found when post id is null
        [TestMethod]
        public void DetailsReturnsNotFoundWhenPostIdIsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (NotFoundResult)controller.Details(null).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DetailsReturnsPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                PostId = 1,
                Title = "Test Post",
                Content = "Test Content",
                Author = "Test Author",
                CategoryId = 1,
                Category = new Category
                {
                    CategoryId = 1,
                    Description = "Test Category",
                    Name = "Test Name"
                }

            };
            context.Post.Add(post);
            context.SaveChanges();
            // Act
            var result = (ViewResult)controller.Details(1).Result;
            var model = (Post)result.Model;

            // Assert
            Assert.AreEqual("Post", result.ViewName);
            Assert.AreEqual(1, model.PostId);
            Assert.AreEqual("Test Post", model.Title);
            Assert.AreEqual("Test Content", model.Content);
            Assert.AreEqual(1, model.CategoryId);
            Assert.AreEqual("Test Category", model.Category.Description);

        }


        [TestMethod]
        public void CreateReturnsView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (ViewResult)controller.Create();

            // Assert
            Assert.AreEqual("Create", result.ViewName);

        }


        [TestMethod]
        public void CreateReturnsPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                Category = new Category
                {
                    CategoryId = 1,
                    Description = "Test Category",
                    Name = "Test Name"
                }
            };
            // Act
            controller.ModelState.AddModelError("", "No error");
            var result = (ViewResult)controller.Create(post).Result;
            var model = (Post)result.Model;

            // Assert
            Assert.AreEqual(post, model);

        }

        [TestMethod]
        public void EditReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (NotFoundResult)controller.Edit(1).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditReturnsPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                Category = new Category
                {
                    CategoryId = 1,
                    Description = "Test Category",
                    Name = "Test Name"
                }

            };
            context.Post.Add(post);
            context.SaveChanges();
            // Act
            var result = (ViewResult)controller.Edit(1).Result;
            var model = (Post)result.Model;

            // Assert
            Assert.AreEqual(post, model);

        }

        [TestMethod]
        public void EditReturnsView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);

            var post = new Post
            {
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                CategoryId = 1

            };


            // Act
            context.Post.Add(post);
            context.SaveChanges();
            var controller = new PostsController(context);

            var result = (RedirectToActionResult)controller.Edit(post.PostId, post).Result;

            //Assert
            Assert.AreEqual("Index", result.ActionName);



        }

        [TestMethod]
        public void DeleteReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (NotFoundResult)controller.Delete(1).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DeleteConfirmedReturnsPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                PostId = 1,
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                CategoryId = 1

            };
            context.Post.Add(post);
            context.SaveChanges();
            // Act
            controller.ModelState.AddModelError("", "No error");
            var result = (RedirectToActionResult)controller.DeleteConfirmed(1).Result;

            // Assert   
            Assert.AreEqual("Index", result.ActionName);


        }

        [TestMethod]
        public void DeleteConfirmedReturnsNotFound()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (RedirectToActionResult)controller.DeleteConfirmed(1).Result;

            // Assert
            Assert.AreEqual(404, result);

        }

        [TestMethod]
        public void DeleteConfirmedReturnsRedirect()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                CategoryId = 1


            };

            controller.ModelState.AddModelError("", "No error");
            context.Post.Add(post);
            context.SaveChanges();

            // Act
            var result = (RedirectToActionResult)controller.DeleteConfirmed(1).Result;

            // Assert
            Assert.AreEqual("Index", result.ActionName);

        }

        [TestMethod]
        public void IndexReturnsView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (ViewResult)controller.Index().Result;

            // Assert
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void IndexReturnsViewWithNoPosts()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (ViewResult)controller.Index().Result;
            var model = (List<Post>)result.Model;

            // Assert
            Assert.AreEqual(0, model.Count);

        }

        [TestMethod]
        public void EditReturnsRedirect()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                PostId = 1,
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                CategoryId = 1

            };
            context.Post.Add(post);
            context.SaveChanges();
            // Act
            var result = (RedirectToActionResult)controller.Edit(1, post).Result;

            // Assert
            Assert.AreEqual("Index", result.ActionName);

        }

        [TestMethod]
        public void EditReturnsNotFoundOnPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                PostId = 1,
                Title = "Test",
                Content = "Test",

            };
            // Act
            var result = (NotFoundResult)controller.Edit(1, post).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditReturnsBadRequestOnPost()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);

            var post = new Post
            {
                PostId = 1,
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                Category = new Category
                {
                    CategoryId = 1,
                    Description = "Test Category",
                    Name = "Test Name"
                }

            };
            context.Post.Add(post);
            context.SaveChanges();
            var controller = new PostsController(context);
            // Act
            var result = (BadRequestResult)controller.Edit(2, post).Result;

            // Assert
            Assert.AreEqual(400, result.StatusCode);
        }


        [TestMethod]
        public void EditReturnsNotFoundOnGet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            // Act
            var result = (NotFoundResult)controller.Edit(1).Result;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditReturnsViewOnGet()
        {

            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ApplicationDbContext(options);
            var controller = new PostsController(context);
            var post = new Post
            {
                Title = "Test",
                Content = "Test",
                Author = "Test",
                Date = DateTime.Now,
                CategoryId = 1
            };


            // Act

            context.Post.Add(post);

            context.SaveChanges();

            var result = (ViewResult)controller.Edit(1).Result;

            // Assert

            Assert.AreEqual("Edit", result.ViewName);

        }




    }
}