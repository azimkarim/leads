using LeadsApi.Repositories;
using LeadsApi.Models;
using Moq;
using Microsoft.AspNetCore.Mvc;
using LeadsApi.Controllers;

namespace LeadsTest
{
    public class LeadsControllerTests
    {
        [Fact]
        public void GetLeads_ReturnsAllLeads()
        {
            var leads = new List<Lead>
            {
                new Lead { Name = "Azim Karim", PhoneNumber = "9166934592", ZipCode = "95742" },
                new Lead { Name = "Bill Smith", PhoneNumber = "123-100-1888", ZipCode = "96023" },
                new Lead { Name = "John Doe", PhoneNumber = "402-122-9900", ZipCode = "94503" },
            };
            var mockRepo = new Mock<ILeadRepository>();
            mockRepo.Setup(repo => repo.GetLeads()).Returns(leads);

            var controller = new LeadsController(mockRepo.Object);
            var result = controller.Get(); //Get all leads

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var leadsResult = Assert.IsType<List<Lead>>(okResult.Value);
            Assert.Equal(3, leadsResult.Count);
        }
    }
}