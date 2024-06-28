using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersShopMVCTraining.Test.Service
{
    public class PathHelperTest
    {
        public const string FAKE_PROJECT_PATH = "C:\\project";

        private Mock<IWebHostEnvironment> _webHostEnvironmentMock;
        private PathHelper _pathHelper;

        [SetUp]
        public void SetUp()
        {
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
            _pathHelper = new PathHelper(_webHostEnvironmentMock.Object);
        }

        [Test]
        [TestCase("path1", "file1", "C:\\project\\path1\\file1")]
        [TestCase("path2", "file2", "C:\\project\\path2\\file2")]
        public void GetPathByFolder(string pathToFolder, string fileName, string resultPath)
        {
            // Arrange
            _webHostEnvironmentMock
                .Setup(x => x.WebRootPath)
                .Returns(FAKE_PROJECT_PATH);

            // Act
            var result = _pathHelper.GetPathByFolder(pathToFolder, fileName);

            // Assert
            Assert.That(result, Is.EqualTo(resultPath));
        }
        [Test]
        [TestCase("pathToFolder1", "C:\\project\\pathToFolder1")]
        [TestCase("pathToFolder1", "C:\\project\\pathToFolder1")]
        public void GetFolderPath(string pathToFolder, string resultpathToFolder)
        {
            // Arrange
            _webHostEnvironmentMock
                .Setup(x => x.WebRootPath)
                .Returns(FAKE_PROJECT_PATH);

            // Act
            var result = _pathHelper.GetFolderPath(pathToFolder);

            // Assert
            Assert.That(result, Is.EqualTo(resultpathToFolder));
        }
    }
}
