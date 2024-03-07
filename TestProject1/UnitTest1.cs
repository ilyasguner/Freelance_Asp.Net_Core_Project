using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FreelanceCoreProject.Areas.Employer.Controllers;
using FreelanceCoreProject.Areas.Employer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject1
{
    public class UnitTest1
    {
        //Baþarýlý giriþ yapma testi

        [Fact]
        public async Task SýgnInTest_ReturnsSuccess()
        {

            var userManagerMock = new Mock<UserManager<Employers>>(
                Mock.Of<IUserStore<Employers>>(), null, null, null, null, null, null, null, null);

            var signInManagerMock = new Mock<SignInManager<Employers>>(
                userManagerMock.Object, Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<Employers>>(), null, null, null, null);

            signInManagerMock.Setup(x => x.PasswordSignInAsync("testuser", "password", false, false))
                            .ReturnsAsync(SignInResult.Success);


            var result = await signInManagerMock.Object.PasswordSignInAsync("testuser", "password", false, false);


            Assert.Equal(SignInResult.Success, result);
        }

        //Baþarýsýz giriþ yapma testi

        [Fact]
        public async Task SýgnInTest_ReturnsFailed()
        {

            var userManagerMock = new Mock<UserManager<Employers>>(
                Mock.Of<IUserStore<Employers>>(), null, null, null, null, null, null, null, null);

            var signInManagerMock = new Mock<SignInManager<Employers>>(
                userManagerMock.Object, Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<Employers>>(), null, null, null, null);

            signInManagerMock.Setup(x => x.PasswordSignInAsync("testuser", "wrongpassword", false, false))
                            .ReturnsAsync(SignInResult.Failed);


            var result = await signInManagerMock.Object.PasswordSignInAsync("testuser", "wrongpassword", false, false);


            Assert.Equal(SignInResult.Failed, result);
        }


        //Baþarýlý kayýt olma testi

        //[Fact]
        //public async Task RegisterViewModelTest_ReturnSuccess()
        //{
        //    // Arrange
        //    var userManagerMock = new Mock<UserManager<Employers>>(
        //        Mock.Of<IUserStore<Employers>>(), null, null, null, null, null, null, null, null);

        //    var controller = new RegisterController(userManagerMock.Object);

        //    userManagerMock.Setup(x => x.CreateAsync(It.IsAny<Employers>(), It.IsAny<string>()))
        //                   .ReturnsAsync(IdentityResult.Success);

        //    var validModel = new UserRegisterViewModel
        //    {
        //        Name = "testname",
        //        Surname = "testsurname",
        //        UserName = "testusername",
        //        Mail = "deneme@gmail.com",
        //        ImagerUrl = "asdsajhqwm",
        //        Password = "123456Aa*",
        //        ConfirmPassword = "123456Aa*",
        //        EmployerRole = 1
        //    };


        //    var result = await controller.Index(validModel);


        //    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //    Assert.Equal("Login", redirectToActionResult.ControllerName);
        //    Assert.Equal("Employer", redirectToActionResult.RouteValues["area"]);
        //}

    }
}
