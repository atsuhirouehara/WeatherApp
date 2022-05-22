using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WheatherApp.Domain.Entities;
using WheatherApp.Domain.Repositories;
using WheatherApp.ViewModels;

namespace WheatherAppTest
{
    [TestClass]
    public class WheatherLatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var wheatherMock = new Mock<IWheatherRepository>();
            wheatherMock.Setup(x => x.GetLatest(1)).Returns(new WheatherEntity(1, Convert.ToDateTime("2018/01/01 2:34:56"), 2, 12.3f));
            wheatherMock.Setup(x => x.GetLatest(2)).Returns(new WheatherEntity(2, Convert.ToDateTime("2018/01/02 2:34:56"), 1, 22.1234f));
            
            var viewModel = new WheatherLatestViewModel(wheatherMock.Object);
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/01 2:34:56", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
            
            viewModel.AreaIdText = "2";
            viewModel.Search();
            Assert.AreEqual("2", viewModel.AreaIdText);
            Assert.AreEqual("2018/01/02 2:34:56", viewModel.DataDateText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);
        }
    }
}
